using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SocialMedia.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Linq;
using SocialMedia_Core.Exceptions;
using SocialMedia_Core.QueryFilters.cs;
using SocialMedia_Core.CustomEntities;

public class PostServices : IPostServices
{
	private readonly IUnitOfWork _UnitOfWork;

	public PostServices(IUnitOfWork unitOfWork)
	{
		_UnitOfWork = unitOfWork;
	}

	public async Task<bool> DeletePost(int id)
	{
        await _UnitOfWork.PostRepository.Delete(id);
		return true;
    }

	public async Task<Post> GetPost(int id)
	{
        return await _UnitOfWork.PostRepository.GetById(id);
    }

	public PagedList<Post> GetPosts(PostQueryFilter filters)
	{
		var posts = _UnitOfWork.PostRepository.GetByAll();
		if(filters.UserId != null)
		{
			posts = posts.Where(x => x.UserId == filters.UserId);
		}
		if(filters.Date != null)
		{
			posts = posts.Where(x => x.Date.ToString() == filters.Date.ToString());
		}
		if(filters.Description != null)
		{
			posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
		}
		var pagedPost = PagedList<Post>.Create(posts, (int)filters.PageNumber,(int)filters.PageSize);

		return pagedPost;
	

    }

	
	public async Task InsertPost(Post post)
	{
		var user = await _UnitOfWork.UserRepository.GetById(post.UserId);
		if (user == null)
		{
			throw new BussinesExceptions("user don't exist");
		}
		var userPost = await _UnitOfWork.PostRepository.GetPostByUser(post.UserId);
		if (userPost.Count() < 10)
		{
			var lastPost = userPost.LastOrDefault();
			TimeSpan dif = (TimeSpan)(lastPost.Date - DateTime.Now);
			
			if ((dif).TotalDays < 7)
			{
				throw new BussinesExceptions("you are not able to publicate");
			}
			
		}
		if (post.Description.Contains("sexo")){
			throw new BussinesExceptions("contenido no permitido");
		}
		await _UnitOfWork.PostRepository.Add(post);
	}

	public async Task<bool> UpdatePost(Post post)
	{
		try
		{
            _UnitOfWork.PostRepository.update(post);
            await _UnitOfWork.saveChangesAsync();
        }
		catch (Exception)
		{
            throw new Exception("Usuario o post inexistente");
        }
       
		return true;
    }
}

using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SocialMedia.Infrastructure.Repositories;

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

	public IEnumerable<Post> GetPosts()
	{
        return  _UnitOfWork.PostRepository.GetByAll();
    }

	public async Task InsertPost(Post post)
	{
		var user = await _UnitOfWork.UserRepository.GetById(post.UserId);
		if (user == null)
		{
			throw new Exception("user don't exist");
		}
		if (post.Description.Contains("sexo")){
			throw new Exception("contenido no permitido");
		}
		await _UnitOfWork.PostRepository.Add(post);
	}

	public async Task<bool> UpdatePost(Post post)
	{
	
        _UnitOfWork.PostRepository.update(post);
		await _UnitOfWork.saveChangesAsync();
		return true;
    }
}

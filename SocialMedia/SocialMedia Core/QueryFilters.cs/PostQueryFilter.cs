﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia_Core.QueryFilters.cs
{
   
    public class PostQueryFilter
    {
        public int? UserId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}

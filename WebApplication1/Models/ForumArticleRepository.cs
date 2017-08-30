using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class ForumArticleRepository : EFRepository<ForumArticle>, IForumArticleRepository
	{

	}

	public  interface IForumArticleRepository : IRepository<ForumArticle>
	{

	}
}
using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class ArticleRepository : EFRepository<Article>, IArticleRepository
	{

	}

	public  interface IArticleRepository : IRepository<Article>
	{

	}
}
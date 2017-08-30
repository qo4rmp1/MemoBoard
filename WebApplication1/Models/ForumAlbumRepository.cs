using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class ForumAlbumRepository : EFRepository<ForumAlbum>, IForumAlbumRepository
	{

	}

	public  interface IForumAlbumRepository : IRepository<ForumAlbum>
	{

	}
}
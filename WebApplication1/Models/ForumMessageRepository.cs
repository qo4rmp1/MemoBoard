using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class ForumMessageRepository : EFRepository<ForumMessage>, IForumMessageRepository
	{

	}

	public  interface IForumMessageRepository : IRepository<ForumMessage>
	{

	}
}
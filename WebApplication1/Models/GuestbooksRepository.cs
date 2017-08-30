using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class GuestbooksRepository : EFRepository<Guestbooks>, IGuestbooksRepository
	{

	}

	public  interface IGuestbooksRepository : IRepository<Guestbooks>
	{

	}
}
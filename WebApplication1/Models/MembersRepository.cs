using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class MembersRepository : EFRepository<Members>, IMembersRepository
	{

	}

	public  interface IMembersRepository : IRepository<Members>
	{

	}
}
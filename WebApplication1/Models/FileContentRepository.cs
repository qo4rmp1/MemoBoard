using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class FileContentRepository : EFRepository<FileContent>, IFileContentRepository
	{

	}

	public  interface IFileContentRepository : IRepository<FileContent>
	{

	}
}
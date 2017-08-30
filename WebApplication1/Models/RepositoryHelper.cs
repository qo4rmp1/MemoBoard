namespace WebApplication1.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static ArticleRepository GetArticleRepository()
		{
			var repository = new ArticleRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ArticleRepository GetArticleRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ArticleRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static FileContentRepository GetFileContentRepository()
		{
			var repository = new FileContentRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static FileContentRepository GetFileContentRepository(IUnitOfWork unitOfWork)
		{
			var repository = new FileContentRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ForumAlbumRepository GetForumAlbumRepository()
		{
			var repository = new ForumAlbumRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ForumAlbumRepository GetForumAlbumRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ForumAlbumRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ForumArticleRepository GetForumArticleRepository()
		{
			var repository = new ForumArticleRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ForumArticleRepository GetForumArticleRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ForumArticleRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static ForumMessageRepository GetForumMessageRepository()
		{
			var repository = new ForumMessageRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ForumMessageRepository GetForumMessageRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ForumMessageRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static GuestbooksRepository GetGuestbooksRepository()
		{
			var repository = new GuestbooksRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static GuestbooksRepository GetGuestbooksRepository(IUnitOfWork unitOfWork)
		{
			var repository = new GuestbooksRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static MembersRepository GetMembersRepository()
		{
			var repository = new MembersRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MembersRepository GetMembersRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MembersRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}
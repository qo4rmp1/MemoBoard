using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ForumArticleService
    {
        //private messageEntities db = new messageEntities();
        private ForumArticleRepository repo = RepositoryHelper.GetForumArticleRepository();
        private ForumMessageRepository repo_Msg;

        public ForumArticleService()
        {
            repo_Msg = RepositoryHelper.GetForumMessageRepository(repo.UnitOfWork);
        }

        public ForumArticle Find(int Id)
        {
            return repo.Where(p => p.AId == Id).FirstOrDefault();
        }

        private IQueryable<ForumArticle> GetAllDataList(ForPaging Paging)
        {
            IQueryable<ForumArticle> Data = repo.All();

            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        private IQueryable<ForumArticle> GetAllDataList(ForPaging Paging, string Search)
        {
            IQueryable<ForumArticle> Data = repo.All().Where(p => p.Members.Name.Contains(Search) || p.Title.Contains(Search) || p.Content.Contains(Search));

            Paging.SetMaxPage(Data.Count());
            Paging.SetRightPage();
            return Data;
        }

        public List<ForumArticle> GetDataList(ForPaging Paging, string Search)
        {
            IQueryable<ForumArticle> data;

            if (string.IsNullOrEmpty(Search))
            {
                data = GetAllDataList(Paging);
            }
            else
            {
                data = GetAllDataList(Paging, Search);
            }

            data = data.OrderByDescending(p => p.AId).Skip((Paging.NowPage - 1) * Paging.ItemNo).Take(Paging.ItemNo);

            return data.ToList();
        }

        public void Insert(ForumArticle FArticle)
        {
            FArticle.CreateTime = DateTime.Now;
            repo.Add(FArticle);
            repo.UnitOfWork.Commit();
        }

        public void Delete(int Id)
        {
            ForumArticle data = Find(Id);

            if (data != null)
            {
                // 先刪除文章內留言
                List<ForumMessage> MsgList = data.ForumMessage.ToList();
                foreach (var item in MsgList)
                {
                    repo_Msg.Delete(item);
                }
                repo_Msg.UnitOfWork.Commit();

                // 再刪除文章
                repo.Delete(data);
                repo.UnitOfWork.Commit();
            }
        }

        public bool CheckUpdate(int Id)
        {
            ForumArticle data = Find(Id);
            return (data != null && data.ForumMessage.Count == 0);
        }

        public List<ForumArticle> GetPopularityDataList()
        {
            return repo.All().OrderByDescending(p => p.Watch).Take(5).ToList();
        }

        public void AddWatch(int Id)
        {
            ForumArticle data = Find(Id);
            data.Watch++;
            repo.UnitOfWork.Commit();
        }

        public void Save()
        {
            repo.UnitOfWork.Commit();
        }
    }
}
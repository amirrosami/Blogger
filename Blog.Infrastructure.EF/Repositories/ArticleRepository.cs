using Blog.Application.Contracts.Article;
using Blog.Domain.ArticleAgg;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EF.Repositories
{
    public class ArticleRepository:BaseRepository<Article,long>,IArticleRepository
    {
        private readonly BlogDbContext _dbcontext;
        public ArticleRepository(BlogDbContext context):base(context)
        {
            _dbcontext = context;
        }

        public  List<ArticleViewModel> GetList()
        {
            return _dbcontext.Articles
                .Include(cat=>cat.articlecategory)
                .Select(x=>new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreationDate = x.CreationDate.ToString(),
                    ArticleCategory=x.articlecategory.Title,
                    IsDeleted=x.IsDeleted,

                }).ToList();
        }
    }
}

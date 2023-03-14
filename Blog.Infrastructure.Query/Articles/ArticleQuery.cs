using Blog.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Query.Articles
{
    public class ArticleQuery
    {
        private readonly BlogDbContext _dbcontext;

        public ArticleQuery(BlogDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<ArticleQueryView> GetArticlesList()
        {

            return _dbcontext.Articles
                .Include(x => x.articlecategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    CreationDate = x.CreationDate.ToString(),
                    Title = x.Title,
                    ImgAddress = x.ImgAddress,
                    ShortDscp = x.ShortDscp,
                    ArticleCategory=x.articlecategory.Title
                }).ToList();
        }

        public ArticleQueryView? GetArticle(long id)
        {
            return _dbcontext.Articles
                .Include(x=>x.articlecategory)
                .Where(x=>x.Id==id)
                 .Select(x => new ArticleQueryView
                 {
                     Id =x.Id,
                     CreationDate = x.CreationDate.ToString(),
                     Title = x.Title,
                     ImgAddress = x.ImgAddress,
                     ShortDscp = x.ShortDscp,
                     ArticleCategory = x.articlecategory.Title
                 }).FirstOrDefault();
        }



    }

  
}

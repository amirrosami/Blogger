using Blog.Domain.ArticleCategory;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EF.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory, long>, IArticleCategoryRepository
    {
        private readonly BlogDbContext _dbContext;
        public ArticleCategoryRepository(BlogDbContext dbcontex) : base(dbcontex)
        {
            _dbContext = dbcontex;
        }
    }
}

using Blog.Application.Article;
using Blog.Application.ArticleCategory;
using Blog.Application.Contracts.Article;
using Blog.Application.Contracts.ArticleCategory;
using Blog.Domain.ArticleAgg;
using Blog.Domain.ArticleCategory;
using Blog.Infrastructure.EF;
using Blog.Infrastructure.EF.Repositories;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void ConfigBloggerServices(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();


            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<BlogDbContext>(options => 
            options.UseSqlServer(connectionstring)
            );

          

        }
    }
}

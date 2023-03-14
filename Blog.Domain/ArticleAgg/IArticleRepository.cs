using Blog.Application.Contracts.Article;
using Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<Article,long>
    {
        List<ArticleViewModel> GetList();
    }
}

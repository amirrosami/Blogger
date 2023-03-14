using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        void Remove(long id);
        void Activate(long id);
        List<ArticleViewModel> GetList();
        EditArticle GetBy(long id);
        EditArticle GetBy(String title);
    }
}

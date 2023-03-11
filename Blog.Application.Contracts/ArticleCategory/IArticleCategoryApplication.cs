using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        void Remove(long id);
        void Activate(long id);
        List<ArticlecategoryviewModel> GetAll();
        ArticlecategoryviewModel GetBy(long id);
        ArticlecategoryviewModel GetBy(String title);
    }
}

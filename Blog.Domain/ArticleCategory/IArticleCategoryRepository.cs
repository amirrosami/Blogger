using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleCategory
{
    public interface IArticleCategoryRepository
    {
        void Rename(string title);
        void Remove();
        void Activate();

    }
}

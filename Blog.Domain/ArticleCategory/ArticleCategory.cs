using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleCategory
{
    public class ArticleCategory
    {
        public long Id { get;private set; }
        public string Title { get;private set; }
        public Boolean IsDeleted { get;private set; }

        public ArticleCategory(string title)
        {
            Title = title;
        }

    }
}


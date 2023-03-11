using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.ArticleCategory
{
    public class ArticlecategoryviewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Boolean IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}

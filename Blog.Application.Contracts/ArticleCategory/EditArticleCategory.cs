using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.ArticleCategory
{
    public class EditArticleCategory:CreateArticleCategory
    {
        public long Id { get; set; }
    }
}

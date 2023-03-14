using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDscp { get; set; }
        public string Body { get; set; }
        public string ImgAddress { get; set; }
        public bool IsDeleted { get; set; }
        public long CategoryId { get; set; }
    }
}

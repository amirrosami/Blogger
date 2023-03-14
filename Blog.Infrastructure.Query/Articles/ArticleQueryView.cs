using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Query.Articles
{
    public class ArticleQueryView
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Title { get; set; }
        public string ShortDscp { get; set; }
        public string ArticleCategory { get; set; }
        public string  ImgAddress { get; set; }
    }
}

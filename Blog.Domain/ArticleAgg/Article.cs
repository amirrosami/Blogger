using Blog.Domain.ArticleCategory;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleAgg
{
    public class Article:DomainBase<long>
    {
        public string Title  { get; set; }
        public string ShortDscp { get; set; }
        public string Body { get; set; }
        public string  ImgAddress { get; set; }
        public string ImgAlt { get; set; }
        public bool IsDeleted { get; set; }
        public long CategoryId { get; set; }
        public ArticleCategory.ArticleCategory articlecategory { get; set; }

        public Article(string title, string shortDscp, string body, string imgAddress, long categoryId)
        {
            Validate(title, categoryId);
            Title = title;
            ShortDscp = shortDscp;
            Body = body;
            ImgAddress = imgAddress;
            IsDeleted = false;
            CategoryId = categoryId;
            ImgAlt = Title;
           
    
        }

        private void Validate(string title,long categoryid)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title is null or empty");

            }
            if (categoryid == 0)
            {
                throw new ArgumentOutOfRangeException("select category");
            }
        }

        public void Edit(string title, string shortDscp, string body, string imgAddress, long categoryId)
        {
            Validate(title, categoryId);
            Title = title;
            ShortDscp = shortDscp;
            Body = body;
            ImgAddress = imgAddress;
            CategoryId = categoryId;
            ImgAlt =title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
    


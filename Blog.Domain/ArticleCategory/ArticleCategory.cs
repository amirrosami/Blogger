using Blog.Domain.ArticleAgg;
using Blog.Domain.ArticleCategory.Exceptions;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleCategory
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get;private set; }
        public Boolean IsDeleted { get;private set; }
        public ICollection<Article> articles { get; set; }


        public ArticleCategory(string title)
        {
            CheckTitleIsNullOrEmpty(title);
            
            Title = title;
            articles = new List<Article>();
        }

        
        private void CheckTitleIsNullOrEmpty(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new NullOrEmptyTitleException();
            }
        }

        public void Edit(string title)
        {
            CheckTitleIsNullOrEmpty(title);
            Title=title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted=false;
        }
    }
}


using Blog.Domain.ArticleAgg;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.CommentAgg
{
    public class Comment:DomainBase<long>
    {
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Body { get; set; }
        public int Status { get; set; }
        public long ArticleId { get; set; }
        public Article article { get; set; }

        public Comment(string name, string email, string body, long articleId)
        {
            Name = name;
            Email = email;
            Body = body;
            Status = Statuses.NotConfirmed;
            ArticleId = articleId;
        }

        public void Remove()
        {
            Status = Statuses.Removed;
        }

        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }

    }
}

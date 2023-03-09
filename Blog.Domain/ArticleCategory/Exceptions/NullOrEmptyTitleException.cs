using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleCategory.Exceptions
{
    [Serializable]
    public class NullOrEmptyTitleException:Exception
    {
        
        public NullOrEmptyTitleException(string message="Title must not be null or empty"):base(message)
        {

        }
    }
}

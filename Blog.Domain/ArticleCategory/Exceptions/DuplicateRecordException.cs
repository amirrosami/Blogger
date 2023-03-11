using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ArticleCategory.Exceptions
{
    public class DuplicateRecordException:Exception
    {
        public DuplicateRecordException(string message="this title exists in Database"):base(message)
        {

        }
    }
}

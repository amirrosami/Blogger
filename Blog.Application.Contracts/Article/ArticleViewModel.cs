﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string ArticleCategory { get; set; }
    }
}

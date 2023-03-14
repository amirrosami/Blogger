using Blog.Domain.ArticleAgg;
using Blog.Application.Contracts.Article;
using Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Blog.Application.Article
{
    public class ArticleApplication: IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _uow;

        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork uow)
        {
            _articleRepository = articleRepository;
            _uow = uow;
        }

        public void Activate(long id)
        {
            _uow.BeginTrans();
            var article = _articleRepository.GetBy(id);
            article.Activate();
            _uow.CommitTrans();
        }

        public void Create(CreateArticle command)
        {
            _uow.BeginTrans();

            CheckTitleExists(command.Title);
            _articleRepository.Create(new Domain.ArticleAgg.Article(command.Title, command.ShortDscp, command.Body, command.ImgAddress, command.CategoryId));
            _uow.CommitTrans();
        }
        public void Edit(EditArticle command)
        {
            _uow.BeginTrans();
            var article = _articleRepository.GetBy(command.Id);
           // CheckTitleExists(command.Title);
            article.Edit(command.Title, command.ShortDscp, command.Body, command.ImgAddress, command.CategoryId);
            _uow.CommitTrans();
        }

        public List<ArticleViewModel> GetList()
        {

            return _articleRepository.GetList();

        }

        public EditArticle GetBy(long id)
        {
            var article = _articleRepository.GetBy(id);
            return new EditArticle
            {
                Id = article.Id,
                IsDeleted = article.IsDeleted,
                Title = article.Title,
                ShortDscp = article.ShortDscp,
                Body = article.Body,
                ImgAddress = article.ImgAddress,
                CategoryId = article.CategoryId,
                
            };


        }

        public EditArticle GetBy(string title)
        {
            var article = _articleRepository.GetBy(x => x.Title == title);
            return new EditArticle
            {
                Id = article.Id,
                IsDeleted = article.IsDeleted,
                Title = article.Title,
                ShortDscp = article.ShortDscp,
                Body = article.Body,
                ImgAddress = article.ImgAddress,
                CategoryId = article.CategoryId
               
            };
        }

        public void Remove(long id)
        {
            _uow.BeginTrans();
            var article = _articleRepository.GetBy(id);
            article.Remove();
            _uow.CommitTrans();
        }

        public void CheckTitleExists(string title)
        {
            if (_articleRepository.Exists(x =>  x.Title == title))
            {
                throw new Exception("this title added before");
            }

        }
    }
}

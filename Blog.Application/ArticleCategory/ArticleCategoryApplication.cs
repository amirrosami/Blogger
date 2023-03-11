using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Contracts.ArticleCategory;
using Blog.Domain.ArticleCategory;
using Blog.Domain.ArticleCategory.Exceptions;
using Common.Infrastructure;

namespace Blog.Application.ArticleCategory
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IUnitOfWork _uow;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Activate(long id)
        {
            _uow.BeginTrans();
            var articlecategory= _articleCategoryRepository.GetBy(id);
            if (articlecategory == null)
            {
                throw new ArgumentNullException("this category does not exists in database");
            }

            articlecategory.Activate();
            _uow.CommitTrans();
        }

        public void Create(CreateArticleCategory command)
        {
            _uow.BeginTrans();

           CheckTitleExists(command.Title);
            _articleCategoryRepository.Create(new Domain.ArticleCategory.ArticleCategory(command.Title));
            _uow.CommitTrans();
        }

        public void Edit(EditArticleCategory command)
        {
            _uow.BeginTrans();
            var articlecategory= _articleCategoryRepository.GetBy(command.Id);
            CheckTitleExists(command.Title);
            articlecategory.Edit(command.Title);
            _uow.CommitTrans();
        }

        public List<ArticlecategoryviewModel> GetAll()
        {

          return _articleCategoryRepository.GetAll()
                .Select(x=>new ArticlecategoryviewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),

                }).ToList();
            
        }

        public ArticlecategoryviewModel GetBy(long id)
        {
            var articleCat = _articleCategoryRepository.GetBy(id);
            return new ArticlecategoryviewModel
            {
                Id = articleCat.Id,
                CreationDate = articleCat.CreationDate.ToString(),
                IsDeleted = articleCat.IsDeleted,
                Title = articleCat.Title,
            };
                
           
        }

        public ArticlecategoryviewModel GetBy(string title)
        {
           var category = _articleCategoryRepository.GetBy(x=>x.Title==title);
            return new ArticlecategoryviewModel
            {
                Title = title,
                IsDeleted = category.IsDeleted,
                Id = category.Id,
                CreationDate = category.CreationDate.ToString(),
            };
        }

        public void Remove(long id)
        {
            _uow.BeginTrans();
           var articlecat=_articleCategoryRepository.GetBy(id);
            articlecat.Remove();
            _uow.CommitTrans();
        }

        public void CheckTitleExists(string title)
        {
            if (_articleCategoryRepository.Exists(x => x.Title ==title))
            {
                throw new DuplicateRecordException();
            }

        }

    }
}

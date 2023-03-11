using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Presentation.Razor.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditArticleCategory editarticlecategory { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

       

        public void OnGet(long id)
        {
           var articlecategory= _articleCategoryApplication.GetBy(id);
            editarticlecategory.Title = articlecategory.Title;
            editarticlecategory.Id= id;
        }

        public IActionResult OnPost(EditArticleCategory command)
        {
            _articleCategoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}

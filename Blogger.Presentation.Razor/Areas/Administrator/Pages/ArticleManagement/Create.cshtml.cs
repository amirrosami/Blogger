using Blog.Application.Contracts.Article;
using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogger.Presentation.Razor.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {                           
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        [BindProperty]
        public List<SelectListItem> ArticleCategories { get; set; }
        public CreateModel(IArticleApplication articleApplication,IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetAll()
                .Select(x => new SelectListItem(x.Title, x.Id.ToString()))
                .ToList();
        }
        public IActionResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }


    }
}

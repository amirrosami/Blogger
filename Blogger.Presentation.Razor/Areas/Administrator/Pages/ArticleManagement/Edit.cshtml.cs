using Blog.Application.Contracts.Article;
using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogger.Presentation.Razor.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        [BindProperty]
        public List<SelectListItem> ArticleCategories { get; set; }
        public EditArticle Article { get; set; }

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
           Article= _articleApplication.GetBy(id);
           ArticleCategories=_articleCategoryApplication.GetAll()
                .Select(x => new SelectListItem(x.Title,x.Id.ToString()))
                .ToList();
        }

        public IActionResult OnPost(EditArticle command)
        {
            _articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}

using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Presentation.Razor.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        public List<ArticlecategoryviewModel> articlecategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategory;

        public IndexModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public void OnGet()
        {
            articlecategories = _articleCategory.GetAll();
        }

        public IActionResult OnPostActivate(long id)
        {
            _articleCategory.Activate(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostRemove(long id)
        {
            _articleCategory.Remove(id);
            return RedirectToPage("./Index");
        }

    }
}

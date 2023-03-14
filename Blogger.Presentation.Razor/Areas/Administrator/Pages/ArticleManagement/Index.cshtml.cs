using Blog.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Presentation.Razor.Areas.Administrator.Pages.ArticleManagement
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        [BindProperty]
        public List<ArticleViewModel> Articles { get; set; }

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
           Articles= _articleApplication.GetList();
        }

        public IActionResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./Index");
        }


    }
}

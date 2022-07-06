using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.models;

namespace razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {

        private readonly razorweb.models.MyBlogContext _context;

        public IndexModel(razorweb.models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name ="p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            if (_context.articles != null)
            {
                int totalArticle = await _context.articles.CountAsync();
                countPages = (int)Math.Ceiling((double)totalArticle/ITEMS_PER_PAGE);
                if(currentPage<1)
                    currentPage = 1;
                 if(currentPage > countPages)
                    currentPage = countPages;


                Console.WriteLine("Begin" + SearchString);
                Article = await _context.articles.OrderByDescending(x=>x.Created).ToListAsync();
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Article = Article.Where(x=>x.Title.Contains(SearchString)).ToList();
                    Console.WriteLine("End" + SearchString);
                }
            }
        }
    }
}

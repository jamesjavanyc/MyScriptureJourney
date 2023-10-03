using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJourney.models;

namespace MyScriptureJourney.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJourney.Data.MyScriptureJourneyContext _context;

        public IndexModel(MyScriptureJourney.Data.MyScriptureJourneyContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchNote { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ScriptureBook { get; set; }


        [BindProperty(SupportsGet = true)]
        public bool SearchBook { get; set; }

        public SelectList? Dates { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public bool DateAdded { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from n in _context.Scripture
                                           orderby n.Book
                                           select n.Book;

            var notes = from n in _context.Scripture
                        select n;
            if (!string.IsNullOrEmpty(SearchNote))
            {
                notes = notes.Where(s => s.Notes.Contains(SearchNote));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                notes = notes.Where(x => x.Book == ScriptureBook);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            //Scripture = await notes.ToListAsync();

            //Use LINQ to get list of dates.
            IQueryable<string> dateQuery = from d in _context.Scripture
                                           orderby d.ReleaseDate
                                           select d.ReleaseDate.ToShortDateString();

            //var dates = from d in _context.Scripture
            //            select d;
            if (SearchBook)
            {
                notes = notes.OrderBy(t => t.Book);
            }


            if (DateAdded)
            {

                notes = notes.OrderBy(y => y.ReleaseDate);
                //notes = notes.Where(y => DateTime.Compare(y.RecordedDate, DateAdded) == 0);
            }
            Dates = new SelectList(await dateQuery.Distinct().ToListAsync());

            Scripture = await notes.ToListAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Data;
using Store.Model;

namespace Store.Pages.Provedores
{
    public class CreateModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public CreateModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item_provedores Item_provedores { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Item_provedores.Add(Item_provedores);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

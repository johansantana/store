using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Model;

namespace Store.Pages.Provedores
{
    public class EditModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public EditModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item_provedores Item_provedores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_provedores =  await _context.Item_provedores.FirstOrDefaultAsync(m => m.Id == id);
            if (item_provedores == null)
            {
                return NotFound();
            }
            Item_provedores = item_provedores;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Item_provedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Item_provedoresExists(Item_provedores.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Item_provedoresExists(int id)
        {
            return _context.Item_provedores.Any(e => e.Id == id);
        }
    }
}

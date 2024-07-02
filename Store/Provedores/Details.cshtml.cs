using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Model;

namespace Store.Pages.Provedores
{
    public class DetailsModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public DetailsModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        public Item_provedores Item_provedores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_provedores = await _context.Item_provedores.FirstOrDefaultAsync(m => m.Id == id);
            if (item_provedores == null)
            {
                return NotFound();
            }
            else
            {
                Item_provedores = item_provedores;
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Model;

namespace Store.Pages.Vendor
{
    public class DetailsModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public DetailsModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        public Model.Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FirstOrDefaultAsync(m => m.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = vendor;
            }
            return Page();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public IndexModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Item_provedores> Item_provedores { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Item_provedores = await _context.Item_provedores.ToListAsync();
        }
    }
}

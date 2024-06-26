using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Model;

namespace Store.Pages.Item
{
    public class IndexModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public IndexModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Model.Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
        }
    }
}

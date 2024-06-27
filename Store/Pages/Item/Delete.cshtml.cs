﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Store.Data.StoreContext _context;

        public DeleteModel(Store.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Item Item { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {

            return Page();
        }

        public IActionResult OnPost(int? id)
        {


            return RedirectToPage("./Index");
        }
    }
}

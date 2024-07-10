using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nontakan.Models;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nontakan.Data;

namespace Nontakan.Views.Items
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _context.Items.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var itemToUpdate = await _context.Items.FindAsync(Item.Id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }

            itemToUpdate.Name = Item.Name;
            itemToUpdate.Description = Item.Description;

            var files = HttpContext.Request.Form.Files;
            if (files.Any())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await files[0].CopyToAsync(memoryStream);
                    itemToUpdate.Image = memoryStream.ToArray();
                    itemToUpdate.ImageBase64 = Convert.ToBase64String(itemToUpdate.Image);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
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

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
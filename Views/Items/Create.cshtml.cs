using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nontakan.Models;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Nontakan.Data;

namespace Nontakan.Views.Items
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Any())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await files[0].CopyToAsync(memoryStream);
                    Item.Image = memoryStream.ToArray();
                    Item.ImageBase64 = Convert.ToBase64String(Item.Image); // แปลง byte[] เป็น Base64 string
                }
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

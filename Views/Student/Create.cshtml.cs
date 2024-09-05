using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lap1.Views.Student
{
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;

        public Create(ILogger<Create> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
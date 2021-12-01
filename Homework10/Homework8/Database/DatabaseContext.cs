using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Services
{
    public class DatabaseContext : PageModel
    {
        public ApplicationContext DbContext { get; }
        
        public DatabaseContext(ApplicationContext context)
        {
            DbContext = context;
        }
    }
}
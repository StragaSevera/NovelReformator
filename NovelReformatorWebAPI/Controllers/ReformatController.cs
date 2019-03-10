using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReformatController : Controller
    {
        [HttpPost("{type}")]
        public async Task<string> Index(string type)
        {
            // Некрасиво, но через [FromBody] выдает 415 - есть ли способы лучше для принятия text/plain ?
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var input = await reader.ReadToEndAsync();
                return type + ": " + input;
            }
        }
    }
}
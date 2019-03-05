using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NovelReformatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET api/home
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] {"hello", "world"};
        }

        // GET api/home/word
        [HttpGet("{word}")]
        public ActionResult<string> Get(string word)
        {
            switch (word)
            {
                case "hello":
                    return "world";
                case "world":
                    return "hello";
                default:
                    return "hello world";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsageController : Controller
    {
        [HttpGet]
        public async Task<Usage> GetbyId(int Id)
        {
            return null;
        }
        [HttpPut]
        public async Task Edit(Usage usage)
        {

        }
        [HttpDelete]
        public async Task Delete(int Id)
        {

        }
        [HttpPost]
        public async Task Create(Usage usage)
        {

        }
    }
}
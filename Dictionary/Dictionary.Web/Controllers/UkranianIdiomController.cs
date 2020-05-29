using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Data.Entity;
using Dictionary.Services.Interface;
using Dictionary.Web.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UkranianIdiomController : Controller
    {
        private readonly IUkranianIdiomService _ukranianIdiomService;
        [HttpGet]
        public async Task<UkranianIdiom> GetbyId(int Id)
        {
            return await _ukranianIdiomService.GetById(Id);
        }
        [HttpPut]
        public async Task Edit(UkranianIdiomModelEdit ukranianIdiomEdit)
        {
            UkranianIdiom ukranianIdiom = await _ukranianIdiomService.GetById(ukranianIdiomEdit.Id);
            ukranianIdiom.UkranianEquivalent = ukranianIdiomEdit.UkranianEquivalent;
            await _ukranianIdiomService.Update(ukranianIdiom);
        }
        [HttpDelete]
        public async Task Delete(int Id)
        {
            await _ukranianIdiomService.Delete(Id);
        }
        [HttpPost]
        public async Task Create(UkranianIdiom u)
        {
            UkranianIdiom ukranianIdiom = new UkranianIdiom() { UkranianEquivalent = u.UkranianEquivalent };
            await _ukranianIdiomService.Add(ukranianIdiom);
        }
    }
}
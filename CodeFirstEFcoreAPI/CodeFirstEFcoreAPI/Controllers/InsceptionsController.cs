using CodeFirstEFcoreAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.Controllers
{
    [Route("api/insceptions")]
    [ApiController]
    public class InsceptionsController : ControllerBase
    {

        private readonly MainDatabaseContext _mainDbContext;

        public InsceptionsController(MainDatabaseContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetInsceptions()
        {

            var result = _mainDbContext.insceptions
                .Select(s =>
                new
                {
                    carname = s.IdCarNavigation.name,
                    YearofProduction = s.IdCarNavigation.ProductionYear,
                    Mechanic = new
                    {
                        MechanicName = s.IdMechanicNavigation.FirstName,
                        MechanicSurname = s.IdMechanicNavigation.LastName
                    },
                    ListOfInsception = s.ServiceTypeDictInsceptions_Insceptions
                                        .Select(s => new 
                                                    { 
                                                        ServiceNames = s.IdServiceTypeNavigation.ServiceType 
                                                    })
                                        .ToList()
                }
                );

            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

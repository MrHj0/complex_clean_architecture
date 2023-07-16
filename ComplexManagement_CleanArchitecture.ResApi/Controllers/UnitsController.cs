using ComplexManagement_CleanArchitecture.Service.Units.Contracts;
using ComplexManagement_CleanArchitecture.Service.Units.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagement_CleanArchitecture.RestApi.Controllers
{
    [Route("units")]
    [ApiController]
    public class UnitsController : Controller
    {
        private readonly UnitService _units;

        public UnitsController(UnitService units)
        {
            _units = units;
        }


        [HttpPost]
        public void Add([FromBody]AddUnitDto dto)
        {
            _units.Add(dto);
        }
    }
}

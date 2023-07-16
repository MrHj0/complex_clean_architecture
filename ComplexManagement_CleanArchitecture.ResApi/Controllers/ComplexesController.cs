using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts;
using ComplexManagement_CleanArchitecture.Service.Complexes.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagement_CleanArchitecture.RestApi.Controllers
{
    [Route("complexes")]
    [ApiController]
    public class ComplexesController : Controller
    {
        private readonly ComplexService _service;

        public ComplexesController(ComplexService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add([FromBody] AddComplexDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllComplexesWithUnitCount> GetAll([FromQuery] ComplexSearchDto dto)
        {
            
            return _service.GetAllComplexesWithUnitCount(dto);
        }

        [HttpPatch]
        [Route("{id}/edit-unitcount")]
        public void UpdateComplexUnitCount([FromRoute]int id, [FromBody]int unitCount)
        {
            _service.EditComplexUnitCount(id,unitCount);
        }
        [HttpGet]
        [Route("{id}")]
        public GetComplexWithUnitsAndBlockCountsDto GetComplexById([FromRoute]int id)
        {
           return _service.GetComplexBlockCountAndUnitsByComplexId(id);
        }

        [HttpGet]
        [Route("block-details")]
        public List<GetAllComplexWithBlockDetailsDto> GetWithBlockDetails([FromQuery]string? name)
        {
            return _service.GetAllComplexWithBlockDetails(name);
        }
    }
}

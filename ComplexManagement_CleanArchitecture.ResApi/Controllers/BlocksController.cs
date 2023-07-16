using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts;
using ComplexManagement_CleanArchitecture.Service.Blocks.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagement_CleanArchitecture.RestApi.Controllers
{
    [Route("blocks")]
    [ApiController]
    public class BlocksController : Controller
    {
        private readonly BlockService _service;
        public BlocksController(BlockService blockRepository)
        {
            _service = blockRepository;
        }

        [HttpPost]
        public void Add(AddBlockDto dto)
        {
            _service.Add(dto);
        }

        [HttpPatch]
        [Route("{id}")]
        public void EditBlockNameAndUnitCount([FromRoute]int id, [FromBody]EditBlockDto dto)
        {
            _service.EditBlock(id,dto);
        }

        [HttpGet]
        public List<GetAllBlocksWithUnitDetailsDto> GetAll()
        {
            return _service.GetAllBlocksWithUnits();
        }

        [HttpGet]
        [Route("{id}/with-unit-details")]
        public GetBlockWithUnitDetailsDto GetBlockById([FromRoute]int id)
        {
            return _service.GetBlockWithUnitDetailsById(id);
        }
    }
}

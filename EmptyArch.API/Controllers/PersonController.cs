using EmptyArch.Application.Abstractions;
using EmptyArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmptyArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplicationService _personAppService;
        public PersonController(IPersonApplicationService personAppservice)
        {
            _personAppService = personAppservice;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var personList= await _personAppService.ReadAll();
            return Ok(personList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute]int id)
        {
            var personList = await _personAppService.ReadById(id);
            return Ok(personList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PersonViewModel personViewModel)
        {
            var createdPerson = await _personAppService.Create(personViewModel);
            return Created("/{id}", createdPerson);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]PersonViewModel personViewModel)
        {
            var updatedPerson= await _personAppService.Update(personViewModel);
            return Accepted(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            await _personAppService.Remove(id);
            return Ok();
        }
    }
}
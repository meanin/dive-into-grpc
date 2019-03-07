using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiveIntoGrpc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValueService.ValueServiceClient _valuesClient;

        public ValuesController(ValueService.ValueServiceClient valuesClient)
        {
            _valuesClient = valuesClient;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var result = await _valuesClient.GetValuesAsync(new ValueRequest { Count = 3 });
            return Ok(result);
        }
    }
}

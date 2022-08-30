using Microsoft.AspNetCore.Mvc;
using TestApi.Interfaces.Services;
using TestApi.Localizer.Interface;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService; 
        private readonly ILocalizerExtension _lang;
        public TestController(ITestService testService, ILocalizerExtension lang)
        {
            this._testService = testService;
            this._lang = lang;
        }
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [Route("~/api/Test")]
        [HttpGet]
        public IActionResult Get([FromQuery] string word)
        {
            var resultado = _lang.GetWord(Request, word);
            return Ok(new { Respuesta = resultado });
        }
    }
}

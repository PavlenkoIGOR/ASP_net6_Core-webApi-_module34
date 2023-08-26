using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ASP_net6_Core_webApi_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase //страница будет отображать из всего названия "BookController" только "Book" без "...Controller". Если не будет "...Controller" отобразится как есть. 
    {
        private ILogger _logger;
        public BookController(ILogger<HomeController> logger)
        {
            _logger = logger;   
        }

        //дальше методы, которые помечены [HttpGet] будут выведены на экран по адресу Book/Books и Book/Books222
        [HttpGet]
        [Route("Books")]
        public void Get() 
        {
            StatusCode(200, "имя сервера: {}");
        }

        [HttpGet]
        [Route("Books222")]
        public IActionResult Get1()
        {
            return StatusCode(200, "имя сервера: {}");
        }

        //метод для загрузки PDF
        [HttpGet]
        [Route("{ourBook}")]
        public IActionResult Get2([FromRoute]string ourBook)
        {
            return StatusCode(200, ourBook);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ASP_net6_Core_webApi_.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase //страница будет отображать из всего названия "BookController" только "Book" без "...Controller". Если не будет "...Controller" отобразится как есть. 
    {
        private ILogger _logger;
        private IHostEnvironment _environment;
        public BookController(ILogger<HomeController> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;   
            _environment = hostEnvironment;
        }

        //дальше методы, которые помечены [HttpGet] будут выведены на экран по адресу Book/Books и Book/Books222
        [HttpGet]
        [Route("Books")] //в {}-скобках это то, что эквивалентно placeholder в HTML. Если отличаются имена в [Route("{моёИмя}")] и
                         //в IActionResult Get([FromRoute] string моёИмя) то будет два поля для ввода.
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
            //далее логика для загрузки фала из ресурса (для этого передается в текущий класс IHostEnvironment)

            //получаем корневую директорию через ContentRootPath:
            string pathWWWROOT = Path.Combine(_environment.ContentRootPath, "wwwroot", "filesForDownload");
            string filePath = Directory.GetFiles(pathWWWROOT) //-как в js вывод первого элекмента массива
                .FirstOrDefault(f => f.Split("\\")
                .Last()
                .Split('.')[0] == ourBook);

            if (string.IsNullOrEmpty(filePath))
            {
                return StatusCode(404, $"Файл {ourBook} не найден!");
            }

            //хорошая практика - показ свойств объекта в ответах, чтообы клиент мог их прочитать.
            string fileType = "aplication/pdf"; //т.к. передаем pdf, что бы клиентское приложение могло адекватно отображать файл
            string fileName = $"{ourBook}.pdf"; //имя файла с которым автоматически сохранится файл.

            //чтобы вернуть именно файл - return PhysicalFile
            return PhysicalFile(filePath, fileType, fileName);
        }
    }
}

/*
Deich-Bradbury
 */
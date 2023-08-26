using ASP_net6_Core_webApi_.Configuration;

namespace ASP_net6_Core_webApi_
{
    public class Program
    {
        /// <summary>
        /// Загрузка конфигурации из файла Json
        /// </summary>
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddJsonFile("JSON/HomeOptions.json").Build();
        
        public static void Main(string[] args)
        {
            
            
            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            //стандартное добавление конфигурации
            builder.Services.Configure<HomeOptions>(Configuration);
            

            //если надо добавить какой-то определенный параметр, а не весь файл целиком:
            //builder.Services.Configure<Address>(Configuration.GetSection("Address"));

            //если надо изменить какой-то параметр в ходе выполнения:
            //builder.Services.Configure<HomeOptions>(j => j.Heating = Heating.Electric);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "SmartHome_ASPNetCore_WebApi_6.0",
                Version = "v1"
            }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //надо обязательно добавлять:
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //это тоже обязательно добавить
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
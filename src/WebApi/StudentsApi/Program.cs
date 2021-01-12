using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GNDSoft.Students.Services.StudentsApi
{
    /// <summary>
    /// Точка входа программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Билдер для хоста
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

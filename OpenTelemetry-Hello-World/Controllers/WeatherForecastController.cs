using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenTelemetry
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;
        private static readonly ActivitySource ActivitySource = new(nameof(WeatherForecastController));

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            using (ActivitySource.StartActivity("Process Delay").SetParentId(Activity.Current.Id).Start())
            {
                _logger.LogInformation("Wait For Some Delay");
                await Task.Delay(5000);
            }

            return await _context.WeatherForecasts.ToArrayAsync();
        }
    }
}

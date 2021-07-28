using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    //this route attribute takes the name of the controller "WeatherForecastController" and uses the name w/o controller. Thus http://localhost:5000/WeatherForecast will call this.
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}
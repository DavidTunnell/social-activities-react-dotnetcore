using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace API.Controllers
{
    [ApiController]
    //this route attribute takes the name of the controller "WeatherForecastController" and uses the name w/o controller. Thus http://localhost:5000/WeatherForecast will call this.
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // ??= checks if null and if so will get service IMediator
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
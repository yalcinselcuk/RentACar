using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        // _mediator set edilmişse döndür, set edilmediyse RequestServices'ten döneni set'le. 
        protected IMediator Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();  
    }
}

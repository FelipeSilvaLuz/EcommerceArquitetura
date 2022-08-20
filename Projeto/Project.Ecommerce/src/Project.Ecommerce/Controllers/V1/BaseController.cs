using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Project.Ecommerce.Controllers.V1
{
    public class BaseController : Controller
    {
        protected string NomeUsuarioLogado
        {
            get
            {
                return "Felipe Luz";
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
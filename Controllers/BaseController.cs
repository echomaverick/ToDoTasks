using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Common;

namespace ToDoApplication.Controllers
{
    public class BaseController : Controller
    {
        protected SessionPerson AuthorizePersonInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                {
                    return new SessionPerson
                    {
                        Username = (string)HttpContext.Session.GetString("Username"),
                    };
                }
                return null;
            }
        }
    }
}

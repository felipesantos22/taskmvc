using Microsoft.AspNetCore.Mvc;

namespace taskmvc.Controllers;

public class ContactController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllocationsCRUD.Controllers
{
    //[Authorize]
    public class TreeGridDemoController : Controller
    {

        [AllowAnonymous]
        public ActionResult Demo1()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MicZDem.MdSpa.WebUI.ViewModels;

namespace MicZDem.MdSpa.WebUI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var model = new TestViewModel();

            StringBuilder userInfoStringBuilder = new StringBuilder();

            userInfoStringBuilder.Append("UserAgent: ");
            userInfoStringBuilder.Append(HttpContext.Request.UserAgent);
            userInfoStringBuilder.Append(" / ");
            userInfoStringBuilder.Append("UserHostAddress: ");
            userInfoStringBuilder.Append(HttpContext.Request.UserHostAddress);
            userInfoStringBuilder.Append(" / ");
            userInfoStringBuilder.Append("UserHostName: ");
            userInfoStringBuilder.Append(HttpContext.Request.UserHostName);
            //userInfoStringBuilder.Append(" / ");

            model.TestUserInfo = userInfoStringBuilder.ToString();
            return View(model);
        }
    }
}
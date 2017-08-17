using blog1.Models;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Mail;

namespace blog1.Controllers
{
    [RequireHttps]
    public class HomeController : UserController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var body = "<p>Email From: <b>{0}</b>({1})</p><p>Message:</p><p>{2}</p>";
                    //model.Body = "This is a message from your personal site. The name and the email of the contacting person is above";
                    var email = new MailMessage(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["emailFrom"])
                    {
                        Subject = "Welcome to my contact",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return RedirectToAction("Sent");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }

            }

            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}


//        public async Task<ActionResult>Contact(EmailModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var body = "<p>Email From:<bold>{0}</bold> ({ 1})</p><p> Message:</p><p>{ 2}</ p >";
//                    //var from = "MyPortfolio<neenaaelias@gmail.com>";
//                    model.Body = "This is a message from your portfolio site The name and the email of the contacting person is above.";
//                    var email = new MailMessage( ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["username"])
//                    {
//                        Subject = "portfolio contact Email",
//                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
//                        IsBodyHtml = true
//                    };

//                    var svc = new PersonalEmail();
//                    await svc.SendAsync(email);
//                    return RedirectToAction("Sent");
//                }
//    catch(Exception ex)
//        {
//         Console.WriteLine(ex.Message);
//        await Task.FromResult(0);
//                }
//            }
//            return View(model);
//        }



//    }
//}



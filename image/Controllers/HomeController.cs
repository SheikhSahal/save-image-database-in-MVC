using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using image.Models;

namespace image.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                      || Path.GetExtension(file.FileName).ToLower() == ".png"
                      || Path.GetExtension(file.FileName).ToLower() == ".gif"
                      || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Image"), file.FileName);
                        file.SaveAs(path);
                    }
                    MastplayEntities db = new MastplayEntities();
                    Movies_detail mdm = new Movies_detail();

                    mdm.image_path = path;
                    db.Movies_detail.Add(mdm);
                    db.SaveChanges();
                }
            }
            return View();
        }
    }
}
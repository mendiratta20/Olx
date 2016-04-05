using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.DataAccessLayer;
using OlxAd.Models;
namespace OlxAd.Controllers
{
    public class InsertAdsController : Controller
    {
        //
        // GET: /InsertAds/

        [HttpGet]
        [ActionName("Insert")]
        public PartialViewResult InsertAds_get()
        {

            InsertAds insert = new InsertAds();


            return PartialView("_Insert", insert);
        }


        [HttpPost]
        // [ActionName("Insert")]
        public PartialViewResult InsertAds_post(InsertAds Insert, HttpPostedFileBase file)
        {
           
            
            try
            { 
                if (ModelState.IsValid)
                {

                    if (file != null)
                    {
                        string pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(
                                               Server.MapPath("~/Images/"), pic);
                        // file is uploaded
                        file.SaveAs(path);

                        Insert.Image = "~/Images/"+pic;

                    }
                    
                    new DBData().InsertdataforADS(Insert,Convert.ToInt32(Session["UserNo"]));
                    ViewBag.dataValid = 1;
                }
                
                return PartialView("_Insert",Insert);

           }

            catch
            {
                ViewBag.dataValid = 0;
                return PartialView("_Insert");
            }
       }



    }
}

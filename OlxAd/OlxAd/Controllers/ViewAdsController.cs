using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.DataAccessLayer;
using OlxAd.Models;
using PagedList;
using System.Web.Http;
using System.Web.Script.Serialization;
namespace OlxAd.Controllers
{
    public class ViewAdsController : Controller
    {
        //
        // GET: /ViewAds/

        public ActionResult Home()
        {
            return View();
        }


        public void _Ads(string Category)
        {
          //  int pageSize = 3;
           // int pageIndex = 1;
         
           // pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            List<InsertAds> AdsList =null;

            AdsList = new DBData().ViewAds(Category);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Response.Write(js.Serialize(AdsList));
           // ViewBag.Category = Category;
           // return AdsList;
          //  IPagedList<InsertAds> objItemCrud = AdsList.ToPagedList(pageIndex, pageSize);

           // return PartialView("_ViewAds", objItemCrud);
           

        }

      
    }
}

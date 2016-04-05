using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.DataAccessLayer;
using OlxAd.Models;
using PagedList;
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


        public PartialViewResult _Ads(int? page,string Category)
        {
            int pageSize = 3;
            int pageIndex = 1;
         
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            List<InsertAds> AdsList =null;

            AdsList = new DBData().ViewAds(Category);
            ViewBag.Category = Category;
           
            IPagedList<InsertAds> objItemCrud = AdsList.ToPagedList(pageIndex, pageSize);

            return PartialView("_ViewAds", objItemCrud);
           

        }

      
    }
}

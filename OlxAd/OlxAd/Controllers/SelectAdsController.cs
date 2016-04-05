using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlxAd.Models;
using OlxAd.DataAccessLayer;
using PagedList;
namespace OlxAd.Controllers
{
    public class SelectAdsController : Controller
    {
        //
        // GET: /SelectAds/

       
        [HttpGet]
        public PartialViewResult selectAds_get(int? page)
        {
            List<InsertAds> ads = new List<InsertAds>();
            int pageSize = 3;
             int pageIndex = 1;

              pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
             ads = new DBData().MyAds(Convert.ToInt32(Session["UserNo"]));
            IPagedList<InsertAds> objItemCrud = ads.ToPagedList(pageIndex, pageSize);
            
            return PartialView("_ShowAds",objItemCrud);
        }


       

       
    }
}

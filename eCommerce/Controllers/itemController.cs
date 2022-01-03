using eCommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using System.IO;


namespace eCommerce.Controllers
{
    public class itemController : Controller
    {


        private Models.ECOMMERCEdBEntities objEcartDbEntites;

        public itemController()
        {
            objEcartDbEntites = new Models.ECOMMERCEdBEntities();

        }




        // GET: item
        public ActionResult ItemAddView()
        {

            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objEcartDbEntites.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.CategoryName,
                                                           Value = objCat.CategoryID.ToString(),
                                                           Selected = true
                                                       }) ;
            CategoryViewModel objCategoryViewModel = new CategoryViewModel();   


            return View(objItemViewModel);
        }




        [HttpPost]
        public ActionResult SaveRecord(ItemViewModel objItemViewModel, HttpPostedFileBase file)
        {
            string _path="";

            Item objItem = new Item();
            string _FileName="";
            if (file.ContentLength > 0)
            {
                _FileName = Path.GetFileName(file.FileName);
                _path = Path.Combine(Server.MapPath("~/Images"), _FileName);
                file.SaveAs(_path);
            }

            objItem.ImagePath = "/Images"+'/'+ _FileName ;


            objItem.CategoryID = objItemViewModel.CategoryID;
            objItem.Description = objItemViewModel.Description;
            objItem.ItemCode = objItemViewModel.ItemCode;
            objItem.ItemId = Guid.NewGuid();
            objItem.ItemName = objItemViewModel.ItemName;
            objItem.ItemPrice = objItemViewModel.ItemPrice;
            objEcartDbEntites.Items.Add(objItem);
            objEcartDbEntites.SaveChanges();


            return View("SaveRecord");
        }


        
        public void UploadFile(HttpPostedFileBase file)
        {
          
            
               
          
        }

    }
}
using eCommerce.Models;
using eCommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace eCommerce.Controllers
{
    public class ShoppingController : Controller
    {

        private ECOMMERCEdBEntities db;
         List<ShoppingCartModel> ListOfshoppingCartViewModels ;
        public ShoppingController()
        {
             db=new ECOMMERCEdBEntities();
            ListOfshoppingCartViewModels=new List<ShoppingCartModel>(); 
        }
        // GET: Shopping
        public ActionResult ShopNow()
        {

            IEnumerable<ViewModel.ShoppingViewModel> listOfShoppingViewModel =(from objItem in db.Items 
                                                                     join 
                                                                     objcategory in db.Categories
                                                                     on objItem.CategoryID equals objcategory.CategoryID   
                                                                     select new ViewModel.ShoppingViewModel()
                                                                     {

                                                                         ItemName=objItem.ItemName,
                                                                         ImagePath=objItem.ImagePath,   
                                                                         ItemPrice=objItem.ItemPrice,   
                                                                         Description=objItem.Description,   
                                                                         ItemId=objItem.ItemId, 
                                                                         Category=objcategory.CategoryName
                                                                     }
                                                                     ).ToList();




            return View(listOfShoppingViewModel);
        }

        public ActionResult ShopItem()
        {






            return View();
        }


        [HttpPost]
        public void AddToCart(Guid itemID)
        {

            
            //creates model   of shoppingView cart that has data of ShoppingCartView of that item
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();

            //creates object of an item in db that have that item id 
            Item objItem = db.Items.FirstOrDefault(model => model.ItemId == itemID);
            if(Session["CartCounter"]!=null)
            {
                ListOfshoppingCartViewModels = Session["CartItems"] as List<ShoppingCartModel>;
            }
      

            //  if item exists in cart so it will be updated
            if(ListOfshoppingCartViewModels.Any(model => model.ItemId == itemID ))
            {
                objShoppingCartModel = ListOfshoppingCartViewModels.Single(model => model.ItemId == itemID);  //add that db object to objShoppingModel
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.PricePerUnit ;
            }
            else
            {
                objShoppingCartModel.ItemId = itemID;
                objShoppingCartModel.ItemName = objItem.ItemName;
                objShoppingCartModel.ImagePath = objItem.ImagePath;
                objShoppingCartModel.PricePerUnit = objItem.ItemPrice;
                objShoppingCartModel.Quantity = 1 ;
                objShoppingCartModel.Total = objItem.ItemPrice;

                //add that item to the list view
                ListOfshoppingCartViewModels.Add(objShoppingCartModel);
            }


            Session["CartCounter"] = ListOfshoppingCartViewModels.Count;    //Session is a state management technique that is used to manage
                                                                            //the state of a
                                                                            //page or
                                                                            //control throughout the application.
                                                                            //can store the value and access it in another page or
                                                                            //throughout the application.
            Session["CartItems"] = ListOfshoppingCartViewModels;


         
        }



        public ActionResult Cart(Guid ItemID)
        {

            AddToCart(ItemID);
           


            return View(ListOfshoppingCartViewModels);
        }

        [ActionName("CartWithoutParameter")]
        public ActionResult CartWithoutParameter()
        {



            ListOfshoppingCartViewModels = Session["CartItems"] as List<ShoppingCartModel>;

            return View(ListOfshoppingCartViewModels);
        }
        public ActionResult CheckOut()
        {
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;
        
            return View();
        }


    }
}
using MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProductController));

        // GET: Product
        public ActionResult Index()
        {
            if (Session["email"] != null)
            {
                IEnumerable<mvcProductModel> productList = null;
                try
                {
                    //Getting Product list from database using web api
                    HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Product").Result;
                    productList = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;
                }catch(Exception e)
                {
                    logger.Error("Exception - " + e.ToString());
                }
                return View(productList);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (Session["email"] != null)
            {
                //checking request for addind product or editing peoduct details
                if (id == 0)
                {
                    return View(new mvcProductModel());
                }
                else
                {
                    HttpResponseMessage res = null;
                    try
                    {
                        //Getting Product detail and setting to form
                        res = GlobalVariables.webApiClient.GetAsync("Product/" + id.ToString()).Result;
                    }catch(Exception e)
                    {
                        logger.Error("Exception - " + e.ToString());
                    }
                    return View(res.Content.ReadAsAsync<mvcProductModel>().Result);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel prd)
        {
            if (ModelState.IsValid) 
            {
                HttpResponseMessage res = null;
                //getting file name and extension
                String FileName = Path.GetFileNameWithoutExtension(prd.SmallImgFile.FileName);
                String FileExtension = Path.GetExtension(prd.SmallImgFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + FileExtension;
                prd.Small_Img = "DBImage/small/" + FileName;
                FileName = Path.Combine(Server.MapPath("~/DBImage/small/"), FileName);
                //saving file in serverfolder
                prd.SmallImgFile.SaveAs(FileName);
                FileName = Path.GetFileNameWithoutExtension(prd.LargeImgFile.FileName);
                FileExtension = Path.GetExtension(prd.LargeImgFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssfff") + FileExtension;
                prd.Large_Img = "DBImage/large/" + FileName;
                FileName = Path.Combine(Server.MapPath("~/DBImage/large/"), FileName);
                prd.LargeImgFile.SaveAs(FileName);

                //creating model for sending to webapi
                WEBProductModel product = new WEBProductModel();
                product.ID = prd.ID;
                product.Name = prd.Name;
                product.Category = prd.Category;
                product.Price = prd.Price;
                product.Quantity = prd.Quantity;
                product.Short_Description = prd.Short_Description;
                product.Long_Description = prd.Long_Description;
                product.Small_Img = prd.Small_Img;
                product.Large_Img = prd.Large_Img;

                if (prd.ID == 0)
                {
                    try
                    {
                        //method for posting data in database
                        res = GlobalVariables.webApiClient.PostAsJsonAsync("Product", product).Result;
                        if (res.IsSuccessStatusCode)
                        {
                            TempData["msg"] = "Product Added Successfully.";
                            logger.Info("Product Added Successfully.");
                        }
                    }
                    catch(Exception e)
                    {
                        logger.Error("Exception - " + e.ToString());
                    }                    
                }
                else
                {
                    try
                    {
                        //method for Editing data in database
                        res = GlobalVariables.webApiClient.PutAsJsonAsync("Product/" + product.ID, product).Result;
                        if (res.IsSuccessStatusCode)
                        {
                            TempData["msg"] = "Product Edited Successfully.";
                            logger.Info("Product Edited Successfully.");
                        }
                    }catch(Exception e)
                    {
                        logger.Error("Exception - " + e.ToString());
                    }
                }
                ModelState.Clear();
                return RedirectToAction("Index","Product");
            }
            else
            {
                return View();
            }
            
            
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage res = null;
            try
            {
                //Getting Product Name for displaying in alert
                res = GlobalVariables.webApiClient.GetAsync("Product/" + id.ToString()).Result;
                mvcProductModel m = res.Content.ReadAsAsync<mvcProductModel>().Result;
                //Removing product details from  database
                res = GlobalVariables.webApiClient.DeleteAsync("Product/" + id.ToString()).Result;
                if (res.IsSuccessStatusCode)
                {
                    TempData["msg"] = m.Name + " Product Deleted Successfully.";
                    logger.Info("Product Deleted Successfully.");
                }
            }catch(Exception e)
            {
                logger.Error("Exception - " + e.ToString());
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult DeleteChecked(FormCollection formCollection)
        {
            //getting check products id 
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            HttpResponseMessage res = null;
            try
            {
                foreach (string id in ids)
                {
                    //removing products from database
                    res = GlobalVariables.webApiClient.DeleteAsync("Product/" + id).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        TempData["msg"] = "Selected Product Deleted Successfully.";
                    }
                }
                logger.Info("Selected Product Deleted Successfully.");
            }
            catch(Exception e)
            {
                logger.Error("Exception - " + e.ToString());
            }
            return RedirectToAction("Index","Product");

        }


    }
}
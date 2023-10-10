using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NewOnlineExam.Models;
using NewOnlineExam.Models.UserDefineModels;

namespace NewOnlineExam.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var catList = db.Category.ToList();

            var CVM = new List<CategoryViewModel>();

            foreach (var cat in catList)
            {
                CVM.Add(new CategoryViewModel()
                {
                    CatId = cat.Id,
                    CatName = cat.Name
                });
            }
            
            var obj = new categoryTableData()
            {
                data = CVM
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveData(CategoryViewModel obj)
        {
            try
            {
                if (obj.CatId == 0)
                {
                    var category = new Category()
                    {
                        Name = obj.CatName
                    };
                    db.Category.Add(category);
                    db.SaveChanges();
                }
                else
                {
                    var category = db.Category.Find(obj.CatId);
                    if (category != null)
                    {
                        category.Name = obj.CatName;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Category Not Found in db");
                    }
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteData(int Id)
        {
            try
            {
                var category = db.Category.Find(Id);
                if (category != null)
                {
                    db.Category.Remove(category);
                    db.SaveChanges();
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class categoryTableData
    {
        public IEnumerable<CategoryViewModel> data { get; set; }
    }

    public class CategoryViewModel
    {
        public string i { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
    }

}

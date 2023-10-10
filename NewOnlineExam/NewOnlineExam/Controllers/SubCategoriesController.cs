using NewOnlineExam.Models;
using NewOnlineExam.Models.UserDefineModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NewOnlineExam.Controllers
{
    public class SubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubCategories
        public ActionResult Index()
        {
            ViewBag.Categories = db.Category.ToList();
            return View();
        }

        public ActionResult GetData(int CatId)
        {
            var SubCatList = db.SubCategory.Where(g=>g.CategoryId==CatId).ToList();

            var CVM = new List<SubCatViewModel>();

            foreach (var SubCat in SubCatList)
            {
                CVM.Add(new SubCatViewModel()
                {
                    SubCatId = SubCat.Id,
                    SubCatName = SubCat.Name
                });
            }

            var obj = new SubCatTableData()
            {
                data = CVM
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveData(SubCatViewModel obj)
        {
            try
            {
                if (obj.SubCatId == 0)
                {
                    var SubCategory = new SubCategory()
                    {
                        Name = obj.SubCatName,
                        CategoryId = obj.CatId
                    };
                    db.SubCategory.Add(SubCategory);
                    db.SaveChanges();
                }
                else
                {
                    var SubCategory = db.SubCategory.Find(obj.SubCatId);
                    if (SubCategory != null)
                    {
                        SubCategory.Name = obj.SubCatName;
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
                var SubCategory = db.SubCategory.Find(Id);
                if (SubCategory != null)
                {
                    db.SubCategory.Remove(SubCategory);
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
    public class SubCatTableData
    {
        public IEnumerable<SubCatViewModel> data { get; set; }
    }

    public class SubCatViewModel
    {
        public string i { get; set; }
        public int SubCatId { get; set; }
        public int CatId { get; set; }
        public string SubCatName { get; set; }
    }

}

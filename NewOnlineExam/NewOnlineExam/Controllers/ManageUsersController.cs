using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewOnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewOnlineExam.Controllers
{
    public class ManageUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ManageUsers
        public ActionResult Index()
        {
            ViewBag.Roles = db.Roles.ToList();
            return View();
        }
        public ActionResult GetData()
        {
            var userId = "";
            if (User.Identity.IsAuthenticated)
                userId = User.Identity.GetUserId();

            var usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  where (role.Name != "Super User" && user.Id != userId)
                                  select new UserViewModel()
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      Role = role.Name
                                  }).ToList();

            var users = new UsersTableData()
            {
                data = usersWithRoles
            };

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUser(string Id)
        {
            try
            {
                var user = db.Users.Find(Id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChangeRole(string Id, string newRole)
        {
            try
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var roles = UserManager.GetRoles(Id);

                if (roles.Count != 0)
                {
                    var result = UserManager.RemoveFromRoleAsync(Id, roles.First());

                    if (result.Result.Succeeded)
                    {
                        result = UserManager.AddToRoleAsync(Id, newRole);

                        if (result.Result.Succeeded)
                        {
                            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }

                return Json(new { success = false, message = "" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }

    public class UsersTableData
    {
        public IEnumerable<UserViewModel> data { get; set; }
    }
    public class UserViewModel
    {
        public string i { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
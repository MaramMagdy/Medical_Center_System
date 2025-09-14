using Medical_Center_System.Data;
using Medical_Center_System.Models;
using Medical_Center_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Center_System.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext db;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, AppDbContext db)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel newRole)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRole.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
					return RedirectToAction("Index");
				}
				foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(newRole);
        }


        public IActionResult Index()
        {
            var roles = roleManager.Roles
                .Select(r => new RoleViewModel { Id = r.Id, RoleName = r.Name })
                .ToList();

            return View(roles);
        }


        [HttpGet]
        public async Task<IActionResult> Delete()
        {
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var usersInRole = await userManager.GetUsersInRoleAsync(role.Name);
            if (usersInRole.Any())
            {
                ModelState.AddModelError("", "Cannot delete role: there are users assigned to it.");
                return RedirectToAction("Index");
            }

            var res = await roleManager.DeleteAsync(role);
            if (!res.Succeeded) TempData["Error"] = string.Join(", ", res.Errors.Select(e => e.Description));
            return RedirectToAction("Index");
        }

    }
}

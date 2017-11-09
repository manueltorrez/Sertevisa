using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace ClienteSistemaFacturacion.Controllers
{
    public class ApplicationRolesController : Controller
    {
        public ApplicationRolesController()
        {
        }

        public ApplicationRolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        
        
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationRoles
        public async Task<ActionResult> Index()
        {
            return View(await RoleManager.Roles.ToListAsync());
        }

        //// GET: ApplicationRoles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // GET: ApplicationRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] ApplicationRoleViewModel applicationRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                //al iniciar esta linea ponerla en comentario
                ApplicationRole applicationRole = new ApplicationRole { Name = applicationRoleViewModel.Name };


                var roleResult = await RoleManager.CreateAsync(applicationRole);

                //Retorno a una vista en limpio si el rol no se creo correctamente.
                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", roleResult.Errors.First());
                    return View();
                }

                //db.IdentityRoles.Add(applicationRole);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ApplicationRoles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }


            //linea agregada al utilizar ApplicationRoleViewModel
            ApplicationRoleViewModel applicationRoleViewModel = new ApplicationRoleViewModel
            {
                Id = applicationRole.Id,
                Name = applicationRole.Name
            };
            return View(applicationRoleViewModel);

            //return View(applicationRole);
        }

        // POST: ApplicationRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] ApplicationRoleViewModel applicationRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole ApplicationRole = await RoleManager.FindByIdAsync(applicationRoleViewModel.Id);
                string originalName = ApplicationRole.Name;

                //Si el nombre original es admin y se desea cambiar no se pueda.
                if (originalName == "Admin" && applicationRoleViewModel.Name != "Admin")
                {
                    ModelState.AddModelError("", "No puedes cambiar el nombre del role a Admin");
                    return View(applicationRoleViewModel);
                }

                //Si el nombre original no es admin y se desea poner tal no se pueda realizar.
                if (originalName != "Admin" && applicationRoleViewModel.Name == "Admin")
                {
                    ModelState.AddModelError("", "No puedes cambiar el nombre del role a Admin");
                    return View(applicationRoleViewModel);
                }

                ApplicationRole.Name = applicationRoleViewModel.Name;
                await RoleManager.UpdateAsync(ApplicationRole);

                //applicationRole.Name = applicationRole.Name;
                //await RoleManager.UpdateAsync(applicationRole);

                //db.Entry(applicationRole).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationRoleViewModel);
        }

        // GET: ApplicationRoles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // POST: ApplicationRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationRole applicationRole = await RoleManager.FindByIdAsync(id);

            //No se puede borrar el usuario admin
            if (applicationRole.Name == "Admin")
            {
                ModelState.AddModelError("", "No puedes eliminar el rol Admin");
                return View(applicationRole);
            }

            await RoleManager.DeleteAsync(applicationRole);

            //db.IdentityRoles.Remove(applicationRole);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RoleManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

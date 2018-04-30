using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestAPICosmos.Controllers
{
    using System.Net;
    using System.Threading.Tasks;

    using RestAPICosmos.Models;

    public class ByController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var by = await DocumentDBRepository<By>.GetItemsAsync(d => !d.Completed);
            return this.View(by);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "ById,ByNavn,postnummer,Completed")] By by)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<By>.CreateCityAsync(by);
                return this.RedirectToAction("Index");
            }

            return View(by);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "ById,ByNavn,postnummer,Completed")] By by)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<By>.UpdateCityAsync(by.ById, by);
                return RedirectToAction("Index");
            }

            return View(by);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            By by = await DocumentDBRepository<By>.GetItemAsync(id);
            if (by == null)
            {
                return HttpNotFound();
            }

            return View(by);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            By by = await DocumentDBRepository<By>.GetItemAsync(id);
            if (by == null)
            {
                return HttpNotFound();
            }

            return View(by);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "ById")] string id)
        {
            await DocumentDBRepository<By>.DeleteCityAsync(id);
            return RedirectToAction("Index");
        }


    }
}
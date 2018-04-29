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

    public class CityController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var city = await DocumentDBRepository<City>.GetItemsAsync(d => !d.Completed);
            return this.View(city);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "CityId,CityName,CityZipCode,Completed")] City city)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<City>.CreateCityAsync(city);
                return this.RedirectToAction("Index");
            }

            return View(city);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "CityId,CityName,CityZipCode,Completed")] City city)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<City>.UpdateCityAsync(city.CityId, city);
                return RedirectToAction("Index");
            }

            return View(city);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = await DocumentDBRepository<City>.GetItemAsync(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            City city = await DocumentDBRepository<City>.GetItemAsync(id);
            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "cityId")] string id)
        {
            await DocumentDBRepository<City>.DeleteCityAsync(id);
            return RedirectToAction("Index");
        }


    }
}
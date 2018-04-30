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

    public class AdresseController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var adresse = await DocumentDBRepository<Adresse>.GetItemsAsync(d => !d.Completed);
            return this.View(adresse);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "AdresseId,AdresseNavn,AdresseNummer,AdresseType,Completed")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Adresse>.CreateAddressAsync(adresse);
                return this.RedirectToAction("Index");
            }

            return View(adresse);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "AdresseId,AdresseNavn,AdresseNummer,AdresseType,Completed")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Adresse>.UpdateAddressAsync(adresse.AdresseID, adresse);
                return RedirectToAction("Index");
            }

            return View(adresse);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Adresse adresser = await DocumentDBRepository<Adresse>.GetItemAsync(id);
            if (adresser == null)
            {
                return HttpNotFound();
            }

            return View(adresser);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Adresse adresser = await DocumentDBRepository<Adresse>.GetItemAsync(id);
            if (adresser == null)
            {
                return HttpNotFound();
            }

            return View(adresser);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "adresseID")] string id)
        {
            await DocumentDBRepository<Adresse>.DeleteAddressAsync(id);
            return RedirectToAction("Index");
        }
    }
}
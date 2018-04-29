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

    public class AddressController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var address = await DocumentDBRepository<Address>.GetItemsAsync(d => !d.Completed);
            return this.View(address);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "AddressId,AddressName,AddressNumber,AddressType,ZipCode,Completed")] Address address)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Address>.CreateAddressAsync(address);
                return this.RedirectToAction("Index");
            }

            return View(address);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "AddressId,AddressName,AddressNumber,AddressType,Completed")] Address address)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Address>.UpdateAddressAsync(address.AddressId, address);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Address addresses = await DocumentDBRepository<Address>.GetItemAsync(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }

            return View(addresses);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Address addresses = await DocumentDBRepository<Address>.GetItemAsync(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }

            return View(addresses);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "addressId")] string id)
        {
            await DocumentDBRepository<Address>.DeleteAddressAsync(id);
            return RedirectToAction("Index");
        }
    }
}
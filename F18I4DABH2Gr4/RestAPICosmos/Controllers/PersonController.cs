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
    public class PersonController : Controller
    {
        // GET: Person
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Person>.GetItemsAsync(d => !d.Completed);
            return this.View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return this.View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "FirstName,MiddleName,LastName,Email,Address,TelephoneNumbers")] Person person)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Person>.CreatePersonAsync(person);
                return RedirectToAction("Index");
            }

            return this.View(person);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "FirstName,MiddleName,LastName,Email,Address,TelephoneNumbers")] Person person)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Person>.UpdatePersonAsync(person.PersonId, person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = await DocumentDBRepository<Person>.GetItemAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id, string category)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = await DocumentDBRepository<Person>.GetItemAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "id")] string id)
        {
            await DocumentDBRepository<Person>.DeletePersonAsync(id);
            return RedirectToAction("Index");
        }

    }

}

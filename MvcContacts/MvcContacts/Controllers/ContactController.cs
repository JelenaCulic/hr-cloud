using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContacts.Models;

namespace MvcContacts.Controllers
{
    public class ContactController : Controller
    {
        private ContactsDBContext db = new ContactsDBContext();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public ActionResult createAngular()
        {

            return View();
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string Ime_c, string Prezime_c, string Tag_c)
        {

            var Taglst = new List<string>();

            var TagQry = from d in db.Contacts
                         orderby d.Tag
                         select d.Tag;

            Taglst.AddRange(TagQry.Distinct());
            ViewBag.Tag_c = new SelectList(Taglst);

            var contacts = from m in db.Contacts
                           select m;

            if (!String.IsNullOrEmpty(Ime_c))
            {
                contacts = contacts.Where(s => s.Ime.Contains(Ime_c));
            }

            if (!String.IsNullOrEmpty(Prezime_c))
            {
                contacts = contacts.Where(s => s.Prezime.Contains(Prezime_c));
            }

            if (string.IsNullOrEmpty(Tag_c))
                return View(contacts);
            else
            {
                return View(contacts.Where(x => x.Tag == Tag_c));
            }
        }
    }
}
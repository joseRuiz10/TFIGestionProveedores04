using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using TFIGestionProveedores04;

namespace TFIGestionProveedores04.Controllers
{
    public class TecnicoesController : Controller
    {
        private dbGestionProveedores03Entities db = new dbGestionProveedores03Entities();

        // GET: Tecnicoes
        public ActionResult Index(String nombre)
        {
            var tecnico = db.Tecnico.Where<Tecnico>(T => T.nombre.Contains(nombre));
            if (nombre.IsEmpty())
            {
                tecnico = db.Tecnico.Include(t => t.Proveedor);
            }

            return View(tecnico.ToList());
        }

        // GET: Tecnicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnico.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnicoes/Create
        public ActionResult Create()
        {
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial");
            return View();
        }

        // POST: Tecnicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTecnico,nombre,apellido,Telefono,Direcccion,id_Proveedor")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Tecnico.Add(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", tecnico.id_Proveedor);
            return View(tecnico);
        }

        // GET: Tecnicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnico.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", tecnico.id_Proveedor);
            return View(tecnico);
        }

        // POST: Tecnicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTecnico,nombre,apellido,Telefono,Direcccion,id_Proveedor")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", tecnico.id_Proveedor);
            return View(tecnico);
        }

        // GET: Tecnicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.Tecnico.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = db.Tecnico.Find(id);
            db.Tecnico.Remove(tecnico);
            db.SaveChanges();
            return RedirectToAction("Index");
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
}

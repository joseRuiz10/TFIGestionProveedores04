using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TFIGestionProveedores04;

namespace TFIGestionProveedores04.Controllers
{
    public class Calificacion_ProveedorController : Controller
    {
        private dbGestionProveedores03Entities db = new dbGestionProveedores03Entities();

        // GET: Calificacion_Proveedor
        public ActionResult Index()
        {
            var calificacion_Proveedor = db.Calificacion_Proveedor.Include(c => c.Calificacion).Include(c => c.Proveedor);
            return View(calificacion_Proveedor.ToList());
        }

        // GET: Calificacion_Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion_Proveedor calificacion_Proveedor = db.Calificacion_Proveedor.Find(id);
            if (calificacion_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(calificacion_Proveedor);
        }

        // GET: Calificacion_Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.idCalificacion = new SelectList(db.Calificacion, "idCalificacion", "idCalificacion");
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial");
            return View();
        }

        // POST: Calificacion_Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCalificacion_Proveedor,comentario,idProveedor,idCalificacion")] Calificacion_Proveedor calificacion_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Calificacion_Proveedor.Add(calificacion_Proveedor);
                db.SaveChanges();
                return RedirectToAction("Index","Proveedors");
            }

            ViewBag.idCalificacion = new SelectList(db.Calificacion, "idCalificacion", "idCalificacion", calificacion_Proveedor.idCalificacion);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", calificacion_Proveedor.idProveedor);
            return View(calificacion_Proveedor);
        }

        // GET: Calificacion_Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion_Proveedor calificacion_Proveedor = db.Calificacion_Proveedor.Find(id);
            if (calificacion_Proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCalificacion = new SelectList(db.Calificacion, "idCalificacion", "idCalificacion", calificacion_Proveedor.idCalificacion);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", calificacion_Proveedor.idProveedor);
            return View(calificacion_Proveedor);
        }

        // POST: Calificacion_Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCalificacion_Proveedor,comentario,idProveedor,idCalificacion")] Calificacion_Proveedor calificacion_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion_Proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCalificacion = new SelectList(db.Calificacion, "idCalificacion", "idCalificacion", calificacion_Proveedor.idCalificacion);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "RazonSocial", calificacion_Proveedor.idProveedor);
            return View(calificacion_Proveedor);
        }

        // GET: Calificacion_Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion_Proveedor calificacion_Proveedor = db.Calificacion_Proveedor.Find(id);
            if (calificacion_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(calificacion_Proveedor);
        }

        // POST: Calificacion_Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacion_Proveedor calificacion_Proveedor = db.Calificacion_Proveedor.Find(id);
            db.Calificacion_Proveedor.Remove(calificacion_Proveedor);
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

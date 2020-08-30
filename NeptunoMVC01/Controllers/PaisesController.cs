using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeptunoMVC01.Context;
using NeptunoMVC01.Models;
using PagedList;

namespace NeptunoMVC01.Controllers
{
    public class PaisesController : Controller
    {
        private NeptunoDbContext db = new NeptunoDbContext();

        // GET: Paises
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var listaPaises = db.Paises
                .OrderBy(p => p.NombrePais)
                .ToPagedList((int) page, 10);
            return View(listaPaises);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaisId,NombrePais")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Paises.Add(pais);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    if (ex.InnerException!=null && ex.InnerException.InnerException!=null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty,"Registro repetido!!!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,"Error al intentar guardar un registro!!!");
                    }
                }

            }

            return View(pais);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Paises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaisId,NombrePais")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(pais).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {

                    if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("IX"))
                    {
                        ModelState.AddModelError(string.Empty, "Registro repetido!!!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al intentar guardar un registro!!!");
                    }
                }

            }
            return View(pais);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = db.Paises.Find(id);
            try
            {
               
                db.Paises.Remove(pais);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null 
                    && ex.InnerException.InnerException!=null
                    && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty,"Registro relacionado... baja denegada");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Error al intentar dar de baja un registro");
                }
            }

            return View(pais);
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

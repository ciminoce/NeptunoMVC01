using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NeptunoMVC01.Classes;
using NeptunoMVC01.Context;
using NeptunoMVC01.Models;

namespace NeptunoMVC01.Controllers
{
    public class ClientesController : Controller
    {
        private NeptunoDbContext db = new NeptunoDbContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Ciudad).Include(c => c.Pais);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            ViewBag.PaisId = new SelectList(Helper.GetPaises(), "PaisId", "NombrePais");
            ViewBag.CiudadId = new SelectList(Helper.GetCiudades(), "CiudadId", "NombreCiudad");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,NombreCliente,Direccion,CodPostal,CiudadId,PaisId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaisId = new SelectList(Helper.GetPaises(), "PaisId", "NombrePais", cliente.PaisId);
            ViewBag.CiudadId = new SelectList(Helper.GetCiudades(), "CiudadId", "NombreCiudad", cliente.CiudadId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaisId = new SelectList(Helper.GetPaises(), "PaisId", "NombrePais", cliente.PaisId);
            ViewBag.CiudadId = new SelectList(Helper.GetCiudades(), "CiudadId", "NombreCiudad", cliente.CiudadId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,NombreCliente,Direccion,CodPostal,CiudadId,PaisId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaisId = new SelectList(Helper.GetPaises(), "PaisId", "NombrePais", cliente.PaisId);
            ViewBag.CiudadId = new SelectList(Helper.GetCiudades(), "CiudadId", "NombreCiudad", cliente.CiudadId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

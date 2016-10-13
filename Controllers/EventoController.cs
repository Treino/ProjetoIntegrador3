using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROJETO3.Models;
using System.Text;

namespace PROJETO3.Controllers
{
    public class EventoController : Controller
    {
        private Entidades db = new Entidades();

        // GET: /Evento/
        public ActionResult Index()
        {            
                var evento = db.Evento.Include(e => e.TipoEvento).Include(e => e.Professor).Include(e => e.Assunto);
                return View(evento.ToList());
        }

        // GET: /Evento/Create
        public ActionResult Cadastrar()
        {
            List<TipoEvento> tipoevento = new List<TipoEvento>();
            SelectList tipoeventoList = new SelectList(tipoevento, "ID", "Name");
            ViewBag.TipoEvento = tipoeventoList;
            return View();

            ViewBag.TipoEvento = new SelectList(db.TipoEvento, "codTipoEvento", "descTipoEvento");
            ViewBag.Professor = new SelectList(db.Professor, "codProfessor", "nome");
            return View();
        }

        // POST: /Evento/Cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /*
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(EventoViewModel evento)
        {
            try
            {
                evento.ativo = true;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO Evento VALUES ('{0}', {1}, '{2}', HASHBYTES('SHA1', '{3}'), {4})",
                    evento.nmEvento,
                    evento.codCurso,
                    evento.email,
                    evento.senha,
                    1);
                using (var ctx = new Entidades())
                {
                    ctx.Database.ExecuteSqlCommand(sb.ToString());
                    ctx.SaveChanges();
                    ViewBag.OK = "S";
                }
            }
            catch (Exception)
            {
                ViewBag.OK = "N";
            }
            return View("Resultado", evento);  
    }
    
        // GET: /Evento/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.codCurso = new SelectList(db.Curso, "codCurso", "nmCurso", evento.codCurso);
            return View(evento);
        }

        // POST: /Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codEvento,nmEvento,codCurso,email,senha,ativo")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codCurso = new SelectList(db.Curso, "codCurso", "nmCurso", evento.codCurso);
            return View(evento);
        }

        // GET: /Evento/Deletar/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Evento.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: /Evento/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Evento.Find(id);
            db.Evento.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // REMOTE DA VALIDAÇÃO DO EMAIL
        public JsonResult VerificarEmail(string email) {
            int intCont = 0;
            intCont=db.Evento.Where(m => m.email == email).Count();
            if (intCont > 0)
                return Json("E-Mail Já Cadrastrado",JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        */

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

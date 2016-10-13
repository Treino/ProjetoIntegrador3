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
    public class ParticipanteController : Controller
    {
        private Entidades db = new Entidades();

        // GET: /Participante/
        public ActionResult Index(string pesquisa = "")
        {            
            if (string.IsNullOrEmpty(pesquisa)) { 
                var participante = db.Participante.Include(p => p.Curso);
                return View(participante.ToList());
            }
            else
            {
                var participante = db.Participante.Include(p => p.Curso).Where(p => p.nmParticipante.Contains(pesquisa) || p.email.Contains(pesquisa));
                return View(participante.ToList());
            }
        }

        // GET: /Participante/Detalhes/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // GET: /Participante/Create
        public ActionResult Cadastrar()
        {
            ViewBag.codCurso = new SelectList(db.Curso, "codCurso", "nmCurso");
            return View();
        }

        // POST: /Participante/Cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ParticipanteViewModel participante)
        {
            try
            {
                participante.ativo = true;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO Participante VALUES ('{0}', {1}, '{2}', HASHBYTES('SHA1', '{3}'), {4})",
                    participante.nmParticipante,
                    participante.codCurso,
                    participante.email,
                    participante.senha,
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
            return View("Resultado", participante);
        }

        // GET: /Participante/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            ViewBag.codCurso = new SelectList(db.Curso, "codCurso", "nmCurso", participante.codCurso);
            return View(participante);
        }

        // POST: /Participante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "codParticipante,nmParticipante,codCurso,email,senha,ativo")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codCurso = new SelectList(db.Curso, "codCurso", "nmCurso", participante.codCurso);
            return View(participante);
        }

        // GET: /Participante/Deletar/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante participante = db.Participante.Find(id);
            if (participante == null)
            {
                return HttpNotFound();
            }
            return View(participante);
        }

        // POST: /Participante/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participante participante = db.Participante.Find(id);
            db.Participante.Remove(participante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // REMOTE DA VALIDAÇÃO DO EMAIL
        public JsonResult VerificarEmail(string email) {
            int intCont = 0;
            intCont=db.Participante.Where(m => m.email == email).Count();
            if (intCont > 0)
                return Json("E-Mail Já Cadrastrado",JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
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

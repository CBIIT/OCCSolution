using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;

namespace OCCSolution.Controllers
{
    public class OCCMessageBoardController : Controller
    {
        private OCCEntities db = new OCCEntities();

        // GET: OCCMessageBoard
        [OutputCache(Duration = 1800)]
        public ActionResult Index()
        {
            var msgBoards = new List<vwOCCMessageBoard>();
            try
            {
                msgBoards = db.vwOCCMessageBoards.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(msgBoards);

           
        }

        [OutputCache(Duration = 1800)]
        public ActionResult OCCMessageBoard()
        {
            var mBoards = new List<vwOCCMessageBoard>();
            try
            {
                mBoards = db.vwOCCMessageBoards.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(mBoards);
        }

        // GET: OCCMessageBoard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwOCCMessageBoard oCCMessageBoard = db.vwOCCMessageBoards.Find(id);
            if (oCCMessageBoard == null)
            {
                return HttpNotFound();
            }
            return View(oCCMessageBoard);
        }

        // GET: OCCMessageBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OCCMessageBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OCCMessageBoardID,Message,Title,isActive,Comments,EffectiveDate,CreatedDateDate,LastUpdatedDate,LastUpdatedUserName")] vwOCCMessageBoard oCCMessageBoard)
        {
            if (ModelState.IsValid)
            {
                db.vwOCCMessageBoards.Add(oCCMessageBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oCCMessageBoard);
        }

        // GET: OCCMessageBoard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            vwOCCMessageBoard oCCMessageBoard = db.vwOCCMessageBoards.Find(id);
            if (oCCMessageBoard == null)
            {
                return HttpNotFound();
            }
            return View(oCCMessageBoard);
        }

        // POST: OCCMessageBoard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OCCMessageBoardID,Message,Title,isActive,Comments,EffectiveDate,CreatedDateDate,LastUpdatedDate,LastUpdatedUserName")] OCCMessageBoard oCCMessageBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oCCMessageBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oCCMessageBoard);
        }

        // GET: OCCMessageBoard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwOCCMessageBoard oCCMessageBoard = db.vwOCCMessageBoards.Find(id);
            if (oCCMessageBoard == null)
            {
                return HttpNotFound();
            }
            return View(oCCMessageBoard);
        }

        // POST: OCCMessageBoard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwOCCMessageBoard oCCMessageBoard = db.vwOCCMessageBoards.Find(id);
            db.vwOCCMessageBoards.Remove(oCCMessageBoard);
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

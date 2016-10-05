using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge2.Models;

namespace Challenge2.Controllers
{
    public class TeamsController : Controller
    {
        private Challenge2Context db = new Challenge2Context();

        // GET: Teams
        [Route("Teams", Name = "Index")]
        public ActionResult Index()
        {
            return Json(db.Teams.OrderBy(x => x.Name).ToList(), JsonRequestBehavior.AllowGet);
        }

        // POST: Teams
        [Route("Teams")]
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                try {
                    db.Teams.Add(team);
                    db.SaveChanges();
                }
                catch
                {
                    return Json("false");
                }
                //return RedirectToAction("Index");
            }
            return Json(db.Teams.OrderBy(x => x.Name).ToList(), JsonRequestBehavior.AllowGet);

        }

        // PUT: Teams
        [Route("Teams")]
        [HttpPut]
        public ActionResult Update(Team team)
        {
            if(ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                //db.Entry(team.HomeStadium).State = EntityState.Modified;
                db.SaveChanges();
                return Json(team);
            }
            else
            {
                return Json("false");
            }
        }

        // DELETE: Teams
        [Route("Teams")]
        [HttpDelete]
        public ActionResult DeleteTeams()
        {
            db.Teams.RemoveRange(db.Teams);
            db.SaveChanges();
            return RedirectToRoute("Index");
        }

        // GET: Teams/{TeamName}
        [Route("Teams/{teamName}")]
        public ActionResult GetTeam(string teamName)
        {
            Team team = db.Teams.Find(teamName);
            if(team != null)
            {
                return Json(team, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json("Could not find team by the name of " + teamName);
            }
        }

        // Below are the methods from the scaffolding

        // GET: Teams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Name,City")] Team team)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Teams.Add(team);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(team);
        //}

        // GET: Teams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,City")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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

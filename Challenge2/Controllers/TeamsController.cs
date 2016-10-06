using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Challenge2.Models;
using System.Data.Entity.Infrastructure;

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
            db.Configuration.ProxyCreationEnabled = false;
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        // PUT: Teams
        [Route("Teams")]
        [HttpPut]
        public ActionResult Update(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                //db.Entry(team.HomeStadium).State = EntityState.Modified;
                try {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Json("'Return':false");
                }
                catch (DbUpdateException ex)
                {
                    return Json("'Return':false");
                }
                return Index();
            }
            else
            {
                return HttpNotFound();
            }
        }

        // DELETE: Teams
        [Route("Teams")]
        [HttpDelete]
        public ActionResult DeleteTeams()
        {
            db.Players.RemoveRange(db.Players);
            db.Stadiums.RemoveRange(db.Stadiums);
            db.Teams.RemoveRange(db.Teams);
            //foreach (Team team in db.Teams)
            //{
            //    db.Stadiums.Remove(team.Stadium);
            //    db.Teams.Remove(team);
            //}
            db.SaveChanges();
            return Index();
        }

        // GET: Teams/{TeamName}
        [Route("Teams/{teamName}")]
        public ActionResult GetTeam(string teamName)
        {
            Team team = db.Teams.Find(teamName);
            if (team != null)
            {
                return Json(team, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Teams/{TeamName}/Players
        [Route("Teams/{teamName}/Players")]
        public ActionResult getTeamPlayers(string teamName)
        {
            Team team = db.Teams.Find(teamName);
            if (team != null)
            {
                return Json(team.Players, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Teams/{TeamName}/Stadium
        [Route("Teams/{teamName}/Stadium")]
        public ActionResult getTeamStadium(string teamName)
        {
            Team team = db.Teams.Find(teamName);
            if (team != null)
            {
                return Json(team.Stadium, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Teams/{TeamName}/Players
        [Route("Teams/{teamName}/Players")]
        [HttpPost]
        public ActionResult addPlayersToTeam(string teamName, Player playerToAdd)
        {
            Team team = db.Teams.Find(teamName);
            if (team != null)
            {
                try
                {
                    team.Players.Add(playerToAdd);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
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

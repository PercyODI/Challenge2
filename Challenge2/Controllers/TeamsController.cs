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

        // Returns a default view page for testing application visibility
        [Route("Teams/Default")]
        [Route("")]
        public ActionResult DefaultPage()
        {
            return new FilePathResult("~/Views/Default.html", "text/html");
        }

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
            }
            return Index();

        }

        // PUT: Teams
        [Route("Teams")]
        [HttpPut]
        public ActionResult Update(Team team)
        {
            // This function will only update teams, not
            // the stadiums or players in a team.
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex) // Used for teams that aren't found
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
                }
                catch (DbUpdateException ex) // Used for any other databse update issue
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
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
            // Due to how the model is created in the Entity Framework,
            // all dependent rows (Players and Stadiums) are deleted
            // before the teams are deleted. This would be much more 
            // involved if we had to delete specific items.
            db.Players.RemoveRange(db.Players);
            db.Stadiums.RemoveRange(db.Stadiums);
            db.Teams.RemoveRange(db.Teams);

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
    }
}

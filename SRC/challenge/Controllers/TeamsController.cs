using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using challenge.Models.DB;
using challenge.Models.Data;
using challenge.Models.Commands;

namespace challenge.Controllers
{
    public class TeamsController : Controller
    {
        private TeamsDB db = new TeamsDB();

        //---------------------------------------------------------------------
        // GET: Teams
        public ActionResult Index()
        {
            CmdGetTeams cmd = new CmdGetTeams();

            using ( Connection db = new Connection() )
            {
                cmd.execCmd( db );
            }

            ViewBag.countTeams = cmd.ArrTeams.Count;

            return View( cmd.ArrTeams );
        }

        //---------------------------------------------------------------------
        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------
        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( [Bind( Include = "Id,Name" )] Team team )
        {
            if ( ModelState.IsValid )
            {
                using ( Connection db = new Connection() )
                {
                    db.Team.Add( team );
                    db.SaveChanges();
                }

                return RedirectToAction( "Index" );
            }

            return View( team );
        }

        //---------------------------------------------------------------------
        // GET: Teams/Edit/5
        public ActionResult Edit( int? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }

            Team team = null;

            using ( Connection db = new Connection() )
            {
                team = db.Team.Find(id);
            }

            if ( team == null )
            {
                return HttpNotFound();
            }

            return View( team );
        }

        //---------------------------------------------------------------------
        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( [Bind( Include = "Id,Name" )] Team team )
        {
            if ( ModelState.IsValid )
            {
                using ( Connection db = new Connection() )
                {
                    db.Entry( team ).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction( "Index" );
            }

            return View( team );
        }

        //---------------------------------------------------------------------
        // GET: Teams/Delete/5
        public ActionResult Delete( int? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
            }

            Team team = null;
            using ( Connection db = new Connection() )
            {
                team = db.Team.Find(id);
            }

            if ( team == null )
            {
                return HttpNotFound();
            }

            return View( team );
        }

        //---------------------------------------------------------------------
        // POST: Teams/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed( int id )
        {
            using ( Connection db = new Connection() )
            {
                Team team = db.Team.Find(id);
                db.Team.Remove( team );
                db.SaveChanges();
            }

            return RedirectToAction( "Index" );
        }

        //---------------------------------------------------------------------
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                using ( Connection db = new Connection() )
                {
                    db.Dispose();
                }
            }
            base.Dispose( disposing );
        }
    }
}

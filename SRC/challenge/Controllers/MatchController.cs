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
using System.IO;
using challenge.Properties;

namespace challenge.Controllers
{
    public class MatchController : Controller
    {
        //---------------------------------------------------------------------
        // GET: Match
        public ActionResult Index()
        {
            CmdGetMatches cmd = new CmdGetMatches();

            using ( MatchDB db = new MatchDB() )
            {
                cmd.execCmd( db );
            }

            ViewBag.arrTeams = cmd.ArrTeams;

            return View( cmd.ArrMatches );
        }
        
        //---------------------------------------------------------------------
        public ActionResult Sort ()
        {
            CmdGetTeams cmd = new CmdGetTeams();

            using ( Connection db = new Connection() )
            {
                cmd.execCmd( db );
            }

            var random = new Random();

            var items =
                from arr in cmd.ArrTeams
                let sort = random.Next(1,10)
                orderby sort
                select arr;

            string msgError = null;

            if ( items == null )
                msgError = Mensagens.ERR_TEAMS_NOT_FOUND;
            else if ( cmd.ArrTeams.Count < 4 )
                msgError = Mensagens.ERR_INSUFFICIENT_NUMBER_TEAMS;

            if ( string.IsNullOrEmpty( msgError ) )
                return ( successPartialViewJson( "PartialTeamsSorted", items.ToList() ) );
            else
                return errorJson( msgError );
        }

		//---------------------------------------------------------------------
		[HttpPost]
		public JsonResult PlayMatchCheckWinner( int idTeamHome, int idTeamVisitor )
		{
			if( ModelState.IsValid )
			{
				CmdPlayMatchCheckWinner cmd = new CmdPlayMatchCheckWinner( idTeamHome, idTeamVisitor );

				using( MatchDB db = new MatchDB() )
				{
					cmd.execCmd( db );
				}

				return ( Json( new { success = true, cmd.Match } ) );

			}
			return ( Json( new { success = false, error = Mensagens.ERR_NO_MATCH_RESULT } ) );
		}
		//---------------------------------------------------------------------
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using ( MatchDB db = new MatchDB() )
                {
                    db.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        //----------------------------------------------------------------------
        #region private ActionResult
        //----------------------------------------------------------------------
        private ActionResult successPartialViewJson( string viewName, object model )
        {
            string strView = RenderPartialView( viewName, model );

            JsonResult result = new JsonResult();

            result.MaxJsonLength = Int32.MaxValue;
            result.Data = new
            {
                success = true,
                view = strView
            };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;
        }

        //----------------------------------------------------------------------
        private string RenderPartialView( string viewName, object model )
        {
            if ( string.IsNullOrEmpty( viewName ) )
                viewName = this.ControllerContext.RouteData.GetRequiredString( "action" );

            this.ViewData.Model = model;
            using ( var sw = new StringWriter() )
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView( this.ControllerContext, viewName );
                var viewContext = new ViewContext( this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw );

                viewResult.View.Render( viewContext, sw );

                return ( sw.GetStringBuilder().ToString() );
            }
        }

        //----------------------------------------------------------------------
        private ActionResult errorJson( string msg )
        {
            return Json( new
            {
                success = false,
                erro = msg
            }, JsonRequestBehavior.AllowGet );
        }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

    }
}

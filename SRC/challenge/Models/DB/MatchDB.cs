using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using challenge.Models.Data;
using System.Web;

namespace challenge.Models.DB
{
    public class MatchDB : Connection
    {
        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        static public IList< Match > getAllTeams( Connection db )
        {
            return ( db.Match.ToList() );
        }

        //----------------------------------------------------------------------
        static public void saveMatch( Connection db, Match match )
		{
			db.Match.Add( match );
			db.SaveChanges();
		}

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------
    }
}
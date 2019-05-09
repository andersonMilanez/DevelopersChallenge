using challenge.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace challenge.Models.DB
{
	public class TeamsDB
	{
        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        static public IList< Team > getAllTeams( Connection db )
        {
            return ( db.Team.ToList() );
        }

        //----------------------------------------------------------------------
        static public Team getTeam( Connection db, int idTeam )
		{
			return ( db.Team.Where( t => t.Id == idTeam ).FirstOrDefault() );
		}

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------
    }
}
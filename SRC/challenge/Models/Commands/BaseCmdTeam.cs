using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using challenge.Models.Data;
using challenge.Models.DB;

namespace challenge.Models.Commands
{
    public class BaseCmdTeam : BaseCmd
    {
        //----------------------------------------------------------------------
        #region variables
        //----------------------------------------------------------------------
        public IList< Team > ArrTeams { get; private set; }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        public override void execCmd( Connection db )
        {
            ArrTeams = new List<Team>();

            ArrTeams = TeamsDB.getAllTeams( db );
        }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------
    }
}
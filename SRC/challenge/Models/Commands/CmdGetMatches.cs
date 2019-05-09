using challenge.Models.Data;
using challenge.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge.Models.Commands
{
    public class CmdGetMatches : BaseCmdTeam
    {
        public IList< Match > ArrMatches { get; private set; }

        public CmdGetMatches()
        {
        }

        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        public override void execCmd( Connection db )
        {
            base.execCmd( db );

            ArrMatches = new List< Match >();

            ArrMatches = MatchDB.getAllTeams( db );
        }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------
    }
}
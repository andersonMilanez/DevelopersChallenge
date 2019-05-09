using challenge.Models.Data;
using challenge.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge.Models.Commands
{
    public class CmdGetTeams : BaseCmdTeam
    {

        public CmdGetTeams()
        {
        }

        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        public override void execCmd( Connection db )
        {
            base.execCmd( db );
        }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------
    }
}
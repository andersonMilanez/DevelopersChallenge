using challenge.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge.Models.Commands
{
    public abstract class BaseCmd
    {
        public abstract void execCmd( Connection db );
    }
}
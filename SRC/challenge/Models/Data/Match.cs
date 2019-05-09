using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge.Models.Data
{
    public class Match
    {
        public int  Id				{ get; set; }
        public int  ScoreHome		{ get; set; }
		public int	ScoreVisitor	{ get; set; }
		public Team Home			{ get; set; }
        public Team Visitor			{ get; set; }
		public Team Winner			{ get; set; }
	}
}
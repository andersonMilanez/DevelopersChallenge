using challenge.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace challenge.Models.DB
{
	public class Connection : DbContext
	{
        //----------------------------------------------------------------------
        #region variables
        //----------------------------------------------------------------------
        public DbSet<Team>  Team    { get; set; }
        public DbSet<Match> Match   { get; set; }

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region constructor
        //----------------------------------------------------------------------
        public Connection () : base( "QuidditchConnection" )
		{
		}

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //---------------------------------------------------------------------
        #region protected functions
        //---------------------------------------------------------------------
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating( modelBuilder );
		}

		//---------------------------------------------------------------------
		#endregion
		//---------------------------------------------------------------------
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using challenge.Models.DB;
using challenge.Models.Data;

namespace challenge.Models.Commands
{
	public class CmdPlayMatchCheckWinner : BaseCmd
	{
        //----------------------------------------------------------------------
        #region variables
        //----------------------------------------------------------------------
        public Match Match	{ get; private set; }

		private int _idTeamHome;
		private int _idTeamVisitor;
		private Team home;
		private Team visitor;

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region constructor
        //----------------------------------------------------------------------
        public CmdPlayMatchCheckWinner( int idTeamHome, int idTeamVisitor )
		{
			_idTeamHome	= idTeamHome;
			_idTeamVisitor = idTeamVisitor;
			home = new Team();
			visitor = new Team();
		}

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region public functions
        //----------------------------------------------------------------------
        public override void execCmd( Connection db )
		{
			Match = new Match();

			home	= TeamsDB.getTeam( db, _idTeamHome );
			visitor	= TeamsDB.getTeam( db, _idTeamVisitor );

			Match.Home		= home;
			Match.Visitor	= visitor;

			makeMatchScore();
			checkTheWinner();

		}

        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        #region private functions
        //----------------------------------------------------------------------
        private void makeMatchScore()
		{
			var random = new Random();

			Match.ScoreHome = random.Next( 0, 150 );
			Match.ScoreVisitor = random.Next( 0, 150 );
		}

        //----------------------------------------------------------------------
        private void checkTheWinner()
		{
			while ( Match.ScoreHome == Match.ScoreVisitor )
			{
				makeMatchScore();
			}

			if( Match.ScoreHome > Match.ScoreVisitor )
				Match.Winner = Match.Home;
			else
				Match.Winner = Match.Visitor;
		}
        //----------------------------------------------------------------------
        #endregion
        //----------------------------------------------------------------------

    }
}
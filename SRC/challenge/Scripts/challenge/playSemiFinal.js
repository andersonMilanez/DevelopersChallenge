//-----------------------------------------------------------------
var showSemiFinalResult = function (eventId, match) {

	var inputIdWinnerTeamHome = $("#form-final-match").find("#input-id-team-home");
	var inputIdWinnerTeamVisitor = $("#form-final-match").find("#input-id-team-visitor");

	if (eventId == "a-match-1")
    {
    	$("#fieldset-score-home-semifinal-1").html(match.ScoreHome);
    	$("#fieldset-score-visitor-semifinal-1").html(match.ScoreVisitor);
    	$("#div-winner-semifinal-1").html(match.Winner.Name);
        inputIdWinnerTeamHome.val( match.Winner.Id );
    }
	else if (eventId == "a-match-2")
    {
    	$("#fieldset-score-home-semifinal-2").html(match.ScoreHome);
    	$("#fieldset-score-visitor-semifinal-2").html(match.ScoreVisitor);
    	$("#div-winner-semifinal-2").html(match.Winner.Name);
    	inputIdWinnerTeamVisitor.val(match.Winner.Id);
	}

	if (inputIdWinnerTeamHome.val().length != 0 && inputIdWinnerTeamVisitor.val().length != 0)
	{
		if ($("#a-final-match").hasClass("disabled"))
			$("#a-final-match").removeClass("disabled");
    }

    $( "#" + eventId ).addClass( "disabled" );

}

//-----------------------------------------------------------------
function playMatch() {
	$(document).ready(function () {
		var eventId = event.currentTarget.id;

		if (eventId == "a-match-1")
			var $form = $("#form-semifinal-match1");
		else if (eventId == "a-match-2")
			var $form = $("#form-semifinal-match2");


		ajaxPost($, $form.attr("action"), $form.serialize(), function (data) {
			if (data.success)
			{
                showSemiFinalResult( eventId, data.Match );
                return ( false );
			}
			else
				messageBoxErro($, data.error);
		})

	});
}
//-----------------------------------------------------------------
var showFinalMatchResult = function (match)
{
	$("#fieldset-score-final-home").html(match.ScoreHome);
	$("#fieldset-score-final-visitor").html(match.ScoreVisitor);
    $( "#div-champion-team" ).html( match.Winner.Name );
    $( "#a-final-match" ).addClass( "disabled" );

}

//-----------------------------------------------------------------
function playFinal() {
	$(document).ready(function () {

		var $form = $("#form-final-match");

		ajaxPost($, $form.attr("action"), $form.serialize(), function (data) {
			if (data.success) {
                showFinalMatchResult( data.Match );
                return ( false );
			}
			else
				messageBoxErro($, data.error);
		})

	});
}
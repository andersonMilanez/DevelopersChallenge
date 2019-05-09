//----------------------------------------------------------------------------
function ajaxInit($) {
	$.myAjaxActive = 0;

	$("#div-ajax-loading")
		.dialog(
		{
			title: "Aguarde...",
			autoOpen: false,
			modal: true,
			resizable: false,
			width: "100",
			heigth: "auto",
			closeOnEscape: false,
			open: function () {
				//	Esconde o botão de close
				$(this).dialog("widget").find(".ui-dialog-titlebar-close").hide();
			}
		})
		.bind(
		{
			myAjaxStart: function () {
				if ($.myAjaxActive++ === 0)
					$(this).dialog("open");
			},
			myAjaxStop: function () {
				if ($.myAjaxActive > 0 && !(--$.myAjaxActive) && $(this).dialog("isOpen"))
					$(this).dialog("close");
			}
		});
}

//----------------------------------------------------------------------------
function ajaxPost($, strURL, dataToSend, fnCallbackSuccess) {
	$("#div-ajax-loading").trigger("myAjaxStart");
	$.ajax(
	{
		type: "post",
		dataType: "json",
		url: strURL,
		cache: false,
		data: dataToSend,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		success: function (data) {
			$("#div-ajax-loading").trigger("myAjaxStop");
			if (fnCallbackSuccess) {
				fnCallbackSuccess(data);
			}
		},
		error: function (jqXHR, textStatus, errorThrown) {
			$("#div-ajax-loading").trigger("myAjaxStop");
			messageBoxErroAjax($, strURL, jqXHR, errorThrown);
		}
	});
}

//----------------------------------------------------------------------------
function ajaxGet( $, strURL, fnCallbackSuccess )
/*
*Parameters:
* [in]$ - JQuery
* [in]strURL - url called
* [in]fnCallbackSuccess - function to be executed when recieve a success response at ajax request
*/
{
    $( "#div-ajax-loading" ).trigger( "myAjaxStart" );
    $.ajax(
        {
            type: "get",
            dataType: "json",
            cache: false,
            url: strURL,
            success: function ( data )
            {
                $( "#div-ajax-loading" ).trigger( "myAjaxStop" );
                if ( fnCallbackSuccess )
                {
                    fnCallbackSuccess( data );
                }
            },
            error: function ( jqXHR, textStatus, errorThrown )
            {
                $( "#div-ajax-loading" ).trigger( "myAjaxStop" );
                messageBoxErroAjax( $, strURL, jqXHR, errorThrown );
            }
        } );
}

//----------------------------------------------------------------------------
function messageBoxErroAjax( $, strURL, jqXHR, errorThrown )
{
    var msgErro = "Não foi possível realizar esta requisição";

    $( '<div></div>' ).html( msgErro ).dialog(
        {
            title: 'Desafio de Quadribol',
            modal: true,
            resizable: false,
            buttons:
                {
                    "Fechar": function ()
                    {
                        $( this ).dialog( "close" );
                    }
                }
        } );

}

//----------------------------------------------------------------------------
function messageBoxErro( $, msgErro, fnCallback )
{
    messageBox( $, "<div class=\"ui-state-error ui-corner-all\" style=\"padding: .7em;\"><span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin-right: .3em;\"></span>" + msgErro + "</div>", fnCallback );
}

//----------------------------------------------------------------------------
function messageBox( $, msg, fnCallback )
{
    $( '<div></div>' ).html( msg ).dialog(
        {
            title: 'Desafio de Quadribol',
            modal: true,
            resizable: false,
            close: function ( event, ui )
            {
                if ( fnCallback )
                    fnCallback();
            },
            buttons:
                {
                    "OK": function ()
                    {
                        $( this ).dialog( "close" );
                    }
                }
        } );
}
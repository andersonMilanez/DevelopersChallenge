$( function ()
{
    $.extend( $.fn,
        {
            battleField: function ( opts )
            {
                var options = $.extend( true,
                    {
                        $dlg: null
                    }, opts );

                options.$pg = $( this );

                var showBattleField = function ( data )
                {
                    if ( data.success )
                    {
                        options.$pg.html( data.view );
                    }
                    else
                        messageBoxErro( $, data.erro );
                }

                //-----------------------------------------------------------------
                //	main
                //-----------------------------------------------------------------
                var url = $.ROOT + "Match/sort";
                ajaxGet( $, url, showBattleField );
            }
        } );
} );
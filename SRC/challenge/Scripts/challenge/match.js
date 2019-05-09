$( function ()
{
    $( "#btn-sortear-times" )
        .unbind( "click" )
        .click( function ( ev )
        {
            if ( ev )
                ev.preventDefault();

            $( "#battle-field" ).battleField();
            return ( false );
        } );
} );
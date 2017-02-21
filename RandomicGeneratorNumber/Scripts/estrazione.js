$(function() {

    var chat = $.connection.iscrizioneHub;

    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (nome, cognome, nomeFile) {

        var firstName = nome; 
        
        if (firstName.indexOf(' ') >= 0) {
            firstName = nome.split(' ').slice(0, -1).join(' ');
        }

        $('#firstElement').remove();
        $('.slotMachineContainer').remove();

        // visualizzazione partecipante       
        var numPartecipante = document.querySelectorAll('#partecipanti .estrazione-item').length;
        $('#partecipanti').append("<a href='#ex1-" + numPartecipante + "' rel='modal:open'><div class='col-sm-1 estrazione-item' id='" + numPartecipante + "'><div class='caption text-center'><div class='caption-content'>" + firstName + "</div></div><img src='/img/" + nomeFile + "' class='img-responsive' alt='" + nome + " " + cognome + "' width='200px'></div></a>");
        $('#partecipantiModal').append("<div class='modal' id='ex1-" + numPartecipante + "' style='display:none;'><div class='caption text-center'><div class='caption-content'>" + nome + " " + cognome + "</div></div><img src='img/" + nomeFile + "' class='img-responsive img-centered' alt=''></div>")
        if (numPartecipante > 0) {
            $("#pronti").show();
        };
        // preparazione slot machine
        $('#machine').append("<div class='slot'><table><tr><td><img src='/img/" + nomeFile + "' width='150' height='130' alt='" + nome + " " + cognome + "'></td><td>&nbsp&nbsp&nbsp&nbsp&nbsp</td><td><p>" + nome + " " + cognome + "</p></td></tr><tr><td colspan='2'>&nbsp</td></tr></table></div>");

        document.getElementById("numeroPartecipanti").innerHTML = document.querySelectorAll('#partecipanti .estrazione-item').length;

    };

    // Start the connection.
    $.connection.hub.start().done();
   
});



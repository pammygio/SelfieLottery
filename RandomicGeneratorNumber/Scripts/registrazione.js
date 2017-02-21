$(function() {

    var chat = $.connection.iscrizioneHub;

    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (nome) {       
        // comunicazione invio effettuato
        $('#success').html("<div class='alert alert-success'>");
        $('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
            .append("</button>");
        $('#success > .alert-success')
            .append("<strong>Ciao " + nome + " la tua registrazione e' stata effettuata con successo! </strong>");
        $('#success > .alert-success')
            .append('</div>');

        $('#send').remove();
    };

    // Start the connection.
    $.connection.hub.start().done(function () {

        $("#registrationForm input,#registrationForm textarea").jqBootstrapValidation({
            preventSubmit: true,
            submitError: function ($form, event, errors) {

            },
            submitSuccess: function ($form, event) {
                // blocco i click multipli
                $("#send").attr("disabled", true);
                event.preventDefault();

                // prendo i valori dalla form
                var nome = $("input#nome").val();
                var email = $("input#email").val();
                var cognome = $("input#cognome").val();
                var filename = $("input#foto").val();
               
                // preparo il nome del file, l'estensione e il nome dell'utente
                var lastIndex = filename.lastIndexOf("\\");
                if (lastIndex >= 0) {
                    filename = filename.substring(lastIndex + 1);
                }
                var firstName = nome;
                if (firstName.indexOf(' ') >= 0) {
                    firstName = nome.split(' ').slice(0, -1).join(' ');
                }

                var estensione = "";
                var estensioneIndex = filename.lastIndexOf(".");
                if (estensioneIndex >= 0) {
                    estensione = filename.substring(estensioneIndex);
                }
                
                var d = new Date().getTime();
                var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                    var r = (d + Math.random() * 16) % 16 | 0;
                    d = Math.floor(d / 16);
                    return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
                });                    

                uuid = firstName.replace(/\W/g, '') + '_' + cognome.replace(/\W/g, '')
                

                //invio l'immagine al server 
                var fileSelect = document.getElementById('foto');
                var files = fileSelect.files;
                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];

                    if (!file.type.match('image.*')) {
                        continue;
                    }

                    formData.append('photos[]', file, uuid + estensione);
                }

                var xhr = new XMLHttpRequest();
                xhr.open('POST', '/api/docfile', true);
               
                xhr.onload = function () {
                    if (xhr.status === 201) {
                        //file salvato comunico i dati tramite signalr
                        chat.server.send(nome, cognome, uuid + estensione);
                    } else {
                        //file non salvato comunico l'errore all'utente
                        $('#success').html("<div class='alert alert-danger'>");
                        $('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                            .append("</button>");
                        $('#success > .alert-danger')
                            .append("<strong>Ciao " + nome + " la tua registrazione non e' andata a buon fine. Riprova ma prima controlla che il file allegato sia un'immagine valida (.jpg). </strong>");
                        $('#success > .alert-danger')
                            .append('</div>');

                        $("#send").attr("disabled", false);
                    }
                };

                xhr.send(formData);
            },
            filter: function () {
                return $(this).is(":visible");
            },
        });
    });


    $("a[data-toggle=\"tab\"]").click(function(e) {
        e.preventDefault();
        $(this).tab("show");
    });
});


$('#nome').focus(function() {
    $('#success').html('');
});

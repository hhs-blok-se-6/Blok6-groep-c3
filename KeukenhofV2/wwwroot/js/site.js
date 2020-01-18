//LEES: Alles dat onderstaande functie staat, wordt automatisch uitgevoerd bij het opstarten van de pagina.
//Dit is de meest fijne manier om met Javascript te werken, omdat je hierdoor niet zelf in HTML nog javascript functies hebt aangeroepen
$(document).ready(function () {

});

var x = document.getElementById("search-bar"); /* the search bar */
var cover = document.getElementById("overlay"); /* the whole page */

/*  displays a search bar and darkens the rest of the site */
function on() {
    x.style.display = "flex";
    cover.style.display = "block";
}

/* hides the search bar and lightens the site when clicked elsewhere or 'Annuleer' */
function off() {
    x.style.display = "none";
    document.getElementById('search').value = "";
    cover.style.display = "none";
}

$(document).ready(function () {
    $(".accordion h1").click(function () {
        var id = this.id;
        $(".accordion-content").each(function () {
            if ($("#" + id).next()[0].id != this.id) {
                $(this).slideUp("slow");
            }
        });

        $(this).next().toggle("slow");
    });
}); 
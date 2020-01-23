//LEES: Alles dat onderstaande functie staat, wordt automatisch uitgevoerd bij het opstarten van de pagina.
//Dit is de meest fijne manier om met Javascript te werken, omdat je hierdoor niet zelf in HTML nog javascript functies hebt aangeroepen
$(document).ready(function () {
    var mq = window.matchMedia("(max-width: 812px)");
    if (mq.matches) {
         
        $(".navbar-header-items").hide();
        $(".mobile-menu-button").show();
        $(".header-p-mobile-menu").show();

        $(".mobile-menu-button").on("click", function (e) {
            $(".mobile-menu-button").hide();
            $(".header-p-mobile-menu").hide();
            $(".mobile-close-button").show();
            $(".header-p-mobile-close").show();
            $(".mobile-sub-menu").show();
           
        });

        $(".mobile-close-button").on("click", function (e) {
            $(".mobile-close-button").hide();
            $(".header-p-mobile-close").hide();
            $(".mobile-menu-button").show();
            $(".header-p-mobile-menu").show();
            $(".mobile-sub-menu").hide();
        });
    }

    $(".search-icon").on("click", function (e) {
        $(".search-dialog").show();
        $('#overlay').fadeIn(300);
        $('.expose').css('z-index', '99999');

    });

    $(".search-dialog-cancel-button").on("click", function (e) {
        $('#overlay').stop().fadeOut(300);
        $(".search-dialog").hide();
        $('.expose').css('z-index', '1');
    });
    
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

$(document).ready(function () { /* ensures elements whithin this class will be hidden */
    $('.download-hide').each(function () {
        $(this).hide();
    });
});

$(document).ready(function () {
    $(".accordion h5").click(function () {
        var id = this.id;
        $(".accordion-content").each(function () {
            if ($("#" + id).next()[0].id != this.id) {
                $(this).slideUp("slow");
            }
        });

        $(this).next().toggle("slow");
    });
}); 
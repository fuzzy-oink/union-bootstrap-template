
function SetupRsvpMessages() {
    var rsvpMessages = ["I want to be there!", "See you there!", "Count me in!", "What are we waiting for!", "Put my name on the list!"];

    var i = 0;
    var buttons = $(".btn-rsvp");

    for (i = 0; i < buttons.length; i++) {
        $(buttons[i]).html(rsvpMessages[Math.floor(Math.random() * rsvpMessages.length - 1)]);
    }
}

function changeCSS(cssFile) {
    $("#currentTheme").attr("href", cssFile);
}

(function ($) {

    $(window).on("load" , function () {
        $("#preloaderContainer").fadeOut(400);
        $("#preloader").delay(100).fadeOut(400, function() {
            $("body").removeClass("loading");
        });
    });

    $(function () {

        SetupRsvpMessages();

        $("a[href*='#']").not(".no-smooth-scroll").bind("click", function(e){
           
            var anchor = $(this);
            $("html, body").stop().animate({
                scrollTop: $(anchor.attr("href")).offset().top - $("nav").height()
            }, 1000);
            e.preventDefault();
        });

        $("body").scrollspy({
            target: ".navbar-custom",
            offset: 70
        });

        $(window).resize(function(){
            $("#DateCountdown").TimeCircles().rebuild();
        });

        $("form").submit(function(e) {
            $(".btn").prop("disabled", true);
            $("div.modal-overlay").removeClass("hidden");
        });

        $("#DateCountdown")
            .attr("data-date", "2017-06-01 16:00:00")
            .TimeCircles({
                "animation": "smooth",
                "bg_width": 0.2,
                "fg_width": 0.03,
                "circle_bg_color": "#90989F",
                "time": {
                    "Days": {
                        "text": "Days",
                        "color": "#ffffff",
                        "show": true
                    },
                    "Hours": {
                        "text": "Hours",
                        "color": "#ffffff",
                        "show": true
                    },
                    "Minutes": {
                        "text": "Minutes",
                        "color": "#ffffff",
                        "show": true
                    },

                    "Seconds": {
                        "text": "Seconds",
                        "color": "#ffffff",
                        "show": true
                    }
                }
        });

        window.setTimeout(function() {
            $("#couple").show();
            $("#wedding").show();
            $("footer").show();
        }, 1000);

        $("#redTheme").on("click", function () { changeCSS("css/red.theme.css") });
        $("#blueTheme").on("click", function () { changeCSS("css/blue.theme.css") });
    });

})(jQuery);
function getRandomIntInclusive(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

(function ($) {

    var rsvpMessages = ["Ek wil ook daar wees!", "Sien julle daar!", "Tel my in!", "Waarvoor wag ons!", "Sit my naam op daardie lys!"];

    $(window).load(function () {
        var url = document.location.href;
        url = url.split("?")[0];
        window.history.pushState("", document.title, url);

        $("#preloaderContainer").fadeOut(400);
		$("#preloader").delay(100).fadeOut(400, function() {
		    $("body").removeClass("loading");

		    if ($("#RsvpModel_Sent").val() === "True") {
		        window.setTimeout(function() {
		            $("#sentModal").modal("show");
		        }, 100);
		    }
		});
		window.LoadSlideshow();
	});

	$(document).ready(function () {

	    (function() {
	        var i = 0;
	        var buttons = $(".btn-rsvp");

	        for (i = 0; i < buttons.length; i++) {
	            $(buttons[i]).html(rsvpMessages[getRandomIntInclusive(0, rsvpMessages.length)]);
	        }
	    })();

	    $("a[href*=#]").not(".no-smooth-scroll").bind("click", function(e){
           
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

		$("#DateCountdown").TimeCircles({
		    "animation": "smooth",
		    "bg_width": 0.2,
		    "fg_width": 0.03,
		    "circle_bg_color": "#90989F",
		    "time": {
		        "Days": {
		            "text": "Dae",
		            "color": "#ffffff",
		            "show": true
		        },
		        "Hours": {
		            "text": "Ure",
		            "color": "#ffffff",
		            "show": true
		        },
		        "Minutes": {
		            "text": "Minute",
		            "color": "#ffffff",
		            "show": true
		        },

		        "Seconds": {
		            "text": "Sekondes",
		            "color": "#ffffff",
		            "show": true
		        }
		    }
		});

		window.setTimeout(function() {
		    $("#ons").show();
		    $("#troue").show();
		    $("footer").show();
		}, 1000);
	    
	});

})(jQuery);
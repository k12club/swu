(function($) {
    
    "use strict";

    /*  ==================== OWL CAROUSEL AND OTHER SLIDER SCRIPT   ==================== */
    function mainslideer_load() {
        // Owl-News-carousel
        if ($('.irs-main-slider').length) {
            $('.irs-main-slider').owlCarousel({
                autoplay: 5000,
                loop: true,
                margin: 0,
                dots: false,
                nav: false,
                autoplayHoverPause: false,
                autoplay: true,
                autoHeight: false,
                smartSpeed: 2000,
                navText: [
                  '<i class=""></i>',
                  '<i class=""></i>'
                ],
                responsive: {
                    0: {
                        items: 1,
                        center: false
                    },
                    480: {
                        items: 1,
                        center: false
                    },
                    600: {
                        items: 1,
                        center: false
                    },
                    768: {
                        items: 1
                    },
                    992: {
                        items: 1
                    },
                    1200: {
                        items: 1
                    }
                }
            })
        }
        // Owl-News-carousel 
        if ($('.irs-main-slider-style2').length) {
            $('.irs-main-slider-style2').owlCarousel({
                loop: true,
                margin: 0,
                dots: false,
                nav: true,
                autoplayHoverPause: false,
                autoplay: true,
                autoHeight: true,
                animateIn: 'fadeIn',
                smartSpeed: 500,
                navText: [
                  '<i class="">P</i>',
                  '<i class="">N</i>'
                ],
                responsive: {
                    0: {
                        items: 1,
                        center: false
                    },
                    480: {
                        items: 1,
                        center: false
                    },
                    600: {
                        items: 1,
                        center: false
                    },
                    768: {
                        items: 1
                    },
                    992: {
                        items: 1
                    },
                    1200: {
                        items: 1
                    }
                }
            })
        }
    }

/* ==========================================================================
   When document is ready, do
   ========================================================================== */
    $(document).on('ready', function () {
    });

/* ==========================================================================
   When document is Scrollig, do
   ========================================================================== */
    // window on Scroll function
    $(window).on('scroll', function () {
        
    });
    
/* ==========================================================================
   When document is loading, do
   ========================================================================== */

    $(window).on('load', function () {
    }); 


/* ==========================================================================
   When Window is resizing, do
   ========================================================================== */
    $(window).on('resize', function() {
    });

})(window.jQuery);
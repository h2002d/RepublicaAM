///// jQuery //////

$(document).ready(function() {
	
    // Scrolling to top
	// Scrolling to top
    
	var top_show = 150;
	var duration = 500;
	$(document).ready(function() {
		// Scroll
		$(window).scroll(function () {
			if ($(this).scrollTop() > top_show) {
				$('#to-top').fadeIn();
			} else {
				$('#to-top').fadeOut();
			}
		});
		// Click
		$('#to-top').click(function () {
			$('body, html').animate({scrollTop: 0}, duration);
		});
	});

    // Sidebar burger //
	// Sidebar burger //

    $( window ).resize(function() {
        if ($(window).width() > 768) {
            if ($('.menu-l-content').css('display') == 'none') {
                $('.menu-l-content').css({ display: 'block' });
            }
        }
    });
    $('.menu-l-open-btn').click(function(){
        if ($('.menu-l-content').css('display') == 'none') {
            $('.menu-l-content').slideDown();
        } else {
            $('.menu-l-content').slideUp();
        }
    });


});


 // Sidebar menu //


$(document).ready(function(){
  
    $('.sidebar-item-1').click(function(){
        if ($('.submenu-1').css('display') == 'none') {
            $('.submenu-1').slideDown();
        } else {
            $('.submenu-1').slideUp();
        }
    });

    $('.sidebar-item-2').click(function(){
        if ($('.submenu-2').css('display') == 'none') {
            $('.submenu-2').slideDown();
        } else {
            $('.submenu-2').slideUp();
        }
    });

    $('.sidebar-item-3').click(function(){
        if ($('.submenu-3').css('display') == 'none') {
            $('.submenu-3').slideDown();
        } else {
            $('.submenu-3').slideUp();
        }
    });
   
  
    $('.sidebar-item-4').click(function(){
        if ($('.submenu-4').css('display') == 'none') {
            $('.submenu-4').slideDown();
        } else {
            $('.submenu-4').slideUp();
        }
    });

    $('.sidebar-item-5').click(function(){
        if ($('.submenu-5').css('display') == 'none') {
            $('.submenu-5').slideDown();
        } else {
            $('.submenu-5').slideUp();
        }
    });

    $('.sidebar-item-6').click(function(){
        if ($('.submenu-6').css('display') == 'none') {
            $('.submenu-6').slideDown();
        } else {
            $('.submenu-6').slideUp();
        }
    });

    $('.sidebar-item-7').click(function(){
        if ($('.submenu-7').css('display') == 'none') {
            $('.submenu-7').slideDown();
        } else {
            $('.submenu-7').slideUp();
        }
    });

    $('.sidebar-item-8').click(function(){
        if ($('.submenu-8').css('display') == 'none') {
            $('.submenu-8').slideDown();
        } else {
            $('.submenu-8').slideUp();
        }
    });

    $('.sidebar-item-9').click(function(){
        if ($('.submenu-9').css('display') == 'none') {
            $('.submenu-9').slideDown();
        } else {
            $('.submenu-9').slideUp();
        }
    });

    $('.sidebar-item-10').click(function(){
        if ($('.submenu-10').css('display') == 'none') {
            $('.submenu-10').slideDown();
        } else {
            $('.submenu-10').slideUp();
        }
    });

    $('.sidebar-item-11').click(function(){
        if ($('.submenu-11').css('display') == 'none') {
            $('.submenu-11').slideDown();
        } else {
            $('.submenu-11').slideUp();
        }
    });

    $('.sidebar-item-12').click(function(){
        if ($('.submenu-12').css('display') == 'none') {
            $('.submenu-12').slideDown();
        } else {
            $('.submenu-12').slideUp();
        }
    });

    $('.searchIcon').click(function () {
        $('#searchForm').submit();
    });
});

$(document).on('click', '.product', function () {
    $('#slideShow').empty();
    var id = $(this).attr('id');
    $('#slideShow').load('/Home/ProductPartial/' + id);
    $('#myModal').css('display', 'block');
});
$(document).on('click', '.close', function () {
    $('#myModal').css('display', 'none');
});

window.onclick = function (event) {
    if (event.target == $('#myModal')) {
        $('#myModal').css('display', 'none');
    }
}

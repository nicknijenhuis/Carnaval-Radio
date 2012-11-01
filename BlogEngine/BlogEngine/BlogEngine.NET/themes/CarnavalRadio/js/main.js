jQuery(function () {           
    jQuery('ul.head-menu').superfish();
});
function OpenStreamPopup() {
    return window.open($('#CRwebroot').attr('href') + 'audioplayer.aspx', 'CarnavalRadio',
'width=800,height=500,scrollbars=yes,toolbar=yes,location=yes'); return false;
}
function onAfter() {
    $('#sponsorlink').html(this.href);
}
function clickSponsor() {
    //alert();
    return window.open('' + $('#sponsorlink').html());
}

$(document).ready(function () {
    $('.slideshow').cycle({
        fx: 'fade',
        timeout: 4000,
        random: 1,
        after: onAfter
    });
            
    $('div.text marquee').marquee('pointer').mouseover(function () {
        $(this).trigger('stop');
    }).mouseout(function () {
        $(this).trigger('start');
    });

    $('div#shadow').css('height', ($('body').height() - 185) + 'px');
});

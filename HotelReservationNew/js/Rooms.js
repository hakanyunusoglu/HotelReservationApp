
var pageNo = 1;
var isPageLoad = true;


$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        if (isPageLoad) {
            $("#load-more-article").show();

            $.ajax({
                url: '/Room/Index',
                data: { page: pageNo },
                success: function (data) {
                    $("#RoomsListing12").append(data);
                    pageNo++;
                    $("#load-more-article").hide();
                    if ($.trim(data) == '') {
                        isPageLoad = false;
                    }
                }
            });

        }
    }
});
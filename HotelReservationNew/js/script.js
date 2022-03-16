function radiocheckchange(a) {
    (function (c) {
        var b = c(a);
        b.wrap('<label class="switch-label-check" />');
        b.after('<span class="switch" />');
        b.css({
            display: "none"
        })
    })(jQuery)
}

function custom_select() {
    if ($(".htlfndr-select-custom").length > 0) {
        $(".htlfndr-select-custom").CustomSelect({
            visRows: 4,
            search: true,
            modifier: "mod"
        })
    }
    var d = $(".htlfndr-custom-select select");
    d.each(function () {
        var g = $(this);
        var f = g.attr("id"),
			e = g.children("optgroup"),
			h = "",
			j = "",
			i = "";
        if (e.length) {
            e.each(function () {
                var m = $(this);
                var l = m.attr("label");
                h += '<li class="optgroup">' + l + "</li>";
                m.children("option").each(function () {
                    var q = $(this);
                    var p = q.attr("value"),
						o = q.html(),
						n = q.attr("selected");
                    if (n === "selected") {
                        j = o;
                        h += '<li class="selected" data-value="' + p + '">' + o + "</li>"
                    } else {
                        h += '<li data-value="' + p + '">' + o + "</li>"
                    }
                })
            });
            g.children("option").each(function () {
                var o = $(this);
                var n = o.attr("value"),
					m = o.html(),
					l = o.attr("selected");
                if (l === "selected") {
                    j = m;
                    h = '<li class="selected" data-value="' + n + '">' + m + "</li>" + h
                } else {
                    h = '<li data-value="' + n + '">' + m + "</li>" + h
                }
            })
        } else {
            g.children("option").each(function () {
                var o = $(this);
                var n = o.attr("value"),
					m = o.html(),
					l = o.attr("selected");
                if (l === "selected") {
                    j = m;
                    h += '<li class="selected" data-value="' + n + '">' + m + "</li>"
                } else {
                    h += '<li data-value="' + n + '">' + m + "</li>"
                }
            })
        }
        i = '<div class="htlfndr-dropdown-container"><div class="htlfndr-dropdown-select fa-angle-down"><span class="' + j + '">' + j + '</span></div><ul class="htlfndr-dropdown-select-ul" data-role="' + f + '">' + h + "</ul></div> <!-- .htlfndr-dropdown-container -->";
        $(i).insertAfter(g)
    });
    var b = $(".htlfndr-dropdown-select"),
		c = $(".htlfndr-dropdown-select-ul"),
		a = $(".htlfndr-dropdown-select-ul li");
    b.on("click", function () {
        $(this).parent(".htlfndr-dropdown-container").toggleClass("active")
    });
    c.on("mouseleave", function () {
        $(this).parent(".htlfndr-dropdown-container").removeClass("active")
    });
    a.on("click", function () {
        var h = $(this);
        if (!h.hasClass("optgroup")) {
            var g = h.parent("ul"),
				j = g.siblings(".htlfndr-dropdown-select"),
				e = h.html(),
				f = h.attr("data-value"),
				i = "#" + g.attr("data-role");
            g.parent(".htlfndr-dropdown-container").toggleClass("active");
            h.siblings("li").removeClass("selected");
            h.addClass("selected");
            $(i).val(f);
            j.children("span").removeClass();
            j.children("span").addClass(e);
            j.children("span").html(e)
        }
    })
}

function user_tabs() {
    $(".htlfndr-user-tabs").tabs().removeClass("ui-widget-content").addClass("ui-tabs-vertical ui-helper-clearfix");
    $(".htlfndr-user-tabs ul").removeClass("ui-widget-header");
    $(".htlfndr-user-tabs li").removeClass("ui-corner-top");
    $(".htlfndr-user-tabs li").click(function () {
        $(".htlfndr-button-to-top").hide();
        if ($("#htlfndr-user-tab-4").css("display") == "block" || $("#htlfndr-user-tab-5").css("display") == "block") {
            $(".htlfndr-button-to-top").show()
        }
    });
    if ($("#htlfndr-hotel-description-tabs").length) {
        var b = $("#htlfndr-hotel-description-tabs").find("ul > li");
        var a = 0;
        b.each(function () {
            if ($(this).hasClass("active")) {
                a = parseInt($(this).attr("data-number"), 10)
            }
        });
        $("#htlfndr-hotel-description-tabs").responsiveTabs({
            startCollapsed: "accordion",
            animation: "slide",
            active: a
        })
    }
}

function click_check() {
    $(".navbar-toggle").click(function () {
        $(".dropdown-toggle.active-on-device").removeClass("active-on-device")
    });
    $("#htlfndr-sing-up-form a").click(function () {
        $("#htlfndr-sing-up").trigger("click")
    });
    $("#htlfndr-recovery-form a").click(function () {
        $("#htlfndr-recovery").trigger("click")
    });
    $("#htlfndr-sing-in-form a").click(function () {
        $("#htlfndr-sing-in").trigger("click")
    });
    $(".btn-primary").click(function () {
        k = 0;
        $(this).parents("form").find("input:required,textarea:required").each(function () {
            $(this).removeClass("incorrect");
            if ($(this).val() == "") {
                $(this).addClass("incorrect");
                k = 1
            }
        });
        if (k == 0) {
            return true
        }
        return false
    });
    if ($(".htlfndr-credit-card .glyphicon-remove").length) {
        $(".glyphicon-remove").click(function () {
            $(this).parents(".htlfndr-credit-card").hide()
        })
    }
    if ($(".htlfndr-hotel-post .glyphicon-remove").length) {
        $(".glyphicon-remove").click(function () {
            $(this).parents(".htlfndr-hotel-post").hide()
        })
    }
    if ($(".htlfndr-credit-card .glyphicon-pencil").length) {
        $(".glyphicon-pencil").click(function () {
            $(this).parents(".htlfndr-hotel-post").hide()
        })
    }
    $(".htlfndr-button-to-top").on("click", function () {
        var d = $(".htlfndr-wrapper");
        $("html, body").animate({
            scrollTop: d.offset().top
        }, 800, "linear")
    });
    $(".htlfndr-menu_elements").on("click", "a", function (d) {
        d.preventDefault();
        var f = $(this).attr("href"),
			e = $(f).offset().top;
        $("body,html").animate({
            scrollTop: e
        }, 1500)
    });
    if ($(".htlfndr-search-result-sorting").length) {
        var b, a, c;
        b = $("#htlfndr-grid");
        a = $("#htlfndr-row");
        c = $(".htlfndr-hotel-post-wrapper");
        b.on("click", function () {
            if (a.hasClass("htlfndr-active")) {
                htlfndr_preloader();
                a.removeClass("htlfndr-active")
            }
            $(this).addClass("htlfndr-active");
            c.removeClass("col-md-12");
            c.addClass("col-md-4");
            c.closest(".htlfndr-search-result").removeClass("htlfndr-row-view");
            c.closest(".htlfndr-search-result").addClass("htlfndr-grid-view");
            htlfndr_save_view("col-md-4")
        });
        a.on("click", function () {
            if (b.hasClass("htlfndr-active")) {
                htlfndr_preloader();
                b.removeClass("htlfndr-active")
            }
            $(this).addClass("htlfndr-active");
            c.removeClass("col-md-4");
            c.addClass("col-md-12");
            c.closest(".htlfndr-search-result").removeClass("htlfndr-grid-view");
            c.closest(".htlfndr-search-result").addClass("htlfndr-row-view");
            htlfndr_save_view("col-md-12")
        })
    }
    $("#htlfndr-sort-by-price").on("click", function (d) {
        d.preventDefault();
        htlfndr_select_sorting_parameters($(this));
        htlfndr_preloader();
        tinysort(".htlfndr-hotel-post-wrapper", {
            selector: ".htlfndr-hotel-price>.cost"
        })
    });
    $("#htlfndr-sort-by-rating").on("click", function (d) {
        d.preventDefault();
        htlfndr_select_sorting_parameters($(this));
        htlfndr_preloader();
        tinysort(".htlfndr-hotel-post-wrapper", {
            selector: ".htlfndr-rating-stars",
            data: "rating",
            order: "desc"
        })
    });
    $("#htlfndr-sort-by-popular").on("click", function (d) {
        d.preventDefault();
        htlfndr_select_sorting_parameters($(this));
        htlfndr_preloader();
        tinysort(".htlfndr-hotel-post-wrapper", {
            selector: ".htlfndr-hotel-reviews>span",
            order: "desc"
        })
    });
    $(".htlfndr-show-number-hotels > ul > li > a").on("click", function (g) {
        g.preventDefault();
        htlfndr_preloader();
        var h, f, d, e;
        h = $(".htlfndr-show-number-hotels>.dropdown-toggle>span");
        d = $(this).text().toString();
        e = parseInt($(this).attr("data-number"), 10);
        if (($("span").is(h)) || ($(h).text().toString() != $(d))) {
            f = '<span style="display: none;">' + d + "</span>"
        }
        if ($(h).text().toString() != $(d)) {
            $(h).remove()
        }
        $(f).appendTo(".htlfndr-show-number-hotels>.dropdown-toggle").fadeIn("slow")
    });
    $(".htlfndr-pagination .pagination > li > a").on("focus", function () {
        $(this).blur()
    });
    $(".htlfndr-pagination .pagination > li > a").on("click", function (f) {
        f.preventDefault();
        htlfndr_preloader();
        var g = $(".htlfndr-pagination .pagination > li");
        var d = $(".htlfndr-pagination .pagination > .current");
        var e = $(this).parent();
        if ($(e).hasClass("htlfndr-left") || $(e).hasClass("htlfndr-right")) {
            if ($(e).hasClass("htlfndr-left")) {
                if (!$(e).next().hasClass("current")) {
                    $(d).prev().addClass("current");
                    $(d).removeClass("current")
                }
            } else {
                if (!$(e).prev().hasClass("current")) {
                    $(d).next().addClass("current");
                    $(d).removeClass("current")
                }
            }
        } else {
            $(g).removeClass("current");
            $(e).addClass("current")
        }
        $(this).unbind("hover")
    })
}

function browser_width() {
    var a = $(window).width();
    if (a < 1280) {
        $(".dropdown-submenu>a").click(function () {
            if ($(this).parent().hasClass("open")) {
                return true
            } else {
                $(this).parent().addClass("open");
                return false
            }
        });
        $(".dropdown").on("click", (function () {
            $(this).find(".open").removeClass("open")
        }));
        $(".pagination .htlfndr-right,.pagination .htlfndr-left").click(function () {
            $(this).find("a").css({
                "background-color": "#08c1da",
                color: "#fff"
            }).delay(400);
            $(this).find("a").animate({
                "background-color": "transparent",
                color: "#000000"
            }, 200)
        })
    }
    if (a < 1280 && a > 767) {
        $(".dropdown-submenu>a").click(function () {
            $(".open").removeClass("open")
        });
        $(".dropdown").mouseleave(function () {
            $(".open").removeClass("open")
        })
    }
    if (a < 900) {
        $(".dropdown-submenu a").hover(function () {
            $("#htlfndr-main-nav .dropdown-submenu .dropdown-menu").each(function () {
                $(this).css("left", "-" + $(this).width() + "px")
            })
        })
    }
    if (a > 991) {
        parent_block = $(".htlfndr-hotel-post-wrapper");
        htlfndr_apply_view_preferences(parent_block, "col-md-4 col-md-12")
    } else {
        localStorage.clear()
    }
    if ((a < 768) && $(".htlfndr-search-result").hasClass("htlfndr-row-view")) {
        var d = $(".htlfndr-search-result");
        d.removeClass("htlfndr-row-view");
        d.addClass("htlfndr-row-view")
    }
    if (a < 992) {
        var b = $(".htlfndr-add-to-wishlist").detach();
        var h = $(".htlfndr-hotel-visit-card").detach();
        h.insertBefore("#htlfndr-main-content");
        h.wrap('<aside class="htlfndr-moved-sidebar-part" />');
        b.prependTo(h)
    }
    if ($(".htlfndr-payment-page").length) {
        $("body").find(".htlfndr-selectmenu > ul").css("max-height", "150px");
        if (a < 992) {
            var c = $(".htlfndr-booking-details").detach();
            c.insertBefore("#htlfndr-main-content");
            c.wrap('<aside class="htlfndr-moved-sidebar-part" />')
        }
    }
    if ($(".htlfndr-steps").length) {
        var f = $(".htlfndr-progress li").length;
        if (f > 0) {
            var e = 100 / f;
            $(".htlfndr-progress li").css("width", e + "%")
        }
        var g = $(".htlfndr-steps").find(".htlfndr-step-description");
        if (a < 768) {
            g.css("display", "none")
        } else {
            g.css("display", "inline-block")
        }
    }
}

function calendar() {
    $("#htlfndr-date-out,#htlfndr-date-in,#htlfndr-date-in-cal").datepicker({
        showAnim: "drop",
        dateFormat: "dd MM yy",
        showOtherMonths: true,
        selectOtherMonths: true,
        minDate: "-0D",
        beforeShow: function () {
            var b = $("#htlfndr-date-in").datepicker("getDate");
            if (b) {
                return {
                    minDate: b
                }
            }
        }
    });
    $("#htlfndr-date-in, #htlfndr-date-out,#htlfndr-date-in-cal").on("focus", function () {
        $(this).blur()
    });
    if ($("body").find(".ui-datepicker").length) {
        var a = $("body").find(".ui-datepicker");
        a.addClass("htlfndr-datepicker")
    }
    $(".htlfndr-clear-datepicker").on("click", function () {
        var b = $(this).parent().find("input");
        $.datepicker._clearDate(b)
    })
}

function htlfndr_save_view(a) {
    localStorage.setItem("view_class", a)
}

function htlfndr_apply_view_preferences(a, c) {
    if (null !== localStorage.getItem("view_class")) {
        var b = localStorage.getItem("view_class");
        a.removeClass(c);
        a.addClass(b);
        if ("col-md-4" == b) {
            a.closest(".htlfndr-search-result").removeClass("htlfndr-row-view");
            a.closest(".htlfndr-search-result").addClass("htlfndr-grid-view")
        } else {
            if ("col-md-12" == b) {
                $("#htlfndr-grid").removeClass("htlfndr-active");
                $("#htlfndr-row").addClass("htlfndr-active");
                a.closest(".htlfndr-search-result").removeClass("htlfndr-grid-view");
                a.closest(".htlfndr-search-result").addClass("htlfndr-row-view")
            }
        }
    }
}

function slider() {
    if ($(".htlfndr-slider-section").length) {
        $(".owl-carousel").owlCarousel({
            singleItem: true,
            autoPlay: 3000,
            pagination: false,
            paginationSpeed: 1000
        })
    }
    if ($("#htlfndr-room-slider").length) {
        $(".owl-carousel").owlCarousel({
            singleItem: true,
            autoPlay: 60000,
            pagination: true,
            paginationSpeed: 1000
        })
    }
    if ($(".htlfndr-post-thumbnail").hasClass("owl-carousel")) {
        var b = function () {
            var d = $(".owl-carousel").find(".owl-buttons").detach();
            d.insertBefore(".owl-controls")
        };
        $(".owl-carousel").owlCarousel({
            singleItem: true,
            autoPlay: 60000,
            pagination: true,
            paginationSpeed: 1000,
            navigation: true,
            navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            afterInit: b
        })
    }
    var c = $("#htlfndr-price-slider");
    c.slider({
        range: true,
        min: 0,
        max: 5000,
        values: [100, 1000],
        slide: function (e, f) {
            $("#htlfndr-price-show").val("$" + f.values[0] + " - $" + f.values[1]);
            $(".price_min").text("$" + f.values[0]);
            $(".price_max").text("$" + f.values[1]);
            var d = 0;
            $(".ui-slider-handle").each(function () {
                if (d == 0) {
                    $(".price_min").css({
                        left: $(this).position().left - 20
                    })
                } else {
                    $(".price_max").css({
                        left: $(this).position().left - 20
                    })
                }
                d++
            })
        },
        change: function (e, f) {
            $("#htlfndr-price-start").val(f.values[0]);
            $("#htlfndr-price-stop").val(f.values[1]);
            $(".price_min").text("$" + f.values[0]);
            $(".price_max").text("$" + f.values[1]);
            var d = 0;
            $(".ui-slider-handle").each(function () {
                if (d == 0) {
                    $(".price_min").css({
                        left: $(this).position().left - 20
                    })
                } else {
                    $(".price_max").css({
                        left: $(this).position().left - 20
                    })
                }
                d++
            })
        }
    });
    $("#htlfndr-price-show").val("$" + c.slider("values", 0) + " - $" + c.slider("values", 1));
    $(".price_min").text("$" + c.slider("values", 0));
    $(".price_max").text("$" + c.slider("values", 1));
    var a = 0;
    $(".ui-slider-handle").each(function () {
        if (a == 0) {
            $(".price_min").css({
                left: $(this).position().left - 20
            })
        } else {
            $(".price_max").css({
                left: $(this).position().left - 20
            })
        }
        a++
    })
}

function edit() {
    var o;
    if ($("ul li").hasClass("dropdown")) {
        o = $(".dropdown");
        var n = o.children("a");
        o.each(function () {
            n.attr({
                "class": "dropdown-toggle",
                "data-toggle": "dropdown",
                role: "button",
                "aria-haspopup": "true",
                "aria-expanded": "false"
            })
        });
        o.on("click", function () {
            $(this).children("a").toggleClass("active-on-device")
        })
    }
    $(".htlfndr-dropdown").selectmenu();
    if ($("body").find(".ui-selectmenu-menu").length) {
        var e = $("body").find(".ui-selectmenu-menu");
        e.addClass("htlfndr-selectmenu");
        if ($("body").find(".htlfndr-payment-page").length) {
            e.addClass("htlfndr-selectmenu-payment-page")
        }
    }
    radiocheckchange(":checkbox");
    radiocheckchange(".htlfndr-classic-radio :radio");
    radiocheckchange(".htlfndr-check-radios :radio");
    $(".htlfndr-check-radios input[type='checkbox']:checked,input[type='radio']:checked").each(function () {
        $(this).parent().parent().removeClass("hover").children("p label").not(".switch-label-check").addClass("mainColor2")
    });
    $("input[type='checkbox'],input[type='radio']").change(function () {
        $(this).parent().parent().removeClass("hover").children("label").not(".switch-label-check").removeClass("mainColor2");
        $("input[type='radio']").parent().parent().removeClass("hover").children("label").not(".switch-label-check").removeClass("mainColor2");
        $(".htlfndr-check-radios input[type='checkbox']:checked,.htlfndr-classic-radio input[type='radio']:checked").parent().parent().removeClass("hover").children("p label").not(".switch-label-check").addClass("mainColor2")
    });
    $(".htlfndr-check-radios label").each(function () {
        $(this).hover(function () {
            $(this).parent().addClass("hover")
        }, function () {
            $(this).parent().removeClass("hover")
        })
    });
    var h = '<span class="htlfndr-special">special offer</span>';
    if ($("#htlfndr-user-tab-4 .htlfndr-hotel-post").hasClass("special-offer")) {
        o = $(".htlfndr-hotel-post.special-offer");
        o.prepend(h)
    } else {
        if ($(".htlfndr-hotel-post").hasClass("special-offer")) {
            o = $(".htlfndr-hotel-post.special-offer");
            o.find(".htlfndr-hotel-price").each(function () {
                $(this).prepend(h)
            })
        } else {
            if ($(".htlfndr-hotel-visit-card").hasClass("special-offer")) {
                o = $(".htlfndr-hotel-visit-card.special-offer");
                o.find(".htlfndr-hotel-price").prepend(h)
            }
        }
    }
    if ($(".htlfndr-modify-search-aside.widget").length) {
        var c, p, u, d;
        c = $(".htlfndr-modify-search-aside.widget");
        c.find(".htlfndr-dropdown").each(function () {
            p = $(this).attr("id");
            u = $("body").find(".ui-selectmenu-menu > ul");
            d = u.attr("id");
            if (d == (p + "-menu")) {
                u.addClass("htlfndr-small-select-menu")
            }
        })
    }
    if ($(".htlfndr-user-rating").length) {
        $(".htlfndr-user-rating").starrr({
            emptyStarClass: "fa fa-star htlfndr-empty-star",
            change: function (w, v) {
                $("#htlfndr-rating").val(v)
            }
        })
    }
    if ($(".switch-label-check").length) {
        var a, r, b;
        a = $(".switch-label-check").find('input[type="checkbox"],input[type="radio"]');
        a.each(function () {
            if ($(this).prop("disabled")) {
                r = $(this).attr("id")
            }
            b = $(this).parent().next();
            if (r == b.attr("for")) {
                b.addClass("label-of-disabled-check")
            } else {
                b.removeClass("label-of-disabled-check")
            }
        })
    }
    $('[data-toggle="tooltip"]').tooltip();
    $("#htlfndr-gallery-and-map-tabs").tabs();
    if ($(".htlfndr-hotel-gallery").length) {
        var l = $("#htlfndr-gallery-synced-1");
        var j = $("#htlfndr-gallery-synced-2");
        l.owlCarousel({
            singleItem: true,
            autoPlay: 3000,
            slideSpeed: 1000,
            stopOnHover: true,
            navigation: true,
            navigationText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            pagination: false,
            afterAction: htlfndr_synced_slider_position,
            responsiveRefreshRate: 200
        });
        j.owlCarousel({
            items: 5,
            itemsDesktop: [1199, 5],
            itemsDesktopSmall: [991, 5],
            itemsTablet: [768, 3],
            itemsMobile: [499, 2],
            pagination: false,
            responsiveRefreshRate: 100,
            afterInit: function (v) {
                v.find(".owl-item").eq(0).addClass("synced")
            }
        });
        j.on("click", ".owl-item", function (w) {
            w.preventDefault();
            var v = $(this).data("owlItem");
            l.trigger("owl.goTo", v)
        })
    }
    make_hover($(".htlfndr-select-hotel-button, .htlfndr-read-more-button, .htlfndr-follow-button"));
    var f = function () {
        return ("value" in document.createElement("meter"))
    };
    if (f() === false) {
        var i, t, s, g;
        i = $(".htlfndr-meter");
        i.each(function () {
            $(this).css("border", "none");
            t = $(this).children();
            s = $(this).children().children();
            g = t.attr("data-value");
            s.css("width", (g * 100) + "%")
        })
    }
    $.fn.btn = $.fn.button.noConflict();
    $(".htlfndr-radio-set").buttonset();
    $("#htlfndr-radio-card").buttonset();
    var q = function (v) {
        if ($(v).length) {
            $(v).find(".htlfndr-accordion-title").click(function () {
                $(this).toggleClass("active");
                $(v).find(".htlfndr-accordion-inner").slideToggle("fast")
            })
        }
    };
    q(".htlfndr-payment-page #htlfndr-accordion-1");
    q(".htlfndr-payment-page #htlfndr-accordion-2");
    q(".htlfndr-payment-page #htlfndr-accordion-3");
    q(".htlfndr-payment-page #htlfndr-accordion-4");
    if ($(".htlfndr-input-error").length) {
        var m = '<p class="htlfndr-error-text">Please enter a first and last name using letters only.</p>';
        $(".htlfndr-input-error").after(m)
    }
    if ($("body").find(".htlfndr-count").length) {
        $(".htlfndr-count").each(function () {
            var v = $(this);
            $({
                Counter: 0
            }).animate({
                Counter: v.text()
            }, {
                duration: 3000,
                easing: "swing",
                step: function () {
                    v.text(Math.ceil(this.Counter))
                }
            })
        })
    }
}

function htlfndr_select_sorting_parameters(b) {
    var d, c, a;
    d = b.text();
    c = $(".htlfndr-show-sort");
    if (($("span").is(c)) || ($(c).text().toString() != $(d).toString())) {
        a = '<span class="htlfndr-show-sort">' + d + "</span>"
    }
    if ($(c).text().toString() != $(d).toString()) {
        $(c).remove()
    }
    if (!$(".htlfndr-sort ").hasClass("sorted")) {
        $(".htlfndr-sort ").addClass("sorted")
    }
    $(a).insertAfter(".htlfndr-sort>.dropdown-toggle").fadeIn("slow")
}

function htlfndr_preloader() {
    $(".htlfndr-loader-overlay").fadeIn(100);
    setTimeout(function () {
        $(".htlfndr-loader-overlay").css("display", "none")
    }, 400)
}

function htlfndr_synced_slider_position(a) {
    var b = this.currentItem;
    $("#htlfndr-gallery-synced-2").find(".owl-item").removeClass("synced").eq(b).addClass("synced");
    if (undefined !== $("#htlfndr-gallery-synced-2").data("owlCarousel")) {
        htlfndr_synced_center(b)
    }
}

function htlfndr_synced_center(c) {
    var e = sync2.data("owlCarousel").owl.visibleItems;
    var a = c;
    var d = false;
    for (var b in e) {
        if (a === e[b]) {
            d = true
        }
    }
    if (false === d) {
        if (a > e[e.length - 1]) {
            sync2.trigger("owl.goTo", a - e.length + 2)
        } else {
            if (-1 === a - 1) {
                a = 0
            }
            sync2.trigger("owl.goTo", a)
        }
    } else {
        if (a === e[e.length - 1]) {
            sync2.trigger("owl.goTo", e[1])
        } else {
            if (a === e[0]) {
                sync2.trigger("owl.goTo", a - 1)
            }
        }
    }
}

function make_hover(a) {
    a.on("touchend", function (d) {
        d.preventDefault();
        var b = $(this);
        b.addClass("hovered");
        var c = b.attr("href");
        setTimeout(function () {
            window.location = c
        }, 500)
    })
} (function (a) {
    var b = document.documentElement;
    b.setAttribute("data-useragent", navigator.userAgent);
    a(document).ready(function () {
        user_tabs();
        click_check();
        custom_select();
        browser_width();
        edit();
        calendar();
        slider()
    })
})(jQuery);
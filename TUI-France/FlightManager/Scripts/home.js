(function () {
    "use strict";

    $('#form-submit .date').datetimepicker();

    // scroll to top action
    $('.scroll-top').on('click', function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 'slow');
    });


    //get the flight
    $(".flight-edit-btn").on('click', function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        get(window.EditFlightUrl, '#EditFlight .content', id, function () {
            $('#EditFlight').addClass('overlay_show');
            $('#edit-form-submit .date').datetimepicker();
        })

        return false;
    });

    //send the edit form
    $(document).on('click', '#edit-form-submit-btn', function (event) {
        event.preventDefault();

        post(window.EditFlightUrl, '#edit-form-submit', function () {
            window.location.reload();
        });

        return false;
    });

    //create the flight
    $("#form-submit-btn").on('click', function (event) {
        event.preventDefault();

        post(window.CreateFlightUrl, '#form-submit');

        return false;
    });

    function post(url, form_selector, callback) {
        $.ajax({
            url: url,
            type: "POST",
            dataType: "html",
            data: $('{0}'.format(form_selector)).serializeJSON(),
            success: function (result) {

                if (typeof result === "undefined" || result === null) {
                    $('{0}'.format(form_selector)).find(".error").text('Unknown Error');
                }

                try {
                    var data = JSON.parse(result);

                    if (data.error === true) {
                        $('{0}'.format(form_selector)).find(".error").text(data.message);
                    }

                }
                catch (e)
                {
                    $('{0}'.format(form_selector)).html(result);

                    if (callback && typeof (callback) == "function") {
                        callback();
                    }
                }
            },
            error: function (result) {
                alert('Ouups ! Unknown Error');
            }
        });
    }

    function get(url, form_selector, id, callback) {
        $.ajax({
            url: '{0}?id={1}'.format(url, id),
            type: "GET",
            success: function (result) {

                if (typeof result === "undefined" || result === null) {
                    alert('Unknown Error');
                }
                else if (result.error === true) {
                    alert(result.message);
                }
                else {
                    $('{0}'.format(form_selector)).html(result);
                    if (callback && typeof (callback) == "function") {
                        callback();
                    }
                }

            },
            error: function (result) {
                alert('Ouups ! Unknown Error');
            }
        });
    }

    String.prototype.format = function () {
        var args = [].slice.call(arguments);
        return this.replace(/(\{\d+\})/g, function (a) {
            return args[+(a.substr(1, a.length - 2)) || 0];
        });
    };

})();
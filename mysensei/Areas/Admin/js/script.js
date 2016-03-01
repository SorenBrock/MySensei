(function () {
    "use strict";

    function modal() {

        var init = function () {

            $(".messageList").on("click", "tr", function (e) {
                $(".chat").hide();
               $(".messageItem").removeClass("messageActive");
                $(this).addClass("messageActive");

                $("#" + $(this).attr("data-modal")).show();
            });

            $(".profileTab").on("click", function (e) {
                $(".tab").hide();
                $(".profileTab").removeClass("tabActive");
                $(this).addClass("tabActive");
                $("#" + $(this).attr("data-modal")).show();
            });
        }

        return {
            init: init
        };
    }

    modal = modal();
    modal.init();

})();
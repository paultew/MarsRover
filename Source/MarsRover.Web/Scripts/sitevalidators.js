/// <reference path="jquery-1.6.2.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
(function ($) {
    if ($.validator && $.validator.unobtrusive) {

        $.validator.addMethod('listlength', function (value, element, params) {
            /*var inAppPurchase = $('#InAppPurchase').is(':checked');

            if (inAppPurchase) {
                return true;
            }

            return false;*/

            var isChecked = $(param).is(':checked');

            if (isChecked) {
                return false;
            }

            return true;
        }, '');

        $.validator.unobtrusive.adapters.add('listlength', ['param'], function (options) {
            options.rules["listlength"] = '#' + options.params.param;
            options.messages['listlength'] = options.message;
        });

    }
})(jQuery);
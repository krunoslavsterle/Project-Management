var Message = {

    successDefault: function (message) {
        Message.success('OK', message);
    },

    warningDefault: function (message) {
        Message.warning('WARNING', message);
    },

    errorDefault: function (message) {
        Message.error('ERROR', message);
    },

    infoDefault: function (message) {
        Message.info('INFO', message);
    },

    success: function (title, message) {
        iziToast.success({
            title: title,
            message: message
        })
    },

    warning: function (title, message) {
        iziToast.warning({
            title: title,
            message: message
        })
    },

    error: function (title, message) {
        iziToast.error({
            title: title,
            message: message
        })
    },

    info: function (title, message) {
        iziToast.info({
            title: title,
            message: message,
        });
    }
};

var Ajax = {

    onSuccess: function (data, elId, invalidateInputs, callbackFunction) {

        if (data) {
            if (data.success === true) {

                Message.successDefault(data.responseText);

                if (invalidateInputs) {
                    $('input[type=text]').val('');
                    $('textarea').val('');
                }

                $("[id$='-modal']").modal('hide');

                // Check if returned html variable contains value.
                if (data.html && elId) {
                    $('#' + elId).html(data.html);

                    if (callbackFunction)
                        callbackFunction();
                }

            } else {
                Message.errorDefault(data.responseText);
            }
        } else {
            console.log('There is no data returned form the server.');
            Message.errorDefault('Something went wrong, please contact the administrator');
        }
    },

    onError: function (ajaxContext) {

        Message.errorDefault(ajaxContext.statusText);
    }
};

var Spinner = {

    show: function () {
        $('#loader').show();
    },

    hide: function () {
        $('#loader').hide();
    }
}
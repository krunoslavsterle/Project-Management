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
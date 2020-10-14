var debug = (o) => { console.dir(o) };

var global = global || {};

global.get = function (url) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: url
        }).done((status) => {
            resolve(status);
        }).fail((jqXHR) => {
            var response = jqXHR.responseText;
            if (global.isJsonString(response)) {
                reject(JSON.parse(response));
            } else {
                reject(jqXHR.status + " " + jqXHR.statusText);
            }
        });
    });
}

global.submit = function (url, data, token) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: url,
            type: "POST",
            headers: { "RequestVerificationToken": token },
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json"
        }).done(function (status) {
            resolve(status);
        }).fail(function (jqXHR) {
            reject(jqXHR.responseText);
        });
    });
};


global.gettoken = function () {
    return $("input[name='__RequestVerificationToken']").val();
};

global.guid = function () {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

global.isJsonString = (str) => {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}

global.date = function () {
    var currentdate = new Date(),
        day = currentdate.getDate().toString(),
        dayf = (day.length === 1) ? '0' + day : day,
        month = (currentdate.getMonth() + 1).toString(),
        monthf = (month.length === 1) ? '0' + month : month,
        yearf = currentdate.getFullYear();
    return yearf + "-" + monthf + "-" + dayf;
}

global.alert = function (message) {
    return new Promise((resolve, reject) => {
        bootbox.alert({
            message: message,
            size: 'small',
            callback: () => {
                resolve();
            }
        })
    });
}

global.confirm = function (message) {
    return new Promise((resolve, reject) => {
        bootbox.confirm({
            title: cfg.text.askConfirmTitle,
            message: message,
            size: 'small',
            buttons: {
                confirm: {
                    label: cfg.bootbox.btnYes,
                    className: 'btn-sm btn-success'
                },
                cancel: {
                    label: cfg.bootbox.btnNo,
                    className: 'btn-sm btn-default'
                }
            },
            callback: (result) => {
                resolve(result);
            }
        });
    });
}

global.prompt = function (message) {
    return new Promise((resolve, reject) => {
        bootbox.prompt(message, (result) => {
            resolve(result);
        });
    });
}

global.toastwarning = function (message) {
    toastr.warning(message);
}

global.toastsuccess = function (message) {
    toastr.success(message);
}
global.toasterror = function (message) {
    toastr.error(message);
}

global.toastinfo = function (message) {
    toastr.info(message);
}
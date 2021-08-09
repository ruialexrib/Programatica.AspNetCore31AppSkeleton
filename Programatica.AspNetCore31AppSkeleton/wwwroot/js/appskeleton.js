var cfg = cfg || {};

cfg.modal = cfg.modal || {};

cfg.bootbox = cfg.bootbox || {};
cfg.bootbox.btnYes = "Yes";
cfg.bootbox.btnNo = "No";

cfg.text = cfg.text || {};
cfg.text.askConfirmTitle = '<i class="fas fa-exclamation-circle text-primary"></i> Please confirm';
cfg.text.askConfirmDelete = "Do you want to delete this record?";

////////////////////////////////////
// toast lib
////////////////////////////////////

toastr.options.closeButton = true;
toastr.options.progressBar = true;
toastr.options.newestOnTop = true;
toastr.options.positionClass = "toast-bottom-right";
toastr.options.showMethod = "fadeIn";
toastr.options.hideMethod = "fadeOut";

paceOptions = {
    // Disable the 'elements' source
    elements: false,

    // Only show the progress on regular and ajax-y page navigation,
    // not every request
    restartOnRequestAfter: false
}

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
            console.log("ok");
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

global.nanoid = () => Math.random().toString(36).slice(-6);

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
                    className: 'btn-primary'
                },
                cancel: {
                    label: cfg.bootbox.btnNo,
                    className: 'btn-secondary'
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

var modal = modal || {};

const modalsizes = {
    SMALL: 'modal-sm',
    NORMAL: '',
    LARGE: 'modal-lg',
    XLARGE: 'modal-xl'
}

modal.show = function (url, size = modalsizes.NORMAL) {
    return new Promise((resolve, reject) => {

        var containerguid = global.nanoid();
        var dialoguid = global.nanoid();
        var contentguid = global.nanoid();

        modal.create(containerguid, dialoguid, contentguid, size);

        var container = $("#" + containerguid);
        var content = $("#" + contentguid);
        var dialog = $("#" + dialoguid);

        $(container).attr('data-modal-url', url);
        $(container).attr('data-modal-size', size != "" ? size : 'modal-nm');

        global.get(url)
            .then((html) => {
                container.modal({
                    backdrop: 'static',
                    keyboard: false
                });
                content.html(html);
                dialog.draggable({
                    handle: ".modal-header"
                })
                resolve(html);
            })
            .catch((error) => {
                reject(error);
            });
    });
};

modal.close = function (e) {

    var t = e.target;
    var container = $(t).closest(".modal");
    var content = container.find(".modal-content");

    content.empty();
    container.modal('hide');

    setTimeout(function () {
        modal.destroy(container);
    }, 500)
};

modal.create = function (containerguid, dialogguid, contentguid, size) {
    var modalList = $("#modalList");
    modalList.append("<div id='" + containerguid + "' class='modal fade' role='dialog' data-backdrop='static'><div id='" + dialogguid + "'class='modal-dialog " + size + "'><div id='" + contentguid + "' class='modal-content'></div></div></div>");
}

modal.destroy = function (container) {
    $(container).remove();
}
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
    modalList.append("<div id='" + containerguid + "' class='modal fade' role='dialog' data-backdrop='static'><div id='" + dialogguid + "'class='modal-dialog modal-dialog-centered " + size + "'><div id='" + contentguid + "' class='modal-content'></div></div></div>");
}

modal.destroy = function (container) {
    $(container).remove();
}
var cfg = cfg || {};

cfg.modal = cfg.modal || {};
cfg.modal.container1 = "#modal-container1";
cfg.modal.dialog1 = "#modal-dialog1";
cfg.modal.content1 = "#modal-content1";

cfg.modal.container2 = "#modal-container2";
cfg.modal.dialog2 = "#modal-dialog2";
cfg.modal.content2 = "#modal-content2";

cfg.modal.container3 = "#modal-container3";
cfg.modal.dialog3 = "#modal-dialog3";
cfg.modal.content3 = "#modal-content3";

cfg.bootbox = cfg.bootbox || {};
cfg.bootbox.btnYes = "YES";
cfg.bootbox.btnNo = "NO";

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


var cfg = cfg || {};

cfg.modal = cfg.modal || {};
cfg.modal.container = "#modal-container";
cfg.modal.dialog = "#modal-dialog";
cfg.modal.content = "#modal-content";

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


var cfg = cfg || {};

cfg.modal = cfg.modal || {};

// set defaults
cfg.modal.container = "#modal-container";
cfg.modal.dialog = "#modal-dialog";
cfg.modal.content = "#modal-content";

////////////////////////////////////
// toast lib
////////////////////////////////////

toastr.options.closeButton = true;
toastr.options.progressBar = false;
toastr.options.newestOnTop = true;
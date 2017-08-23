(function ($) {
    function Course() {
        var $this = this;
        function InitializeModel() {
            $("#modal-action-course").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () { InitializeModel() }

    }
    $(function () {
        var self = new Course();
        self.init();
    })
}(jQuery))
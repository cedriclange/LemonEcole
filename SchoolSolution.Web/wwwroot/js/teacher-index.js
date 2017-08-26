(function ($) {
    function Teacher() {
        var $this = this;
        function InitializeModel() {
            $("#modal-action-teacher").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () { InitializeModel() }

    }
    $(function () {
        var self = new Teacher();
        self.init();
    })
}(jQuery))
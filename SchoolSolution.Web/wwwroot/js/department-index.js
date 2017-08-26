(function ($) {
    function Department() {
        var $this = this;
        function InitializeModel() {
            $("#modal-action-dapartment").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () { InitializeModel() }

    }
    $(function () {
        var self = new Department();
        self.init();
    })
}(jQuery))
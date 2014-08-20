(function () {
    'use strict';
    var controllerId = 'personadd';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', personadd]);

    function personadd(common, datacontext, $location) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logErr = getLogFn(controllerId,'logError');

        var vm = this;
        vm.title = 'Add Person';
        
        function initPerson() {
            vm.firstName = "";
            vm.lastName = "";
            vm.age = 0;
            vm.location = "";
        }

        activate();

        function activate() {
            initPerson();
            common.activateController([], controllerId)
                .then(function () { log('Activated Add Person View'); });
        }

        vm.addPerson = function () {

            var newPerson = new datacontext.personApi({
                Id: null,
                FirstName: vm.firstName,
                LastName: vm.lastName, 
                Age: vm.age,
                Location: vm.location
            });
            newPerson.$save().then(function (data) {
                log(data.FirstName + ' ' + data.LastName + ' Created with Id: ' + data.Id);
                initPerson();
                console.dir(data);
            }, function (error) {
                logErr('An Error Occured');
                console.dir(error);
            });

        }

    }
})();
(function () {
    'use strict';
    var controllerId = 'personedit';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$routeParams', '$location' , personedit]);

    function personedit(common, datacontext, $routeParams, $location) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logErr = getLogFn(controllerId, 'logError');

        var vm = this;
        vm.title = 'Add Person';
        vm.person = {};
        //Id: null,
        //    FirstName: "",
        //    LastName: "",
        //    Age: 0,
        //    Location: ""
        //};

        activate();

        function activate() {
            common.activateController([getPersonDetails()], controllerId)
                .then(function () { log('Activated Edit Person View'); });
        }

        function getPersonDetails() {
            return datacontext.getPersonDetails($routeParams.personId).then(function (data) {
                return vm.person = data;
            });
        }

        vm.savePerson = function () {
            vm.person.$update().then(function (data) {
                log(vm.person.FirstName + ' ' + vm.person.LastName + ' Updated');
                $location.path('/dashboard');
            }, function (error) {
                logErr('An Error Occured');
                console.dir(error);
            });

            //var newPerson = new datacontext.personApi({
            //    Id: null,
            //    FirstName: vm.firstName,
            //    LastName: vm.lastName, 
            //    Age: vm.age,
            //    Location: vm.location
            //});
            //newPerson.$save().then(function (data) {
            //    log(data.FirstName + ' ' + data.LastName + ' Created with Id: ' + data.Id);
            //    initPerson();
            //    console.dir(data);
            //}, function (error) {
            //    logErr('An Error Occured');
            //    console.dir(error);
            //});

        }

    }
})();
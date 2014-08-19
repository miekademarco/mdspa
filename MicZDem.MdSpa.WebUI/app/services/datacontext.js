(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$resource', datacontext]);

    function datacontext(common, $resource) {
        var $q = common.$q;
        var personApi = $resource('/api/Persons/:Id');

        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount,
            personApi: personApi
        };

        return service;
        
        function getMessageCount() { return $q.when(33); }

        function getPeople() {
            var people = personApi.query();
            return $q.when(people);
        }
}


})();
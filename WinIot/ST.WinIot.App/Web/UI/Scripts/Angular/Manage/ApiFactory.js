(function () {
    'use strict';

    angular
        .module('app')
        .factory('ApiFactory', ApiFactory);

    ApiFactory.$inject = ['$http'];

    function ApiFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();
'use strict';

portfoliosApp.factory('portfolioService', function ($resource, $q) {
    var resource = $resource('/bca-odata/:entity?:odataParam', { entity: '@entity', odataParam: '@odataParam' });
        return {
        getAllocationSummaries: function (odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'AllocationSummaries', odataParam: odataParam },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },
        getPortfolioSummaries: function (odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'PortfolioSummaries', odataParam: odataParam },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },
        getAllocationHistories: function (allocationId, odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'AllocationHistorySummaries(' + allocationId + ')/', odataParam: odataParam },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },
        
        getCommentSummaries: function (portfolioId, odataParam) {
        var deferred = $q.defer();
        resource.get({ entity: 'CommentSummaries(' + portfolioId + ')', odataParam: odataParam },
            function (data) {
                deferred.resolve(data);
            },
            function (response) {
                deferred.reject(response);
            });
            return deferred.promise;
        },

        getServices: function (serviceId, odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'Services(' + serviceId + ')', odataParam: odataParam },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        
        getAllServices: function () {
            var deferred = $q.defer();
            resource.get({ entity: 'Services' },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        getAllPortfolios: function (odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'Portfolios' },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        getPortfolios: function (portfolioId, odataParam) {
            var deferred = $q.defer();
            resource.get({ entity: 'Portfolios(' + portfolioId + ')', odataParam: odataParam },
                function (data) {
                    deferred.resolve(data);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        }
    };
});


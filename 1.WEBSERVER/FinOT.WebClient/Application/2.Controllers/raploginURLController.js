﻿'use strict';
var raploginURLController = ['$scope', '$modal', 'alertService', '$location', '$anchorScroll', function ($scope, $modal, alert, $location, $anchorScroll) {
    var self = this;
    $anchorScroll();
    self.LoginPublic = function () {
        $location.path("/Login");
    }
    self.LoginCity = function () {
        $location.path("/CityLogin");
    }

}];
var raploginURLController_resolve = {
    model: ['$route', 'alertService',  function ($route, alert) {
        //return auth.fetchToken().then(function (response) {
        //return rapFactory.GetCustomer(null).then(function (response) {
        //       if (!alert.checkResponse(response)) { return; }
        //       rapGlobalFactory.CustomerDetails= response.data;
            
        //});
    }]
}
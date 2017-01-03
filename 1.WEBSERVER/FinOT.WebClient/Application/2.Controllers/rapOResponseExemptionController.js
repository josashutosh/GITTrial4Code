﻿'use strict';
var rapOResponseExemptionController = ['$scope', '$modal', 'alertService', 'rapOResponseExemptionFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory) {
    var self = this;
    self.model = $scope.model;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.caseinfo.CustomerID = self.custDetails.custID;
    self.caseinfo.OwnerResponseInfo.PropertyInfo.CustomerID = self.custDetails.custID;  

    self.Calender = masterFactory.Calender;

    rapFactory.GetOResponseExemption(self.caseinfo).then(function (response) {
        if (!alert.checkResponse(response)) { return; }
        rapGlobalFactory.CaseDetails = response.data;
        self.caseinfo = response.data;     
    });

    self.Continue = function () {   
        rapGlobalFactory.CaseDetails = self.caseinfo;
        rapFactory.SaveOResponseExemption(self.caseinfo).then(function (response) {
            if (!alert.checkResponse(response)) { return; }
            rapGlobalFactory.CaseDetails = response.data;
            MoveNext();
        });   
    }

    function MoveNext() {
        $scope.model.oresponseException = false;
        $scope.model.oresponseDocument = true;
        $scope.model.DisableAllCurrent();
        $scope.model.oResponseCurrentStatus.AdditionalDocumentation = true;
        $scope.model.oResponseActiveStatus.Exeption = true;
    }
}];
var rapOResponseExemptionController_resolve = {
    model: ['$route', 'alertService', 'rapOwnerRentalHistoryFactory', function ($route, alert, rapFactory) {
        ////return auth.fetchToken().then(function (response) {
        //return rapFactory.GetTenantPetetionFormInfo().then(function (response) {
        //  if (!alert.checkResponse(response)) { return; }
        //        return response.data;
        //    });
    }]
}
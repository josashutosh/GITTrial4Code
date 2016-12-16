﻿'use strict';
var rapAppealTypeController = ['$scope', '$modal', 'alertService', 'rapappealtypeFactory', '$location', 'rapGlobalFactory', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory) {
    var self = this;
    self.model = $scope.model;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    var _getPetitionCategory = function () {
        rapFactory.GetPetitionCategory().then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.caseinfo.PetitionCategory = response.data.PetitionCategory;
            rapGlobalFactory.CaseDetails = self.caseinfo;
           // self.bPetitionType = true;
        });
    }
    

    var _GetCaseInfo = function (caseID) {
        rapFactory.GetCaseInfo(caseID).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            //self.model = response.data;
            self.caseinfo = response.data;
            rapGlobalFactory.CaseDetails = self.caseinfo;
            _getPetitionCategory();
           // self.bPetitionType = true;
        });
    }
    _GetCaseInfo(self.caseinfo.CaseID);

    
    self.ContinueToImportantInformation = function () {
        $scope.model.bAppealType = false;
        $scope.model.bImpInfoAppeal = true;
        
    }
}];
var rapAppealTypeController_resolve = {
    model: ['$route', 'alertService', 'rapappealtypeFactory', function ($route, alert, rapFactory) {
        ////return auth.fetchToken().then(function (response) {
        //return rapFactory.GetTenantPetetionFormInfo().then(function (response) {
        //  if (!alert.checkResponse(response)) { return; }
        //        return response.data;
        //    });
    }]
}
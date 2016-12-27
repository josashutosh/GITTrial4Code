﻿'use strict';
var rapTRReviewController = ['$scope', '$modal', 'alertService', 'rapTRreviewFactory', '$location', 'rapGlobalFactory', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory) {
    var self = this;
    self.model = $scope.model;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;

    var _GetTenantReviewInfo = function (custID) {
        rapFactory.GetTenantReviewInfo(custID).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.caseinfo.TenantPetitionInfo = response.data;
        });
    }
    _GetTenantReviewInfo(self.custDetails.custID);

    self.EditApplicantInfo = function () {
        $scope.model.bReview = false;
        $scope.model.bAppInfo = true;
    }
    self.EditGroundsInfo = function () {
        $scope.model.bReview = false;
        $scope.model.bGrounds = true;
    }
    self.EditRentalHistoryInfo = function () {
        $scope.model.bReview = false;
        $scope.model.bRentalHistory = true;
    }
    self.EditDocumentsInfo = function () {
        $scope.model.bReview = false;
        $scope.model.bAddDocuments = true;
    }
    self.ContinueToVerification = function () {
        $scope.model.bReview = false;
        $scope.model.bVerification = true;
        $scope.model.tPetionActiveStatus.Review = true;
    }

}];
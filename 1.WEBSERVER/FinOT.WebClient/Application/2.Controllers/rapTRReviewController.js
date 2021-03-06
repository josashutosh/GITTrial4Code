﻿'use strict';
var rapTRReviewController = ['$scope', '$modal', 'alertService', 'rapTRreviewFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.model = $scope.model;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    $scope.model.stepNo = 7;

    var _GetTenantResponseReviewInfo = function (CaseNumber,custID) {
        rapFactory.GetTenantResponseReviewInfo(CaseNumber, custID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.caseinfo = response.data;
            rapGlobalFactory.CaseDetails = self.caseinfo;
            //self.caseinfo.Documents = response.data.Documents;
            $anchorScroll();
        });
    }
    _GetTenantResponseReviewInfo(self.caseinfo.CaseID, self.custDetails.custID);

    self.EditApplicantInfo = function () {
        $scope.model.bReview = false;
        $scope.model.bAppInfo = true;
    }
    self.EditExemptContested = function () {
        $scope.model.bReview = false;
        $scope.model.bExemptionContested = true;
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
        $scope.model.TRSubmissionStatus.Review = true;
    }

    self.Download = function (doc) {
        masterFactory.GetDocument(doc);

    }

}];
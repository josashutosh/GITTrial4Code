﻿'use strict';
var rapOResponseReviewController = ['$scope', '$modal', 'alertService', 'rapOResponseReviewFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.model = $scope.model;
    $scope.model.stepNo = 9;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.caseinfo.CustomerID = self.custDetails.custID;
    self.caseinfo.OwnerResponseInfo.ApplicantInfo.CustomerID = self.custDetails.custID;
    self.caseinfo.OwnerResponseInfo.PropertyInfo.CustomerID = self.custDetails.custID;

    self.Calender = masterFactory.Calender;
    self.Error = '';
    $anchorScroll();
    rapFactory.GetOResponseReview(self.caseinfo).then(function (response) {
         if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
        rapGlobalFactory.CaseDetails = response.data;
        self.caseinfo = response.data;
        
    });
    self.EditApplicantInfo = function () {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseApplicantInfo = true;
    }
      self.EditRentalProperty = function () {
          $scope.model.oresponseReview = false;
        $scope.model.oresponseRentalProperty = true;
    }
    self.EditRentalHistory = function () {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseRentalHistory = true;
    }
    self.EditDecreasedHousing = function () {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseDecreasedHousing = true;
    }
    self.EditExemption = function () {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseException = true;
    }
    self.EditAdditionalDocuments = function () {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseDocument = true;
    }

    self.Download = function (doc) {
        masterFactory.GetDocument(doc);
    }
   
    self.Continue = function () {
        rapGlobalFactory.CaseDetails = self.caseinfo;
        rapFactory.SaveOResponseReviewPageSubmission(self.custDetails.custID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            MoveNext();
        });
    }
    function MoveNext() {
        $scope.model.oresponseReview = false;
        $scope.model.oresponseVerification = true;
        $scope.model.DisableAllCurrent();
        $scope.model.oResponseCurrentStatus.Verification = true;
        $scope.model.oResponseActiveStatus.Review = true;
    }
}];
var rapOResponseReviewController_resolve = {
    model: ['$route', 'alertService', 'rapOwnerRentalHistoryFactory', function ($route, alert, rapFactory) {
        ////return auth.fetchToken().then(function (response) {
        //return rapFactory.GetTenantPetetionFormInfo().then(function (response) {
        //  if (!alert.checkResponse(response)) { return; }
        //        return response.data;
        //    });
    }]
}
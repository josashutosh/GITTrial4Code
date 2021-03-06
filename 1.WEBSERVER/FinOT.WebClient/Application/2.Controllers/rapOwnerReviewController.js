﻿var rapOwnerReviewController = ['$scope', '$modal', 'alertService', '$location', 'rapOwnerReviewFactory', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, $location, rapFactory, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.model = $scope.model;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.caseinfo.CustomerID = self.custDetails.custID;   
    self.caseinfo.OwnerPetitionInfo.PropertyInfo.CustomerID = self.custDetails.custID;
    self.caseinfo.OwnerPetitionInfo.ApplicantInfo.CustomerID = self.custDetails.custID;
    self.Error = "";
    $scope.model.stepNo = 8;
    rapFactory.GetOwnerReview(self.caseinfo).then(function (response) {
        if (!alert.checkForResponse(response)) {
            self.Error = rapGlobalFactory.Error;
            $anchorScroll();
            return;
        }
        rapGlobalFactory.CaseDetails = response.data;
        self.caseinfo = response.data;
        $anchorScroll();
    });

    self.Download = function (doc) {
        masterFactory.GetDocument(doc);
    }

    self.Continue = function () {
        rapGlobalFactory.CaseDetails = self.caseinfo;
        rapFactory.SaveOwnerReviewPageSubmission(self.custDetails.custID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                return;
            }
            $scope.model.ownerReview = false;
            $scope.model.ownerVerification = true;
            $scope.model.DisableAllCurrent();
            $scope.model.oPetionCurrentStatus.Verification = true;
            $scope.model.oPetionActiveStatus.Review = true;
            
        });
    }

    self.EditApplicantInfo = function()
    {
        $scope.model.ownerReview = false;
        $scope.model.ownerApplicantInfo = true;
    }
    self.EditJustification = function () {
        $scope.model.ownerReview = false;
        $scope.model.ownerJustification = true;
    }
    self.EditRentalProperty = function () {
        $scope.model.ownerReview = false;
        $scope.model.ownerRentalProperty = true;
    }
    self.EditRentalHistory = function () {
        $scope.model.ownerReview = false;
        $scope.model.ownerRentalHistory = true;
    }
    self.EditAdditionalDocuments = function () {
        $scope.model.ownerReview = false;
        $scope.model.ownerAdditionalDocuments = true;
    }

    self.Print = function () {
        var doc = document.getElementById('printable');
        //var doc = $("#printable");
                   // $('body').html2canvas({
        // html2canvas($("#printable"), {
         html2canvas(doc, {
              onrendered: function (canvas) {
                var img = canvas.toDataURL("image/jpeg");
                window.print(img);
            }
        });
    }
  
}];

var rapOwnerReviewController_resolve = {
    model: ['$route', 'alertService', function ($route, alert, rapFactory) {

    }]
}
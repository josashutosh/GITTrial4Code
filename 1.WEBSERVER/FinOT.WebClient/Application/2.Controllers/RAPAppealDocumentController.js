﻿'use strict';
var rapAppealDocumentController = ['$scope', '$modal', 'alertService', 'ajaxService', '$location', 'rapGlobalFactory', 'rapAppealDocumentFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, ajaxService, $location, rapGlobalFactory, rapFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.model = $scope.model;
    $scope.model.stepNo = 5;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.caseinfo.CustomerID = self.custDetails.custID;
    self.DocDescriptions = masterFactory.DocDescription();
    self.Error = "";
    masterFactory.DocDescription().then(function (response) {
        if (!alert.checkForResponse(response)) {
            self.Error = rapGlobalFactory.Error;
            return;
        }
        self.DocDescriptions = response.data;
    });
    self.description1 = null;
    self.description2 = null;
    self.Documents = null;
    rapFactory.GetAppealDocuments(self.custDetails.custID, 'A_AdditionalDocuments').then(function (response) {
        if (!alert.checkForResponse(response)) {
            self.Error = rapGlobalFactory.Error;
            $anchorScroll();
            return;
        }
        self.Documents = response.data;
       $anchorScroll();
    });

    $scope.onFileSelected = function ($files, docTitle) {
        if ($files && $files.length) {
            for (var i = 0; i < $files.length; i++) {
                var file = $files[i];
                var filename = file.name;
                var mimetype = file.type;
                var filesize = ((file.size / 1024) / 1024).toFixed(4);
                if (filesize < masterFactory.FileSize)
                    var index = filename.lastIndexOf(".");
                var ext = filename.substring(index, filename.length).toUpperCase();
                if (masterFactory.FileExtensons.indexOf(ext) > -1) {
                    var document = {};
                    document.DocTitle = docTitle;
                    document.DocName = filename;
                    document.MimeType = mimetype;
                    document.CustomerID = self.custDetails.custID;
                    document.C_ID = self.caseinfo.C_ID;
                    document.isUploaded = false;
                    document.IsPetitonFiled = false;
                    var reader = new FileReader();
                    reader.readAsDataURL(file);
                    reader.onload = function (e) {
                        var base64 = e.target.result;
                        if (base64 != null) {
                            document.Base64Content = base64.substring(base64.indexOf('base64') + 7)
                        }
                    }
                    var desc = angular.copy(self.description1);
                    if (desc == null) {
                        desc = angular.copy(self.description2);
                    }
                    document.DocDescription = desc
                    self.Documents.push(document);
                    self.description1 = null;
                    self.description2 = null;
                }
            }

        }
    }


    self.Download = function (doc) {
        masterFactory.GetDocument(doc);

    }

    self.Delete = function (doc) {
        var index = self.Documents.indexOf(doc);
        self.Documents.splice(index, 1);
    }

    self.ContinueToServeAppeal = function () {
        rapGlobalFactory.CaseDetails = self.caseinfo;
        rapFactory.SaveAppealDocuments(self.Documents, self.custDetails.custID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            $scope.model.bAddDocs = false;
            $scope.model.bServingAppeal = true;
            $scope.model.AppealSubmissionStatus.AdditionalDocumentation = true;
        });     
       // $scope.model.tPetionActiveStatus.AdditionalDocumentation = true;       
    } 
    
    
}];
var rapAppealDocumentController_resolve = {
    model: ['$route', 'alertService', function ($route, alert)
    {
    }]
}
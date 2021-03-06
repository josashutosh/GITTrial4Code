﻿var rapAdditionalCaseDocumentController = ['$scope', '$modal', 'alertService', '$location', 'rapAdditionalCaseDocumentFactory', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, $location, rapFactory, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.custDetails = rapGlobalFactory.CityUser;
    self.customerDetails = rapGlobalFactory.CustomerDetails;
    if (rapGlobalFactory.SelectedCase == null || rapGlobalFactory.SelectedCase == undefined) {
        $location.path("/staffdashboard");
    }
    self.CaseID = rapGlobalFactory.SelectedCase.CaseID;
    self.c_id = rapGlobalFactory.SelectedCase.C_ID;
    self.DocDescriptions = masterFactory.DocDescription();
    $anchorScroll();
    self.Home = function () {
        if (self.customerDetails != null) {
            $location.path("/publicdashboard");
        }
        else {
            $location.path("/staffdashboard");
        }
    }
    self.CaseClick = function () {
        if (self.customerDetails != null) {
            $location.path("/publicdashboard");
        }
        else {
            $location.path("/selectedcase");
        }
    }
    masterFactory.DocDescription().then(function (response) {
        if (!alert.checkForResponse(response)) {
            self.Error = rapGlobalFactory.Error;
            $anchorScroll();
            return;
        }
        self.DocDescriptions = response.data;
    });
    self.description1 = null;
    self.description2 = null;
 
    self.Documents = null;
    rapFactory.GetCaseDocuments(self.c_id).then(function (response) {
        if (!alert.checkForResponse(response)) {
            self.Error = rapGlobalFactory.Error;
            $anchorScroll();
            return;
        }
        self.Documents = response.data;       
    });
    self.Delete = function (doc) {
        var index = self.Documents.indexOf(doc);
        self.Documents.splice(index, 1);
    }
    $scope.onFileSelected = function ($files, docTitle) {
        if ($files && $files.length) {
            for (var i = 0; i < $files.length; i++) {
                var file = $files[i];
                var filename = file.name;
                var mimetype = file.type;
                var filesize = ((file.size / 1024) / 1024).toFixed(4);
                //if (filesize < 25) {
                if (filesize < masterFactory.FileSize)
                    var index = filename.lastIndexOf(".");
                var ext = filename.substring(index, filename.length).toUpperCase();
                //if (ext == '.PDF' || ext == '.DOC' || ext == '.DOCX' || ext == '.XLS' || ext == '.JPEG' || ext == '.TIFF' || ext == '.PNG') {
                if (masterFactory.FileExtensons.indexOf(ext) > -1) {
                    var document = {}; // angular.copy(self.caseinfo.Document);
                    document.DocTitle = docTitle;
                    document.DocName = filename;
                    document.MimeType = mimetype;
                    if (self.custDetails != null)
                    {
                        document.CityUserID = self.custDetails.UserID;
                    }
                    else if (self.customerDetails != null)
                    {
                        document.CustomerID = self.customerDetails.custID;
                    }
                    document.C_ID = self.c_id;
                    document.isUploaded = false;
                    document.IsPetitonFiled = true;
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
    self.Submit = function () {
         rapFactory.SaveCaseDocuments(self.Documents).then(function (response) {
             if (!alert.checkForResponse(response)) {
                 self.Error = rapGlobalFactory.Error;
                 $anchorScroll();
                 return;
             }
            self.Documents = response.data;
            if(self.customerDetails != null){
                 $location.path("/publicdashboard");
            }
            else {
                $location.path("/selectedcase");
            }

        });   
    }
        self.Cancel = function () {
         
            if(self.customerDetails != null){
                 $location.path("/publicdashboard");
            }
            else {
             $location.path("/selectedcase");
            }

        
    }

}];

var rapAdditionalCaseDocumentController_resolve = {
    model: ['$route', 'alertService', function ($route, alert, rapFactory) {

    }]
}
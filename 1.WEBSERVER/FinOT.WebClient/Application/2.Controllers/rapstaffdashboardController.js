﻿'use strict';
var rapstaffdashboardController = ['$scope', '$modal', 'alertService', 'rapstaffdashboardFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory) {
    var self = this;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.model = rapGlobalFactory.CityUser;
    self.CaseSearchModel = [];
    self.CaseSearchResult = [];
    self.SearchModel = {
        TotalCount: 0,
        PageSize: null,
        CurrentPage: 1,
        SortBy: 'Name',
        SortReverse: true
    };
    self.pageNumberList = [];
    self.pagesizeOptions = [5, 10, 20, 50];
    self.CaseList = [];
    self.Analysts = [];
    self.FromRecord = 1;
    self.ToRecord = 5;
    self.HearingOfficers = [];
    self.InviteThirdPartyUser = function () {
        $location.path("/invitethirdparty");
    }
    self.FilePetition = function () {
        $location.path("/filePetition");
    }
    self.NewCaseStatus = function () {
        $location.path("/newCaseStatus");
    }
    self.AccountSearch = function () {
        $location.path("/accountSearch");
    }
    self.ManageAccounts = function () {
        $location.path("/admindashboard");
    }

    
   
    self.FileAppeal = function (model) {
        //self.caseinfo.CaseID = 
        rapFactory.GetCaseInfoWithModel(model).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }

            self.caseinfo = response.data;
            rapGlobalFactory.CaseDetails = self.caseinfo;
        });
        $location.path("/fileappeal");
    }

    self.GetCaseActivityStatus = function (model) {
        rapFactory.GetCaseActivityStatus(model).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.caseinfo.ActivityStatus = response.data;
        });
    }
    var _GetCasesNoAnalyst = function (userID) {
        rapFactory.GetCasesNoAnalyst(userID).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.CaseList = response.data;
        });
    }
    _GetCasesNoAnalyst(self.model.UserID);

    var _GetAnalysts = function () {
        masterFactory.GetAnalysts().then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.Analysts = response.data;
        });
    }
    _GetAnalysts();

    var _GetHearingOfficers = function () {
        masterFactory.GetHearingOfficers().then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            self.HearingOfficers = response.data;
        });
    }
    _GetHearingOfficers();
    var _GetCaseInfo = function () {

        rapFactory.GetCaseInfo().then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }

            self.caseinfo = response.data;
            rapGlobalFactory.CaseDetails = self.caseinfo;
        });
    }
    var _getEmptyCaseSearchModel = function () {
        rapFactory.GetEmptyCaseSearchModel().then(function (response) {
            if (!alert.checkResponse(response)) { return; }
            self.CaseSearchModel = response.data;
            self.CaseSearchModel.PageSize = 5;
        });
    }
    _getEmptyCaseSearchModel();
    if (self.caseinfo == null) {
        _GetCaseInfo();
    }

    self.AssignAnalyst = function (C_ID, Analyst) {

        masterFactory.AssignAnalyst(C_ID, Analyst.UserID).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            _GetCasesNoAnalyst(self.model.UserID);
        });
    }

    self.AssignHearingOfficer = function (C_ID, HearingOfficer) {

        masterFactory.AssignHearingOfficer(C_ID, HearingOfficer.UserID).then(function (response) {
            if (!alert.checkResponse(response)) {
                return;
            }
            _GetCasesNoAnalyst(self.model.UserID);
        });
    }
    self.OpenSelectedCase = function (caseinfo)
    {
        rapGlobalFactory.SelectedCase = caseinfo;
        $location.path("/selectedcase");
    }

    self.OnClearFilter = function () {
        _getEmptyCaseSearchModel();
        self.CaseSearchResult = [];
    }

    

    self.CaseSearch = function (model) {

        model.CurrentPage = 1;
        model.SortBy = "CreatedDate";
        model.SortReverse = 0;
        
        rapFactory.GetCaseSearch(model).then(function (response) {
            if (!alert.checkResponse(response)) { return; }
            self.CaseSearchResult = response.data.List;
            self.CaseSearchModel.TotalCount = response.data.TotalCount;
            self.CaseSearchModel.CurrentPage = response.data.CurrentPage;
            self.FromRecord = self.CaseSearchResult[0].RankNo;
            self.ToRecord = self.CaseSearchResult[(self.CaseSearchResult.length-1)].RankNo;
            self.GeneratePageNumberList();
        });
    }
    self.GeneratePageNumberList = function()
    {
        var TotalPages = Math.ceil(self.CaseSearchModel.TotalCount / self.CaseSearchModel.PageSize);
        for (var i = 1; i <= TotalPages; i++)
        {
            self.pageNumberList.push({ text: i, active: true });
        }
         
    }
    
    self.isLastPage = function () {
        return (self.CaseSearchModel.TotalCount - (self.CaseSearchModel.CurrentPage * self.CaseSearchModel.PageSize) <= 0);
    };
    self.GetPage = function (newPage, model) {

        //if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.CaseSearchModel.CurrentPage)) {
            self.CaseSearchModel.CurrentPage = newPage;
            rapFactory.GetCaseSearch(self.CaseSearchModel).then(function (response) {
                if (!alert.checkResponse(response)) { return; }
                self.CaseSearchResult = response.data.List;
                self.CaseSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.CaseSearchResult[0].RankNo;
                self.ToRecord = self.CaseSearchResult[(self.CaseSearchResult.length - 1)].RankNo;
            });
       // }
    }
    self.GetNextPage = function (model) {
        var newPage = self.CaseSearchModel.CurrentPage + 1;
        if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.CaseSearchModel.CurrentPage)) {
            self.CaseSearchModel.CurrentPage = self.CaseSearchModel.CurrentPage+1;
            rapFactory.GetCaseSearch(self.CaseSearchModel).then(function (response) {
                if (!alert.checkResponse(response)) { return; }
                self.CaseSearchResult = response.data.List;
                self.CaseSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.CaseSearchResult[0].RankNo;
                self.ToRecord = self.CaseSearchResult[(self.CaseSearchResult.length - 1)].RankNo;
            });
        }
    }
    self.GetPreviousPage = function (model) {
        var newPage = self.CaseSearchModel.CurrentPage - 1;
        if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.CaseSearchModel.CurrentPage)) {
            self.CaseSearchModel.CurrentPage = self.CaseSearchModel.CurrentPage - 1;
            rapFactory.GetCaseSearch(self.CaseSearchModel).then(function (response) {
                if (!alert.checkResponse(response)) { return; }
                self.CaseSearchResult = response.data.List;
                self.CaseSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.CaseSearchResult[0].RankNo;
                self.ToRecord = self.CaseSearchResult[(self.CaseSearchResult.length - 1)].RankNo;
            });
        }
    }
    self.OnPageSizeChange = function () {
        self.CaseSearchModel.CurrentPage = 1;

        rapFactory.GetAccountSearch(self.CaseSearchModel).then(function (response) {
            if (!alert.checkResponse(response)) { return; }
            self.CaseSearchResult = response.data.List;
            self.CaseSearchModel.TotalCount = response.data.TotalCount;
            self.CaseSearchModel.CurrentPage = response.data.CurrentPage;
            self.FromRecord = self.CaseSearchResult[0].RankNo;
            self.ToRecord = self.CaseSearchResult[(self.CaseSearchResult.length - 1)].RankNo;
        });
    }

}];
var rapstaffdashboardController_resolve = {
    model: ['$route', 'alertService',  function ($route, alert) {
        //return auth.fetchToken().then(function (response) {
        //return rapFactory.GetCustomer(null).then(function (response) {
        //    $scope.model = response.data;
        //    //   if (!alert.checkResponse(response)) { return; }
        //    //    return response.data;
        //    //});
        //});
    }]
}
﻿'use strict';
var rapadmindashboardController = ['$scope', '$modal', 'alertService', 'rapadmindashboardFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.Error = "";
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.CityUser = rapGlobalFactory.CityUser;
    self.pageNumberList = [];
    self.CreateCityUserAccount = function () {
        rapGlobalFactory.IsAdmin = true;
        rapGlobalFactory.IsEdit = false;
        $location.path("/createCityUserAccount");
    }
    self.CreatePublicUserAccount = function () {
        rapGlobalFactory.IsAdmin = true;
        rapGlobalFactory.IsEdit = false;
        $location.path("/register");
    }
    self.EditPublicUserAccount = function () {
        $location.path("/editpublicuser");
    }
    self.Home = function () {
        $location.path("/staffdashboard");
    }

    self.AccountTypesList = [];
    self.AccountSearchModel = [];
    self.AccountSearchResult = [];
    self.model = {
        List:[],
        TotalCount: 0,
        PageSize: null,
        CurrentPage: 1,
        SortBy: 'Name',
        SortReverse: true
    };
    self.pageNumberList = [];
    self.pagesizeOptions = [5, 10, 20, 50];
    self.FromRecord = 1;
    self.ToRecord = 5;
    
    //self.model.PageSize = 10;
    //self.isLastPage = function () {
    //    return (self.model.TotalCount - (self.model.CurrentPage * self.model.PageSize) <= 0);
    //};
    //self.totalPage = function () {
    //    if (self.model == null || self.model == undefined) { return 0; }
    //    return (Math.floor(self.model.TotalCount / self.model.PageSize) + (((self.model.TotalCount % self.model.PageSize) != 0) ? 1 : 0))
    //};
    var _getAccountTypes = function (AccountTypeID) {
        self.Error = "";
        masterFactory.GetAccountTypes(AccountTypeID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.AccountTypesList = response.data;
            $anchorScroll();
        });
    }
    var _getEmptyAccountSearchModel = function () {
        self.Error = "";
        rapFactory.GetEmptyAccountSearchModel().then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.AccountSearchModel = response.data;
            self.AccountSearchModel.PageSize = 20;
        });
    }
    _getAccountTypes(self.CityUser.AccountType.AccountTypeID);
    _getEmptyAccountSearchModel();
    $anchorScroll();
    self.GeneratePageNumberList = function () {
        self.pageNumberList = [];
        var TotalPages = Math.ceil(self.AccountSearchModel.TotalCount / self.AccountSearchModel.PageSize);
        for (var i = 1; i <= TotalPages; i++) {
            self.pageNumberList.push({ text: i, active: true });
        }

    }
    self.AccountSearch = function (model) {
        //model.PageSize = 10;
        self.AccountSearchResult = [];
        self.pageNumberList = [];
        model.CurrentPage = 1;
        model.SortBy = "Name";
        model.SortReverse = 0;
        self.Error = "";
        if (model.FromDate != null && (model.ToDate == null || model.ToDate ==""))
        {
            self.Error = "Please select valid End Date.";
            $anchorScroll();
            return;
        }
        if ((model.FromDate == null || model.FromDate == "") && model.ToDate != null) {
            self.Error = "Please select valid Start Date.";
            $anchorScroll();
            return;
        }
        rapFactory.GetAccountSearch(model).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.AccountSearchResult = response.data.List;
            self.AccountSearchModel.TotalCount = response.data.TotalCount;
            self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
            self.AccountSearchModel.CurrentPage = 1;
            self.AccountSearchModel.SortBy = "Name";
            self.AccountSearchModel.SortReverse = 0;
            self.FromRecord = self.AccountSearchResult[0].RankNo;
            self.ToRecord = self.AccountSearchResult[(self.AccountSearchResult.length - 1)].RankNo;
            self.GeneratePageNumberList();
        });
    }
    self.OnClearFilter = function () {
        _getEmptyAccountSearchModel();
        self.AccountSearchResult = [];
        self.pageNumberList = [];
        self.Error = "";
    }
    self.isLastPage = function () {
        return (self.AccountSearchModel.TotalCount - (self.AccountSearchModel.CurrentPage * self.AccountSearchModel.PageSize) <= 0);
    };
    self.isFirstPage = function () {
        return (self.AccountSearchModel.CurrentPage == 1);
    };
    self.GetPage = function (newPage, model) {
        self.Error = "";
        if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.AccountSearchModel.CurrentPage)) {
            self.AccountSearchModel.CurrentPage = newPage;            
            rapFactory.GetAccountSearch(model).then(function (response) {
                if (!alert.checkForResponse(response)) {
                    self.Error = rapGlobalFactory.Error;
                    $anchorScroll();
                    return;
                }
                self.AccountSearchResult = response.data.List;
                self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.AccountSearchResult[0].RankNo;
                self.ToRecord = self.AccountSearchResult[(self.AccountSearchResult.length - 1)].RankNo;
            });
        }
    }
    self.GetNextPage = function (model) {
        var newPage = self.AccountSearchModel.CurrentPage + 1;
        self.Error = "";
        if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.AccountSearchModel.CurrentPage)) {
            self.AccountSearchModel.CurrentPage = self.AccountSearchModel.CurrentPage + 1;
            rapFactory.GetAccountSearch(self.AccountSearchModel).then(function (response) {
                if (!alert.checkForResponse(response)) {
                    self.Error = rapGlobalFactory.Error;
                    $anchorScroll();
                    return;
                }
                self.AccountSearchResult = response.data.List;
                self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.AccountSearchResult[0].RankNo;
                self.ToRecord = self.AccountSearchResult[(self.AccountSearchResult.length - 1)].RankNo;
            });
        }
    }
    self.GetPreviousPage = function (model) {
        var newPage = self.AccountSearchModel.CurrentPage - 1;
        self.Error = "";
        if ((newPage > 0 && !self.isLastPage()) || (newPage > 0 && newPage < self.AccountSearchModel.CurrentPage)) {
            self.AccountSearchModel.CurrentPage = self.AccountSearchModel.CurrentPage - 1;
            rapFactory.GetAccountSearch(self.AccountSearchModel).then(function (response) {
                if (!alert.checkForResponse(response)) {
                    self.Error = rapGlobalFactory.Error;
                    $anchorScroll();
                    return;
                }
                self.AccountSearchResult = response.data.List;
                self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
                self.FromRecord = self.AccountSearchResult[0].RankNo;
                self.ToRecord = self.AccountSearchResult[(self.AccountSearchResult.length - 1)].RankNo;

            });
        }
    }
    self.TotalPage = function () {
        if (self.AccountSearchModel == null || self.AccountSearchModel == undefined) { return 0; }
        return (Math.floor(self.AccountSearchModel.TotalCount / self.AccountSearchModel.PageSize) + (((self.AccountSearchModel.TotalCount % self.AccountSearchModel.PageSize) != 0) ? 1 : 0))
    };
    self.OnPageSizeChange = function () {
        self.AccountSearchModel.CurrentPage = 1;
        
        rapFactory.GetAccountSearch(self.AccountSearchModel).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.AccountSearchResult = response.data.List;
            self.AccountSearchModel.TotalCount = response.data.TotalCount;
            self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
        });
    }
    self.onSort = function (_sortBy, model) {
        self.Error = "";
        if (model.SortBy == _sortBy) {
            model.SortReverse = !model.SortReverse;
        } else {
            model.SortBy = _sortBy;
            model.SortReverse = false;
        }
        rapFactory.GetAccountSearch(model).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.AccountSearchResult = response.data.List;
            self.AccountSearchModel.TotalCount = response.data.TotalCount;
            self.AccountSearchModel.CurrentPage = response.data.CurrentPage;
            self.AccountSearchModel.SortBy = model.SortBy;
            self.AccountSearchModel.SortReverse = model.SortReverse;

        });
    }
    self.GetCaseActivityStatus = function (model) {
        //self.caseinfo.CaseID = 
        self.Error = "";
        rapFactory.GetCaseActivityStatus(model).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.caseinfo.ActivityStatus = response.data;

           // self.caseinfo = response.data;
            //rapGlobalFactory.CaseDetails = self.caseinfo;
        });
       // $location.path("/fileappeal");
    }

    self.EditAccount = function (model) {
        self.Error = "";
        rapGlobalFactory.SelectedForEdit = model;
         rapGlobalFactory.IsEdit = true;
        if(self.AccountSearchModel.AccountType.AccountTypeID == 3)
        {
            rapGlobalFactory.IsAdmin = true;
            $location.path("/editcustomerinformation");
        }
        else 
        {
            $location.path("/createCityUserAccount");
        }
    }
    

}];
var rapadmindashboardController_resolve = {
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
﻿'use strict';
var rapCityUserAcctController = ['$scope', '$modal', 'alertService', 'rapcityuserregisterFactory', 'rapGlobalFactory', 'masterdataFactory', '$location', '$anchorScroll', function ($scope, $modal, alert, rapFactory, rapGlobalFactory, masterFactory, $location, $anchorScroll) {
    var self = this;
    // self.CityUserAccount = [];
    self.AccountTypesList = [];
    self.confirmPwd = "";
    self.Error = '';
    self.Hide = false;

    self.bEdit = rapGlobalFactory.IsEdit;
    self.Title = "Create a City of Oakland Account";
    self.SubmitText = "Create account";
    $anchorScroll();
    var _GetCityUserFromID = function (CityUserID) {
        return rapFactory.GetCityUserFromID(CityUserID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.CityUserAccount = response.data;
            $anchorScroll();
        });
    }
    if (rapGlobalFactory.IsEdit == true) {
        self.Title = "Edit a City of Oakland Account";
        self.SubmitText = "Update account";
        _GetCityUserFromID(rapGlobalFactory.SelectedForEdit.custID);
    }

    var checkPassword = function (pwd, email) {
        if (email == pwd)
            return false;
        var strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@\_\-])(?=.{8,})");
        return strongRegex.test(pwd);
        }
    self.CreateAccount = function (model) {
        if (self.bEdit != true) {
            if (model.Password != self.confirmPwd) {
                self.Error = "Please enter same password in password fields.";
                return;
            }
            if (!checkPassword(model.Password, model.email)) {
                self.PasswordError = true;
                self.Error = "Enter password matching the requirements";
                return;
            }
        }
        rapFactory.CreateCityUserAccount(model).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            if (rapGlobalFactory.IsEdit == true) {
                rapGlobalFactory.SelectedForEdit = null;
                rapGlobalFactory.IsEdit = false;
                $location.path("/admindashboard");
            }
            else if(rapGlobalFactory.IsAdmin == true)
            {
                rapGlobalFactory.IsAdmin = false;
                $location.path("/admindashboard");
            }
            else {
                $location.path("/CityLogin");
            }
            
            
        });
    }
    self.DeleteCityUser = function (UserID) {
        rapFactory.DeleteCityUser(UserID).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            if (rapGlobalFactory.IsEdit == true) {
                rapGlobalFactory.SelectedForEdit = null;
                rapGlobalFactory.IsEdit = false;
                $location.path("/admindashboard");
            }
            else {
                $location.path("/CityLogin");
            }

        });
    }
    self.Cancel = function () {
        if (rapGlobalFactory.IsEdit == true) {
            rapGlobalFactory.SelectedForEdit = null;
            rapGlobalFactory.IsEdit = false;
            $location.path("/admindashboard");
        }
        else if (rapGlobalFactory.IsAdmin == true) {
            rapGlobalFactory.IsAdmin = false;
            $location.path("/admindashboard");
        }
        else {
            $location.path("/CityLogin");
        }
    }
    //var _getAccountTypes = function (AccountTypeID) {
    //    masterFactory.GetAccountTypes(AccountTypeID).then(function (response) {
    //        if (!alert.checkResponse(response)) { return; }
    //        self.AccountTypesList = response.data;
    //    });
    //}
    //_getAccountTypes(self.model.AccountType.AccountTypeID);

}];
var rapCityUserAcctController_resolve = {
    model: ['$route', 'alertService', 'rapcityuserregisterFactory', function ($route, alert, rapFactory) {
        //return auth.fetchToken().then(function (response) {
        //return rapFactory.GetCustomer(null).then(function (response) {
        //     //   if (!alert.checkResponse(response)) { return; }
        //    //    return response.data;
        //    //});
        //});
    }]
}
﻿'use strict';
var rapOResponseRentalPropertyController = ['$scope', '$modal', 'alertService', 'rapOResponseRentalPropertyFactory', '$location', 'rapGlobalFactory', 'masterdataFactory', '$anchorScroll', function ($scope, $modal, alert, rapFactory, $location, rapGlobalFactory, masterFactory, $anchorScroll) {
    var self = this;
    self.model = $scope.model;
    $scope.model.stepNo = 4;
    self.custDetails = rapGlobalFactory.CustomerDetails;
    self.caseinfo = rapGlobalFactory.CaseDetails;
    self.caseinfo.CustomerID = self.custDetails.custID;
    self.caseinfo.OwnerResponseInfo.PropertyInfo.CustomerID = self.custDetails.custID;
    self.StateList = [];
    self.IsTenant = false;
    self.Hide = false;
    self.Error = '';
    var _GetStateList = function () {
        masterFactory.GetStateList().then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            self.StateList = response.data;
        });
    }

    _GetStateList();
    var _GetIsTenant = function () {
        var isPresent = false;
        self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.forEach(function (tenant) {
            if (tenant.IsDeleted == false) {
                self.IsTenant = true;
                isPresent = true;
            }
        });
        if (isPresent == false) {
            self.IsTenant = false;
        }
    }
    rapFactory.GetOwnerPropertyAndTenantInfo(self.caseinfo).then(function (response) {
        if (!alert.checkResponse(response)) { return; }
        rapGlobalFactory.CaseDetails = response.data;
        self.caseinfo = response.data;
        _GetIsTenant();
        $anchorScroll();
    });

    self.Continue = function () {
        if (self.caseinfo.OwnerResponseInfo.PropertyInfo.UnitTypeID == null || self.caseinfo.OwnerResponseInfo.PropertyInfo.UnitTypeID == 0) {
            self.Hide = false;
            self.Error = "Type of unit you rent is required";
            $anchorScroll();
            return;
        }
        if (self.IsTenant == false) {
            if (self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.FirstName != null && self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.FirstName != "" &&
                self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine1 != null && self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine1 != "" &&
                self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.City != null && self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.City != "" &&
                self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Zip != null && self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Zip != "")     {

                self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.push(self.caseinfo.OwnerPetitionTenantInfo);
              
            }
            _GetIsTenant();
        }
        if (self.IsTenant == false) {
            self.Hide = false;
            self.Error = "Please add tenant information";
            $anchorScroll();
            return;
        }   
        rapGlobalFactory.CaseDetails = self.caseinfo;
        rapFactory.SaveOwnerPropertyAndTenantInfo(self.caseinfo).then(function (response) {
            if (!alert.checkForResponse(response)) {
                self.Error = rapGlobalFactory.Error;
                $anchorScroll();
                return;
            }
            rapGlobalFactory.CaseDetails = response.data;
            MoveNext();
        });
       
    }

    function MoveNext() {
        $scope.model.oresponseRentalProperty = false;
        $scope.model.oresponseRentalHistory = true;
        $scope.model.DisableAllCurrent();
        $scope.model.oResponseCurrentStatus.RentHistory = true;
        $scope.model.oResponseActiveStatus.RentalProperty = true;
    }
    self.AddTenant = function (_userInfo) {
        if (self.IsTenant == true) {
            for (var i = 0 ; i < self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.length; i++)
            {
                var existingTenant;
                if(self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].IsDeleted == false)
                {
                    _userInfo.TenantUserInfo.AddressLine1 = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].TenantUserInfo.AddressLine1;
                    _userInfo.TenantUserInfo.AddressLine2 = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].TenantUserInfo.AddressLine2;
                    _userInfo.TenantUserInfo.City = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].TenantUserInfo.City;
                    _userInfo.TenantUserInfo.State = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].TenantUserInfo.State;
                    _userInfo.TenantUserInfo.Zip = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[i].TenantUserInfo.Zip;
                    break;
                }               
            }
            //_userInfo.TenantUserInfo.AddressLine1 = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.AddressLine1;
            //_userInfo.TenantUserInfo.AddressLine2 = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.AddressLine2;
            //_userInfo.TenantUserInfo.City = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.City;
            //_userInfo.TenantUserInfo.State = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.State;
            //_userInfo.TenantUserInfo.Zip = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.Zip;
            //_userInfo.TenantUserInfo.PhoneNumber = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.PhoneNumber;
           // _userInfo.TenantUserInfo.Email = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo[0].TenantUserInfo.Email;
        }
        if (_userInfo.TenantUserInfo.FirstName != null && _userInfo.TenantUserInfo.FirstName != "" &&
            _userInfo.TenantUserInfo.AddressLine1 != null && _userInfo.TenantUserInfo.AddressLine1 != "" &&
             _userInfo.TenantUserInfo.City != null && _userInfo.TenantUserInfo.City != "" &&
             _userInfo.TenantUserInfo.Zip != null && _userInfo.TenantUserInfo.Zip != "") {
            var _userInfo1 = angular.copy(_userInfo);
            //  var _userInfo = self.caseinfo.OwnerPetitionTenantInfo;
            self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.push(_userInfo1);
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.FirstName = null;
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.LastName = null;
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.PhoneNumber = null;
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Email = null;
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine1 = "";
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine2 = "";
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.City = "";
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.State.StateName = "";
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Zip = 0;
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.PhoneNumber = 0;
            //self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Email = "";
            _GetIsTenant();
        }
    }
    self.RemoveTenant = function (_tenant) {
        var index = self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.indexOf(_tenant);
        self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.splice(index, 1);
        _tenant.IsDeleted = true;
        self.caseinfo.OwnerResponseInfo.PropertyInfo.TenantInfo.push(_tenant);
        _GetIsTenant();
        if (self.IsTenant == false) {
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine1 = "";
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.AddressLine2 = "";
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.City = "";
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.State.StateName = "";
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Zip =null;
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.PhoneNumber = null;
            self.caseinfo.OwnerPetitionTenantInfo.TenantUserInfo.Email = "";
        }
        //self.caseinfo.OwnerPetitionInfo.PropertyInfo.TenantInfo = self.caseinfo.OwnerPetitionInfo.PropertyInfo.TenantInfo.update(
        //    self.caseinfo.OwnerPetitionInfo.PropertyInfo.TenantInfo.indexOf(function (item) {
        //        return item.TenantUserInfo.FirstName == _tenant.TenantUserInfo.FirstName && item.TenantUserInfo.LastName == _tenant.TenantUserInfo.LastName;
        //    }), function (item) { return item.set(item.IsDeleted, true); }
        //    );    
        //self.caseinfo.OwnerPetitionInfo.PropertyInfo.TenantInfo.remove(_tenant);
        //_tenant.IsDeleted = true;
        //self.caseinfo.OwnerPetitionInfo.PropertyInfo.TenantInfo.push(_tenant);
    }

}];
var rapOwnerRentalPropertyController_resolve = {
    model: ['$route', 'alertService', 'rapOwnerRentalPropertyFactory', function ($route, alert, rapFactory) {
        ////return auth.fetchToken().then(function (response) {
        //return rapFactory.GetTenantPetetionFormInfo().then(function (response) {
        //  if (!alert.checkResponse(response)) { return; }
        //        return response.data;
        //    });
    }]
}
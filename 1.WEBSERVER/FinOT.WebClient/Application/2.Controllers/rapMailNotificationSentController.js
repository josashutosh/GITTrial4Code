﻿var rapMailNotificationSentController = ['$scope', 'alertService', '$location', 'rapGlobalFactory', 'masterdataFactory', function ($scope, alert, $location, rapGlobalFactory, masterFactory) {
    var self = this;
    //self.custDetails = rapGlobalFactory.CityUser;
    //if (rapGlobalFactory.SelectedCase == null || rapGlobalFactory.SelectedCase == undefined)
    //{
    //    $location.path("/staffdashboard");
    //}
    //self.c_id = rapGlobalFactory.SelectedCase.C_ID;
    //self.caseinfo = rapGlobalFactory.SelectedCase;
    self.Title = '';
    if (rapGlobalFactory.MailNotification == null || rapGlobalFactory.MailNotification == undefined) {
        var userType = rapGlobalFactory.GetUserType();
        if (userType == 'PublicUser') {
            $location.path("/publicdashboard");
        }
        else if (userType == 'CityUser') {
            $location.path("/staffdashboard");
        }
    }
    self.model = rapGlobalFactory.MailNotification;
    self.caseid = rapGlobalFactory.Notification_CaseID;

    if (rapGlobalFactory.FromSelectedCase == true) {

        self.Title = 'Staff Dashboard';
    }
    else {
        self.Title = 'Dashboard';
    }
    //self.Recipient = null;
    //for (var i = 0 ; i < self.model.Message.RecipientAddress.length; i++)
    //{
    //    if(i == 0)
    //    {
    //        self.Recipient = self.model.Message.RecipientAddress[i];
    //        self.Recipient = self.Recipient + ',' + self.model.Message.RecipientAddress[i];
    //    }
    //}

    //var _date = function () {
    //    var today = new Date();
    //    var dd = today.getDate();
    //    var mm = today.getMonth() + 1; //January is 0!
    //    var yyyy = today.getFullYear();

    //    if (dd < 10) {
    //        dd = '0' + dd
    //    }

    //    if (mm < 10) {
    //        mm = '0' + mm
    //    }

    //    today = mm + '-' + dd + '-' + yyyy;
    //    return today;
    //}
    //if (!(self.model.MailingDate == null || self.model.CreatedDate == undefined)) {
    //    self.Date = self.model.MailingDate;
    //}
   //    self.SentBy = rapGlobalFactory.CityUser.FirstName + ' ' + rapGlobalFactory.CityUser.LastName;
    self.BackToCase = function () {
        rapGlobalFactory.MailNotification = null;
        rapGlobalFactory.Notification_CaseID = null;
        if (rapGlobalFactory.FromSelectedCase == true) {
            rapGlobalFactory.FromSelectedCase = false;
            $location.path("/selectedcase");
        }
        else {
            $location.path("publicdashboard");
        }       
    }

}];

var rapMailNotificationSentController_resolve = {
    model: ['$route', 'alertService', function ($route, alert) {

    }]
}
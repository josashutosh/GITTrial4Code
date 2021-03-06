﻿'use strict';
var rapSelectedCaseFactory = ['blockUI', 'ajaxService', function (blockUI, ajax) {
    var factory = {};
    var _routePrefix = 'api/accountmanagement';

    var _GetSelectedCase = function (C_ID) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/GetSelectedCase';
        if (!(C_ID == null || C_ID == undefined)) { url = url + '/' + C_ID; }

        return ajax.Get(url)
       .finally(function () {
           blockUI.stop();
       });
    }
    var _GetCaseInfoWithModel = function (model) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/getcaseinfo';

        //if (!(caseid == null || caseid == undefined)) { url = url + '/' + caseid; }

        return ajax.Post(model, url)
       .finally(function () {
           blockUI.stop();
       });
    }


    var _GetCaseActivityStatus = function (model) {
        blockUI.start();

        var url = 'api/dashboard' + '/getcaseactivitystatus';

        return ajax.Post(model, url)
        .finally(function () {
            blockUI.stop();
        });
    }

    var _GetCaseInfo = function () {
        blockUI.start();

        var url = _routePrefix + '/getcaseinfo';

        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetTenantAppealInfoForView = function (CID) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/GetTenantAppealInfoForView';
        if (!(CID == null || CID == undefined)) { url = url + '/' + CID; }

        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetPetitionViewInfo = function (CID) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/GetPetitionViewInfo';
        if (!(CID == null || CID == undefined)) { url = url + '/' + CID; }

        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetTenantResponseViewInfo = function (CID) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/GetTenantResponseViewInfo';
        if (!(CID == null || CID == undefined)) { url = url + '/' + CID; }

        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetOResponseViewByCaseID = function (CID) {
        blockUI.start();
        var url = 'api/applicationprocessing' + '/GetOResponseViewByCaseID';
        if (!(CID == null || CID == undefined)) {
            url = url + '/' + CID;
        }

        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _getCaseDocuments = function (cid) {
        blockUI.start();
        var url = 'api/dashboard' + '/GetCaseDocuments';
        if (!(cid == null || cid == undefined)) { url = url + '/' + cid; }
        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }

    var _GetCustomEmailNotification = function (cid, activityid, NotificationID) {
        blockUI.start();
        var url = 'api/dashboard' + '/GetCustomEmailNotification';
        if (!(cid == null || cid == undefined)) { url = url + '/' + cid; }
        if (!(activityid == null || activityid == undefined)) { url = url + '/' + activityid; }
        if (!(NotificationID == null || NotificationID == undefined)) { url = url + '/' + NotificationID; }
        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetMailNotification = function (NotificationID) {
        blockUI.start();
        var url = 'api/dashboard' + '/GetMailNotification';
        if (!(NotificationID == null || NotificationID == undefined)) { url = url + '/' + NotificationID; }
        return ajax.Get(url)
        .finally(function () {
            blockUI.stop();
        });
    }
    factory.GetPetitionViewInfo = _GetPetitionViewInfo;
    factory.GetCaseInfo = _GetCaseInfo;
    factory.GetSelectedCase = _GetSelectedCase;
    factory.GetCaseInfoWithModel = _GetCaseInfoWithModel;
    factory.GetCaseActivityStatus = _GetCaseActivityStatus;
    factory.GetAppealInfoForView = _GetTenantAppealInfoForView;
    factory.GetTenantResponseViewInfo = _GetTenantResponseViewInfo;
    factory.GetCaseDocuments = _getCaseDocuments;
    factory.GetCustomEmailNotification = _GetCustomEmailNotification;
    factory.GetMailNotification = _GetMailNotification;
    factory.GetOResponseViewByCaseID = _GetOResponseViewByCaseID;

    return factory;
}];
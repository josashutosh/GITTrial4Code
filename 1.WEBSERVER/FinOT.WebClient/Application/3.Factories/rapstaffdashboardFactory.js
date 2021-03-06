﻿'use strict';
var rapstaffdashboardFactory = ['blockUI', 'ajaxService', function (blockUI, ajax) {
    var factory = {};
    var _routePrefix = 'api/accountmanagement';
  
    var _GetCasesNoAnalyst = function (UserID) {
        blockUI.start();

        var url = 'api/applicationprocessing' + '/getcasesnoanalyst';
        if (!(UserID == null || UserID == undefined)) { url = url + '/' + UserID; }

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
    var _GetCaseActivityStatus = function(model) {
        blockUI.start();

        var url = 'api/dashboard' + '/getcaseactivitystatus';

        return ajax.Post(model, url)
        .finally(function () {
            blockUI.stop();
         });
    }
    var _GetEmptyCaseSearchModel = function () {
        blockUI.start();

        var url = 'api/dashboard' + '/GetEmptyCaseSearchModel';

        return ajax.Get(url)
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
    var _GetCaseSearch = function (model) {
        blockUI.start();
        var url = 'api/dashboard' + '/GetCaseSearch/'

        return ajax.Post(model, url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetCaseswithNoAnalyst = function (model, UserID) {
        blockUI.start();
        var url = 'api/dashboard' + '/GetCaseswithNoAnalyst/' + UserID;

        return ajax.Post(model, url)
        .finally(function () {
            blockUI.stop();
        });
    }
     
    factory.GetCaseInfo = _GetCaseInfo;
    factory.GetCasesNoAnalyst = _GetCasesNoAnalyst;
    factory.GetCaseSearch = _GetCaseSearch;
    factory.GetCaseInfoWithModel = _GetCaseInfoWithModel;
    factory.GetCaseActivityStatus = _GetCaseActivityStatus;
    factory.GetEmptyCaseSearchModel = _GetEmptyCaseSearchModel;
    factory.GetCaseswithNoAnalyst = _GetCaseswithNoAnalyst;


    return factory;
}];
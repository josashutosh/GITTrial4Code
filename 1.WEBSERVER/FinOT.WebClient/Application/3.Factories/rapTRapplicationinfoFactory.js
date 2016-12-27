﻿'use strict';
var rapTRapplicationinfoFactory = ['blockUI', 'ajaxService', function (blockUI, ajax) {
    var factory = {};
    var _routePrefix = 'api/applicationprocessing';

    var _SaveApplicationInfo = function (model) {
        blockUI.start();

        var url = _routePrefix + '/saveapplicationinfo';

        return ajax.Post(model, url)
        .finally(function () {
            blockUI.stop();
        });
    }
    var _GetTenantResponseApplicationInfo = function (CaseNumber, customerid) {
        blockUI.start();

        var url = _routePrefix + '/gettenantresponseapplicationinfo/' + CaseNumber;
        if (!(customerid == null || customerid == undefined)) { url = url + '/' + customerid; }

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


    factory.GetCaseInfo = _GetCaseInfo;
    factory.SaveApplicationInfo = _SaveApplicationInfo;
    factory.GetTenantResponseApplicationInfo = _GetTenantResponseApplicationInfo;
    
    return factory;
}];
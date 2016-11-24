﻿'use strict';
var rapapplicationinfoFactory = ['blockUI', 'ajaxService', function (blockUI, ajax) {
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
    factory.SaveApplicationInfo = _SaveApplicationInfo;
    
    return factory;
}];
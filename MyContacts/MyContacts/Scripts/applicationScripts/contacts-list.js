﻿$('.btn-add-new').unbind('click').click(function () {
    var btnObj = $(this);
    var dialogTitle = btnObj.attr('title');
    var key = btnObj.data('objectKey') ? btnObj.data('objectKey') : "";
    var params = {
        'key': key
    };
    $.ajax({
        Type: 'GET',
        url: '/api/contact/Edit',
        dataType: 'json',
        data: params,
        success: function (response) {
            var editContactDialog = $('#contactEdit');
            $('#modalTitle', editContactDialog).html(dialogTitle);
            $('input[name="Key"]', editContactDialog).val(response.ContactKey);
            $('#contactEdit').modal('show');
        },
        error: function (textStatus) {
            alert(textStatus);
        }
    });
});

$('.btn-edit').unbind('click').click(function () {
    var btnObj = $(this);
    var dialogTitle = btnObj.attr('title');
    var key = btnObj.data('objectKey') ? btnObj.data('objectKey') : "";
    var params = {
        'key': key
    };
    $.ajax({
        Type: 'GET',
        url: '/api/contact/Edit',
        dataType: 'json',
        data: params,
        success: function (response) {
            var editContactDialog = $('#contactEdit');
            $('#modalTitle', editContactDialog).html(dialogTitle);
            $('input[name="Key"]', editContactDialog).val(response.ContactKey ? response.ContactKey : "");

            $('input[name="FirstName"]', editContactDialog).val(response.FirstName ? response.FirstName : "");
            $('input[name="LastName"]', editContactDialog).val(response.LastName ? response.LastName : "");
            $('input[name="Address1"]', editContactDialog).val(response.Address1 ? response.Address1 : "");
            $('input[name="Address2"]', editContactDialog).val(response.Address2 ? response.Address2 : "");
            $('input[name="City"]', editContactDialog).val(response.City ? response.City : "");
            $('input[name="State"]', editContactDialog).val(response.State ? response.State : "");
            $('input[name="Zip"]', editContactDialog).val(response.ZipCode ? response.ZipCode : "");
            $('input[name="Email"]', editContactDialog).val(response.Email ? response.Email : "");
            $('input[name="Phone"]', editContactDialog).val(response.Phone ? response.Phone : "");
            $('#contactEdit').modal('show');
        },
        error: function (textStatus) {
            alert(textStatus);
        }
    });
});

$('.btn-save').unbind('click').click(function() {
    
});

$('.btn-delete').unbind('click').click(function () {
    $('#contactDelete').modal('show'); 
});

$('.btn-load-vcard').unbind('click').click(function () {
    var btnObj = $(this);

    var itemKey = btnObj.data('objectKey');
    var entityType = btnObj.data('objectType');
    var vCardVersion = btnObj.data('vcardVersion');
    var exportType = btnObj.data('exportType');
    var targetUrl = btnObj.data('url');

    var params = {
        'key': itemKey,
        'version': vCardVersion
    };

    var clbk = exportType == 'file'
        ? responseToFile
        : responseToClipboard;

    getVcfData(entityType, targetUrl, params, clbk);

    return true;
});

function getVcfData(entityType, targetUrl, params, contentCallback) {
    var xhr = $.ajax({
        Type: 'GET',
        url: '/api/' + entityType + '/' + targetUrl,
        data: params,
        success: function (response) {
            var contentHeader = xhr.getResponseHeader('content-disposition');
            var fileName = '';
            if (contentHeader) {
                fileName = contentHeader.substr(contentHeader.indexOf("=") + 1);
            }
            if (typeof contentCallback === 'function') {
                contentCallback(response, fileName);
            }
        },
        error: function (textStatus) {
            alert(textStatus);
        }
    });
}

function responseToFile(response, fileName) {
    var blob = new Blob([response]);

    window.URL = window.URL || window.webkitURL;
    var link = window.URL.createObjectURL(blob);
    var a = document.createElement("a");
    a.download = a.pathname = fileName.replace(/['"]+/g, '');
    a.href = link;

    document.body.appendChild(a);

    a.click();

    document.body.removeChild(a);
}

function responseToClipboard(response) {
    if (navigator.clipboard) {
        navigator.clipboard.writeText(response);
    } else {
        var aux = $("<textarea />").appendTo('body');
        aux.val(response);
        aux.select();
        document.execCommand('copy');
        aux.remove();
    }
}
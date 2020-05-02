
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
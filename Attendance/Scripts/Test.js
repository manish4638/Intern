/// <reference path="jquery-1.9.1.intellisense.js" />


$(document).ready(function () {
    loadData();
});
function loadData() {
    $.ajax({
        url: "api/APIEmployee",
        type: "GET",
        contentType: "json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.EID + '</td>';
                html += '<td>' + item.FULL_NAME + '</td>';
                html += '<td>' + item.ADDRESS + '</td>';
                html += '<td>' + item.CONTACT + '</td>';
                html += '<td>' + item.EMAIL + '</td>';              
                
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

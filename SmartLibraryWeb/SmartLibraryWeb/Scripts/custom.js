
//Search without clicking search button
//$("#txtBoxSearch").keyup(function () {
//     $('#BookListTable tr td a:not([title^="c#"])').parents('tr').hide()
//    alert($("#txtBoxSearch").val());
//});

function SearchBook() {
    debugger;
    $('#BookListTable tr').show();
    $("#NotFoundDiv").hide();
    var textInput = $('#txtBoxSearch').val().toLowerCase();

    if (textInput.trim().length == 0)
        return;

    if ($("#BookListTable tr td a[title*=" + "'" + textInput + "'" + "]").parents('tr').length == 0) {
        $("#NotFoundDiv").show();
    }

    $("#BookListTable tr td a:not([title*=" + "'" + textInput + "'" + "])").parents('tr').hide();
}
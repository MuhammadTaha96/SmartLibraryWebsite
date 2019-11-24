
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

function CallRenderComments(bookId) {
    debugger;
    $("#loading").show();
    $('.modal-title').text('Comments');
    var url = $('#CommentPartialView').val();
    $.ajax({
        url: url,
        type: 'POST',
        data: { bookId: bookId },
        closeBtn: 'true',
        success: function (data) {
            $("#loading").hide();
            $('#modal-data').html(data);
            //   $('#myModal').modal('show');
        },
        error: function (req, status, error) {
        },
        complete: function () {

        },
    });
}
function CallRenderReviews(bookId) {
    $("#loading").show();
    $('.modal-title').text('Reviews');
    var url = $('#ReviewPartialView').val();
    $.ajax({
        url: url,
        type: 'POST',
        data: { bookId: bookId },
        closeBtn: 'true',
        success: function (data) {
            $("#loading").hide();
            $('#modal-data').html(data);
            //   $('#myModal').modal('show');
        },
        error: function (req, status, error) {
        },
        complete: function () {

        },
    });
}

function ShowBookLocation(bookId) {
    debugger;
    $("#loading").show();
    $('.modal-title').text('Book Location');
    var url = $('#BookLocationPartialView').val();
    $.ajax({
        url: url,
        type: 'POST',
        data: { bookId: bookId },
        closeBtn: 'true',
        success: function (data) {
            $("#loading").hide();
            $('#modal-data').html(data);
            //   $('#myModal').modal('show');
        },
        error: function (req, status, error) {
        },
        complete: function () {

        },
    });
}

function AddComment() {
    debugger;
    var commentText = $('#textarea-comment').val();
    if (commentText.trim() == "") {
        $('#commentBoxError').show();
        return;
    }
    $('#commentBoxError').hide();
    $('.modal-title').text('Comments');
    $("#loading").show();

    var bookId = $('#BookId').val();
    var commentText = $('#textarea-comment').val();
    var userLoginId = $('#LoginUser').attr('userloginid');
    var url = $('#AddCommentUrl').val();

    $.ajax({
        url: url,
        type: 'POST',
        data: { bookId: bookId, commentText: commentText, userLoginId: userLoginId },
        closeBtn: 'true',
        success: function (data) {
            CallRenderComments(bookId);
            $("#loading").hide();
            //   $('#myModal').modal('show');
        },
        error: function (req, status, error) {
        },
        complete: function () {

        },
    });
}

function PopulateCategoryFilter() {
    var tblBooks = $('#BookListTable').dataTable();
    tblBooks.api().columns('colCategory:name').every(function () {

        var column = this;
        var ddlCategoryFilter = $('#ddlCategoryFilter')
            .on('change', function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );
                column
                    .search(val ? '^' + val + '$' : '', true, false)
                    .draw();
            });

        // Populate Category Filter DDL...
        ddlCategoryFilter.empty();
        $(document.createElement('option')).attr('value', '').text('All Categories').appendTo(ddlCategoryFilter);
        column.data().unique().sort().each(function (d, j) {
            $(document.createElement('option')).attr('value', d).text(d).appendTo(ddlCategoryFilter);
        });
    });
}

function PopulateLanguageFilter() {
    var tblBooks = $('#BookListTable').dataTable();
    tblBooks.api().columns('colLanguage:name').every(function () {

        var column = this;
        var ddlLanguageFilter = $('#ddlLanguageFilter')
            .on('change', function () {
                var val = $.fn.dataTable.util.escapeRegex(
                    $(this).val()
                );
                column
                    .search(val ? '^' + val + '$' : '', true, false)
                    .draw();
            });

        // Populate Category Filter DDL...
        ddlLanguageFilter.empty();
        $(document.createElement('option')).attr('value', '').text('All Languages').appendTo(ddlLanguageFilter);
        column.data().unique().sort().each(function (d, j) {
            $(document.createElement('option')).attr('value', d).text(d).appendTo(ddlLanguageFilter);
        });
    });
}
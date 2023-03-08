
$(document).on("click", "[data-showAddModel='showAddModel']", function () {
    const url = $(this).attr("data-action");
    const container = $(this).attr("data-container");
    const modal = $(this).attr("data-modal-id");
    $.get(url, null, function (rd) {
        $("#" + container).html(rd);
        $("#" + modal).modal("show");
    })
    
}); 
$(document).on("click", "#btnAddNew", function () {
    var action = $(this).attr("data-action");
    var method = $(this).attr("data-method");
    var formid = "#" + $(this).attr("data-form");

    var actionBind = $(this).attr("data-action-BindGrid");
    var actionRefresh = $(this).attr("data-action-RefreshGrid");
    if (method === "post") {
        var sendingData = $(formid).serialize();

        $.post(action, sendingData, function (op) {
            if (op.success.toString() == "true") {
                $("#exampleModal").modal("hide");
                ShowSuccessMessage(op.message);
                BindGrid(actionBind);
                RefreshsearchBox(actionRefresh);
            }
            else {
                ShowFailMessage(op.message)

            }
        });
    }
});

function BindGrid(url) {
    console.log(url);
    var SendingData = $("#frmSearch").serialize();
    $.get(url, SendingData, function (grd) {
        $("#dvGrid").html(grd);
    });
}


function RefreshsearchBox(url) {
    var SendingData = $("#frmSearch").serialize();
    $.get(url, SendingData, function (frmSearch) {
        $("#dvSearch").html(frmSearch);
    });
}

function ShowSuccessMessage(msg) {
    Swal.fire({
        icon: 'success',
        title: 'وضعیت ثبت',
        text: msg,
    });
}

function ShowFailMessage(msg) {
    Swal.fire({
        icon: 'error',
        title: 'وضعیت ثبت',
        text: msg,
    });
}



$(document).on("click", "[data-Delete='Delete']", function () {
    var actionBind = $(this).attr("data-action-BindGrid");
    var actionRefresh = $(this).attr("data-action-RefreshGrid");
    if (confirm("آیا مطمنید")) {
        var id = $(this).attr("data-id");
        var sendingData = "id=" + id;
        var sendingUrl = $(this).attr("data-action");
        $.post(sendingUrl, sendingData, function (op) {
            if (op.success.toString() == "true") {
                var rowID = "#tr_" + id;
                $(rowID).slideUp(500);
                BindGrid(actionBind);
                RefreshsearchBox(actionRefresh);
            }
            else {
                ErrorMessage(op.message);
            }
        });
    }

});




$(document).on("keyup", "[data-search='search']", function () {
    var action = $(this).attr("data-action");

    BindGrid(action);
    });
$(document).on("change", "[data-search='search']", function () {
    var action = $(this).attr("data-action");
    BindGrid(action);
});

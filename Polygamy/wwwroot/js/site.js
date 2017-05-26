$(function () {
    $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        buttons: {
            "NO": function () {
                $(this).dialog("close");
            },
            "SI": function () {
                $(this).dialog("close");
            }
        }
    });
});
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

$(function () {
    $("#fechaInicio").datepicker({ dateFormat: 'yy-mm-dd' });
    $("#fechaFin").datepicker({ dateFormat: 'yy-mm-dd' });
});

function crearReporte() {
    var fechaInicio = $("#fechaInicio").val();
    var fechaFin = $("#fechaFin").val();
    var url = 'Reporte/Create';

    $.ajax({
        type: 'POST',
        url: url,
        data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
        dataType: "json",
        success: function (response) {
            $("#fechaInicio").val("");
            $("#fechaFin").val("");
            alert(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.responseText);
        }
    });
}
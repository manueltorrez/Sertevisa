$(function () {

    $("a[data-modal=facturaDeta]").on("click", function () {
        $("#facturaDetaModalContent").load(this.href, function () {
            $("#facturaDetaModal").modal({ keyboard: true }, "show");

            $(document).on("submit", "#facturaDetachoice", function () {


                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $("#facturaDetaModal").modal("hide");
                            location.reload();
                        } else {
                            $("#MessageToClient").text("No se pudo actualizar el registro.");
                        }
                    },
                    error: function () {
                        $("#MessageToClient").text("Información inconsistente, no se pudo actualizar el registro .");
                    }
                });
                return false;
            });
        });
        return false;
    });




});



function recalculatePart() {
    var quantity = parseInt(document.getElementById("Cantidad").value).toFixed(0);
    var unitPrice = parseFloat(document.getElementById("Precio").value).toFixed(2);

    if (isNaN(quantity)) {
        quantity = 0;
    }

    if (isNaN(unitPrice)) {
        unitPrice = 0;
    }

    document.getElementById("Cantidad").value = quantity;
    document.getElementById("Precio").value = unitPrice;

    document.getElementById("Subtotal").value = (quantity * unitPrice).toFixed(2);
}

$(document).ready(function () {
    //$(document).on('change', '.productSelect', function () {
    //    var prodId = $('option:selected', this).attr('value');
    //    $.ajax({
    //        url: "/DetalleFacturas/GetProductInfo?productId=" + prodId,
    //        type: 'GET'
    //    }).done(function (price) {
    //        $('.tbPrecio').val(price);
    //    });
    //});

    $(document).on('change', '.cantidad', function () {
        recalculatePart();
    });

    $(document).on('mouseover', '.btnSave', function () {
        $('.cantidad').trigger('change');
    });
    //btnSave
});
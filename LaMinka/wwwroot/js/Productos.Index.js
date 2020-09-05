var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable =
        $('#table').DataTable();
}

function Delete(url) {
    swal({
        title: "Esta seguro que desea eliminar el Producto?",
        text: "No podra recuperar Productos que hayan sido eliminados",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                   
                    location.href = "/Productos";
                }
            });
        }
    });
}
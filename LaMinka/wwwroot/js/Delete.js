var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable =
        $('#table_id').DataTable(

            {

               
            }
        );

    
}

function Delete(url) {
    swal({
        title: "Esta seguro que desea eliminar el Usuario?",
        text: "No podra recuperar Usuarios que hayan sido eliminados",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
                url: url,
                success: function (data) {
                    
                        location.href = "/Users";

                        dataTable.ajax.reload();
                    
                    
                }
            });
        }
    });
}
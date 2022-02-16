var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblCountry").DataTable(
        {
            "ajax": {
                "url": "/Admin/Countries/GetAllCountries",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "countryName", "width": "25%" },
                { "data": "countryDescription", "width": "25%" },
                { "data": "isdCode", "width": "25%" },
                {
                    "data": "countryId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="Countries/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("/Admin/Countries/DeleteCountry/${data}") class="btn btn-danger text-white"
                                style='cursor:pointer:'><i class='far fa-trash-alt'></i></a>
                            </div>
                            `;
                    },
                    "width": "33%"
                }
            ],
            "dom": 'Bfrtip',
            "buttons": [
                'copy', 'csv', 'excel', 'pdf', 'print',  'pageLength'
            ],
            "responsive": true,
            "lengthMenu": [[10, 20, 30, 50, 100, -1], [10, 20, 30, 50, 100, "All"]]     // page length options
        }
    );
}

function Delete(url) {
    swal({
        title: "Are your sure you want to delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerousMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        //toastr.success(data.message);
                        //dataTable.ajax.reload();
                        window.location.href = '/Admin/Countries/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}
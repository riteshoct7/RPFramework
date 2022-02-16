var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblState").DataTable(
        {
            "ajax": {
                "url": "/Admin/States/GetAllStates",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "stateName", "width": "16%" },
                { "data": "stateDescription", "width": "16%" },
                { "data": "countries.countryName", "width": "16%" },
                { "data": "countries.countryDescription", "width": "16%" },
                { "data": "countries.isdCode", "width": "16%" },
                {
                    "data": "stateId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="States/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("/Admin/States/DeleteState/${data}") class="btn btn-danger text-white"
                                style='cursor:pointer:'><i class='far fa-trash-alt'></i></a>
                            </div>
                            `;
                    },
                    "width": "25%"
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
                        window.location.href = '/Admin/States/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}
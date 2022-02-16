var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblCity").DataTable(
        {
            "ajax": {
                "url": "/Admin/Cities/GetAllCities",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "cityName", "width": "12%" },
                { "data": "cityDescription", "width": "12%" },
                { "data": "states.stateName", "width": "12%" },
                { "data": "states.stateDescription", "width": "12%" },
                { "data": "states.countries.countryName", "width": "12%" },
                { "data": "states.countries.countryDescription", "width": "12%" },
                { "data": "states.countries.isdCode", "width": "12%" },
                {
                    "data": "cityId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="Cities/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("/Admin/Cities/DeleteCity/${data}") class="btn btn-danger text-white"
                                style='cursor:pointer:'><i class='far fa-trash-alt'></i></a>
                            </div>
                            `;
                    },
                    "width": "12%"
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
                        window.location.href = '/Admin/Cities/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}
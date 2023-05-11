let dataTable;

$(document).ready(function () {
    loadDataTable();
    loadDataDefault();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            url: '/admin/author/getall',
            dataSrc: "data",
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'description' },
            { data: 'dob' },
            { data: 'createAt' },
            {
                data: 'id',
                render: function (data) {
                    return `
                          <a onClick=loadDataEdit('/admin/author/getone/${data}') class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                          <a onClick=deleteCategory('/admin/author/delete/${data}') class="btn btn-sm btn-danger"><i class="bi bi-trash3-fill"></i></a>
                    `
                }
            }
        ]
    });
}

function deleteCategory(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function ({ success, message }) {
                    dataTable.ajax.reload();
                    toastr.success(message);
                }
            })
        }
    })
}

function loadDataDefault() {
    $("#btnUpdateData").click(function () {
        const dataPost = {
            id: $(`#updateModal #idEdit`).val(),
            name: $(`#updateModal #nameEdit`).val(),
            description: $(`#updateModal #descriptionEdit`).val(),
        }

        if ($(`#updateModal #dobEdit`).val()) {
            dataPost.dob = $(`#updateModal #dobEdit`).val();
        }


        $.post(`/admin/author/edit/${dataPost.id}`, dataPost, function ({ status, message }) {
            if (status) {
                dataTable.ajax.reload();
                $(`#updateModal`).modal('hide');
            }
        })
    })
}

function loadDataEdit(url) {
    $.get(url, function ({ data }) {
        $(`#updateModal`).modal('show');

        $(`#updateModal #idEdit`).val(data.id);
        $(`#updateModal #nameEdit`).val(data.name);
        $(`#updateModal #descriptionEdit`).val(data.description);
        $(`#updateModal #dobEdit`).val(data.dob);
    })
}
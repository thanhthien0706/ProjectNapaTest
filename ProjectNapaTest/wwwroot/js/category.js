let dataTable;

$(document).ready(function () {
    loadDataTable();
    loadDataDefault();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            url: '/admin/category/getall',
            dataSrc: "data",
        },
        columns: [
            { data: 'id' },
            { data: 'title' },
            { data: 'displayOrder' },
            { data: 'createAt' },
            {
                data: 'id',
                render: function (data) {
                    return `
                          <a onClick=loadDataEdit('/admin/category/getone/${data}') class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                          <a onClick=deleteCategory('/admin/category/delete/${data}') class="btn btn-sm btn-danger"><i class="bi bi-trash3-fill"></i></a>
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
            title: $(`#updateModal #nameEdit`).val(),
            displayOrder: $(`#updateModal #displayOrderEdit`).val(),
        }

        $.post(`/admin/category/edit/${dataPost.id}`, dataPost, function ({ status, message }) {
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
        $(`#updateModal #nameEdit`).val(data.title);
        $(`#updateModal #displayOrderEdit`).val(data.displayOrder);
    })
}
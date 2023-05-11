let dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            url: '/admin/book/getall',
            dataSrc: "data",
        },
        columns: [
            { data: 'id' },
            {
                data: 'thumbnail',
                render: function (data) {
                    return `<img src="${data}" class="img-rounded" alt="Cinque Terre" width="70" height="70">`
                }
            },
            { data: 'title' },
            { data: 'subDescription' },
            { data: 'yearPublished' },
            { data: 'author.name' },
            { data: 'category.title' },
            { data: 'createAt' },
            {
                data: 'id',
                render: function (data) {
                    return `
                          <a href="/admin/book/upsert/${data}" class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                          <a onClick=deleteCategory('/admin/book/delete/${data}') class="btn btn-sm btn-danger"><i class="bi bi-trash3-fill"></i></a>
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

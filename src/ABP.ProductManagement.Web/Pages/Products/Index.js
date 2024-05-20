$(function () {
    var l = abp.localization.getResource('ProductManagement'); // 在js程式中也可以使用i18n語言
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditProductModal');

    editModal.onResult(function () { // 當編輯視窗關閉後，重新載入表格
        dataTable.ajax.reload();
    });

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({ // abp的datatable
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                aBP.productManagement.products.product.getList
            ),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('CategoryName'),
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('StockState'),
                    data: "stockState",
                    render: function (data) {
                        return l('Enum:StockState:' + data);
                    }
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    dataFormat: 'date'
                },
                {
                    title: l('Actions'), // 操作row
                    rowAction: { // abp的row，可以添加一個或多個操作
                        items: [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id }); // 打開編輯視窗，跟據 row id
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) { // 確認是否刪除視窗
                                    return l('ProductDeleteConfirmationMessage', data.record.name);
                                },
                                action: function (data) {
                                    aBP.productManagement.products.product
                                        .delete(data.record.id) // 註冊 promise
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        })
                                }
                            }
                        ]
                    }
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateProductModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
})
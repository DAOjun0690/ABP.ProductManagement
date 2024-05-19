$(function () {
    var l = abp.localization.getResource('ProductManagement'); // 在js程式中也可以使用i18n語言
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditProductModal');

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
                }
            ]
        })
    )
})
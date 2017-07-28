/// <reference path="../_references.ts" />
module Swu {

    @Module("app")
    @Constant({ name: "AppConstant" })
    export class AppConstant {
        constructor() {

        }
        api = {
            protocal: "http",
            ip: "localhost",
            port: "8081",
            versionName: "V1",
        };
        gridOptions: ngGrid.IGridOptions = {
            showFilter: false,
            multiSelect: false,
            enableSorting: false,
            enablePaging: true,
            enableColumnResize: true,
            showFooter: true,
            enableCellSelection: false,
            enableRowSelection: true,
            selectedItems: [],
            pagingOptions: {
                pageSizes: [5, 10, 50],
                pageSize: '5',
                currentPage: 1,
                totalServerItems: 0,
            },
        };
    }
}
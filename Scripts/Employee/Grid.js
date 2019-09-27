

Employee.prototype.Grid = new Grid();
function Grid() {
    var gridObj = this;
    gridObj.SelectId = []
    gridObj.id = "";
    gridObj.GetGridDetails = function () {
        $.ajax({
            type: "Get",
            url: '/Employee/GetGridInfo',//@Url.Action("GetGridInfo", "Employee")',
            success: function (data) {
                debugger;
                $('#formId').empty();
                $('.container').show();
                $('#gridId').html(data);
                $("#btnAdd").click(function () {
                    baseObj.form.GetForm(0);
                });
                $(".glyphicon-pencil").click(function () {
                    debugger;
                    var empId = $(this).attr("data-id");
                    baseObj.form.GetForm(empId);
                    return false;
                });
                $(".glyphicon-trash").click(function () {
                    debugger;
                    var empId = $(this).attr("data-id");
                    gridObj.Delete(empId);
                    return false;
                });
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    }
    $("#btnClear1").click(function () {
        alert("clear");
    });
   
    gridObj.Delete = function (empId) {
        debugger;
        $.ajax({
            url: '/Employee/DeleteGrid', //@Url.Action("DeleteGrid", "Employee" )',
            type: "POST",
            data: { id: empId },
            success: function (data) {
                debugger;
                gridObj.GetGridDetails();
               
            },
            error: function (obj) {
                debugger;
                alert("Error while inserting data");
            }
        });

    }



}
baseObj.Grid.GetGridDetails();




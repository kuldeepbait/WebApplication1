
var baseObj = new Employee();
Employee.prototype.form = new form();
function form() {
    var formObj = this;
    formObj.GetForm = function (empId) {
        debugger;
        $.ajax({
            url: '/Employee/EditDetailsClientSide',
            type: "Get",
            data: { id: empId },
            success: function (data) {
                debugger;
                $('.container').hide();
                $('#formId').html(data);
                //  $.validator.unobtrusive.parse($("#formPostId"));
                $("#btnClear").click(function () {
                    debugger;
                    baseObj.Grid.GetGridDetails();
                });
                $("#btnSave1").click(function () {
                    debugger;
                    var emp = {};
                    emp.id = $("#id").val();
                    emp.name = $("#name").val();
                    emp.Salary = $("#Salary").val();

                    $.ajax({
                        type: "POST",
                        url: 'http://localhost:55790/api/SaveEmployee', //'@Url.Action("SaveGridDetails", "Finance")',
                        data: JSON.stringify(emp),
                        dataType: "JSON",
                        contentType: "application/json; charset=UTF-8", //
                       
                        success: function (data) {
                            debugger;
                            $('.container').show();
                            return false;
                        },
                        error: function (x) {
                            debugger;
                            alert("Error while inserting data");
                        }
                    });
                    return false;
                });

            },
            error: function (obj) {
                debugger;
                alert("Error while inserting data");
            }
        });
    }
    formObj.OnSuccess = function () {
        debugger;
        baseObj.Grid.GetGridDetails();
    }
    formObj.OnFailure = function () {
        debugger;
        alert("failure");
    }
}
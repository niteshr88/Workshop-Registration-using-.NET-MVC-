$(document).ready(function () {
    GetTechnology();
});

function GetTechnology() {
    $.ajax({
        type: "GET",
        url: "../Workshop/GetTechnologyList",
        data: "{}",
        dataType: "json",
        asnc: false,
        success: function (data) {
            $("#ddTechnology").val(0);
            $("#ddTechnology").html("");
            $("#ddTechnology").append($("<option></option>").val(0).html("-Select-"));
            $.each(data, function (i, item) {
                $("#ddTechnology").append($("<option></option>").val(item.techID).html(item.name));
            });
        },
        error: function (result) {
            $("#ddTechnology").append($("<option></option>").val(0).html("select Technology"));
        }
    });
}
function AddStudents() {

    var txtFullName = $("#txtFullName");
    var ddLocation = $("#ddLocation");
    var ddTechnology = $("#ddTechnology"); 
    var txtEmailID = $("#txtEmailID");
    var txtContactNo = $("#txtContactNo");
    var ddCourse = $("#ddCourse");
    var ddBranch = $("#ddBranch");
    var ddSemester = $("#ddSemester");
    var txtCollege = $("#txtCollege");

    var WorkshopVM =
    {
        name: txtFullName.val().trim(),
        location: ddLocation.val(),
        technology: ddTechnology.val(),
        email: txtEmailID.val().trim(),
        contactNo: txtContactNo.val().trim(),
        course: ddCourse.val(),
        branch: ddBranch.val(),
        semester: ddSemester.val(),
        college: txtCollege.val().trim()
    };
    var requestData = { WorkshopVM: WorkshopVM }
    $.ajax({
        url: "../Workshop/Index",
        cache: false,
        type: "POST",
        dataType: "json",
        data: JSON.stringify(requestData),
        contentType: 'application/json',
        success: function (data) {
            if (data.Status === "SUCCESS") {
                setTimeout(
                    function () {
                        alert("Alert", data.ActionMessage);
                        window.location.href = "../Workshop/Index";
                    }, 1000);

            } else {
                alert("Error", data.ActionMessage);
            }
        },

        error: function (err) {
            alert("Error", err)
        }
    });
}
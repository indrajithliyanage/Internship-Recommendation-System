$(document).ready(function () {
    $("#degreeSub").click(function () {
        $("#degreeForm").submit(function (e) {
            e.preventDefault();
        });
        if (DegreeValidate()) {
            DegreeSubmit();
        }
    });
});

function DegreeSubmit() {

    var degreeObject = {};

    degreeObject.DegreeName = $("#DegreeName").val();
    degreeObject.DegreeDescription = $("#DegreeDescription").val();

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/Degree/AddDegree",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, degree: degreeObject },
        success: function (response) {
            var degreeModal = $('#degreeModal');
            degreeModal.find('.modal-body').text(response);
            degreeModal.modal('show');
            $('#degreeForm')[0].reset();
            $('#degreeForm').removeClass('was-validated');
        },
        error: function () {
            var degreeModal = $('#degreeModal');
            degreeModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            degreeModal.modal('show');
        }
    });

}

function DegreeValidate() {
    var isValid = true;
    if ($("#DegreeName").val() == "" || $("#DegreeDescription").val().length > 200) {
        isValid = false;
    }
    return isValid;
}

function deleteDEG(DegreeID) {
    var deleteModal = $('#deleteModal');
    deleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        deleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Degree/DeleteDegree",
            data: { id: DegreeID },
            success: function (response) {
                var generalModal = $('#generalDEGModal');
                generalModal.find('.modal-body').text("Record Deleted Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalDEGModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });
}
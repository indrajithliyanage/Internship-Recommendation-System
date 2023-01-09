$(document).ready(function () {
    $("#uniSub").click(function () {
        $("#uniForm").submit(function (e) {
            e.preventDefault();
        });
        if (UniValidate()) {
            UniSubmit();
        }
    });
});

function UniSubmit() {

    var uniObject = {};

    uniObject.UniversityName = $("#UniversityName").val();
    uniObject.UniversityAddress = $("#UniversityAddress").val();

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/University/AddUniversity",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, university: uniObject },
        success: function (response) {
            var uniModal = $('#uniModal');
            uniModal.find('.modal-body').text(response);
            uniModal.modal('show');
            $('#uniForm')[0].reset();
            $('#uniForm').removeClass('was-validated');
        },
        error: function () {
            var uniModal = $('#uniModal');
            uniModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            uniModal.modal('show');
        }
    });

}

function UniValidate() {
    var isValid = true;
    if ($("#UniversityName").val() == "" || $("#UniversityAddress").val() == "") {
        isValid = false;
    }
    return isValid;
}

function deleteUNI(uniID) {
    var deleteModal = $('#deleteModal');
    deleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        deleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/University/DeleteUniversity",
            data: { id: uniID },
            success: function (response) {
                var generalModal = $('#generalUNIModal');
                generalModal.find('.modal-body').text("Record Deleted Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalUNIModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });
}
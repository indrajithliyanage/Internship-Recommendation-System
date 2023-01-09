$(document).ready(function () {
    if ($("#btncompSub") != undefined) {
        $("#btncompSub").click(function () {
            $("#compForm").submit(function (e) {
                e.preventDefault();
            });
            if (CompValidate()) {
                CompSubmit();
            }
        });
    }    
});

function CompSubmit() {

    var companyObject = {};

    companyObject.CompanyName = $("#CompanyName").val();
    companyObject.HRManager = $("#HRManager").val();
    companyObject.Email = $("#Email").val();
    companyObject.PhoneNo = $("#PhoneNo").val();
    companyObject.CompanyAddress = $("#CompanyAddress").val();  

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/Company/AddCompany",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, company: companyObject },
        success: function (response) {
            var companyModal = $('#companyModal');
            companyModal.find('.modal-body').text(response);
            companyModal.modal('show');
            $('#compForm')[0].reset();
            $('#compForm').removeClass('was-validated')  
        },
        error: function () {
            var companyModal = $('#companyModal');
            companyModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            companyModal.modal('show');
        }
    });

}

function CompValidate() {
    var isValid = true;
    if ($("#CompanyName").val() == "" || $("#CompanyAddress").val() == "") {
        isValid = false;
    } else if ($("#PhoneNo").val() != "") {
        if (!(/^\d{10}$/.test($("#PhoneNo").val()))) {
            isValid = false;
        }
    }
    return isValid;
}

function deleteCOMP(companyID) {
    var deleteModal = $('#deleteModal');
    deleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        deleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Company/DeleteCompany",
            data: { id: companyID },
            success: function (response) {
                var generalModal = $('#generalCOMPModal');
                generalModal.find('.modal-body').text("Record Updated Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalCOMPModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });
}
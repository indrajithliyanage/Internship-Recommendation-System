$(document).ready(function () {
    $("#jobPosSub").click(function () {
        $("#jobPosForm").submit(function (e) {
            e.preventDefault();
        });
        if (JobValidate()) {
            JobSubmit();
        }
    });
});

function JobSubmit() {

    var jobObject = {};

    jobObject.JobPosition = $("#JobPosition").val();
    jobObject.JobDescription = $("#JobDescription").val();

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/JobPosition/AddPosition",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, job: jobObject },
        success: function (response) {            
            var jobModal = $('#jobModal');
            jobModal.find('.modal-body').text(response);
            jobModal.modal('show');
            $('#jobPosForm')[0].reset();
            $('#jobPosForm').removeClass('was-validated');  
        },
        error: function () {
            var jobModal = $('#jobModal');
            jobModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            jobModal.modal('show');
        }
    });

}

function JobValidate() {
    var isValid = true;
    if ($("#JobPosition").val() == "" || $("#JobDescription").val() == "") {
        isValid = false;
    } else if ($("#JobDescription").val().length > 200) {
        isValid = false;
    }    
    return isValid;
}

function deleteJOB(jobID) {
    var deleteModal = $('#deleteModal');
    deleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        deleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/JobPosition/DeleteJob",
            data: { id: jobID },
            success: function (response) {
                var generalModal = $('#generalJOBModal');
                generalModal.find('.modal-body').text("Record Updated Successfully!");
                generalModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var generalModal = $('#generalJOBModal');
                generalModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                generalModal.modal('show');
            }
        });
    });
}
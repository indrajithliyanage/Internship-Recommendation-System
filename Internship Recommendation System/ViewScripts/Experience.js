$(document).ready(function () {
    $("#expSubBtn").click(function () {
        $("#intexpForm").submit(function (e) {
            e.preventDefault();
        });
        if (ExperienceValidate()) {
            IntExpSubmit();
        }
    });
});

function ExperienceValidate() {
    var isValid = true;
    if ($("#CompanyName").val() == "" || $("#JobPosition").val() == "" || $("#YearStarted").val() == "" || $("#UniversityYear_FK").val() == "" || $("#InternshipPeriod").val() == "" || $("#AcceptanceLetterPath").val() == "") {
        isValid = false;
    } else if ($("#Parameter1").val() == "" || $("#Parameter2").val() == "" || $("#Parameter3").val() == "" || $("#Parameter4").val() == "" || $("#Parameter5").val() == "" || $("#Parameter6").val() == "" || $("#Parameter7").val() == "" || $("#Parameter8").val() == "" || $("#Parameter9").val() == "" || $("#Parameter10").val() == "") {
        isValid = false;
    } else if ($("#InternshipPeriod").val() > 24 || $("#InternshipPeriod").val() < 1) {
        isValid = false;
    } else if ($('#AcceptanceLetter').val() == "" || $('#AcceptanceLetter').val() == undefined) {
        isValid = false;
    }
    return isValid;
}

function IntExpSubmit() {
    var experienceFormDataObj = new FormData();
    experienceFormDataObj.append("AcceptanceLetter", $('#AcceptanceLetter')[0].files[0]);
    experienceFormDataObj.append("ServiceLetter", $('#ServiceLetter')[0].files[0]);
    experienceFormDataObj.append("CompanyID_FK", $("#CompanyID_FK").val());
    experienceFormDataObj.append("JobID_FK", $("#JobID_FK").val());
    experienceFormDataObj.append("YearStarted", $("#YearStarted").val());
    experienceFormDataObj.append("UniversityYear_FK", $("#UniversityYear_FK").val());
    experienceFormDataObj.append("InternshipPeriod", $("#InternshipPeriod").val());
    experienceFormDataObj.append("IsCompleted", $("#IsCompleted").prop("checked"));
    experienceFormDataObj.append("Parameter1", $("#Parameter1").val());
    experienceFormDataObj.append("Parameter2", $("#Parameter2").val());
    experienceFormDataObj.append("Parameter3", $("#Parameter3").val());
    experienceFormDataObj.append("Parameter4", $("#Parameter4").val());
    experienceFormDataObj.append("Parameter5", $("#Parameter5").val());
    experienceFormDataObj.append("Parameter6", $("#Parameter6").val());
    experienceFormDataObj.append("Parameter7", $("#Parameter7").val());
    experienceFormDataObj.append("Parameter8", $("#Parameter8").val());
    experienceFormDataObj.append("Parameter9", $("#Parameter9").val());
    experienceFormDataObj.append("Parameter10", $("#Parameter10").val());

    $.ajax({
        url: "/Experience/AddExperience",
        type: "POST",
        data: experienceFormDataObj,
        contentType: false,
        processData: false,
        success: function (response) {
            var expModal = $('#expModal');
            expModal.find('.modal-body').text(response);
            expModal.modal('show');
            $('#intexpForm')[0].reset();
            $('#intexpForm').removeClass('was-validated');
            formSectionController();
            const a = ["parameter1val", "parameter2val", "parameter3val", "parameter4val", "parameter5val", "parameter6val", "parameter7val", "parameter8val", "parameter9val", "parameter10val"];
            for (const element of a) {
                document.getElementById(element).innerHTML = "";
            }
        },
        error: function () {
            var expModal = $('#expModal');
            expModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            expModal.modal('show');
        }
    });
}

function formSectionController() {
    var sliderSection = document.getElementById("sliderSection");
    var formSection = document.getElementById("formSection");
    if (formSectionValidate() && sliderSection.style.display === "none") {
        sliderSection.style.display = "block";
        formSection.style.display = "none";
    } else {
        sliderSection.style.display = "none";
        formSection.style.display = "block";
    }
}

function formSectionValidate() {
    var isValid = true;
    if ($("#CompanyName").val() == "" || $("#JobPosition").val() == "" || $("#YearStarted").val() == "" || $("#UniversityYear_FK").val() == "" || $("#InternshipPeriod").val() == "" || $("#AcceptanceLetterPath").val() == "") {
        isValid = false;
    } else if ($("#InternshipPeriod").val() > 24 || $("#InternshipPeriod").val() < 1) {
        isValid = false;
    } else if ($('#AcceptanceLetter').val() == "" || $('#AcceptanceLetter').val() == undefined) {
        isValid = false;
    }
    return isValid;
}

function approveEXP(IntExpID) {
    var expapproveModal = $('#expapproveModal');
    expapproveModal.modal('show');

    $("#approveBtn").click(function (e) {
        e.preventDefault();
        expapproveModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Experience/ApproveExperience",
            data: { id: IntExpID },
            success: function (response) {
                var expGeneralModal = $('#expGeneralModal');
                expGeneralModal.find('.modal-body').text("Record Approved Successfully!");
                expGeneralModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var expGeneralModal = $('#expGeneralModal');
                expGeneralModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                expGeneralModal.modal('show');
            }
        });
    });
}

function deleteEXP(IntExpID) {
    var expDeleteModal = $('#expDeleteModal');
    expDeleteModal.modal('show');

    $("#deleteBtn").click(function (e) {
        e.preventDefault();
        expDeleteModal.modal('hide');
        $.ajax({
            type: "POST",
            url: "/Experience/DeleteExperience/",
            data: { id: IntExpID },
            success: function (response) {
                var expGeneralModal = $('#expGeneralModal');
                expGeneralModal.find('.modal-body').text("Record Deleted Successfully!");
                expGeneralModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 2000);
            },
            error: function () {
                var expGeneralModal = $('#expGeneralModal');
                expGeneralModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
                expGeneralModal.modal('show');
            }
        });
    });
}
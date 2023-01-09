$(document).ready(function () {
    $("#expSubBtn").click(function () {
        $("#intexpForm").submit(function (e) {
            e.preventDefault();
        });
        if (IntExpValidate()) {
            IntExpSubmit();
        }
    });
    $("#recSubBtn").click(function () {
        $("#recommendationForm").submit(function (e) {
            e.preventDefault();
        });
        if (RecValidate()) {
            RecSubmit();
        }
    });    
});

function IntExpValidate() {
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
        url: "/Home/AddExp",
        type: "POST",
        data: experienceFormDataObj,
        contentType: false,
        processData: false,
        success: function (response) {
            alertify.alert("Alert", response);
            $('#intexpForm')[0].reset();
            const a = ["parameter1val", "parameter2val", "parameter3val", "parameter4val", "parameter5val", "parameter6val", "parameter7val", "parameter8val", "parameter9val", "parameter10val"];
            for (const element of a) { 
                document.getElementById(element).innerHTML = "";
            }
        },
        error: function () { alertify.alert("Alert", "System Ran into an Error! Please Try Again!"); }
    });

}


function RecValidate() {
    var isValid = true;
    if ($("#Parameter1").val() == "" || $("#Parameter2").val() == "" || $("#Parameter3").val() == "" || $("#Parameter4").val() == "" || $("#Parameter5").val() == "" || $("#Parameter6").val() == "" || $("#Parameter7").val() == "" || $("#Parameter8").val() == "" || $("#Parameter9").val() == "" || $("#Parameter10").val() == "") {
        isValid = false;
    }
    return isValid;
}

function RecSubmit() {

    var recObject = {};

    recObject.Parameter1 = $("#Parameter1").val();
    recObject.Parameter2 = $("#Parameter2").val();
    recObject.Parameter3 = $("#Parameter3").val();
    recObject.Parameter4 = $("#Parameter4").val();
    recObject.Parameter5 = $("#Parameter5").val();
    recObject.Parameter6 = $("#Parameter6").val();
    recObject.Parameter7 = $("#Parameter7").val();
    recObject.Parameter8 = $("#Parameter8").val();
    recObject.Parameter9 = $("#Parameter9").val();
    recObject.Parameter10 = $("#Parameter10").val();   

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        url: "/Home/GetRec",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, recommendation: recObject },       
        success: function (response) {            
            alertify.alert("Alert", response);
            $('#recommendationForm')[0].reset();
            const a = ["parameter1val", "parameter2val", "parameter3val", "parameter4val", "parameter5val", "parameter6val", "parameter7val", "parameter8val", "parameter9val", "parameter10val"];
            for (const element of a) {
                document.getElementById(element).innerHTML = "";
            }
        },
        error: function () { alertify.alert("Alert", "System Ran into an Error! Please Try Again!"); }
    });

}
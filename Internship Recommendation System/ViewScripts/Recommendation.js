$(document).ready(function () {
    $("#recSubBtn").click(function () {
        $("#recommendationForm").submit(function (e) {
            e.preventDefault();
        });
        if (RecValidate()) {
            RecSubmit();
        }
    });
});

function RecValidate() {
    var isValid = true;
    if ($("#JobID").val() == "") {
        isValid = false;
    } else if ($("#Parameter1").val() == "" || $("#Parameter2").val() == "" || $("#Parameter3").val() == "" || $("#Parameter4").val() == "" || $("#Parameter5").val() == "" || $("#Parameter6").val() == "" || $("#Parameter7").val() == "" || $("#Parameter8").val() == "" || $("#Parameter9").val() == "" || $("#Parameter10").val() == "") {
        isValid = false;
    }
    return isValid;
}

function RecSubmit() {
    var recObject = {};

    recObject.JobID = $("#JobID").val();
    recObject.UniYearID = $("#UniYearID").val();
    recObject.ExpectedPeriodID = $("#ExpectedPeriodID").val();
    recObject.IsCompleted = $("#IsCompleted").is(':checked'); 
    recObject.IncludeBioData = $("#IncludeBioData").is(':checked'); 
    recObject.IncludeAcademicData = $("#IncludeAcademicData").is(':checked'); 
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
        url: "/Recommendation/GetRecommendation",
        type: "POST",
        data: { __RequestVerificationToken: tokenForValidation, recommendation: recObject },
        success: function (response) {
            
            var recLoaderModal = $('#recLoaderModal');

            recLoaderModal.modal('show');
            setTimeout(function () {
                recLoaderModal.modal('hide');
                recModalGenerator(response);
            }, 3000);
          
        },
        error: function () {
            var recModal = $('#recModal');
            recModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            recModal.modal('show');
        }
    });
}

function recModalGenerator(response) {
    var recResultModal = $('#recResultModal');
    var results = JSON.parse(response);
    var resultsCount = results.length;
    document.getElementById("recResultModal-modal-body").innerHTML = "";
    const cardSRow = '<div class="row"> ';
    const cardERow = '</div>';
    var resultCard = '';
    var rowCards = '';
    if (resultsCount > 0) {
        var fullResultBody = '<div> <h5 class="text-success text-center">Accroding to your Preferences the best matches for you as follows...</h5> </div>';
    } else {
        var fullResultBody = '<div> <h5 class="text-danger text-center">Oh no... Accroding to your Preferences there are no matches for you. Try expanding your preferences</h5> </div>';
    }    
    var count = 0;
    results.forEach(function (item, index) {        
        resultCard += '<div id="result' + (index + 1) + '" class="col-xxl-6 col-md-6"> <div class="card info-card sales-card"> <div class="card-body"> <div class="d-flex align-items-center"> <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"> <i class="bi bi-building bx-md"></i> </div> <div class="ps-3"> <h5 class="card-title text-center">' + (index + 1) + ') ' + item.CompanyName + '</h5> </div> </div> </div> </div> </div>';
        count++;
        if (count % 2 == 0 || index == (resultsCount - 1)) {
            rowCards = cardSRow + resultCard + cardERow;
            fullResultBody += rowCards;
            resultCard = ''
        }
    });
    document.getElementById("recResultModal-modal-body").innerHTML = document.getElementById("recResultModal-modal-body").innerHTML + fullResultBody;   
    const closeBtn = '<div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button></div>';
    document.getElementById("recResultModal-modal-body").innerHTML += closeBtn;
    $('#recommendationForm')[0].reset();
    $('#recommendationForm').removeClass('was-validated');
    const a = ["parameter1val", "parameter2val", "parameter3val", "parameter4val", "parameter5val", "parameter6val", "parameter7val", "parameter8val", "parameter9val", "parameter10val"];
    for (const element of a) {
        document.getElementById(element).innerHTML = "";
    }
    recResultModal.modal('show');
}

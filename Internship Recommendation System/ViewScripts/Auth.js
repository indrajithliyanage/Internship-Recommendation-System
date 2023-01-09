$(document).ready(function () {
    $("#cgunitRegisterForm").hide();
    $("input[name='formSelector']").change(function () {
        if ($(this).val() == "cgunitForm") {
            $("#cgunitRegisterForm").show();
            $("#studentRegisterForm").hide();
        } else {
            $("#cgunitRegisterForm").hide();
            $("#studentRegisterForm").show();
        }
    });
    $("#stdRegBtn").click(function () {
        $("#studentRegisterForm").submit(function (e) {
            e.preventDefault();
        });        
        if (StudentRegisterValidate()) {
            StudentRegister();
        }
    });
    $("#cguRegBtn").click(function () {
        $("#cgunitRegisterForm").submit(function (e) {
            e.preventDefault();
        });
        if (CGURegisterValidate()) {
            CGURegister();
        }
    });
    $("#loginBtn").click(function () {
        $("#loginForm").submit(function (e) {
            e.preventDefault();
        });
        if (LoginValidate()) {
            Login();
        }
    });
});

function StudentRegister() {
    var registerObject = {};

    registerObject.StuFirstName = $("#StuFirstName").val();
    registerObject.StuLastName = $("#StuLastName").val();
    registerObject.StuEmail = $("#StuEmail").val();
    registerObject.StuPassword = $("#StuPassword").val();
    registerObject.StuConfirmPassword = $("#StuConfirmPassword").val();
    registerObject.StuUniversityID = $("#StuUniversityID").val();
    registerObject.Gender = $("input[name='Gender']:checked").val();
    registerObject.DateofBirth = $("#DateofBirth").val();
    registerObject.DegreeID = $("#DegreeID").val();
    registerObject.IndexNo = $("#IndexNo").val();
    registerObject.Role = "STU";

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        type: "POST",
        url: "/Auth/Register",
        data: { __RequestVerificationToken: tokenForValidation, register: registerObject },
        success: function (response) {
            var registerModal = $('#registerModal');
            registerModal.find('.modal-body').text(response);
            registerModal.modal('show');
            $('#studentRegisterForm')[0].reset();
            $('#studentRegisterForm').removeClass('was-validated')  
        },
        error: function () {
            var registerModal = $('#registerModal');
            registerModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            registerModal.modal('show');
        }
    });
}

function StudentRegisterValidate() {
    var isValid = true;
    if ($("#StuFirstName").val() == "" || $("#StuLastName").val() == "" || $("#StuEmail").val() == "" || $("#StuPassword").val() == "" || $("#StuConfirmPassword").val() == "" || $("#StuUniversityID").val() == "") {
        isValid = false;
    } else if ($("#DateofBirth").val() == "" || $("#IndexNo").val() == "" || $("#Degree").val() == "" ) {
        isValid = false;
    }
    else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($("#StuEmail").val()))) {
        isValid = false;
    } else if ($("#StuPassword").val().length > 20 || $("#StuPassword").val().length < 8) {
        isValid = false;
    } else if ($("#StuPassword").val() != $("#StuConfirmPassword").val()) {
        isValid = false;
    } else if ($("input[name='Gender']:checked").val() == undefined) {
        isValid = false;
    }
    return isValid;
}

function CGURegister() {
    var registerObject = {};

    registerObject.CguFirstName = $("#CguFirstName").val();
    registerObject.CguLastName = $("#CguLastName").val();
    registerObject.CguEmail = $("#CguEmail").val();
    registerObject.CguPassword = $("#CguPassword").val();
    registerObject.CguConfirmPassword = $("#CguConfirmPassword").val();
    registerObject.CguUniversityID = $("#CguUniversityID").val();
    registerObject.PhoneNo = $("#PhoneNo").val();
    registerObject.Address = $("#Address").val();
    registerObject.Role = "CGU";

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        type: "POST",
        url: "/Auth/Register",
        data: { __RequestVerificationToken: tokenForValidation, register: registerObject },
        success: function (response) {
            var registerModal = $('#registerModal');
            registerModal.find('.modal-body').text(response);
            registerModal.modal('show');
            $('#cgunitRegisterForm')[0].reset();
            $('#cgunitRegisterForm').removeClass('was-validated')          
        },
        error: function () {
            var registerModal = $('#registerModal');
            registerModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            registerModal.modal('show');
        }
    });
}

function CGURegisterValidate() {
    var isValid = true;
    if ($("#CguFirstName").val() == "" || $("#CguLastName").val() == "" || $("#CguEmail").val() == "" || $("#CguPassword").val() == "" || $("#CguConfirmPassword").val() == "" || $("#CguUniversityID").val() == "") {
        isValid = false;
    } else if ($("#PhoneNo").val() == "" || $("#Address").val() == "") {
        isValid = false;
    }
    else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($("#CguEmail").val()))) {
        isValid = false;
    } else if ($("#CguPassword").val().length > 20 || $("#CguPassword").val().length < 8) {
        isValid = false;
    } else if ($("#CguPassword").val() != $("#CguConfirmPassword").val()) {
        isValid = false;
    }
    return isValid;
}

function Login() {
    var loginObject = {};

    loginObject.Email = $("#Email").val();
    loginObject.Password = $("#Password").val();
    loginObject.RememberMe = $("#RememberMe").prop("checked");    

    var tokenForValidation = $('[name="__RequestVerificationToken"]').val();

    $.ajax({
        type: "POST",
        url: "/Auth/Login",
        data: { __RequestVerificationToken: tokenForValidation, login: loginObject },
        success: function (response) {                      
            if (response.redirectToUrl != undefined) {
                var modalBody = '<div><h5 class="text-success text-center">Success! You are now being redirected...</h5></div><div class="d-flex justify-content-center"><div class="spinner-border" role="status"></div>'
                document.getElementById("loginModal-modal-body").innerHTML = modalBody;                    
                var loginModal = $('#loginModal');
                loginModal.modal('show');
                setTimeout(function () {
                    window.location.href = response.redirectToUrl;
                }, 3000);                
            } else {     
                var loginModal = $('#loginModal');
                loginModal.find('.modal-body').text(response);
                loginModal.modal('show');
            }   
        },
        error: function () {
            var loginModal = $('#loginModal');
            loginModal.find('.modal-body').text("System Ran into an Error! Please Try Again!");
            loginModal.modal('show');
        }
    });
}

function LoginValidate() {
    var isValid = true;
    if ($("#Email").val() == "" || $("#Password").val() == "") {
        isValid = false;
    }
    else if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($("#Email").val()))) {
        isValid = false;
    } else if ($("#Password").val().length > 20 || $("#Password").val().length < 8) {
        isValid = false;
    }
    return isValid;
}
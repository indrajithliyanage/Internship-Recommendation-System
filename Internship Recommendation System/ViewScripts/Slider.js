$(document).ready(function () {
    GenerateSliders();
    SlidersValues();
});

function GenerateSliders() {
    var stop = 11;
    for (i = 1; i < stop; i++) {
        var expSliderElement = document.getElementById("expParaSlider" + i + "");
        var recSliderElement = document.getElementById("recParaSlider" + i + "");
        const expContent = '<div class="range mx-auto"> <div class="sliderValue"> <span id="sliderval' + i + '"></span> </div> <div class="field"> <div class="value left"> <img src="/Images/emoji-1.png" alt="" class="img-responsive img-rounded" style="max-height: 25px; max-width: 25px;"> </div> <input id="slider' + i + '" type="range" min="1" max="5" steps="1"> <div class="value right"> <img src="/Images/emoji-4.png" alt="" class="img-responsive img-rounded" style="max-height: 25px; max-width: 25px;"> </div> </div> </div>';
        const recContent = '<div class="range mx-auto"> <div class="sliderValue"> <span id="sliderval' + i + '"></span> </div> <div class="field"> <div class="value left"> <img src="/Images/emoji-2.png" alt="" class="img-responsive img-rounded" style="max-height: 25px; max-width: 25px;"> </div> <input id="slider' + i + '" type="range" min="1" max="5" steps="1"> <div class="value right"> <img src="/Images/emoji-3.png" alt="" class="img-responsive img-rounded" style="max-height: 25px; max-width: 25px;"> </div> </div> </div>';
        if (expSliderElement != null || expSliderElement != undefined) {
            expSliderElement.innerHTML += expContent;
        } else {
            recSliderElement.innerHTML += recContent;
        }        
    }
}

function SlidersValues() {
    const slideValue1 = document.querySelector("#sliderval1");
    const inputSlider1 = document.querySelector("#slider1");
    inputSlider1.oninput = (() => {
        let value = inputSlider1.value;
        slideValue1.textContent = value;
        document.getElementById("Parameter1").value = value;
        var expSliderElement = document.getElementById("expParaSlider1");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter1", "parameter1val");
        } else {
            RecParameterOutput("Parameter1", "parameter1val");
        }        
    });

    const slideValue2 = document.querySelector("#sliderval2");
    const inputSlider2 = document.querySelector("#slider2");
    inputSlider2.oninput = (() => {
        let value = inputSlider2.value;
        slideValue2.textContent = value;
        document.getElementById("Parameter2").value = value;
        var expSliderElement = document.getElementById("expParaSlider2");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter2", "parameter2val");
        } else {
            RecParameterOutput("Parameter2", "parameter2val");
        }
        
    });

    const slideValue3 = document.querySelector("#sliderval3");
    const inputSlider3 = document.querySelector("#slider3");
    inputSlider3.oninput = (() => {
        let value = inputSlider3.value;
        slideValue3.textContent = value;
        document.getElementById("Parameter3").value = value;
        var expSliderElement = document.getElementById("expParaSlider3");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter3", "parameter3val");
        } else {
            RecParameterOutput("Parameter3", "parameter3val");
        }
    });

    const slideValue4 = document.querySelector("#sliderval4");
    const inputSlider4 = document.querySelector("#slider4");
    inputSlider4.oninput = (() => {
        let value = inputSlider4.value;
        slideValue4.textContent = value;
        document.getElementById("Parameter4").value = value;
        var expSliderElement = document.getElementById("expParaSlider4");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter4", "parameter4val");
        } else {
            RecParameterOutput("Parameter4", "parameter4val");
        }
    });

    const slideValue5 = document.querySelector("#sliderval5");
    const inputSlider5 = document.querySelector("#slider5");
    inputSlider5.oninput = (() => {
        let value = inputSlider5.value;
        slideValue5.textContent = value;
        document.getElementById("Parameter5").value = value;
        var expSliderElement = document.getElementById("expParaSlider5");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter5", "parameter5val");
        } else {
            RecParameterOutput("Parameter5", "parameter5val");
        }
    });

    const slideValue6 = document.querySelector("#sliderval6");
    const inputSlider6 = document.querySelector("#slider6");
    inputSlider6.oninput = (() => {
        let value = inputSlider6.value;
        slideValue6.textContent = value;
        document.getElementById("Parameter6").value = value;
        var expSliderElement = document.getElementById("expParaSlider6");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter6", "parameter6val");
        } else {
            RecParameterOutput("Parameter6", "parameter6val");
        }
    });

    const slideValue7 = document.querySelector("#sliderval7");
    const inputSlider7 = document.querySelector("#slider7");
    inputSlider7.oninput = (() => {
        let value = inputSlider7.value;
        slideValue7.textContent = value;
        document.getElementById("Parameter7").value = value;
        var expSliderElement = document.getElementById("expParaSlider7");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter7", "parameter7val");
        } else {
            RecParameterOutput("Parameter7", "parameter7val");
        }
    });

    const slideValue8 = document.querySelector("#sliderval8");
    const inputSlider8 = document.querySelector("#slider8");
    inputSlider8.oninput = (() => {
        let value = inputSlider8.value;
        slideValue8.textContent = value;
        document.getElementById("Parameter8").value = value;
        var expSliderElement = document.getElementById("expParaSlider8");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter8", "parameter8val");
        } else {
            RecParameterOutput("Parameter8", "parameter8val");
        }
    });

    const slideValue9 = document.querySelector("#sliderval9");
    const inputSlider9 = document.querySelector("#slider9");
    inputSlider9.oninput = (() => {
        let value = inputSlider9.value;
        slideValue9.textContent = value;
        document.getElementById("Parameter9").value = value;
        var expSliderElement = document.getElementById("expParaSlider9");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter9", "parameter9val");
        } else {
            RecParameterOutput("Parameter9", "parameter9val");
        }
    });

    const slideValue10 = document.querySelector("#sliderval10");
    const inputSlider10 = document.querySelector("#slider10");
    inputSlider10.oninput = (() => {
        let value = inputSlider10.value;
        slideValue10.textContent = value;
        document.getElementById("Parameter10").value = value;
        var expSliderElement = document.getElementById("expParaSlider10");
        if (expSliderElement != null || expSliderElement != undefined) {
            ExpParameterOutput("Parameter10", "parameter10val");
        } else {
            RecParameterOutput("Parameter10", "parameter10val");
        }
    });
}

function ExpParameterOutput(para, paraValue) {
    var paraError = document.getElementById(para + "-error");
    if (paraError != undefined || paraError != null) {
        paraError.remove();
    }
    switch (document.getElementById(para).value) {
        case "1":
            document.getElementById(paraValue).innerHTML = "Very Dissatisfied";
            break;
        case "2":
            document.getElementById(paraValue).innerHTML = "Not Satisfied";
            break;
        case "3":
            document.getElementById(paraValue).innerHTML = "Neutral";
            break;
        case "4":
            document.getElementById(paraValue).innerHTML = "Satisfied";
            break;
        case "5":
            document.getElementById(paraValue).innerHTML = "Very Satisfied";
            break;
        default:
            document.getElementById(paraValue).innerHTML = "";
    }
}

function RecParameterOutput(para, paraValue) {
    var paraError = document.getElementById(para + "-error");
    if (paraError != undefined || paraError != null) {
        paraError.remove();
    }
    switch (document.getElementById(para).value) {
        case "1":
            document.getElementById(paraValue).innerHTML = "No Importance";
            break;
        case "2":
            document.getElementById(paraValue).innerHTML = "Less Important";
            break;
        case "3":
            document.getElementById(paraValue).innerHTML = "Neutral";
            break;
        case "4":
            document.getElementById(paraValue).innerHTML = "Important";
            break;
        case "5":
            document.getElementById(paraValue).innerHTML = "Very Important";
            break;
        default:
            document.getElementById(paraValue).innerHTML = "";
    }
}
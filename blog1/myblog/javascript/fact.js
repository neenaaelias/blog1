$(document).ready(function () {
    $("#facto").click(function (event) {
        event.preventDefault();
    });
})

$("#facto").click(calculateNumbers);

function calculateNumbers() {

    var firstValue = parseInt($("#number").val());
    var result = 1;
    for (i = 2; i <= firstValue; i++) {
        result *= i;

    }
    $("#answer").append(result);
};





$(document).ready(function () {
    $("#calculate").click(function (event) {
        event.preventDefault();
    });
})

$("#calculate").click(calculateNumbers);


    function calculateNumbers() {
        var firstValue = parseInt($("#firstnumber").val());
        var secondValue = parseInt($("#secondnumber").val());
        var thirdValue = parseInt($("#thirdnumber").val());
        var fourthValue = parseInt($("#fourthnumber").val());
        var fifthValue = parseInt($("#fifthnumber").val());
        var min = Math.min(firstValue, secondValue, thirdValue, fourthValue, fifthValue);
        var max = Math.max(firstValue, secondValue, thirdValue, fourthValue, fifthValue);

        var resultSum = firstValue+ secondValue+thirdValue+ fourthValue+fifthValue;



        var numArray = [firstValue, secondValue, thirdValue, fourthValue, fifthValue];
        resultMean = resultSum / numArray.length
        var resultProduct = 1;
        for (i = 0; i < numArray.length; i++) {
            resultProduct *= numArray[i];
        }


        $("#least").html(min);
        $("#great").html(max);
        $("#mean").html(resultMean);
        $("#sum").html(resultSum);
        $("#product").html(resultProduct);


    };
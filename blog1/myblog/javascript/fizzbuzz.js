$(document).ready(function () {
    $("#fiz").click(function (event) {
        event.preventDefault();
    });
})

$("#fiz").click(fizzbuzz);

function fizzbuzz() {
    var one = parseInt($("#firstnumber1").val());
    var two = parseInt($("#secondnumber1").val());
    var number = [];
    var i = 1;
    for (i = 1; i <= 100; i++) {
        number.push(i);
    }
    var length = number.length;
    var j;
    var resultarray = [];
    for (j = 0; j < length; j++) {

        if (number[j] % one === 0 && number[j] % two === 0) {

            resultarray[j] = "fizzbuzz" + "</br>";
        }

        else if (number[j] % one === 0) {

            resultarray[j] = "fizz" + "</br>";
        }

        else if (number[j] % two === 0) {
            resultarray[j] = "buzz" + "</br>";
        }
        else {

            resultarray[j] = number[j] + "</br>";
        }
    }
    $("#products").html(resultarray);
};








































































































































































































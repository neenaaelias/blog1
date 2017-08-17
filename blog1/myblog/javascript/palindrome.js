$(document).ready(function () { //default. Waits for document to load first
    $("#palin").click(function (event) {
        event.preventDefault();
    });
})

$("#palin").click(palindrome);

function palindrome() {
    //variables
    var arr = "";

    var arr = ($("#word").val());
    //syntax

    var array = arr.split("");
    //var len = array.length;
    var rever = array.reverse();
    var joins = array.join("");


    if (arr == joins) {

        ($("#result").html("yes"));
    }
    else {
        ($("#result").html("no"));
    }
};


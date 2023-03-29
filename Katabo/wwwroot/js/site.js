// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function decrement() {
    var input = document.getElementById("quantity");
    input.value = parseFloat(input.value) - 1;
}

function increment() {
    var input = document.getElementById("quantity");
    input.value = parseFloat(input.value) + 1;
}
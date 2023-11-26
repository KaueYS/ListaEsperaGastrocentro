// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".alert").ready(function () { 
    $(".alert").fadeIn(300).delay(4000).fadeOut(400);
});

let table = new DataTable('#lp');
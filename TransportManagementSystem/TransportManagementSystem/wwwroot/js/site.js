// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function validate() {
    if (document.getElementById("text1").value == "Srikanth"
        && document.getElementById("text2").value == "Sri@30091999") {
        alert("validation succeeded");
        location.href = "run.html";
    }
    else {
        alert("validation failed");
        location.href = "fail.html";
    }
}

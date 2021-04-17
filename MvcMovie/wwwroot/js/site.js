const reviewControllerUri = "/review/";



function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function addReview() {
    var formData = new FormData();
    var movieId = getUrlVars()["movieid"];
    formData.append("userName", $("#userName").val()); //https://www.w3schools.com/jquery/tryit.asp?filename=tryjquery_dom_val_get
    formData.append("Comment", $("#Comment").val());
    formData.append("movieId", movieId);


    $.ajax({
        type: "POST",
        url: reviewControllerUri + "PostReview",
        processData: false,
        contentType: false,
        data: formData,
        mimeType: "multipart/form-data",
        cache: false,
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            alert("review was added successfully!");

        }


    });
    return false;
}

$(document).ready(function () {
    $("#formButton").click(function () {
        $("#form1").toggle();
    });
});

$(document).ready(function () {
    $("#cancel").click(function () {
        $("#form1").toggle();
    });
});

$(".add-review-form").on("submit", function () {
    addReview();

    return false;
});
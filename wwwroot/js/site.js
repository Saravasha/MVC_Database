// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.






function ListAllPeople()
{
    var peopleList = $('#peopleList');
    $.ajax({
        type: "GET",
        url: "Person/PersonView",
        success: function (peopleList) {
            console.log(peopleList);
            $("#peopleList").html();
        }
    })
}

function GetDetails() {

    var detailsGet = $('#detailsGet');
    $.ajax({
        type: "POST",
        url: "Person/PersonView",
        success: function (detailsGet) {
            console.log(detailsGet);
            $("div#detailsGet")
        }
    })
}


function AnnihilatePerson() {

    var annihilate = $('#annihilate');
    $.ajax({
        type: "POST",
        url: "Person/PersonView",
        success: function (annihilate) {
            console.log(annihilate);
            document.annihilate
        }
    })

}




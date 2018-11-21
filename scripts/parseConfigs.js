$(document).ready(function () {

    var filename = "../configs.json";

    $.getJSON(filename, function(data) {

        var title = `${data.blogname}`

        var about = `${data.about}`

        document.getElementById("HTMLtitle").innerHTML=title;
        document.getElementById("navbarBrand").innerHTML=title;
        document.getElementById("about").innerHTML=about;

    });
});
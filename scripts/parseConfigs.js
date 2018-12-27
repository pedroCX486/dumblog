$(document).ready(function () {

    var filename = "../configs.json";

    $.getJSON(filename, function(data) {

        var title = `${data.blogname}`

        var about = `${data.about}`

        document.title = title;
		
        document.getElementById("navbarBrand").innerHTML=title;
        document.getElementById("about").innerHTML=about;

    });
});
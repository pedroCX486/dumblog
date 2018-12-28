$(document).ready(function () {

    var filename = "../configs.json";

    $.getJSON(filename, function(data) {

		//Get from JSON
        var title = `${data.blogname}`
        var about = `${data.about}`

		//Set HTML title
        document.title = title;
		
		//Set elements contents
        document.getElementById("navbarBrand").innerHTML=title;
        document.getElementById("about").innerHTML=about;

    });
});
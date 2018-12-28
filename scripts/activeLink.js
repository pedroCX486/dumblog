//This is a simple script to set the current active link in the navbar.

$(document).ready(function () {
	
    var url = window.location.pathname;
    var filename = url.substring(url.lastIndexOf('/')+1);
	
    if (filename == "index.html") {
        var activeLink = document.getElementById("index");
        activeLink.className += " active";
        
    }else if(filename == "archives.html"){
        var activeLink = document.getElementById("archives");
        activeLink.className += " active";
    }
});
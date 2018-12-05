//I hate javascript.

var archive = "/posts/archive.lst";
var url = document.URL;
var filename;
var filename2;

$(document).ready(function () {

    $.getJSON(archive, function(result){

        if(url.includes("post.html")){
            filename = "/posts/"+url.substring(url.lastIndexOf('?')+1)+".post";
        }else{ //This means it's on the home page
            filename2 = "/posts/"+result.filenames[1]+".post";
            filename = "/posts/"+result.filenames[0]+".post";
        }

        $.getJSON(filename, function(data) {
            
            var title = `${data.title}`
            $("#title").html(title);

            var timestamp = `${data.timestamp}`
            timestamp = new Date(timestamp*1000);
            $("#timestamp").html(timestamp);

            var editedTimestamp = `${data.editedTimestamp}`
            editedTimestamp = new Date(editedTimestamp*1000);
            $("#editedTimestamp").html("Edited on: " + editedTimestamp);
            $("#editedTimestamp").css("visibility","visible");

            var content = `${data.content}`
            $("#content").html(content);
        });

		//This one will only load (of course) if we're on the homepage)
        $.getJSON(filename2, function(data) {
            
            var title = `${data.title}`
            $("#title2").html(title);

            var timestamp = `${data.timestamp}`
            timestamp = new Date(timestamp*1000);
            $("#timestamp2").html(timestamp);

            var editedTimestamp = `${data.editedTimestamp}`
            editedTimestamp = new Date(editedTimestamp*1000);
            $("#editedTimestamp2").html("Edited on: " + editedTimestamp);
            $("#editedTimestamp2").css("visibility","visible");

            var content = `${data.content}`
            $("#content2").html(content);
        });
    });
});
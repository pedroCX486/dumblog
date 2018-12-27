//I hate javascript.

var archive = "/posts/archive.lst";
var url = document.URL;
var filename;
var filename2;

//This is a hack and this makes me feel dirty.
var quote =  '<div class="alert alert-secondary" style="width:90%; margin: 0 auto;"><h1 class="alert-heading"><img style="max-width: 8%; height: auto;" src="quote.png"/></h4>';

$(document).ready(function () {

    $.getJSON(archive, function(result){

        if(url.includes("post.html")){
            filename = "/posts/"+url.substring(url.lastIndexOf('?')+1)+".post";
			simpleFilename = url.substring(url.lastIndexOf('?')+1);
        }else{ //This means it's on the home page
            filename2 = "/posts/"+result.filenames[1]+".post";
            filename = "/posts/"+result.filenames[0]+".post";
			
			simpleFilename2 = result.filenames[1];
			simpleFilename = result.filenames[0];
        }

        $.getJSON(filename, function(data) {
            
            var title = `${data.title}`
            $("#title").html(title);
			$("#title").wrap('<a href="'+window.location.origin+'/post.html?'+simpleFilename+'" target="_self"></a>');
			
			if(url.includes("post.html")){
				document.title = title;
			}
			
            var timestamp = `${data.timestamp}`
            timestamp = new Date(timestamp*1000);
            $("#timestamp").html(timestamp);

            var editedTimestamp = `${data.editedTimestamp}`
            if(editedTimestamp){
                editedTimestamp = new Date(editedTimestamp*1000);
                $("#editedTimestamp").html("Edited on: " + editedTimestamp);
                $("#editedTimestamp").css("visibility","visible");
            }
			
            var content = `${data.content}`
            $("#content").html(content.replace(/<div class="quote">/g, quote));
			
        });

		//This one will only load (of course) if we're on the homepage)
        $.getJSON(filename2, function(data) {
            
            var title = `${data.title}`
            $("#title2").html(title);
			$("#title2").wrap('<a href="'+window.location.origin+'/post.html?'+simpleFilename2+'" target="_self"></a>');

            var timestamp = `${data.timestamp}`
            timestamp = new Date(timestamp*1000);
            $("#timestamp2").html(timestamp);

            var editedTimestamp = `${data.editedTimestamp}`
            if(editedTimestamp){
                editedTimestamp = new Date(editedTimestamp*1000);
                $("#editedTimestamp2").html("Edited on: " + editedTimestamp);
                $("#editedTimestamp2").css("visibility","visible");
            }

            var content = `${data.content}`
            $("#content2").html(content.replace('<div class="quote">', quote));
        });
    });
});
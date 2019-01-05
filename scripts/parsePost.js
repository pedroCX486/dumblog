//I hate javascript.

var archive = "/posts/archive.lst";
var url = document.URL;

//This is a hack and this makes me feel dirty.
var quote =  '<div class="alert alert-secondary" style="width:90%; margin: 0 auto;"><h1 class="alert-heading"><img src="quote.png"/></h1> <hr>';

$(document).ready(function () {

    $.getJSON(archive, function(result){
		
		function parsePost(filename){
			$.getJSON("/posts/"+filename+".post", function(data) {
				
				var title = `${data.title}`
				$("#title").html(title);
				$("#title").wrap('<a href="'+window.location.origin+'/post.html?'+filename+'" target="_self"></a>');
				
				if(url.includes("post.html")){
					document.title = title + " - " + document.title;
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
				$("#content").html(content.replace(/<div class="quote"><br>/g, quote));
			});
		}
		
		//This one will only be used if we're on the homepage
		function parsePost2(filename2){
			$.getJSON("/posts/"+filename2+".post", function(data) {
				
				var title = `${data.title}`
				$("#title2").html(title);
				$("#title2").wrap('<a href="'+window.location.origin+'/post.html?'+filename2+'" target="_self"></a>');

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
				$("#content2").html(content.replace(/<div class="quote"><br>/g, quote));
			});
		}

        if(url.includes("post.html")){
            parsePost(url.substring(url.lastIndexOf('?')+1));
        }else{ //This means we're on the home page
            parsePost(result.filenames[0]);
			parsePost2(result.filenames[1]);
        }
		
    });
});

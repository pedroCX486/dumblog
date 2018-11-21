$(document).ready(function () {

    var archiveFile = "/posts/archive.lst";

    $.getJSON(archiveFile, function(data) {

        var fileList = `${data.filenames}`
        fileList = fileList.split(",");

        $('#archiveList').html("");

        for(let i = 0;i < fileList.length;i++){
			            
            $.getJSON("/posts/"+fileList[i]+".post", function(data) {

                $('#archiveList').append('<a href="post.html?'+fileList[i]+'"</a><div class="card"><div class="card-body">'+`${data.title}`+'</div></div><br>');
                //You gotta love how sometimes it FUCKING MIXES THE RESULTS. ASYNC EH?
        
            });
        }
    });
});
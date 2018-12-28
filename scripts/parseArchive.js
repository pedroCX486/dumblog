$(document).ready(function () {

    var archiveFile = "/posts/archive.lst";

    $.getJSON(archiveFile, function(data) {

        $('#archiveList').html("");

        $.each(data.filenames, function(index, filenames) {
			            
            $.getJSON("/posts/"+filenames+".post", function(postContent) {

                $('#archiveList').append('<a href="post.html?'+filenames+'"><div class="card"><div class="card-body">'+`${postContent.title}`+'</div></div></a><br>');
                //You gotta love how sometimes it FUCKING MIXES THE RESULTS. ASYNC EH?
				//I tried mitigating it until I get a better fix.
            });
        });
    });
});
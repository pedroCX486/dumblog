$(document).ready(function () {

    var archiveFile = "/posts/archive.lst";

    $.getJSON(archiveFile, function(data) {

        $('#archiveList').html("");

        $.each(data.filenames, function(index, filenames) {

            $('#archiveList').append('<a href="post.html?'+filenames+'"><div class="card"><div class="card-body">'+data.postTitles[index]+'</div></div></a><br>');

        });
    });
});
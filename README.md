### Notice

This version of the Dumblog platform was discontinued. This atrocious mash of code has to be forgotten. Check out the new sleek version in Angular [here](https://github.com/pedroCX486/ngx-dumblog).

# Dumblog

An small (and dumb) blog platform made in HTML and JS.

## Why?

Why not?

## What you should know:

- It was made to run on the GitHub Pages service. Which means, the index.html has to be on the root of the repo.

- No it won't run locally, CORS configs from newer browsers will screech at you.
  
- An (dumb) editor is included in the release page of this repo. The source (and compiled file) you can find inside the '/posts/editor' folder (as a VS2017 project).

- .NET Framework 4 is required to run the editor.

- To publish it on GitHub Pages (because it hates binaries) you need a .gitignore file (so you don't publish a compiled editor and the source) containing this: [Ee]ditor/

- If you wish to use a different file for the first post instead of the default, change the file name to the one you generate on the archive.lst file (same applies if you want to delete an entry in the archive)
  
- The code is an abomination. Look at your own disclosure.

## Libs used:

* Web Front-End
	* JQuery
	* Bootstrap 4.1
	* Popper
	
* Editor (required to compile)
	* Newtonsoft JSON (as a NuGet package)

## Icons used:

* Favicon - Web Front-End: [UI Essence - new file by Laura Reen](https://www.shareicon.net/document-write-file-new-create-887243)
* Quote - Web Front-End: [Font Awesome - Quote Left](https://fontawesome.com/v4.7.0/icon/quote-left)
* EXE Icon - Editor: [Flat Paint Brush by Clipartmax](https://www.clipartmax.com/middle/m2i8i8m2A0i8d3d3_open-flat-paint-brush-icon/)

## Post notes:

This project is licensed under the WTFPL. The assets used are each under their original licenses.

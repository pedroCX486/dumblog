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
  
- The code is an abomination. Look at your own disclosure.

## Libs used (all required to compile)

* Newtonsoft JSON (as a NuGet package)

## Post notes:

This project is licensed under the WTFPL. The libs used are each under their original licenses.

## TODO:

- An Window in the editor to manage the archive entries.

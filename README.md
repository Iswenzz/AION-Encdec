# AION Encdec
[![Build status](https://ci.appveyor.com/api/projects/status/u6aiu1hde2ca04u0?svg=true)](https://ci.appveyor.com/project/Iswenzz/aion-encdec)
[![codecov](https://codecov.io/gh/Iswenzz/AION-Encdec/branch/master/graph/badge.svg)](https://codecov.io/gh/Iswenzz/AION-Encdec)
[![CodeFactor](https://www.codefactor.io/repository/github/iswenzz/aion-encdec/badge)](https://www.codefactor.io/repository/github/iswenzz/aion-encdec)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

This program serves as both a Graphical User Interface and Command Line Interface for roxan & M. Soltys' command line applications. Some of the things this application provides include decoding `.XML`, `.HTML`, and `.CFG` files, as well as un-packing and re-packing `.PAK` files. Usage information and miscellaneous details can be found at the bottom of this document.

## Features
* Encode/Decode `.XML`, `.HTML`, and `.CFG` files.
* Un-pack and re-pack `.PAK` files.
* Graphical User Interface
* Command Line Interface

![](https://i.imgur.com/iKu3JIG.png)

## Command-Line
```c
  -u, --unpack    Unpack pak files at the specified input folder.
  -d, --decode    Decode pak files at the specified input folder.
  -r, --repack    Repack pak files at the specified output folder.
  -o, --output    (Default: ./REPACK) The output folder path.
  -i, --input     (Default: ./PAK) The input folder path.
  --help          Display this help screen.
  --version       Display version information.
```

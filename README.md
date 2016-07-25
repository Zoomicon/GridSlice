# GridSlice
.NET Library and Application to slice an image into 9 image cells using a 3x3 grid

# Usage
- Left click in the empty area of the application to show a file dialog (or double left click to load a new image)
- Pick an image file
- Left drag on the image file to define the middle box of the 3x3 grid
- Right click to create sliced image tiles in the same folder as the original image file, with the following file suffixes:
_TL, _TM, _TR
_ML, _M,  _MR
_BL, _BM, _BR
where T=Top, M=Middle, B=Bottom, L=Left, R=Right
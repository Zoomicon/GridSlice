'Description: IGridSlicer interface
'Author: George Birbilis (birbilis@kagi.com)
'Version: 20090306

Imports System.Drawing

Public Interface IGridSlicer

#Region "Properties"

	WriteOnly Property BitmapFile() As String
	Property Bitmap() As Bitmap
	ReadOnly Property BitmapArea(ByVal theArea As Rectangle) As Bitmap
	ReadOnly Property BitmapTopLeft() As Bitmap
	ReadOnly Property BitmapTopRight() As Bitmap
	ReadOnly Property BitmapTopMiddle() As Bitmap
	ReadOnly Property BitmapMiddleLeft() As Bitmap
	ReadOnly Property BitmapMiddle() As Bitmap
	ReadOnly Property BitmapMiddleRight() As Bitmap
	ReadOnly Property BitmapBottomLeft() As Bitmap
	ReadOnly Property BitmapBottomMiddle() As Bitmap
	ReadOnly Property BitmapBottomRight() As Bitmap

	ReadOnly Property CellTopLeft() As Rectangle
	ReadOnly Property CellTopMiddle() As Rectangle
	ReadOnly Property CellTopRight() As Rectangle
	ReadOnly Property CellMiddleLeft() As Rectangle
	Property CellMiddle() As Rectangle
	ReadOnly Property CellMiddleRight() As Rectangle
	ReadOnly Property CellBottomLeft() As Rectangle
	ReadOnly Property CellBottomMiddle() As Rectangle
	ReadOnly Property CellBottomRight() As Rectangle

#End Region

#Region "Methods"

	Sub SaveBitmaps(ByVal filename As String)

#End Region

End Interface

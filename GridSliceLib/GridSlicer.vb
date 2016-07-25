'Description: GridSlicer class
'Author: George Birbilis (birbilis@kagi.com), using info from http://www.vb-helper.com/howto_2005_crop_picture.html
'Version: 20090306

Imports System.Drawing

Public Class GridSlicer
	Implements IGridSlicer

#Region "Constants"

#Region "Filename suffixes"

	Const TOP_LEFT As String = "_TL"
	Const TOP_MIDDLE As String = "_TM"
	Const TOP_RIGHT As String = "_TR"

	Const MIDDLE_LEFT As String = "_ML"
	Const MIDDLE As String = "_M"
	Const MIDDLE_RIGHT As String = "_MR"

	Const BOTTOM_LEFT As String = "_BL"
	Const BOTTOM_MIDDLE As String = "_BM"
	Const BOTTOM_RIGHT As String = "_BR"

#End Region

#End Region

#Region "Fields"

	Private fBitmap As Bitmap
	Private fMiddleCell As Rectangle

#End Region

#Region "Properties"

#Region "Helper private properties"

	Private ReadOnly Property OutTop() As Integer
		Get
			Return fMiddleCell.Top - 1
		End Get
	End Property

	Private ReadOnly Property OutLeft() As Integer
		Get
			Return fMiddleCell.Left - 1
		End Get
	End Property

	Private ReadOnly Property OutBottom() As Integer
		Get
			If fBitmap Is Nothing Then Return 0
			Return fBitmap.Height - fMiddleCell.Bottom - 1
		End Get
	End Property

	Private ReadOnly Property OutRight() As Integer
		Get
			If fBitmap Is Nothing Then Return 0
			Return fBitmap.Width - fMiddleCell.Width - 1
		End Get
	End Property

#End Region

	Public WriteOnly Property BitmapFile() As String Implements IGridSlicer.BitmapFile
		Set(ByVal value As String)
			Bitmap = Bitmap.FromFile(value)
		End Set
	End Property

	Public Property Bitmap() As System.Drawing.Bitmap Implements IGridSlicer.Bitmap
		Get
			Return fBitmap
		End Get
		Set(ByVal value As System.Drawing.Bitmap)
			fBitmap = value
		End Set
	End Property

	Public ReadOnly Property BitmapArea(ByVal theArea As System.Drawing.Rectangle) As System.Drawing.Bitmap Implements IGridSlicer.BitmapArea
		Get
			With theArea
				Dim destRect As New Rectangle(0, 0, .Width, .Height)
				Dim croppedBitmap As New Bitmap(.Width, .Height)
				Using g As Graphics = Graphics.FromImage(croppedBitmap)
					g.DrawImage(Bitmap, destRect, theArea, GraphicsUnit.Pixel)
				End Using
				Return croppedBitmap
			End With
		End Get
	End Property

	Public ReadOnly Property BitmapBottomLeft() As System.Drawing.Bitmap Implements IGridSlicer.BitmapBottomLeft
		Get
			Return BitmapArea(CellBottomLeft())
		End Get
	End Property

	Public ReadOnly Property BitmapBottomMiddle() As System.Drawing.Bitmap Implements IGridSlicer.BitmapBottomMiddle
		Get
			Return BitmapArea(CellBottomMiddle())
		End Get
	End Property

	Public ReadOnly Property BitmapBottomRight() As System.Drawing.Bitmap Implements IGridSlicer.BitmapBottomRight
		Get
			Return BitmapArea(CellBottomRight())
		End Get
	End Property

	Public ReadOnly Property BitmapMiddleLeft() As System.Drawing.Bitmap Implements IGridSlicer.BitmapMiddleLeft
		Get
			Return BitmapArea(CellMiddleLeft())
		End Get
	End Property

	Public ReadOnly Property BitmapMiddle() As System.Drawing.Bitmap Implements IGridSlicer.BitmapMiddle
		Get
			Return BitmapArea(CellMiddle)
		End Get
	End Property

	Public ReadOnly Property BitmapMiddleRight() As System.Drawing.Bitmap Implements IGridSlicer.BitmapMiddleRight
		Get
			Return BitmapArea(CellMiddleRight())
		End Get
	End Property

	Public ReadOnly Property BitmapTopLeft() As System.Drawing.Bitmap Implements IGridSlicer.BitmapTopLeft
		Get
			Return BitmapArea(CellTopLeft())
		End Get
	End Property

	Public ReadOnly Property BitmapTopMiddle() As System.Drawing.Bitmap Implements IGridSlicer.BitmapTopMiddle
		Get
			Return BitmapArea(CellTopMiddle())
		End Get
	End Property

	Public ReadOnly Property BitmapTopRight() As System.Drawing.Bitmap Implements IGridSlicer.BitmapTopRight
		Get
			Return BitmapArea(CellTopRight())
		End Get
	End Property

	Public ReadOnly Property CellBottomLeft() As System.Drawing.Rectangle Implements IGridSlicer.CellBottomLeft
		Get
			With CellMiddle
				Return New Rectangle(0, .Bottom + 1, OutLeft, OutBottom)
			End With
		End Get
	End Property

	Public ReadOnly Property CellBottomMiddle() As System.Drawing.Rectangle Implements IGridSlicer.CellBottomMiddle
		Get
			With CellMiddle
				Return New Rectangle(.Left, .Bottom + 1, .Width, OutBottom)
			End With
		End Get
	End Property

	Public ReadOnly Property CellBottomRight() As System.Drawing.Rectangle Implements IGridSlicer.CellBottomRight
		Get
			With CellMiddle
				Return New Rectangle(.Right + 1, .Bottom + 1, OutRight, OutBottom)
			End With
		End Get
	End Property

	Public ReadOnly Property CellMiddleLeft() As System.Drawing.Rectangle Implements IGridSlicer.CellMiddleLeft
		Get
			With CellMiddle
				Return New Rectangle(0, .Top, OutLeft, .Height)
			End With
		End Get
	End Property

	Public Property CellMiddle() As System.Drawing.Rectangle Implements IGridSlicer.CellMiddle
		Get
			Return fMiddleCell
		End Get
		Set(ByVal value As System.Drawing.Rectangle)
			fMiddleCell = value
		End Set
	End Property

	Public ReadOnly Property CellMiddleRight() As System.Drawing.Rectangle Implements IGridSlicer.CellMiddleRight
		Get
			With CellMiddle
				Return New Rectangle(.Right + 1, .Top, OutRight, .Height)
			End With
		End Get
	End Property

	Public ReadOnly Property CellTopLeft() As System.Drawing.Rectangle Implements IGridSlicer.CellTopLeft
		Get
			With CellMiddle
				Return New Rectangle(0, 0, OutLeft, OutTop)
			End With
		End Get
	End Property

	Public ReadOnly Property CellTopMiddle() As System.Drawing.Rectangle Implements IGridSlicer.CellTopMiddle
		Get
			With CellMiddle
				Return New Rectangle(.Left, 0, .Width, OutTop)
			End With
		End Get
	End Property

	Public ReadOnly Property CellTopRight() As System.Drawing.Rectangle Implements IGridSlicer.CellTopRight
		Get
			With CellMiddle
				Return New Rectangle(.Right + 1, 0, OutRight, OutTop)
			End With
		End Get
	End Property

#End Region

#Region "Methods"

	Public Sub SaveBitmaps(ByVal filename As String) Implements IGridSlicer.SaveBitmaps
		Dim filepathNoExt As String = IO.Path.Combine(IO.Path.GetDirectoryName(filename), IO.Path.GetFileNameWithoutExtension(filename))
		Dim extension As String = IO.Path.GetExtension(filename)

		SaveBitmap(BitmapTopLeft, filepathNoExt + TOP_LEFT + extension)
		SaveBitmap(BitmapTopMiddle, filepathNoExt + TOP_MIDDLE + extension)
		SaveBitmap(BitmapTopRight, filepathNoExt + TOP_RIGHT + extension)

		SaveBitmap(BitmapMiddleLeft, filepathNoExt + MIDDLE_LEFT + extension)
		SaveBitmap(BitmapMiddle, filepathNoExt + MIDDLE + extension)
		SaveBitmap(BitmapMiddleRight, filepathNoExt + MIDDLE_RIGHT + extension)

		SaveBitmap(BitmapBottomLeft, filepathNoExt + BOTTOM_LEFT + extension)
		SaveBitmap(BitmapBottomMiddle, filepathNoExt + BOTTOM_MIDDLE + extension)
		SaveBitmap(BitmapBottomRight, filepathNoExt + BOTTOM_RIGHT + extension)
	End Sub

	Protected Sub SaveBitmap(ByVal bitmap As Bitmap, ByVal filename As String)
		bitmap.Save(filename)
	End Sub

#End Region

End Class

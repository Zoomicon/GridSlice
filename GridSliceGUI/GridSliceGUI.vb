'Description: GridSliceGUI application (slices an image into 9 image cells using a grid)
'Author: George Birbilis (birbilis@kagi.com)
'Version: 20090306

Imports System.Math
Imports GridSliceLib

Public Class GridSliceGUI

#Region "Fields"

	Dim slicer As New GridSlicer()

#End Region

#Region "Methods"

	Protected Sub DrawCropRectangle()
		Dim bm As Bitmap = slicer.Bitmap.Clone()
		Using gr As Graphics = Graphics.FromImage(bm)
			gr.DrawRectangle(Pens.Red, slicer.CellMiddle)
		End Using
		PictureBox.Image = bm
		PictureBox.Update()	'needed in order to update the display ASAP
	End Sub

#End Region

#Region "Events"

	Private Sub OpenFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
		With slicer
			.BitmapFile = OpenFileDialog.FileName
			PictureBox.Image = .Bitmap
		End With
	End Sub

	Private Sub PictureBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox.DoubleClick
		OpenFileDialog.ShowDialog()
	End Sub

	Private Sub PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseDown
		If (slicer.Bitmap Is Nothing) Then
			OpenFileDialog.ShowDialog()
		ElseIf (e.Button = MouseButtons.Right) Then
			slicer.SaveBitmaps(OpenFileDialog.FileName)
			MsgBox("OK")
		Else
			slicer.CellMiddle = New Rectangle(e.X, e.Y, 0, 0)
			DrawCropRectangle()
		End If
	End Sub

	Private Sub PictureBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseMove
		If (slicer.Bitmap Is Nothing) Then Exit Sub
		If (e.Button = MouseButtons.Left) Then
			With slicer.CellMiddle
				slicer.CellMiddle = Rectangle.FromLTRB(Min(.X, e.X), Min(.Y, e.Y), Max(.X, e.X), Max(.Y, e.Y))
			End With
			DrawCropRectangle()
		End If
	End Sub

#End Region

End Class
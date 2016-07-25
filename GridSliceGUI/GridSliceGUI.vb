'Description: GridSliceGUI application (slices an image into 9 image cells using a grid)
'Author: George Birbilis (birbilis@kagi.com)
'Version: 20090307

Imports System.Math
Imports GridSliceLib

Public Class GridSliceGUI

#Region "Fields"

	Dim slicer As New GridSlicer()
	Dim lastX, lastY As Integer

#End Region

#Region "Methods"

	Protected Sub DrawCropRectangle()
		Dim bm As Bitmap = slicer.Bitmap.Clone()
		Using gr As Graphics = Graphics.FromImage(bm)
			Dim pen As Pen = Pens.Red
			With slicer.CellMiddle
				gr.DrawLine(pen, 0, .Top, bm.Width - 1, .Top)
				gr.DrawLine(pen, 0, .Bottom, bm.Width - 1, .Bottom)
				gr.DrawLine(pen, .Left, 0, .Left, bm.Height - 1)
				gr.DrawLine(pen, .Right, 0, .Right, bm.Height - 1)
			End With
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
			lastX = e.X
			lastY = e.Y
			DrawCropRectangle()
		End If
	End Sub

	Private Sub PictureBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseMove
		If (slicer.Bitmap Is Nothing) Then Exit Sub
		If (e.Button = MouseButtons.Left) Then
			With slicer.CellMiddle
				If (e.X < lastX) Then lastX = .Right Else lastX = .Left
				If (e.Y < lastY) Then lastY = .Bottom Else lastY = .Top
				slicer.CellMiddle = Rectangle.FromLTRB(Min(lastX, e.X), Min(lastY, e.Y), Max(lastX, e.X), Max(lastY, e.Y))
			End With
			DrawCropRectangle()
		End If
	End Sub

#End Region

End Class
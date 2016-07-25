<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridSliceGUI
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.StatusStrip = New System.Windows.Forms.StatusStrip
		Me.PictureBox = New System.Windows.Forms.PictureBox
		Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
		CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'StatusStrip
		'
		Me.StatusStrip.Location = New System.Drawing.Point(0, 425)
		Me.StatusStrip.Name = "StatusStrip"
		Me.StatusStrip.Size = New System.Drawing.Size(664, 22)
		Me.StatusStrip.TabIndex = 0
		Me.StatusStrip.Text = "StatusStrip1"
		'
		'PictureBox
		'
		Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PictureBox.Location = New System.Drawing.Point(0, 0)
		Me.PictureBox.Name = "PictureBox"
		Me.PictureBox.Size = New System.Drawing.Size(664, 447)
		Me.PictureBox.TabIndex = 1
		Me.PictureBox.TabStop = False
		'
		'OpenFileDialog
		'
		Me.OpenFileDialog.FileName = "OpenFileDialog1"
		'
		'GridSliceGUI
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(664, 447)
		Me.Controls.Add(Me.StatusStrip)
		Me.Controls.Add(Me.PictureBox)
		Me.Name = "GridSliceGUI"
		Me.Text = "GridSlice - Zoomicon.com"
		CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
	Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
	Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class

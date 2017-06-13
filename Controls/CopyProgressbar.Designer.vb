<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class copyprogressbar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.bare = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lblms = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.bar, Me.bare})
        Me.ShapeContainer1.Size = New System.Drawing.Size(370, 95)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'bar
        '
        Me.bar.CornerRadius = 1
        Me.bar.FillColor = System.Drawing.Color.DeepSkyBlue
        Me.bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.bar.Location = New System.Drawing.Point(1, 7)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(2, 11)
        '
        'bare
        '
        Me.bare.CornerRadius = 3
        Me.bare.FillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bare.FillGradientColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.bare.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Vertical
        Me.bare.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.bare.Location = New System.Drawing.Point(0, 7)
        Me.bare.Name = "bare"
        Me.bare.Size = New System.Drawing.Size(364, 11)
        '
        'lblms
        '
        Me.lblms.AutoSize = True
        Me.lblms.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblms.Location = New System.Drawing.Point(3, 38)
        Me.lblms.Name = "lblms"
        Me.lblms.Size = New System.Drawing.Size(16, 13)
        Me.lblms.TabIndex = 1
        Me.lblms.Text = "..."
        '
        'copyprogressbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblms)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "copyprogressbar"
        Me.Size = New System.Drawing.Size(370, 95)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents bare As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblms As System.Windows.Forms.Label

End Class

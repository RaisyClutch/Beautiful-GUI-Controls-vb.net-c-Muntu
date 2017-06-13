<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Material_Switch
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
        Me.trck = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.baa = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.trck, Me.baa})
        Me.ShapeContainer1.Size = New System.Drawing.Size(85, 33)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'trck
        '
        Me.trck.BorderColor = System.Drawing.Color.DarkGray
        Me.trck.FillColor = System.Drawing.Color.DarkGray
        Me.trck.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.trck.Location = New System.Drawing.Point(0, 1)
        Me.trck.Name = "trck"
        Me.trck.SelectionColor = System.Drawing.Color.DeepSkyBlue
        Me.trck.Size = New System.Drawing.Size(28, 27)
        '
        'baa
        '
        Me.baa.BorderColor = System.Drawing.Color.Silver
        Me.baa.FillColor = System.Drawing.Color.Silver
        Me.baa.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.baa.Location = New System.Drawing.Point(0, 13)
        Me.baa.Name = "baa"
        Me.baa.Size = New System.Drawing.Size(75, 2)
        '
        'Material_Switch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Material_Switch"
        Me.Size = New System.Drawing.Size(85, 33)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents trck As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents baa As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class

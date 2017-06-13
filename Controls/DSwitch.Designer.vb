<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DarkSwitch2
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
        Me.swt = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.swch = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.swt, Me.swch})
        Me.ShapeContainer1.Size = New System.Drawing.Size(264, 28)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'swt
        '
        Me.swt.FillColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.swt.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.swt.Location = New System.Drawing.Point(5, 5)
        Me.swt.Name = "swt"
        Me.swt.Size = New System.Drawing.Size(13, 12)
        '
        'swch
        '
        Me.swch.CornerRadius = 8
        Me.swch.FillGradientColor = System.Drawing.Color.Gray
        Me.swch.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Vertical
        Me.swch.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.swch.Location = New System.Drawing.Point(0, 4)
        Me.swch.Name = "swch"
        Me.swch.Size = New System.Drawing.Size(59, 16)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Switch state ON/OFF"
        '
        'DarkSwitch2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "DarkSwitch2"
        Me.Size = New System.Drawing.Size(264, 28)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents swch As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents swt As Microsoft.VisualBasic.PowerPacks.OvalShape

End Class

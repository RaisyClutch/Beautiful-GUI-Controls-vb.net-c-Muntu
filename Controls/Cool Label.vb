Imports System.Drawing
Imports System.ComponentModel

Public Class CoolLabel
    Private textco As Color = Color.FromArgb(45, 45, 45)
    Private hoverco As Color = Color.SteelBlue
    Private clickco As Color = Color.SkyBlue
    Private txt As String = "Cool Label"
    Private fnt As Font = New Font("segoe UI", 12)
    <Category("Colors")>
    Property TextColor As Color
        Get
            Return textco
        End Get
        Set(ByVal value As Color)
            textco = value
            Invalidate()
            Update()
        End Set
    End Property

    Property Caption As String
        Get
            Return txt
        End Get
        Set(ByVal value As String)
            txt = value
            Label1.Text = txt
            Invalidate()
            Update()
        End Set
    End Property

    Property FontFamily As Font
        Get
            Return fnt
        End Get
        Set(ByVal value As Font)
            fnt = value
            Label1.Font = fnt
            Invalidate()
            Update()
        End Set
    End Property

    Property Hover As Color
        Get
            Return hoverco
        End Get
        Set(ByVal value As Color)
            hoverco = value
            Invalidate()
            Update()
        End Set
    End Property

    Property ClickColor As Color
        Get
            Return clickco
        End Get
        Set(ByVal value As Color)
            clickco = value
            Invalidate()
            Update()
        End Set
    End Property

    Private Sub CoolLabel_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        Label1.Text = Caption
        Label1.Font = fnt
    End Sub

    Private Sub CoolLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Caption
        Label1.Font = fnt
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseClick
        Label1.ForeColor = clickco
        Label1.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        Label1.ForeColor = hoverco
        Label1.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = textco
    End Sub
End Class

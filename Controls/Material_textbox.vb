Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

<ToolboxBitmap("FCP.bmp")>
Public Class Material_textbox
    Inherits UserControl
    <Description("text color"), DisplayName("textColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsstee As Color
        Get
            Return TextBox1.ForeColor
        End Get
        Set(ByVal value As Color)
            _TextBox1.ForeColor = value
        End Set
    End Property

    <Description("background color"), DisplayName("BGColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnssee As Color
        Get
            Return TextBox1.BackColor
        End Get
        Set(ByVal value As Color)
            _TextBox1.BackColor = value
            Me.BackColor = value
        End Set
    End Property

    <Description("line color"), DisplayName("LineColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsseae As Color
        Get
            Return RectangleShape1.FillColor
        End Get
        Set(ByVal value As Color)
            RectangleShape1.FillColor = value
            RectangleShape1.BorderColor = value
        End Set
    End Property

    <Description("font of the text"), DisplayName("Font"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsseaye As Font
        Get
            Return TextBox1.Font
        End Get
        Set(ByVal value As Font)
            TextBox1.Font = value
        End Set
    End Property

    <Description("caption"), DisplayName("text"), _
Browsable(True), Category("extendedProperties")> _
    Public Property butontxt As String
        Get
            Return _TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property
    Private Sub Material_textbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Size = Me.Size
        RectangleShape1.Width = Me.Width
    End Sub

    Private Sub Material_textbox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        RectangleShape1.Height = 4
    End Sub

    Private Sub Material_textbox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        RectangleShape1.Height = 3
    End Sub

    Private Sub Material_textbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TextBox1.Size = Me.Size
        RectangleShape1.Width = Me.Width
    End Sub

    Private Sub TextBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseHover
        RectangleShape1.Height = 4
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        RectangleShape1.Height = 3
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub RectangleShape1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles RectangleShape1.MouseHover
        RectangleShape1.Height = 4
    End Sub

    Private Sub RectangleShape1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RectangleShape1.MouseLeave
        RectangleShape1.Height = 3
    End Sub
End Class

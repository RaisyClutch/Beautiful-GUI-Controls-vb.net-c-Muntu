Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

<ToolboxBitmap("FCP.bmp")>
Public Class darkbutton
    Inherits UserControl


    <Description("caption"), DisplayName("buttontext"), _
Browsable(True), Category("extendedProperties")> _
    Public Property butontxt As String
        Get
            Return _Button1.Text
        End Get
        Set(ByVal value As String)
            _Button1.Text = value
        End Set
    End Property

    <Description("textPosistion"), DisplayName("TextPosition"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsize As Size
        Get
            Return _Button1.Size
        End Get
        Set(ByVal value As Size)
            _Button1.Size = value
        End Set
    End Property

    <Description("button hover color"), DisplayName("buttonHover"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btns As Color
        Get
            Return _Button1.FlatAppearance.MouseOverBackColor
        End Get
        Set(ByVal value As Color)
            _Button1.FlatAppearance.MouseOverBackColor = value
        End Set
    End Property

    <Description("button click color"), DisplayName("buttonClick"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnss As Color
        Get
            Return _Button1.FlatAppearance.MouseDownBackColor
        End Get
        Set(ByVal value As Color)
            _Button1.FlatAppearance.MouseDownBackColor = value
        End Set
    End Property

    <Description("button text color"), DisplayName("buttontextColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnssee As Color
        Get
            Return _Button1.ForeColor
        End Get
        Set(ByVal value As Color)
            _Button1.ForeColor = value
        End Set
    End Property

    <Description("button color"), DisplayName("buttonBackColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsse As Color
        Get
            Return _Button1.BackColor
        End Get
        Set(ByVal value As Color)
            _Button1.BackColor = value
        End Set
    End Property

    <Description("button border color"), DisplayName("buttonBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnssea As Color
        Get
            Return _Button1.FlatAppearance.BorderColor
        End Get
        Set(ByVal value As Color)
            _Button1.FlatAppearance.BorderColor = value
        End Set
    End Property

    <Description("button border size"), DisplayName("buttonSize"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsseaa As String
        Get
            Return _Button1.FlatAppearance.BorderSize
        End Get
        Set(ByVal value As String)
            _Button1.FlatAppearance.BorderSize = value
        End Set
    End Property

    <Description("image on the button"), DisplayName("image"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsseaga As Image
        Get
            Return _Button1.Image
        End Get
        Set(ByVal value As Image)
            _Button1.Image = value
        End Set
    End Property

    <Description("image alignment on the button"), DisplayName("imageAlign"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnssehagsa As ImageLayout
        Get
            Return _Button1.ImageAlign
        End Get
        Set(ByVal value As ImageLayout)
            _Button1.ImageAlign = value
        End Set
    End Property

    <Description("text alignment on the button"), DisplayName("textAlign"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnssehagsae As ImageLayout
        Get
            Return _Button1.TextAlign
        End Get
        Set(ByVal value As ImageLayout)
            _Button1.TextAlign = value
        End Set
    End Property

    <Description("background of the button"), DisplayName("background"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnae As Image
        Get
            Return _Button1.BackgroundImage
        End Get
        Set(ByVal value As Image)
            _Button1.BackgroundImage = value
        End Set
    End Property

    <Description("background of the button alignment"), DisplayName("backgroundLayout"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnaee As ImageLayout
        Get
            Return _Button1.BackgroundImageLayout
        End Get
        Set(ByVal value As ImageLayout)
            _Button1.BackgroundImageLayout = value
        End Set
    End Property


    Private Sub darkbutton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub darkbutton_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Button1.Size = Me.Size

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class



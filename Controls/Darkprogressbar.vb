Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

<ToolboxBitmap("FCP.bmp")>
Public Class darkprogressbar
    Inherits UserControl
    <Description("Style of the progressbar"), DisplayName("ProgressbarStyle"), _
 Browsable(True), Category("extendedProperties")> _
    Public Property BarStyle As Color
        Get
            Return bar.FillColor
        End Get
        Set(ByVal value As Color)
            bar.FillColor = value
        End Set
    End Property

    <Description("Color of the progressbar"), DisplayName("ProgressbarColor"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property BarColor As Color
        Get
            Return bare.FillColor
        End Get
        Set(ByVal value As Color)
            bare.FillColor = value
        End Set
    End Property

    <Description("size"), DisplayName("width of bar"), _
Browsable(True), Category("extendedProperties")> _
    Public Property progbarwidth As Size
        Get
            Return bare.Size
            Return bar.Size
        End Get
        Set(ByVal value As Size)
            bare.Size = value
            bar.Size = value
        End Set
    End Property

    <Description("Value of progressbar"), DisplayName("Value"), _
Browsable(True), Category("extendedProperties")> _
    Public Property value As String
        Get
            Return _bar.Width
        End Get
        Set(ByVal value As String)
            valuue(value)
        End Set
    End Property

    Function valuue(ByVal va As String)
        bar.Width = va / 100 * bare.Width
        Return bar.Width
    End Function

    Private Sub darkprogressbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bar.Width = 0
    End Sub

    Private Sub darkprogressbar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        bare.Size = Me.Size
        bar.Height = Me.Height - 4

    End Sub

    Private Sub bare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bare.Click

    End Sub
End Class

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Public Class CustomSeperator
    Inherits UserControl
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#Region "Declarations"
    Private _SeperatorColour As Color = Color.FromArgb(35, 35, 35)
    Private _Alignment As Style = Style.Horizontal
    Private _Thickness As Single = 1
#End Region

#Region "Properties"

    Enum Style
        Horizontal
        Verticle
    End Enum

    <Category("Control")>
    Public Property Thickness As Single
        Get
            Return _Thickness
        End Get
        Set(ByVal value As Single)
            _Thickness = value
        End Set
    End Property

    <Category("Control")>
    Public Property Alignment As Style
        Get
            Return _Alignment
        End Get
        Set(ByVal value As Style)
            _Alignment = value
        End Set
    End Property

    <Category("Colors")>
    Public Property Color As Color
        Get
            Return _SeperatorColour
        End Get
        Set(ByVal value As Color)
            _SeperatorColour = value
        End Set
    End Property

#End Region
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Size = New Size(20, 20)
        InitializeComponent()
    End Sub

    Private Sub CustomSeperator_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width - 1, Height - 1)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            Select Case _Alignment
                Case Style.Horizontal
                    .DrawLine(New Pen(_SeperatorColour, _Thickness), New Point(0, Height / 2), New Point(Width, Height / 2))
                Case Style.Verticle
                    .DrawLine(New Pen(_SeperatorColour, _Thickness), New Point(Width / 2, 0), New Point(Width / 2, Height))
            End Select
        End With
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()

    End Sub
End Class

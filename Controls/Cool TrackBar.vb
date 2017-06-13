Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class CoolTrackBar

    Inherits UserControl
    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#Region "Declaration"
    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private CaptureMovement As Boolean = False
    Private Bar As Rectangle = New Rectangle(0, 10, Width - 21, Height - 21)
    Private Track As Size = New Size(28, 18)
    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _BarBaseColor As Color = Color.FromArgb(40, 40, 40)
    Private _StripColor As Color = Color.FromArgb(50, 50, 50)
    Private _StripAmountColor As Color = Color.DeepSkyBlue
#End Region

#Region "Properties"

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TrackColor As Color
        Get
            Return _BarBaseColor
        End Get
        Set(ByVal value As Color)
            _BarBaseColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property BGColor As Color
        Get
            Return _StripColor
        End Get
        Set(ByVal value As Color)
            _StripColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(ByVal value As Color)
            _TextColor = value
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property AmountColor As Color
        Get
            Return _StripAmountColor
        End Get
        Set(ByVal value As Color)
            _StripAmountColor = value
        End Set
    End Property

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _Maximum = value
            If value < _Value Then _Value = value
            Invalidate()
        End Set
    End Property

    Event ValueChanged()

    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < 0
                    _Value = 0
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            Invalidate()
            RaiseEvent ValueChanged()
        End Set
    End Property

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        BackColor = Color.Transparent
        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim MovementPoint As New Rectangle(New Point(e.Location.X, e.Location.Y), New Size(1, 1))
        Dim Bar As New Rectangle(10, 10, Width - 21, Height - 21)
        If New Rectangle(New Point(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2 - 1), 0), New Size(Track.Width, Height)).IntersectsWith(MovementPoint) Then
            CaptureMovement = True
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureMovement = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If CaptureMovement Then
            Dim MovementPoint As New Point(e.X, e.Y)
            Dim Bar As New Rectangle(10, 10, Width - 21, Height - 21)
            Value = CInt(Maximum * ((MovementPoint.X - Bar.X) / Bar.Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e) : CaptureMovement = False
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                    ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                    ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            Bar = New Rectangle(13, 11, Width - 27, Height - 21)

            .SmoothingMode = SmoothingMode.AntiAlias
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .FillRectangle(New SolidBrush(_StripColor), New Rectangle(3, CInt((Height / 2) - 4), Width - 5, 8))
            .DrawRectangle(New Pen(_BorderColor, 2), New Rectangle(4, CInt((Height / 2) - 4), Width - 5, 8))
            .FillRectangle(New SolidBrush(_StripAmountColor), New Rectangle(4, CInt((Height / 2) - 4), CInt(Bar.Width * (Value / Maximum)) + CInt(Track.Width / 2), 8))
            .FillRectangle(New SolidBrush(_BarBaseColor), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
            .DrawRectangle(New Pen(_BorderColor, 2), Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width, Track.Height)
            .DrawString(_Value, New Font("Segoe UI", 6.5, FontStyle.Regular), New SolidBrush(_TextColor), New Rectangle(Bar.X + CInt(Bar.Width * (Value / Maximum)) - CInt(Track.Width / 2), Bar.Y + CInt((Bar.Height / 2)) - CInt(Track.Height / 2), Track.Width - 1, Track.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

    Private Sub CoolTrackBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Public Class HScrollBar

    Inherits UserControl

#Region "Declarations"

    Private ThumbMovement As Integer
    Private LSA As Rectangle
    Private RSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle
    Private ShowThumb As Boolean
    Private ThumbPressed As Boolean
    Private _ThumbSize As Integer = 45
    Private _Minimum As Integer = 0
    Private _Maximum As Integer = 100
    Private _Value As Integer = 0
    Private _SmallChange As Integer = 1
    Private _ButtonSize As Integer = 16
    Private _LargeChange As Integer = 10
    Private _ThumbBorder As Color = Color.FromArgb(35, 35, 35)
    Private _LineColors As Color = Color.DeepSkyBlue
    Private _ArrowColors As Color = Color.FromArgb(37, 37, 37)
    Private _BaseColors As Color = Color.FromArgb(47, 47, 47)
    Private _ThumbColors As Color = Color.DeepSkyBlue
    Private _ThumbSecondBorder As Color = Color.FromArgb(65, 65, 65)
    Private _FirstBorder As Color = Color.FromArgb(55, 55, 55)
    Private _SecondBorder As Color = Color.FromArgb(35, 35, 35)
    Private ThumbDown As Boolean = False
#End Region

#Region "Properties & Events"

    <Category("Colors")> _
    Public Property StyleColors As Color
        Get
            Return _LineColors
        End Get
        Set(ByVal value As Color)
            _LineColors = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ScrollLineColors As Color
        Get
            Return _ArrowColors
        End Get
        Set(ByVal value As Color)
            _ArrowColors = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BGColors As Color
        Get
            Return _BaseColors
        End Get
        Set(ByVal value As Color)
            _BaseColors = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ScrollColor As Color
        Get
            Return _ThumbColors
        End Get
        Set(ByVal value As Color)
            _ThumbColors = value
        End Set
    End Property


    <Category("Colors")> _
    Public Property FirstBorder As Color
        Get
            Return _FirstBorder
        End Get
        Set(ByVal value As Color)
            _FirstBorder = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property SecondBorder As Color
        Get
            Return _SecondBorder
        End Get
        Set(ByVal value As Color)
            _SecondBorder = value
        End Set
    End Property

    Event Scrolla(ByVal sender As Object)

    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            InvalidateLayout()
        End Set
    End Property

    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
        End Set
    End Property

    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < _Minimum
                    _Value = _Minimum
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            InvalidatePosition()
            RaiseEvent Scrolla(Me)
        End Set
    End Property

    Public Property SmallScroll() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Is >
                    _SmallChange = value
            End Select
        End Set
    End Property

    Public Property LargeScroll() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Else
                    _LargeChange = value
            End Select
        End Set
    End Property

    Public Property ButtonSize As Integer
        Get
            Return _ButtonSize
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 16
                    _ButtonSize = 16
                Case Else
                    _ButtonSize = value
            End Select
        End Set
    End Property

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        LSA = New Rectangle(0, 1, 0, Height)
        Shaft = New Rectangle(LSA.Right + 1, 0, Width - 3, Height)
        ShowThumb = ((_Maximum - _Minimum))
        Thumb = New Rectangle(0, 1, _ThumbSize, Height - 3)
        RaiseEvent Scrolla(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.X = CInt(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Width - _ThumbSize) + 1)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If LSA.Contains(e.Location) Then
                ThumbMovement = _Value - _SmallChange
            ElseIf RSA.Contains(e.Location) Then
                ThumbMovement = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    Return
                Else
                    If e.X < Thumb.X Then
                        ThumbMovement = _Value - _LargeChange
                    Else
                        ThumbMovement = _Value + _LargeChange
                    End If
                End If
            End If
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.X - LSA.Width - (_ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Width - _ThumbSize

            ThumbMovement = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or _
                           ControlStyles.UserPaint Or ControlStyles.Selectable Or _
                           ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Height = 18
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Width)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Color.FromArgb(47, 47, 47))
            Dim P() As Point = {New Point(5, Height / 2), New Point(13, Height / 4), New Point(13, Height / 2 - 2), New Point(Width - 13, Height / 2 - 2), _
                    New Point(Width - 13, Height / 4), New Point(Width - 5, Height / 2), New Point(Width - 13, Height - Height / 4 - 1), New Point(Width - 13, Height / 2 + 2), _
                               New Point(13, Height / 2 + 2), New Point(13, Height - Height / 4 - 1)}
            .FillRectangle(New SolidBrush(_ThumbColors), Thumb)
            .DrawRectangle(New Pen(_ThumbBorder), Thumb)
            .DrawLine(New Pen((_LineColors), 2), New Point(Thumb.X + 4, (CInt(Thumb.Height / 2 + 1))), New Point(Thumb.Right - 4, (CInt(Thumb.Height / 2 + 1))))

        End With
        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region


    Private Sub HScrollBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class


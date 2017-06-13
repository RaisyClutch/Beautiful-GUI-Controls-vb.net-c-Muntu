Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Public Class CircularProgressT
    Inherits UserControl
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _BaseColor As Color = Color.FromArgb(42, 42, 42)
    Private _ProgressColor As Color = Color.FromArgb(0, 160, 199)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _StartingAngle As Integer = 168
    Private _RotationAngle As Integer = 360
    Private ReadOnly _Font As Font = New Font("Segoe UI", 20)
    Private txtcolor As Color = Color.Black



    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                Case Else
                    Return _Value
            End Select
        End Get

        Set(ByVal V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property ProgressColor As Color
        Get
            Return _ProgressColor
        End Get
        Set(ByVal value As Color)
            _ProgressColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("Colors")>
    Public Property TextColor As Color
        Get
            Return txtcolor
        End Get
        Set(ByVal value As Color)
            txtcolor = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("ControlAngel")>
    Public Property StartAngle As Integer
        Get
            Return _StartingAngle
        End Get
        Set(ByVal value As Integer)
            _StartingAngle = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Category("ControlAngel")>
    Public Property RotationAngle As Integer
        Get
            Return _RotationAngle
        End Get
        Set(ByVal value As Integer)
            _RotationAngle = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(78, 78)
        BackColor = Color.Transparent
        InitializeComponent()
    End Sub

    Private Sub CustomRadialProgress_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(Color.Transparent)
            Select Case _Value
                Case 0
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case _Maximum
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Case Else
                    .DrawArc(New Pen(New SolidBrush(_BorderColor), 1 + 5), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5)
                    .DrawArc(New Pen(New SolidBrush(_BaseColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle)
                    .DrawArc(New Pen(New SolidBrush(_ProgressColor), 1 + 3), CInt(3 / 2) + 1, CInt(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, CInt((_RotationAngle / _Maximum) * _Value))
                    .DrawString(_Value, _Font, ToBrush(txtcolor), New Point(Width / 2, Height / 2 - 1), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End Select
        End With
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Private Sub CustomRadialProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

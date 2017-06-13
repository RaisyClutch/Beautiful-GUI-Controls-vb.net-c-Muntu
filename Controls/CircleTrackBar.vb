Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Class CircleTrackBar : Inherits UserControl

#Region " Variables"

    Private W, H As Integer
    Private Val As Integer
    Private Bool As Boolean
    Private Track As Rectangle
    Private Knob As Rectangle
    Private Style_ As _Style
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            Track = New Rectangle(Val, 0, 10, 20)

            Bool = Track.Contains(e.Location)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Bool AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
            Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Bool = False
    End Sub

#End Region

#Region " Styles"

    <Flags()> _
    Enum _Style
        Slider
        Knob
    End Enum

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property SpillColor As Color
        Get
            Return _TrackColor
        End Get
        Set(ByVal value As Color)
            _TrackColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property KnobColor As Color
        Get
            Return SliderColor
        End Get
        Set(ByVal value As Color)
            SliderColor = value
        End Set
    End Property

#End Region

    Event Scrolll(ByVal sender As Object)
    Private _Minimum As Integer
    Public Property Minimum As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
            End If

            _Minimum = value

            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property
    Private _Maximum As Integer = 10
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
            End If

            _Value = value
            Invalidate()
            RaiseEvent Scrolll(Me)
        End Set
    End Property
    Private _ShowValue As Boolean = True

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Subtract Then
            If Value = 0 Then Exit Sub
            Value -= 1
        ElseIf e.KeyCode = Keys.Add Then
            If Value = _Maximum Then Exit Sub
            Value += 1
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Height = 23
    End Sub

#End Region

#Region " Colors"

    Private BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _TrackColor As Color = Color.FromArgb(55, 55, 55)
    Private SliderColor As Color = Color.DimGray
    Private _HatchColor As Color = Color.FromArgb(23, 148, 92)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Height = 18
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(1, 6, W - 2, 8)
        Dim GP, GP2 As New GraphicsPath

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(BackColor)

            '-- Value
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (W - 10))
            Track = New Rectangle(Val, 0, 10, 20)
            Knob = New Rectangle(Val, 4, 13, 13)

            '-- Base
            GP.AddRectangle(Base)
            .SetClip(GP)
            .FillRectangle(New SolidBrush(BaseColor), New Rectangle(10, 7, W, 8))
            .FillRectangle(New SolidBrush(_TrackColor), New Rectangle(0, 7, Track.X + Track.Width, 6))
            .ResetClip()

            '-- Hatch Brush


            '-- Slider/Knob


            GP2.AddEllipse(Knob)
            .FillPath(New SolidBrush(SliderColor), GP2)


            '-- Show the value 

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

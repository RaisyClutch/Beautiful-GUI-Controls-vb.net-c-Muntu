Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
'****README FIRST*************
'
'Copyright (c) 2017 Raisy Clutch
'your free to use this code in anyway you want , for anything but at your own risk, i wont be responsible for what happens to your computer, released under the MIT Licence
'if you love something set it free
'
'copy ffmpeg.exe to your bin/Debug and Release folder
' Donate to raisycltch@gmail.com i need a cup of coffee
'blog: raisyclutch.wordpress.com
'********THE END***************
Module ASS
#Region " Variables"
    ' From the flat theme by isynthesis
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region

#Region " Functions"
    'functions by aeonhack
    Private Function Round(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    '-- Credit: AeonHack
    Private Function DrawArrow(ByVal x As Integer, ByVal y As Integer, ByVal flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 12
        Dim H As Integer = 6

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

#End Region


#Region " Mouse States"

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#End Region


    Private Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Private Function Roun(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function


    Private Function Triangle(ByVal Location As Point, ByVal Size As Size) As Point()
        Dim ReturnPoints(0 To 3) As Point
        ReturnPoints(0) = Location
        ReturnPoints(1) = New Point(Location.X + Size.Width, Location.Y)
        ReturnPoints(2) = New Point(Location.X + Size.Width \ 2, Location.Y + Size.Height)
        ReturnPoints(3) = Location
        Return ReturnPoints
    End Function


#Region "Functions"

    Private Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Private Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

#End Region
End Module

Public Class Listitems
    Inherits ProfessionalColorTable

#Region "Declarations"

    Private _BackColor As Color = Color.FromArgb(42, 42, 42)
    Private _BorderColor As Color = Color.FromArgb(35, 35, 35)
    Private _SelectedColor As Color = Color.DeepSkyBlue

#End Region

#Region "Properties"
    <ToolboxItem(True)>
    <Category("Colors")>
Public Property SelectedColor As Color
        Get
            Return _SelectedColor
        End Get
        Set(ByVal value As Color)
            _SelectedColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BgColor As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value
        End Set
    End Property

    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return _BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return _SelectedColor
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return _BorderColor
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return _BackColor
        End Get
    End Property

#End Region

End Class
Public Class DarkTabControl
    Inherits TabControl

#Region "Declarations"

    Private _TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _BackTabColor As Color = Color.FromArgb(45, 45, 45)
    Private _BaseColor As Color = Color.FromArgb(35, 35, 35)
    Private _ActiveColor As Color = Color.FromArgb(47, 47, 47)
    Private _BorderColor As Color = Color.FromArgb(30, 30, 30)
    Private _UpLineColor As Color = Color.FromArgb(0, 160, 199)
    Private _HorizLineColor As Color = Color.FromArgb(23, 119, 151)
    Private CenterSF As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}

#End Region

#Region "Properties"
    <ToolboxItem(True)>
    <Category("Colors")> _
Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property LineColor As Color
        Get
            Return _UpLineColor
        End Get
        Set(ByVal value As Color)
            _UpLineColor = value
            Invalidate()
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
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property TabColor As Color
        Get
            Return _BackTabColor
        End Get
        Set(ByVal value As Color)
            _BackTabColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property BgColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")> _
    Public Property ActiveColor As Color
        Get
            Return _ActiveColor
        End Get
        Set(ByVal value As Color)
            _ActiveColor = value
            Invalidate()
            Update()
        End Set
    End Property

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 8)
        SizeMode = TabSizeMode.Normal
        ItemSize = New Size(240, 32)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .Clear(_BaseColor)
            Try : SelectedTab.BackColor = _BackTabColor : Catch : End Try
            Try : SelectedTab.BorderStyle = BorderStyle.None : Catch : End Try
            .DrawRectangle(New Pen(_BorderColor, 1), New Rectangle(0, 0, Width, Height))
            For i = 0 To TabCount - 1
                Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))
                If i = SelectedIndex Then
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)
                    .FillRectangle(New SolidBrush(_ActiveColor), New Rectangle(Base.X, Base.Y + 5, Base.Width, Base.Height + 6))
                    .DrawString(TabPages(i).Text, Font, New SolidBrush(_TextColor), New Rectangle(Base.X, Base.Y, Base.Width, Base.Height), CenterSF)
                    .DrawLine(New Pen(_UpLineColor, 2), New Point(Base.X, Base.Y), New Point(Base.X, Base.Height))
                Else
                    .DrawString(TabPages(i).Text, Font, New SolidBrush(_TextColor), BaseSize, CenterSF)
                End If
            Next
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class

Class KnobTrackBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private Val As Integer
    Private Bool As Boolean
    Private Track As Rectangle
    Private Knob As Rectangle
    Private Style_ As _Style

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
    <ToolboxItem(True)>
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

    Event Scroll(ByVal sender As Object)
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
            RaiseEvent Scroll(Me)
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

Public Class TrackBar

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
    <ToolboxItem(True)>
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
End Class

Class VerticalTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or _
                 ControlStyles.DoubleBuffer, True)

        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(44, 135)
        DrawMode = TabDrawMode.OwnerDrawFixed

        For Each Page As TabPage In Me.TabPages
            Page.BackColor = tabpagecolor
        Next
    End Sub
    Private tabpagecolor As Color = Color.FromArgb(50, 50, 50)
    Private linecolor As Color = Color.FromArgb(25, 26, 28)
    Private Activecolor As Color = Color.FromArgb(50, 50, 50)
    Private tabgcolor As Color = Color.FromArgb(45, 45, 45)
    Private hoverColor As Color = Color.DeepSkyBlue
    Private txtco As Color = Color.FromArgb(254, 255, 255)
    Private fant As Font = New Font("Segoe UI", 8)

    <ToolboxItem(True)>
    <Category("Colors")>
    Property PageColor As Color
        Get
            Return tabpagecolor
        End Get
        Set(ByVal value As Color)
            tabpagecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property SelectedColor As Color
        Get
            Return Activecolor
        End Get
        Set(ByVal value As Color)
            Activecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property MenuColor As Color
        Get
            Return tabgcolor
        End Get
        Set(ByVal value As Color)
            tabgcolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property VLineColor As Color
        Get
            Return linecolor
        End Get
        Set(ByVal value As Color)
            linecolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property TextColor As Color
        Get
            Return txtco
        End Get
        Set(ByVal value As Color)
            txtco = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Font")>
    Property TabFont As Font
        Get
            Return fant
        End Get
        Set(ByVal value As Font)
            fant = value
            Invalidate()
            Update()
        End Set
    End Property


    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        If TypeOf e.Control Is TabPage Then
            For Each i As TabPage In Me.Controls
                i = New TabPage
            Next
            e.Control.BackColor = tabpagecolor
        End If
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        MyBase.DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        Appearance = TabAppearance.Normal
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        With G

            .Clear(tabpagecolor)
            .SmoothingMode = SmoothingMode.HighSpeed
            .CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            .CompositingMode = Drawing2D.CompositingMode.SourceOver

            ' Draw tab selector background
            .FillRectangle(New SolidBrush(tabgcolor), New Rectangle(-5, 0, ItemSize.Height + 5, Height))
            ' Draw vertical line at the end of the tab selector rectangle
            .DrawLine(New Pen(linecolor), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height)

            For TabIndex As Integer = 0 To TabCount - 1
                If TabIndex = SelectedIndex Then
                    Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))

                    ' Draw background of the selected tab
                    .FillRectangle(New SolidBrush(Activecolor), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3)
                    ' Draw a tab highlighter on the background of the selected tab
                    Dim TabHighlighter As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - IIf(TabIndex = 0, 1, 1)), New Size(4, GetTabRect(TabIndex).Height - 7))
                    .FillRectangle(New SolidBrush(hoverColor), TabHighlighter)
                    ' Draw tab text
                    .DrawString(TabPages(TabIndex).Text, fant, New SolidBrush(txtco), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                    If Me.ImageList IsNot Nothing Then
                        Dim Index As Integer = TabPages(TabIndex).ImageIndex
                        If Not Index = -1 Then
                            .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                        End If
                    End If

                Else

                    Dim TabRect As Rectangle = New Rectangle(New Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), New Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8))
                    ' Draw tab text
                    .DrawString(TabPages(TabIndex).Text, fant, New SolidBrush(txtco), New Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), New StringFormat With {.Alignment = StringAlignment.Near})

                    If Me.ImageList IsNot Nothing Then
                        Dim Index As Integer = TabPages(TabIndex).ImageIndex
                        If Not Index = -1 Then
                            .DrawImage(Me.ImageList.Images.Item(TabPages(TabIndex).ImageIndex), TabRect.X + 9, TabRect.Y + 6, 24, 24)
                        End If
                    End If

                End If
            Next
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality
            e.Graphics.DrawImage(B.Clone, 0, 0)
            G.Dispose()
            B.Dispose()
        End With
    End Sub
End Class

Public Class NormalComboBox : Inherits ComboBox

#Region " Control Help - Properties & Flicker Control "
    Enum ColorSchemes
        Light
        Dark
    End Enum
    <ToolboxItem(True)>
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property
    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property
    Private _StartIndex As Integer = 0
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds)
                    Case ColorSchemes.Light
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
                End Select
            End If
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.White, e.Bounds)
                Case ColorSchemes.Light
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.Black, e.Bounds)
            End Select
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
    End Sub
#End Region
    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
        AccentColor = Color.DodgerBlue
        ColorScheme = ColorSchemes.Dark
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI Semilight", 9.75F)
        StartIndex = 0
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Curve As Integer = 2
        G.SmoothingMode = SmoothingMode.HighQuality
        Select Case ColorScheme
            Case ColorSchemes.Dark
                G.Clear(Color.FromArgb(50, 50, 50))
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))
            Case ColorSchemes.Light
                G.Clear(Color.White)
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100)), New Point(Width - 14, 15), New Point(Width - 14, 14))
        End Select
        G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))
        Try
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.DrawString(Text, Font, Brushes.White, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                Case ColorSchemes.Light
                    G.DrawString(Text, Font, Brushes.Black, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End Select
        Catch
        End Try
        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class

Public Class CircleProgress
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

    ' from the logintheme by xherts
    <ToolboxItem(True)>
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
End Class


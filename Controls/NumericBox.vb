Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class NumericBox
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
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
    Public Function DrawArrow(ByVal x As Integer, ByVal y As Integer, ByVal flip As Boolean) As GraphicsPath
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





#Region " Mouse States"

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#End Region

    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return New SolidBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return New SolidBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, R, G, B)))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(R, G, B)))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, C)))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return New Pen(New SolidBrush(Color))
    End Function

    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
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

    Public Function Triangle(ByVal Location As Point, ByVal Size As Size) As Point()
        Dim ReturnPoints(0 To 3) As Point
        ReturnPoints(0) = Location
        ReturnPoints(1) = New Point(Location.X + Size.Width, Location.Y)
        ReturnPoints(2) = New Point(Location.X + Size.Width \ 2, Location.Y + Size.Height)
        ReturnPoints(3) = Location
        Return ReturnPoints
    End Function

    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRect(ByVal x!, ByVal y!, ByVal w!, ByVal h!, Optional ByVal r! = 0.3, Optional ByVal TL As Boolean = True, Optional ByVal TR As Boolean = True, Optional ByVal BR As Boolean = True, Optional ByVal BL As Boolean = True) As GraphicsPath
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
#Region " Variables"

    Private W, H As Integer
    Private State As MouseState = MouseState.None
    Private x, y As Integer
    Private _Value, _Min, _Max As Long
    Private Bool As Boolean

#End Region

#Region " Properties"

    Public Property Value As Long
        Get
            Return _Value
        End Get
        Set(ByVal value As Long)
            If value <= _Max And value >= _Min Then _Value = value
            Invalidate()
        End Set
    End Property

    Public Property Maximum As Long
        Get
            Return _Max
        End Get
        Set(ByVal value As Long)
            If value > _Min Then _Max = value
            If _Value > _Max Then _Value = _Max
            Invalidate()
        End Set
    End Property

    Public Property Minimum As Long
        Get
            Return _Min
        End Get
        Set(ByVal value As Long)
            If value < _Max Then _Min = value
            If _Value < _Min Then _Value = Minimum
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.Location.X
        y = e.Location.Y
        Invalidate()
        If e.X < Width - 23 Then Cursor = Cursors.IBeam Else Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If x > Width - 21 AndAlso x < Width - 3 Then
            If y < 15 Then
                If (Value + 1) <= _Max Then _Value += 1
            Else
                If (Value - 1) >= _Min Then _Value -= 1
            End If
        Else
            Bool = Not Bool
            Focus()
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        Try
            If Bool Then _Value = CStr(CStr(_Value) & e.KeyChar.ToString())
            If _Value > _Max Then _Value = _Max
            Invalidate()
        Catch : End Try
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Back Then
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Height = 26
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BGColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ButtonColor As Color
        Get
            Return _ButtonColor
        End Get
        Set(ByVal value As Color)
            _ButtonColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _ButtonColor As Color = Color.FromArgb(55, 55, 55)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
        ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 10)
        BackColor = Color.FromArgb(60, 70, 73)
        ForeColor = Color.DimGray
        _Min = 0
        _Max = 1000000000
        InitializeComponent()
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 3
            .PixelOffsetMode = 2
            .TextRenderingHint = 5
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)
            .FillRectangle(New SolidBrush(_ButtonColor), New Rectangle(Width - 24, 0, 24, H))

            '-- Add
            .DrawString("˄", New Font("Segoe UI", 7), Brushes.DimGray, New Point(Width - 12, 8), CenterSF)
            '-- Subtract
            .DrawString("˅", New Font("Segoe UI", 7), Brushes.DimGray, New Point(Width - 12, 20), CenterSF)

            '-- Text
            .DrawString(Value, Font, Brushes.White, New Rectangle(5, 1, W, H), New StringFormat() With {.LineAlignment = StringAlignment.Center})
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

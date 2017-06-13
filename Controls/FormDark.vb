Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class FormDark
    Inherits UserControl

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#Region "Declarations"
    Private _AllowClose As Boolean = True
    Private _AllowMinimize As Boolean = True
    Private _AllowMaximize As Boolean = True
    Private _FontSize As Integer = 9
    Private ReadOnly _Font As Font = New Font("Segoe UI", _FontSize)
    Private _ShowIcon As Boolean = False
    Private State As MouseState = MouseState.None
    Private MouseXLoc As Integer
    Private MouseYLoc As Integer
    Private CaptureMovement As Boolean = False
    Private Const MoveHeight As Integer = 35
    Private MouseP As Point = New Point(0, 0)
    Private _FontColor As Color = Color.FromArgb(255, 255, 255)
    Private _BaseColor As Color = Color.FromArgb(35, 35, 35)
    Private _ContainerColor As Color = Color.FromArgb(46, 46, 46)
    Private _BorderColor As Color = Color.FromArgb(60, 60, 60)
    Private _HoverColor As Color = Color.DeepSkyBlue
#End Region

#Region "Properties & Events"

    <Category("Control")>
    Public Property FontSize As Integer
        Get
            Return _FontSize
        End Get
        Set(ByVal value As Integer)
            _FontSize = value
        End Set
    End Property

    <Category("Control")>
    Public Property AllowMinimize As Boolean
        Get
            Return _AllowMinimize
        End Get
        Set(ByVal value As Boolean)
            _AllowMinimize = value
        End Set
    End Property

    <Category("Control")>
    Public Property AllowMaximize As Boolean
        Get
            Return _AllowMaximize
        End Get
        Set(ByVal value As Boolean)
            _AllowMaximize = value
        End Set
    End Property

    <Category("Control")>
    Public Property ShowIcon As Boolean
        Get
            Return _ShowIcon
        End Get
        Set(ByVal value As Boolean)
            _ShowIcon = value
        End Set
    End Property

    <Category("Control")>
    Public Property CloseIcon As Boolean
        Get
            Return _AllowClose
        End Get
        Set(ByVal value As Boolean)
            _AllowClose = value
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
    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(ByVal value As Color)
            _HoverColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BGColor As Color
        Get
            Return _BaseColor
        End Get
        Set(ByVal value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property BaseColor As Color
        Get
            Return _ContainerColor
        End Get
        Set(ByVal value As Color)
            _ContainerColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property FontColor As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
        End Set
    End Property

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        CaptureMovement = False
        State = MouseState.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        MouseXLoc = e.Location.X
        MouseYLoc = e.Location.Y
        Invalidate()
        If CaptureMovement Then
            Parent.Location = MousePosition - MouseP
        End If
        If e.X < Width - 90 AndAlso e.Y > 35 Then Cursor = Cursors.Arrow Else Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If MouseXLoc > Width - 39 AndAlso MouseXLoc < Width - 16 AndAlso MouseYLoc < 22 Then
            If _AllowClose Then
                Environment.Exit(0)
            End If
        ElseIf MouseXLoc > Width - 64 AndAlso MouseXLoc < Width - 41 AndAlso MouseYLoc < 22 Then
            If _AllowMaximize Then
                Select Case FindForm.WindowState
                    Case FormWindowState.Maximized
                        FindForm.WindowState = FormWindowState.Normal
                    Case FormWindowState.Normal
                        FindForm.WindowState = FormWindowState.Maximized
                End Select
            End If
        ElseIf MouseXLoc > Width - 89 AndAlso MouseXLoc < Width - 66 AndAlso MouseYLoc < 22 Then
            If _AllowMinimize Then
                Select Case FindForm.WindowState
                    Case FormWindowState.Normal
                        FindForm.WindowState = FormWindowState.Minimized
                    Case FormWindowState.Maximized
                        FindForm.WindowState = FormWindowState.Minimized
                End Select
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width - 90, MoveHeight).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(Width - 90, 22, 75, 13).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(Width - 15, 0, 15, MoveHeight).Contains(e.Location) Then
            CaptureMovement = True
            MouseP = e.Location
        Else
            Focus()
        End If
        State = MouseState.Down
        Invalidate()
    End Sub

#End Region

#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.DoubleBuffered = True
        Me.BackColor = _BaseColor
        Me.Dock = DockStyle.Fill
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Parent.FindForm.FormBorderStyle = FormBorderStyle.None
        Parent.FindForm.AllowTransparency = False
        Parent.FindForm.TransparencyKey = Color.White
        Parent.FindForm.FindForm.StartPosition = FormStartPosition.CenterScreen
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .FillRectangle(New SolidBrush(_BaseColor), New Rectangle(0, 0, Width, Height))
            .FillRectangle(New SolidBrush(_ContainerColor), New Rectangle(2, 45, Width - 4, Height - 45))

            Dim ControlBoxPoints() As Point = {New Point(Width - 90, 0), New Point(Width - 90, 22), New Point(Width - 15, 22), New Point(Width - 15, 0)}
            Select Case State
                Case MouseState.Over
                    If MouseXLoc > Width - 39 AndAlso MouseXLoc < Width - 16 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 39, 0, 23, 22))
                    ElseIf MouseXLoc > Width - 64 AndAlso MouseXLoc < Width - 41 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 64, 0, 23, 22))
                    ElseIf MouseXLoc > Width - 89 AndAlso MouseXLoc < Width - 66 AndAlso MouseYLoc < 22 Then
                        .FillRectangle(New SolidBrush(_HoverColor), New Rectangle(Width - 89, 0, 23, 22))
                    End If
            End Select
            .DrawLine(New Pen(_BorderColor), Width - 40, 0, Width - 40, 22)
            ''Close Button
            .DrawLine(New Pen(_FontColor), Width - 33, 6, Width - 22, 16)
            .DrawLine(New Pen(_FontColor), Width - 33, 16, Width - 22, 6)
            ''Minimize Button
            .DrawLine(New Pen(_FontColor), Width - 83, 16, Width - 72, 16)
            ''Maximize Button
            .DrawLine(New Pen(_FontColor), Width - 58, 16, Width - 47, 16)
            .DrawLine(New Pen(_FontColor), Width - 58, 16, Width - 58, 6)
            .DrawLine(New Pen(_FontColor), Width - 47, 16, Width - 47, 6)
            .DrawLine(New Pen(_FontColor), Width - 58, 6, Width - 47, 6)
            .DrawLine(New Pen(_FontColor), Width - 58, 7, Width - 47, 7)
            If _ShowIcon Then
                .DrawIcon(FindForm.Icon, New Rectangle(6, 6, 22, 22))
                .DrawString(Text, _Font, New SolidBrush(_FontColor), New RectangleF(31, 0, Width - 110, 35), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            Else
                .DrawString(Text, _Font, New SolidBrush(_FontColor), New RectangleF(3, 0, Width - 110, 35), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End If
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region
End Class

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

#Region " NotificationBox "

Class NotificationBox
    Inherits UserControl

#Region " Variables "

    Private CloseCoordinates As Point
    Private IsOverClose As Boolean
    Private _BorderCurve As Integer = 8
    Private CreateRoundPath As GraphicsPath
    Private NotificationText As String = Nothing
    Private _NotificationType As Type
    Private _RoundedCorners As Boolean
    Private _ShowCloseButton As Boolean
    Private _Image As Image
    Private _ImageSize As Size
    Private setngz As Array = {Color.DimGray, Color.DarkSlateGray, Color.White}

    Dim customTex As String = "CUSTOM"
    Dim Tex As String = "Hey Look at This"

#End Region
#Region " Enums "

    ' Create a list of Notification Types
    Enum Type
        [Normal]
        [Success]
        [Warning]
        [Error]
        [Custom]
    End Enum

#End Region
#Region " Custom Properties "

    ' Create a NotificationType property and add the Type enum to it
    Public Property NotificationType As Type
        Get
            Return _NotificationType
        End Get
        Set(ByVal value As Type)
            _NotificationType = value
            Invalidate()
        End Set
    End Property
    ' Boolean value to determine whether the control should use border radius
    Public Property RoundCorners As Boolean
        Get
            Return _RoundedCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundedCorners = value
            Invalidate()
        End Set
    End Property
    ' Boolean value to determine whether the control should draw the close button
    Public Property AllowClose As Boolean
        Get
            Return _ShowCloseButton
        End Get
        Set(ByVal value As Boolean)
            _ShowCloseButton = value
            Invalidate()
        End Set
    End Property

    Public Property CustomNotification As Array
        Get
            Return setngz
        End Get
        Set(ByVal value As Array)
            setngz = value
            Invalidate()
        End Set
    End Property

    Public Property CustomText As String
        Get
            Return customTex
        End Get
        Set(ByVal value As String)
            customTex = value
            Invalidate()
        End Set
    End Property

    ' Integer value to determine the curve level of the borders
    Public Property Radius As Integer
        Get
            Return _BorderCurve
        End Get
        Set(ByVal value As Integer)
            _BorderCurve = value
            Invalidate()
        End Set
    End Property
    ' Image value to determine whether the control should draw an image before the header
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            If value Is Nothing Then
                _ImageSize = Size.Empty
            Else
                _ImageSize = value.Size
            End If

            _Image = value
            Invalidate()
        End Set
    End Property
    ' Size value - returns the image size
    Protected ReadOnly Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
    End Property

#End Region
#Region " EventArgs "

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)

        ' Decides the location of the drawn ellipse. If mouse is over the correct coordinates, "IsOverClose" boolean will be triggered to draw the ellipse
        If e.X >= Width - 19 AndAlso e.X <= Width - 10 AndAlso e.Y > CloseCoordinates.Y AndAlso e.Y < CloseCoordinates.Y + 12 Then
            IsOverClose = True
        Else
            IsOverClose = False
        End If
        ' Updates the control
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        ' Disposes the control when the close button is clicked
        If _ShowCloseButton = True Then
            If IsOverClose Then
                Dispose()
            End If
        End If
    End Sub

#End Region

    Friend Function CreateRoundRect(ByVal r As Rectangle, ByVal curve As Integer) As GraphicsPath
        ' Draw a border radius
        Try
            CreateRoundPath = New GraphicsPath(FillMode.Winding)
            CreateRoundPath.AddArc(r.X, r.Y, curve, curve, 180.0F, 90.0F)
            CreateRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270.0F, 90.0F)
            CreateRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0.0F, 90.0F)
            CreateRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90.0F, 90.0F)
            CreateRoundPath.CloseFigure()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & vbNewLine & "value can't be 0, must be higher", "Invalid Integer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' Return to the default border curve if the parameter is less than "1"
            _BorderCurve = 8
            Radius = 8
        End Try
        Return CreateRoundPath
    End Function

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.UserPaint Or _
                 ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.ResizeRedraw, True)

        Font = New Font("Tahoma", 9)
        Me.MinimumSize = New Size(100, 40)
        RoundCorners = False
        AllowClose = True
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        ' Declare Graphics to draw the control
        Dim GFX As Graphics = e.Graphics
        ' Declare Color to paint the control's Text, Background and Border
        Dim ForeColor, BackgroundColor, BorderColor As Color
        ' Determine the header Notification Type font
        Dim TypeFont As New Font(Font.FontFamily, Font.Size, FontStyle.Bold)
        ' Decalre a new rectangle to draw the control inside it
        Dim MainRectangle As New Rectangle(0, 0, Width - 1, Height - 1)
        ' Declare a GraphicsPath to create a border radius
        Dim CrvBorderPath As GraphicsPath = CreateRoundRect(MainRectangle, _BorderCurve)

        GFX.SmoothingMode = SmoothingMode.HighQuality
        GFX.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        GFX.Clear(Parent.BackColor)

        Select Case _NotificationType
            Case Type.Normal
                BackgroundColor = Color.FromArgb(90, 160, 160)
                BorderColor = Color.Transparent
                ForeColor = Color.White
            Case Type.Success
                BackgroundColor = Color.FromArgb(91, 195, 162)
                BorderColor = Color.FromArgb(91, 195, 162)
                ForeColor = Color.White
            Case Type.Warning
                BackgroundColor = Color.FromArgb(254, 209, 108)
                BorderColor = Color.FromArgb(254, 209, 108)
                ForeColor = Color.DimGray
            Case Type.Error
                BackgroundColor = Color.FromArgb(217, 103, 93)
                BorderColor = Color.FromArgb(217, 103, 93)
                ForeColor = Color.White
            Case Type.Custom
                BackgroundColor = setngz(0)
                BorderColor = setngz(1)
                ForeColor = setngz(2)
        End Select

        If _RoundedCorners = True Then
            GFX.FillPath(New SolidBrush(BackgroundColor), CrvBorderPath)
            GFX.DrawPath(New Pen(BorderColor), CrvBorderPath)
        Else
            GFX.FillRectangle(New SolidBrush(BackgroundColor), MainRectangle)
            GFX.DrawRectangle(New Pen(BorderColor), MainRectangle)
        End If

        Select Case _NotificationType
            Case Type.Normal
                NotificationText = "Notification"
            Case Type.Success
                NotificationText = "SUCCESS"
            Case Type.Warning
                NotificationText = "WARNING"
            Case Type.Error
                NotificationText = "ERROR"
            Case Type.Custom
                NotificationText = customTex
        End Select

        If IsNothing(Image) Then
            GFX.DrawString(NotificationText, TypeFont, New SolidBrush(ForeColor), New Point(10, 5))
            GFX.DrawString(Tex, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        Else
            GFX.DrawImage(_Image, 12, 4, 16, 16)
            GFX.DrawString(NotificationText, TypeFont, New SolidBrush(ForeColor), New Point(30, 5))
            GFX.DrawString(Tex, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        End If

        CloseCoordinates = New Point(Width - 26, 4)

        If _ShowCloseButton = True Then
            ' Draw the close button
            GFX.DrawString("r", New Drawing.Font("Marlett", 10, FontStyle.Regular), New SolidBrush(Color.FromArgb(255, 255, 255)), New Rectangle(Width - 20, 10, Width, Height), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
        End If

        CrvBorderPath.Dispose()
    End Sub

    Private Sub NotificationBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

#End Region

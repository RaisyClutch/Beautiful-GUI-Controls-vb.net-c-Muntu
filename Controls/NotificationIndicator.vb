Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.ComponentModel

Class NotificationIndicator
    Inherits UserControl

    Private Bg As Color = Color.DeepSkyBlue
    Private fc As Color = Color.White
    Private fnt As Font = New Font("Segoe UI", 8, FontStyle.Bold)


#Region " Variables "

    Private _Value As Integer = 0
    Private _Maximum As Integer = 99

#End Region
#Region " Properties "
    <ToolboxItem(True)>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                Case Else
                    Return _Value
            End Select
        End Get
        Set(ByVal i As Integer)
            Select Case i
                Case Is > _Maximum
                    i = _Maximum
            End Select
            _Value = i
            Invalidate()
        End Set
    End Property

    Public Property BGColor As Color
        Get
            Return Bg
        End Get
        Set(ByVal value As Color)
            Bg = value
            Invalidate()
        End Set
    End Property

    Public Property FontColor As Color
        Get
            Return fc
        End Get
        Set(ByVal value As Color)
            fc = value
            Invalidate()
        End Set
    End Property

    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal i As Integer)
            Select Case i
                Case Is < _Value
                    _Value = i
            End Select
            _Maximum = i
            Invalidate()
        End Set
    End Property

#End Region

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
        BackColor = Color.Transparent
        Text = Nothing
        DoubleBuffered = True
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        ' Make the width and height of the control unchangeable
        Height = 20
        Width = 20
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        With e.Graphics

            .SmoothingMode = SmoothingMode.AntiAlias

            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(18, 20)), Bg, Bg, 90.0F)
            .FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(18, 18)))
            .DrawEllipse(New Pen(Bg), New Rectangle(New Point(0, 0), New Size(18, 18))) ' Draw border
            .DrawString(_Value, fnt, New SolidBrush(fc), New Rectangle(0, 0, Width - 2, Height), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End With
        e.Dispose()
    End Sub

    Private Sub NotificationIndicator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.Transparent
    End Sub
End Class

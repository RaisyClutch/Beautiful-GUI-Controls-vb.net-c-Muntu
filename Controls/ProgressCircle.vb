Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ProgressCircle
    Inherits UserControl
    Private rr As Integer = 0
    Private widthh As Integer = 50
    Private heightt As Integer = 50
    Private pens As Integer = 3
    Private penc As Color = Color.DeepSkyBlue
    Dim tcaa As Color = Color.DeepSkyBlue
    Private tca As Boolean = False
    Private sz As Integer = 8
    Private e As PaintEventArgs


    <Description("Style of the progressbar"), DisplayName("ProgressCircle"), _
Browsable(True), Category("extendedProperties")> _
    Public Property BrSty As Color
        Get
            Return penc
        End Get
        Set(ByVal value As Color)
            penc = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Description("TextColor of the percentage text, "), DisplayName("TextColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property BarSty As Color
        Get
            Return tcaa
        End Get
        Set(ByVal value As Color)
            tcaa = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Description("size of the pens"), DisplayName("ProgressPen"), _
Browsable(True), Category("extendedProperties")> _
    Public Property BarStyl As Integer
        Get
            Return pens
        End Get
        Set(ByVal value As Integer)
            pens = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property


    <Description("Value of progress"), DisplayName("Value"), _
Browsable(True), Category("extendedProperties")> _
    Public Property Ba As Integer
        Get
            Return rr
        End Get
        Set(ByVal value As Integer)
            rr = value
            Me.Invalidate()
            Me.Update()

        End Set
    End Property

    <Description("width"), DisplayName("ProgressPenWidth"), _
Browsable(True), Category("extendedProperties")> _
    Public Property BarStyle As Integer
        Get
            Return widthh
        End Get
        Set(ByVal value As Integer)
            widthh = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Description("height"), DisplayName("ProgressPenHeight"), _
Browsable(True), Category("extendedProperties")> _
    Public Property Bartyle As Integer
        Get
            Return heightt
        End Get
        Set(ByVal value As Integer)
            heightt = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    <Description("textsize"), DisplayName("textsize"), _
Browsable(True), Category("extendedProperties")> _
    Public Property Bartyl As Integer
        Get
            Return sz
        End Get
        Set(ByVal value As Integer)
            sz = value
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private Sub DrawProgress(ByVal g As Graphics, ByVal rect As Rectangle, ByVal percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle
        'create pens to use for the arcs
        Using progressPen As New Pen(penc, pens), remainderPen As New Pen(Me.BackColor, pens)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)

        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font(Me.Font.FontFamily, sz)

            Dim textSize = g.MeasureString(percentage.ToString, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(percentage.ToString, fnt, ToBrush(tcaa), textPoint)

        End Using
    End Sub


    Private Sub ProgressCircle_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint

        DrawProgress(e.Graphics, New Rectangle(10, 10, widthh, heightt), rr)
    End Sub

    Private Sub ProgressCircle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        widthh = Me.Width
        heightt = Me.Height
    End Sub
End Class

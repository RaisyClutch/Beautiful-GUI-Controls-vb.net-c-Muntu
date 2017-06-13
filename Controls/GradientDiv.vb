Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class GradientDiv
    Inherits UserControl

    Dim C1 As Color = Color.FromArgb(51, 49, 47)
    Dim C2 As Color = Color.FromArgb(90, 91, 90)
    Dim C3 As Color = Color.FromArgb(70, 71, 70)
    Dim C4 As Color = Color.FromArgb(62, 61, 58)

    <Description("First Color"), DisplayName("OuterBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnsS As Color
        Get
            Return C1
        End Get
        Set(ByVal value As Color)
            C1 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("Second Color"), DisplayName("innerBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnseS As Color
        Get
            Return C2
        End Get
        Set(ByVal value As Color)
            C2 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("Third Color"), DisplayName("Top"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsSe As Color
        Get
            Return C3
        End Get
        Set(ByVal value As Color)
            C3 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("bottom Color"), DisplayName("Bottom"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btensS As Color
        Get
            Return C4
        End Get
        Set(ByVal value As Color)
            C4 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property


    Private Sub SkyDarkButton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub



    Private Sub SkyDarkButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim G1 As New LinearGradientBrush(New Point(0, 0), New Point(0, Height), C3, C4)
        G.FillRectangle(G1, 0, 0, Width, Height)
        G1.Dispose()
        Dim S1 As New StringFormat
        S1.LineAlignment = StringAlignment.Center
        S1.Alignment = StringAlignment.Center
        Select Case Enabled
            Case True
                G.DrawString(Text, Font, ToBrush(113, 170, 186), New Rectangle(0, 0, Width - 1, Height - 1), S1)
            Case False
                G.DrawString(Text, Font, Brushes.Gray, New Rectangle(0, 0, Width - 1, Height - 1), S1)
        End Select
        S1.Dispose()
        G.DrawRectangle(ToPen(C1), 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(ToPen(C2), 1, 1, Width - 3, Height - 3)
        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class


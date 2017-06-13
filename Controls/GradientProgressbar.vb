Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class GradientProgressbar
    Sub New()
        max = 100


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim C1 As Color = Color.FromArgb(51, 49, 47)
    Dim C2 As Color = Color.FromArgb(81, 77, 77)
    Dim C3 As Color = Color.FromArgb(250, 124, 0)
    Dim C4 As Color = Color.FromArgb(255, 128, 64)
    Dim C5 As Color = Color.FromArgb(62, 59, 58)
    Private max As Integer

    <Description("First Color"), DisplayName("OuterBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnsS As Color
        Get
            Return C1
        End Get
        Set(ByVal value As Color)
            C1 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("Second Color"), DisplayName("InnerBorder"), _
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

    <Description("linear Gradient Top"), DisplayName("valuetop"), _
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

    <Description("linear Gradient down"), DisplayName("valueBottom"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btenszS As Color
        Get
            Return C4
        End Get
        Set(ByVal value As Color)
            C4 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property


    <Description(" Color of inner bar"), DisplayName("InnerColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btensS As Color
        Get
            Return C5
        End Get
        Set(ByVal value As Color)
            C5 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property


    <Description("maximum value of progress"), DisplayName("Max"), _
Browsable(True), Category("Properties")> _
    Public Property Maximum() As Integer
        Get
            Return max
        End Get
        Set(ByVal _value As Integer)
            If _value < 1 Then
                max = 1
            Else
                max = _value
            End If
            If _value < val Then
                val = max
            End If
            Invalidate()
        End Set
    End Property

    Private val As Integer


    <Description("value of progress"), DisplayName("Value"), _
Browsable(True), Category("Properties")> _
    Public Property Value() As Integer
        Get
            Return val
        End Get
        Set(ByVal _value As Integer)
            If _value > max Then
                val = max
            ElseIf _value < 0 Then
                val = 0
            Else
                val = _value
            End If
            Invalidate()
        End Set
    End Property

    Private Sub GradientProgressbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GradientProgressbar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Fill As Rectangle = New Rectangle(3, 3, CInt((Width - 7) * (val / max)), Height - 7)
        G.Clear(C5)
        Dim G1 As New LinearGradientBrush(New Point(0, 0), New Point(0, Height), C3, C4)
        G.FillRectangle(G1, Fill)
        G1.Dispose()
        G.DrawRectangle(ToPen(C2), Fill)
        G.DrawRectangle(ToPen(C1), 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(ToPen(C2), 1, 1, Width - 3, Height - 3)
        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class GradientButton
    Inherits UserControl
    Private texta As String = "CustomButton"
#Region "Properties"
    <Description("text of the button"), DisplayName("Text"), _
Browsable(True), Category("extendedProperties")> _
    Public Overrides Property Text As String
        Get
            Return texta
        End Get
        Set(ByVal value As String)
            texta = value
            Invalidate()
        End Set
    End Property
#End Region
    Dim C1 As Color = Color.FromArgb(51, 49, 47)
    Dim C2 As Color = Color.FromArgb(90, 91, 90)
    Dim C3 As Color = Color.FromArgb(70, 71, 70)
    Dim C4 As Color = Color.FromArgb(62, 61, 58)

    Dim C5 As Color = Color.FromArgb(255, 255, 255)
    Dim C6 As Color = Color.DimGray
    Dim C7 As Color = Color.Black

    Enum MouseState
        None
        Over
        Down
    End Enum

    Private ms As MouseState
    <Description("state of the mouse"), DisplayName("Mousestate"), _
    Browsable(True), Category("extendedProperties")> _
    Private Property State() As MouseState
        Get
            Return ms
        End Get
        Set(ByVal value As MouseState)
            ms = value
            Invalidate()
        End Set
    End Property

    <Description("First Color"), DisplayName("OuterBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnEEsS As Color
        Get
            Return C1
        End Get
        Set(ByVal value As Color)
            C1 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("text on the button"), DisplayName("Text"), _
Browsable(True), Category("extendedProperties")> _
    Public Property b As String
        Get
            Return texta
        End Get
        Set(ByVal value As String)
            texta = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property


    <Description("text color of the caption"), DisplayName("textColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnsS As Color
        Get
            Return C5
        End Get
        Set(ByVal value As Color)
            C5 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("Second Color"), DisplayName("innerBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btseS As Color
        Get
            Return C2
        End Get
        Set(ByVal value As Color)
            C2 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("onmouse over color"), DisplayName("Hover"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnseS As Color
        Get
            Return C6
        End Get
        Set(ByVal value As Color)
            C6 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("onmouse click color"), DisplayName("Click"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnvseS As Color
        Get
            Return C7
        End Get
        Set(ByVal value As Color)
            C7 = value
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

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e) : State = MouseState.Over
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e) : State = MouseState.None
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e) : State = MouseState.Down
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e) : State = MouseState.Over
    End Sub

    Private Sub GradientButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim G1 As New LinearGradientBrush(New Point(0, 0), New Point(0, Height), C3, C4)
        G.FillRectangle(G1, 0, 0, Width, Height)
        G1.Dispose()
        If Enabled Then
            Select Case State
                Case MouseState.Over
                    G.FillRectangle(New SolidBrush(C6), New Rectangle(0, 0, Width, Height))

                Case MouseState.Down
                    G.FillRectangle(New SolidBrush(C7), New Rectangle(0, 0, Width, Height))

            End Select
        End If
        Dim S1 As New StringFormat
        S1.LineAlignment = StringAlignment.Center
        S1.Alignment = StringAlignment.Center
        Select Case Enabled
            Case True
                G.DrawString(texta, Font, ToBrush(C5), New Rectangle(0, 0, Width - 1, Height - 1), S1)
            Case False
                G.DrawString(texta, Font, Brushes.Gray, New Rectangle(0, 0, Width - 1, Height - 1), S1)
        End Select
        S1.Dispose()
        G.DrawRectangle(ToPen(C1), 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(ToPen(C2), 1, 1, Width - 3, Height - 3)
        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

    Private Sub GradientButton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel


Public Class DarkSwitch2
    Inherits UserControl
    Private onoff As Boolean = False
    'bar
    Dim cbod As Color = Drawing.Color.Gray
    Dim c1 As Color = Drawing.Color.Black
    Dim c2 As Color = Drawing.Color.Gray

    'swch
    Dim cbo As Color = Drawing.Color.Gray
    Dim c11 As Color = Drawing.Color.Gray
    Dim c22 As Color = Drawing.Color.DimGray

    'on
    Dim c3 As Color = Drawing.Color.DeepSkyBlue
    Dim cb As Color = Drawing.Color.Gray

    Dim rad As String = 5
    Dim rada As String = 5
    Dim radu As String = "Custom Swich"
    Dim radua As Color = Color.Black
    Dim c As Size

    <Description("switch color Gradient top"), DisplayName("SwchColorTop"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnEs As Color
        Get
            Return c11
        End Get
        Set(ByVal value As Color)
            c11 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("switch color GradientTop"), DisplayName("SwchColorBot"), _
Browsable(True), Category("extendedProperties")> _
    Public Property btnEsS As Color
        Get
            Return c22
        End Get
        Set(ByVal value As Color)
            c22 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("bar color Gradient top"), DisplayName("BarColorTop"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betEs As Color
        Get
            Return c1
        End Get
        Set(ByVal value As Color)
            c1 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("color of the string"), DisplayName("TextColor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betiEs As Color
        Get
            Return Label1.ForeColor
        End Get
        Set(ByVal value As Color)
            radua = value
            Label1.ForeColor = radua
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("bar color GradientTop"), DisplayName("BarColorBot"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnEsS As Color
        Get
            Return c2
        End Get
        Set(ByVal value As Color)
            c2 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property


    <Description("border color of the switch"), DisplayName("BorderSwch"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnEEs As Color
        Get
            Return cbo
        End Get
        Set(ByVal value As Color)
            cbo = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("border color of the bar"), DisplayName("BorderBar"), _
Browsable(True), Category("extendedProperties")> _
    Public Property b As Color
        Get
            Return cbod
        End Get
        Set(ByVal value As Color)
            cbod = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("size of the switch"), DisplayName("swchSize"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betnEEsS As Size
        Get
            Return swt.Size
        End Get
        Set(ByVal value As Size)
            c = value
            swt.Size = c
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("On state color of the bar"), DisplayName("OnState"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betns As Color
        Get
            Return c3
        End Get
        Set(ByVal value As Color)
            c3 = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("onstate border Color"), DisplayName("OnStateBorder"), _
Browsable(True), Category("extendedProperties")> _
    Public Property banEaS As Color
        Get
            Return cb
        End Get
        Set(ByVal value As Color)
            cb = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("true for On, false for OFF"), DisplayName("TurnON"), _
Browsable(True), Category("extendedProperties")> _
    Public Property bn As Boolean
        Get
            Return onoff
        End Get
        Set(ByVal value As Boolean)
            onoff = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    <Description("string name or value"), DisplayName("Text"), _
Browsable(True), Category("extendedProperties")> _
    Public Property betiqEs As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            radu = value
            Label1.Text = radu
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    Private Sub swch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles swch.Click
        If swt.Left = 38 Then
            swt.Left = 2
            onoff = False
            swch.FillColor = c1
            swch.FillGradientColor = c2
            swch.BorderColor = cbod
            swch.CornerRadius = rad


            swt.FillColor = c11
            swt.FillGradientColor = c22
            swt.BorderColor = cbo
            Label1.ForeColor = radua

        ElseIf swt.Left = 2 Then
            onoff = True
            swt.Left = 38
            swch.FillColor = c3
            swch.FillGradientColor = c3
            swch.BorderColor = cb
            swch.CornerRadius = rad


            swt.FillColor = c11
            swt.FillGradientColor = c22

        End If

    End Sub

    Sub onstate()
        swch.FillColor = c3
        swch.FillGradientColor = c3
        swch.BorderColor = cb
        swch.CornerRadius = rad


        swt.FillColor = c11
        swt.FillGradientColor = c22
    End Sub

    Sub offstate()
        swch.FillColor = c1
        swch.FillGradientColor = c2
        swch.BorderColor = cbod
        swch.CornerRadius = rad


        swt.FillColor = c11
        swt.FillGradientColor = c22
        swt.BorderColor = cbo
    End Sub

    Private Sub swch_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles swch.Invalidated
        If onoff = False Then
            swt.Left = 2
            offstate()
        ElseIf onoff = True Then
            swt.Left = 38
            onstate()
        End If
    End Sub

    Private Sub swch_RegionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles swch.RegionChanged
        If onoff = False Then
            swt.Left = 2
            offstate()
        ElseIf onoff = True Then
            swt.Left = 38
            onstate()
        End If
    End Sub

    Private Sub DarkSwitch_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        If onoff = False Then
            swt.Left = 2
            offstate()
        ElseIf onoff = True Then
            swt.Left = 38
            onstate()
        End If
    End Sub

    Private Sub DarkSwitch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If onoff = False Then
            swt.Left = 2
            offstate()
        ElseIf onoff = True Then
            swt.Left = 38
            onstate()
        End If
    End Sub
End Class

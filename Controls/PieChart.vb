Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Class pieChart : Inherits UserControl
    Private Percen As Array = {10, 20, 50, 10, 10}
    Private Colos As Array = {Color.DarkGray, Color.DimGray, Color.FromArgb(50, 50, 50), Color.DeepSkyBlue, Color.SlateGray}
    Private piesiz As Size = New Size(150, 150)

    <ToolboxItem(True)>
    Public Property ItemPercents As Array
        Get
            Return Percen
        End Get
        Set(ByVal value As Array)
            Percen = value
            Invalidate()
            Update()
        End Set
    End Property

    Public Property PieSize As Size
        Get
            Return piesiz
        End Get
        Set(ByVal value As Size)
            piesiz = value
            Invalidate()
            Update()
        End Set
    End Property

    Public Property ItemColors As Array
        Get
            Return Colos
        End Get
        Set(ByVal value As Array)
            Colos = value
            Invalidate()
            Update()
        End Set
    End Property

    Public Sub DrawPieChart()
        Dim percents = Percen
        Dim colors = Colos
        Using graphics = Me.CreateGraphics()
            Dim location As New Point(0, 0)
            Dim size As New Size(150, 150)
            DrawPieChart(percents, colors, graphics, location, size)
        End Using
    End Sub
    Public Sub DrawPieChart(ByVal percents() As Integer, ByVal colors() As Color,
                        ByVal surface As Graphics, ByVal location As Point,
                        ByVal pieSize As Size)

        ' Check if sections add up to 100.
        Dim sum = 0
        For Each percent In percents
            sum += percent
        Next

        If sum <> 100 Then
            Throw New ArgumentException("Percentages do not add up to 100.")
        End If

        If percents.Length <> colors.Length Then
            Throw New ArgumentException("There must be the same number of percents and colors.")
        End If

        Dim percentTotal = 0
        For percent = 0 To percents.Length() - 1
            Using brush As New SolidBrush(colors(percent))
                surface.FillPie(brush,
                                New Rectangle(location, pieSize),
                                CSng(percentTotal * 360 / 100),
                                CSng(percents(percent) * 360 / 100))
            End Using

            percentTotal += percents(percent)
        Next
        Return
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        DrawPieChart()
    End Sub


    Private Sub pieChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class


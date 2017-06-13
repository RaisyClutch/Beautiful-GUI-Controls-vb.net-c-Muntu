Imports System.Drawing
Imports System.Windows.Forms

Module ConversionFunctions



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
End Module

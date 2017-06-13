Imports System.Windows.Forms
Imports System.Drawing

Module Utils
    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop

    End Sub

    Public Sub GrayScale(ByVal bm As Bitmap)
        Dim maxWidth As Integer = bm.Width - 1
        Dim maxHeight As Integer = bm.Height - 1
        Dim aPixel As Color
        Dim newColor As Integer

        For x As Integer = 0 To maxWidth
            For y As Integer = 0 To maxHeight
                aPixel = bm.GetPixel(x, y)
                newColor = (CInt(aPixel.R) + aPixel.B + aPixel.G) \ 3
                bm.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor))
            Next
        Next

    End Sub

    Public Sub Invert(ByVal bm As Bitmap)
        Dim maxWidth As Integer = bm.Width - 1
        Dim maxHeight As Integer = bm.Height - 1

        For x As Integer = 0 To maxWidth
            For y As Integer = 0 To maxHeight
                Dim aColor As Color = bm.GetPixel(x, y)
                Dim newColor As Color = Color.FromArgb(255 - aColor.R, 255 - aColor.G, 255 - aColor.B)
                bm.SetPixel(x, y, newColor)
            Next
        Next
    End Sub

    Public Sub Blur(ByVal bm As Bitmap, ByVal degree As Integer)

        Dim maxWidth As Integer = bm.Width - 1 - degree
        Dim maxHeight As Integer = bm.Height - 1 - degree
        Dim pixel1 As Color
        Dim otherPixel As Color
        Dim redValues As Integer
        Dim greenValues As Integer
        Dim blueValues As Integer
        Dim counter As Integer

        For x As Integer = degree To maxWidth
            For y As Integer = degree To maxHeight

                pixel1 = bm.GetPixel(x, y)
                redValues = pixel1.R
                greenValues = pixel1.G
                blueValues = pixel1.B
                counter = 1

                For i As Integer = 1 To degree
                    otherPixel = bm.GetPixel(x - i, y)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    otherPixel = bm.GetPixel(x - i, y - i)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += pixel1.B

                    otherPixel = bm.GetPixel(x, y - i)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    otherPixel = bm.GetPixel(x - i, y + i)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    otherPixel = bm.GetPixel(x + i, y)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    otherPixel = bm.GetPixel(x + i, y + i)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    otherPixel = bm.GetPixel(x, y + i)
                    redValues += otherPixel.R
                    greenValues += otherPixel.G
                    blueValues += otherPixel.B

                    counter += 7
                Next

                redValues \= counter
                greenValues \= counter
                blueValues \= counter

                bm.SetPixel(x, y, Color.FromArgb(redValues, greenValues, blueValues))

                For i As Integer = 1 To degree
                    bm.SetPixel(x + i, y, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x + i, y + i, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x, y + i, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x - i, y, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x, y - i, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x + i, y - i, Color.FromArgb(redValues, greenValues, blueValues))
                    bm.SetPixel(x - i, y - i, Color.FromArgb(redValues, greenValues, blueValues))
                Next
            Next
        Next

    End Sub

End Module

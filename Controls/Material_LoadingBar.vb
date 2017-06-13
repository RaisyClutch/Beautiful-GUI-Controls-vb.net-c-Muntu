Imports System.Drawing

Public Class Material_LoadingBar
    Dim second As Integer
    Private bc As Color = Color.DeepSkyBlue
    Function valu(ByVal e As Integer)
        bar.Width = e / 100 * Me.Width
        Return e
    End Function

    Function vale(ByVal e As Integer)
        bar.Width = e / 100 * Me.Width
        Return bar.Width
    End Function

    Public Property BarColor As Color
        Get
            Return bc
        End Get
        Set(ByVal value As Color)
            bc = value
            bar.FillColor = bc
            bar.BorderColor = bc
            Invalidate()
        End Set
    End Property


    Public Property BarHeight As Integer
        Get
            Return bar.Height
        End Get
        Set(ByVal value As Integer)
            bar.Height = value
            Invalidate()
        End Set
    End Property

    Public Property Value As Integer
        Get
            Return bar.Width / Me.Width * 100
        End Get
        Set(ByVal value As Integer)
            valu(value)
            Invalidate()
        End Set
    End Property

    Private Sub Material_LoadingBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bar.Width = Me.Width
    End Sub

    Private Sub Material_LoadingBar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        bar.Width = Me.Width
    End Sub
End Class

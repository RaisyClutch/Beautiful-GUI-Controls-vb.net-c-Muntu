Imports System.Drawing
Imports System.Windows.Forms

Public Class Material_Switch
    Inherits UserControl

    Private offco As Color = Color.DarkGray
    Private onco As Color = Color.SteelBlue
    Public Property OnColor As Color
        Get
            Return onco
        End Get
        Set(ByVal value As Color)
            onco = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    Public Property Offcolor As Color
        Get
            Return offco
        End Get
        Set(ByVal value As Color)
            offco = value
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    Public Property SwitchON As Boolean
        Get
            Return state
        End Get
        Set(ByVal value As Boolean)
            state = value
            If state = True Then
                trck.Left = 50
                trck.FillColor = onco
                trck.BorderColor = onco
                baa.FillColor = onco
                state = True
            Else
                trck.Left = 0
                trck.FillColor = offco
                baa.FillColor = offco
                trck.BorderColor = offco
                state = False
            End If
            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    Private state As Boolean = False
    Private Sub Material_Switch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If trck.Left = 0 Or state = False Then
            trck.Left = 50
            trck.FillColor = onco
            trck.BorderColor = onco
            baa.FillColor = onco
            state = True
        Else
            trck.Left = 0
            trck.FillColor = offco
            baa.FillColor = offco
            trck.BorderColor = offco
            state = False
        End If
    End Sub

    Private Sub Material_Switch_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
     
    End Sub

    Private Sub Material_Switch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If state = True Then
            trck.Left = 50
            trck.FillColor = onco
            trck.BorderColor = onco
            baa.FillColor = onco
            state = True
        Else
            trck.Left = 0
            trck.FillColor = offco
            baa.FillColor = offco
            trck.BorderColor = offco
            state = False
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub baa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baa.Click
          If trck.Left = 0 Or state = False Then
            trck.Left = 50
            trck.FillColor = onco
            trck.BorderColor = onco
            baa.FillColor = onco
            state = True
        Else
            trck.Left = 0
            trck.FillColor = offco
            baa.FillColor = offco
            trck.BorderColor = offco
            state = False
        End If
    End Sub

    Private Sub trck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trck.Click
        If trck.Left = 0 Or state = False Then
            trck.Left = 50
            trck.FillColor = onco
            trck.BorderColor = onco
            baa.FillColor = onco
            state = True
        Else
            trck.Left = 0
            trck.FillColor = offco
            baa.FillColor = offco
            trck.BorderColor = offco
            state = False
        End If
    End Sub

    Private Sub trck_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles trck.Resize
        Me.Size = New Size(85, 33)
    End Sub

    Private Sub Material_Switch_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub Material_Switch_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
    
    End Sub
End Class

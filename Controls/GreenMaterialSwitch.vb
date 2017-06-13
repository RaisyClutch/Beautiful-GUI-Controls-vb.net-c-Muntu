Imports System.Windows.Forms

Public Class GreenMaterialSwitch
    Inherits UserControl
    Private stat As Boolean = False
    Public Property State As Boolean
        Get
            Return stat
        End Get
        Set(ByVal value As Boolean)
            stat = value
            If stat = True Then
                PictureBox1.Image = My.Resources.gchkk
                stat = True
            ElseIf stat = False Then
                PictureBox1.Image = My.Resources.gchk
                stat = False
            End If
        End Set
    End Property
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If stat = False Then
            PictureBox1.Image = My.Resources.gchkk
            stat = True
        ElseIf stat = True Then
            PictureBox1.Image = My.Resources.gchk
            stat = False
        End If
    End Sub

    Private Sub GreenMaterialSwitch_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        If stat = True Then
            PictureBox1.Image = My.Resources.gchkk
            stat = True
        ElseIf stat = False Then
            PictureBox1.Image = My.Resources.gchk
            stat = False
        End If
    End Sub

    Private Sub GreenMaterialSwitch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If stat = True Then
            PictureBox1.Image = My.Resources.gchkk
            stat = True
        ElseIf stat = False Then
            PictureBox1.Image = My.Resources.gchk
            stat = False
        End If
    End Sub

    Private Sub GreenMaterialSwitch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Size = New Drawing.Size(91, 62)
    End Sub
End Class


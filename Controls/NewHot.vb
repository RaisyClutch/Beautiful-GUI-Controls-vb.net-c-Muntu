Imports System.Windows.Forms

Public Class NewHotRibbons
    Inherits UserControl
    Private ribbontype As Typee
    Enum Typee
        [hotribbon]
        [newribbon]

    End Enum

    Public Property Ribbons As Typee
        Get
            Return ribbontype
        End Get
        Set(ByVal value As Typee)
            ribbontype = value
            Select Case Ribbons
                Case Typee.hotribbon
                    PictureBox1.Image = My.Resources.v2_hot
                Case Typee.newribbon
                    PictureBox1.Image = My.Resources.v2_new
            End Select

            Me.Update()
            Me.Invalidate()
        End Set
    End Property

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub NewHotRibbons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       Select Ribbons
            Case Typee.hotribbon
                PictureBox1.Image = My.Resources.v2_hot
            Case Typee.newribbon
                PictureBox1.Image = My.Resources.v2_new
        End Select

    End Sub
End Class

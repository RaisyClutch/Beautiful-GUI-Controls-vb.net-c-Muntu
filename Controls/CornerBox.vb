Imports System.Windows.Forms

Public Class CornerBox
    Inherits UserControl
    Private shadowboxes As Typee
    Enum Typee
        [top]
        [top2]
        [top3]
        [bot]
        [bot2]
        [bot3]
        [bot4]

    End Enum

    Public Property StackStyles As Typee
        Get
            Return shadowboxes
        End Get
        Set(ByVal value As Typee)
            shadowboxes = value
            Select Case shadowboxes
                Case Typee.bot
                    PictureBox1.Image = My.Resources.a
                Case Typee.bot2
                    PictureBox1.Image = My.Resources.aa
                Case Typee.top
                    PictureBox1.Image = My.Resources.s
                Case Typee.top2
                    PictureBox1.Image = My.Resources.ss
                Case Typee.top3
                    PictureBox1.Image = My.Resources.sss
                Case Typee.bot3
                    PictureBox1.Image = My.Resources.drag_normal_left_up
                Case Typee.bot4
                    PictureBox1.Image = My.Resources.drag_pressed_left_up
            End Select
        End Set
    End Property

    Private Sub CornerStacks_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        Select Case shadowboxes
            Case Typee.bot
                PictureBox1.Image = My.Resources.a
            Case Typee.bot2
                PictureBox1.Image = My.Resources.aa
            Case Typee.top
                PictureBox1.Image = My.Resources.s
            Case Typee.top2
                PictureBox1.Image = My.Resources.ss
            Case Typee.top3
                PictureBox1.Image = My.Resources.sss
            Case Typee.bot3
                PictureBox1.Image = My.Resources.drag_normal_left_up
            Case Typee.bot4
                PictureBox1.Image = My.Resources.drag_pressed_left_up
        End Select
        Me.BackColor = Drawing.Color.Transparent
    End Sub

    Private Sub CornerStacks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case shadowboxes
            Case Typee.bot
                PictureBox1.Image = My.Resources.a
            Case Typee.bot2
                PictureBox1.Image = My.Resources.aa
            Case Typee.top
                PictureBox1.Image = My.Resources.s
            Case Typee.top2
                PictureBox1.Image = My.Resources.ss
            Case Typee.top3
                PictureBox1.Image = My.Resources.sss
            Case Typee.bot3
                PictureBox1.Image = My.Resources.drag_normal_left_up
            Case Typee.bot4
                PictureBox1.Image = My.Resources.drag_pressed_left_up
        End Select
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class


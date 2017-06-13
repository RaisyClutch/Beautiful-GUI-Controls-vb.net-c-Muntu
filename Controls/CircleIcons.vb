Imports System.Windows.Forms

Public Class CircleIcons
    Inherits UserControl

    Private shadowboxes As Typee
    Enum Typee
        [android]
        [battery]
        [bag]
        [bing]
        [bluetick]
        [blue]
        [black]
        [del]
        [doc]
        [download]
        [green]
        [teal]
        [img]
        [menu]
        [music]
        [apps]
        [plus]
        [play]
        [orange]
        [refresh]
        [videocamera]
        [video]
        [x]
        [tck]
        [msg]
        [goog]
    End Enum

    Public Property Icon As Typee
        Get
            Return shadowboxes
        End Get
        Set(ByVal value As Typee)
            shadowboxes = value
            Select shadowboxes
                Case Typee.android
                    PictureBox1.Image = My.Resources.ando
                Case Typee.apps
                    PictureBox1.Image = My.Resources.more_apps
                Case Typee.bag
                    PictureBox1.Image = My.Resources.bag
                Case Typee.download
                    PictureBox1.Image = My.Resources.dwn
                Case Typee.battery
                    PictureBox1.Image = My.Resources.bat
                Case Typee.bing
                    PictureBox1.Image = My.Resources.bing
                Case Typee.black
                    PictureBox1.Image = My.Resources.blc

                Case Typee.blue
                    PictureBox1.Image = My.Resources.blu
                Case Typee.bluetick
                    PictureBox1.Image = My.Resources.blutck
                Case Typee.del
                    PictureBox1.Image = My.Resources.del
                Case Typee.doc
                    PictureBox1.Image = My.Resources.doc
                Case Typee.goog
                    PictureBox1.Image = My.Resources.goog
                Case Typee.green
                    PictureBox1.Image = My.Resources.gree
                Case Typee.img
                    PictureBox1.Image = My.Resources.img

                Case Typee.menu
                    PictureBox1.Image = My.Resources.menu
                Case Typee.msg
                    PictureBox1.Image = My.Resources.msg
                Case Typee.music
                    PictureBox1.Image = My.Resources.msic
                Case Typee.orange
                    PictureBox1.Image = My.Resources.orng
                Case Typee.play
                    PictureBox1.Image = My.Resources.play
                Case Typee.plus
                    PictureBox1.Image = My.Resources.pls
                Case Typee.refresh
                    PictureBox1.Image = My.Resources.ref
                Case Typee.tck
                    PictureBox1.Image = My.Resources.tck
                Case Typee.teal
                    PictureBox1.Image = My.Resources.gren
                Case Typee.video
                    PictureBox1.Image = My.Resources.vd
                Case Typee.videocamera
                    PictureBox1.Image = My.Resources.vcam
                Case Typee.x
                    PictureBox1.Image = My.Resources.x
            End Select
        End Set
    End Property
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles PictureBox1.LoadCompleted
        Select Case shadowboxes
            Case Typee.android
                PictureBox1.Image = My.Resources.ando
            Case Typee.apps
                PictureBox1.Image = My.Resources.more_apps
            Case Typee.bag
                PictureBox1.Image = My.Resources.bag
            Case Typee.download
                PictureBox1.Image = My.Resources.down
            Case Typee.battery
                PictureBox1.Image = My.Resources.bat
            Case Typee.bing
                PictureBox1.Image = My.Resources.bing
            Case Typee.black
                PictureBox1.Image = My.Resources.blc

            Case Typee.blue
                PictureBox1.Image = My.Resources.blu
            Case Typee.bluetick
                PictureBox1.Image = My.Resources.blutck
            Case Typee.del
                PictureBox1.Image = My.Resources.del
            Case Typee.doc
                PictureBox1.Image = My.Resources.doc
            Case Typee.goog
                PictureBox1.Image = My.Resources.goog
            Case Typee.green
                PictureBox1.Image = My.Resources.gree
            Case Typee.img
                PictureBox1.Image = My.Resources.img

            Case Typee.menu
                PictureBox1.Image = My.Resources.menu
            Case Typee.msg
                PictureBox1.Image = My.Resources.msg
            Case Typee.music
                PictureBox1.Image = My.Resources.msic
            Case Typee.orange
                PictureBox1.Image = My.Resources.orng
            Case Typee.play
                PictureBox1.Image = My.Resources.play
            Case Typee.plus
                PictureBox1.Image = My.Resources.pls
            Case Typee.refresh
                PictureBox1.Image = My.Resources.ref
            Case Typee.tck
                PictureBox1.Image = My.Resources.tck
            Case Typee.teal
                PictureBox1.Image = My.Resources.gren
            Case Typee.video
                PictureBox1.Image = My.Resources.vd
            Case Typee.videocamera
                PictureBox1.Image = My.Resources.vcam
            Case Typee.x
                PictureBox1.Image = My.Resources.x
        End Select
    End Sub

    Private Sub CircleIcons_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case shadowboxes
            Case Typee.android
                PictureBox1.Image = My.Resources.ando
            Case Typee.apps
                PictureBox1.Image = My.Resources.more_apps
            Case Typee.bag
                PictureBox1.Image = My.Resources.bag
            Case Typee.download
                PictureBox1.Image = My.Resources.down
            Case Typee.battery
                PictureBox1.Image = My.Resources.bat
            Case Typee.bing
                PictureBox1.Image = My.Resources.bing
            Case Typee.black
                PictureBox1.Image = My.Resources.blc

            Case Typee.blue
                PictureBox1.Image = My.Resources.blu
            Case Typee.bluetick
                PictureBox1.Image = My.Resources.blutck
            Case Typee.del
                PictureBox1.Image = My.Resources.del
            Case Typee.doc
                PictureBox1.Image = My.Resources.doc
            Case Typee.goog
                PictureBox1.Image = My.Resources.goog
            Case Typee.green
                PictureBox1.Image = My.Resources.gree
            Case Typee.img
                PictureBox1.Image = My.Resources.img

            Case Typee.menu
                PictureBox1.Image = My.Resources.menu
            Case Typee.msg
                PictureBox1.Image = My.Resources.msg
            Case Typee.music
                PictureBox1.Image = My.Resources.msic
            Case Typee.orange
                PictureBox1.Image = My.Resources.orng
            Case Typee.play
                PictureBox1.Image = My.Resources.play
            Case Typee.plus
                PictureBox1.Image = My.Resources.pls
            Case Typee.refresh
                PictureBox1.Image = My.Resources.ref
            Case Typee.tck
                PictureBox1.Image = My.Resources.tck
            Case Typee.teal
                PictureBox1.Image = My.Resources.gren
            Case Typee.video
                PictureBox1.Image = My.Resources.vd
            Case Typee.videocamera
                PictureBox1.Image = My.Resources.vcam
            Case Typee.x
                PictureBox1.Image = My.Resources.x
        End Select
    End Sub
End Class

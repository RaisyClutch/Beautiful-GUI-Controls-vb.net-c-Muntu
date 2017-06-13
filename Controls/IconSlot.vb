Imports System.Windows.Forms
Imports System.Drawing

Public Class IconSlot
    Inherits UserControl

    Private shadowboxes As Typee
    Enum Typee
        [menu]
        [home]
        [jmusic]
        [media]
        [addressbar]
        [file]
        [phone]
        [edit]
        [image]
        [new]
        [writer]
        [user]
        [web]
        [view]
        [backup]
        [app]
        [setbg]
        [play]
        [send]
        [more]
        [download]
        [headphone]
        [picture]
        [recycle]
        [search]
        [charset]
    End Enum

    Public Property Icon As Typee
        Get
            Return shadowboxes
        End Get
        Set(ByVal value As Typee)
            shadowboxes = value
            Select Case shadowboxes
                Case Typee.addressbar
                    PictureBox1.Image = My.Resources.ic_addressbar_access_land
                Case Typee.app
                    PictureBox1.Image = My.Resources.ic_app
                Case Typee.backup
                    PictureBox1.Image = My.Resources.ic_backup_cloud
                Case Typee.download
                    PictureBox1.Image = My.Resources.icdwn
                Case Typee.edit
                    PictureBox1.Image = My.Resources.icreset_editor_icon
                Case Typee.file
                    PictureBox1.Image = My.Resources.icwriter_share_text

                Case Typee.headphone
                    PictureBox1.Image = My.Resources.ichead
                Case Typee.home
                    PictureBox1.Image = My.Resources.ic_homepage
                Case Typee.image
                    PictureBox1.Image = My.Resources.ic_picture
                Case Typee.jmusic
                    PictureBox1.Image = My.Resources.ic_music
                Case Typee.media
                    PictureBox1.Image = My.Resources.ic_media
                Case Typee.menu
                    PictureBox1.Image = My.Resources.icmenu

                Case Typee.more
                    PictureBox1.Image = My.Resources.ic_more
                Case Typee.new
                    PictureBox1.Image = My.Resources.ic_new
                Case Typee.phone
                    PictureBox1.Image = My.Resources.ic_phone
                Case Typee.picture
                    PictureBox1.Image = My.Resources.iccategory_image
                Case Typee.play
                    PictureBox1.Image = My.Resources.ic_play
                Case Typee.recycle
                    PictureBox1.Image = My.Resources.ic_recycle

                Case Typee.search
                    PictureBox1.Image = My.Resources.icsearc
                Case Typee.send
                    PictureBox1.Image = My.Resources.ic_send
                Case Typee.setbg
                    PictureBox1.Image = My.Resources.ic_setbg
                Case Typee.user
                    PictureBox1.Image = My.Resources.ic_user
                Case Typee.view
                    PictureBox1.Image = My.Resources.ico_view_icon_s
                Case Typee.web
                    PictureBox1.Image = My.Resources.ic_web
                Case Typee.charset
                    PictureBox1.Image = My.Resources.ic_charset

            End Select
        End Set
    End Property

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub MaterialIconSlot_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case shadowboxes
            Case Typee.addressbar
                PictureBox1.Image = My.Resources.ic_addressbar_access_land
            Case Typee.app
                PictureBox1.Image = My.Resources.ic_app
            Case Typee.backup
                PictureBox1.Image = My.Resources.ic_backup_cloud
            Case Typee.download
                PictureBox1.Image = My.Resources.icdwn
            Case Typee.edit
                PictureBox1.Image = My.Resources.icreset_editor_icon
            Case Typee.file
                PictureBox1.Image = My.Resources.icwriter_share_text

            Case Typee.headphone
                PictureBox1.Image = My.Resources.ichead
            Case Typee.home
                PictureBox1.Image = My.Resources.ic_homepage
            Case Typee.image
                PictureBox1.Image = My.Resources.ic_picture
            Case Typee.jmusic
                PictureBox1.Image = My.Resources.ic_music
            Case Typee.media
                PictureBox1.Image = My.Resources.ic_media
            Case Typee.menu
                PictureBox1.Image = My.Resources.icmenu

            Case Typee.more
                PictureBox1.Image = My.Resources.ic_more
            Case Typee.new
                PictureBox1.Image = My.Resources.ic_new
            Case Typee.phone
                PictureBox1.Image = My.Resources.ic_phone
            Case Typee.picture
                PictureBox1.Image = My.Resources.iccategory_image
            Case Typee.play
                PictureBox1.Image = My.Resources.ic_play
            Case Typee.recycle
                PictureBox1.Image = My.Resources.ic_recycle

            Case Typee.search
                PictureBox1.Image = My.Resources.ic_search_web
            Case Typee.send
                PictureBox1.Image = My.Resources.ic_send
            Case Typee.setbg
                PictureBox1.Image = My.Resources.ic_setbg
            Case Typee.user
                PictureBox1.Image = My.Resources.ic_user
            Case Typee.view
                PictureBox1.Image = My.Resources.ico_view_icon_s
            Case Typee.web
                PictureBox1.Image = My.Resources.ic_web
            Case Typee.charset
                PictureBox1.Image = My.Resources.ic_charset

        End Select
        Me.BackColor = Color.Transparent
    End Sub
End Class

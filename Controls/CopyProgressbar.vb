Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

'****README FIRST*************
'
'Copyright (c) 2017 Raisy Clutch
'your free to use this code in anyway you want , for anything but at your own risk, i wont be responsible for what happens to your computer, released under the MIT Licence
'if you love something set it free
'features
'-- screen capture
'
'
' Donate to raisycltch@gmail.com i need a cup of coffee
'blog: raisyclutch.wordpress.com
'********THE END***************

<ToolboxBitmap("FCP.bmp")>
Public Class copyprogressbar
    Inherits UserControl

    ' ## property variables
    Private _from As String = ""
    Private _to As String = ""
    Private _start As Boolean = False
    Private _show As Boolean = True
    Private _msgFormat As String = "SR"
    Private _msgStrings(4) As String

    ' ## other variables
    Dim fromStream As FileStream
    Dim toStream As FileStream

    'Variables
    Private intFileLength As Integer = 0
    Private cancel As Boolean = False
    Dim total As Long = 0
    Dim current As Long = 0
    Dim buffer(1024) As Byte
    Dim kbRemaining As Integer = 0
    Dim secRemaining As Integer = 0
    Dim kbs As Double = 0.0
    Dim eta As TimeSpan
    Dim startTime As DateTime
    Dim FileLength As Long
    Dim msg1 As String = ""
    Dim msg2 As String = ""
    Dim msg3 As String = ""
    Dim msg4 As String = ""
    Dim intTemp

    ' ## Constants
    Const KB As Long = 1024
    Const MB As Long = KB * 1024
    Const GB As Long = MB * 1024
    Const TB As Long = GB * 1024
    Const M As Long = 60
    Const H As Long = M * 60
    Const D As Long = H * 24


    ' ############### extended custom properties
    ' ##########################################

    <Description("Style of the progressbar"), DisplayName("ProgressbarFill"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property BarStyle As Color
        Get
            Return bar.FillColor
        End Get
        Set(ByVal value As Color)
            bar.FillColor = value
        End Set
    End Property

    <Description("Color of the progressbar"), DisplayName("ProgressbarColorBack"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property BarColor As Color
        Get
            Return bare.FillColor
        End Get
        Set(ByVal value As Color)
            bare.FillColor = value
        End Set
    End Property

    <Description("Show or hide info label"), DisplayName("ShowInfo"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property ShowLabel As Boolean
        Get
            Return _show
        End Get
        Set(ByVal value As Boolean)
            _show = value
            lblms.Visible = value
            If value Then
                Me.Height = bare.Height + lblms.Height
            Else
                Me.Height = bare.Height
            End If
        End Set
    End Property

    <Description("Message format: T-otal to copy, C-urrent copied, S-peed, R-emain ing Time"), DisplayName("info format"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property msgFormat As String
        Get
            Return _msgFormat
        End Get
        Set(ByVal value As String)
            _msgFormat = value
        End Set
    End Property

    <Description("Path of original file."), DisplayName("FileSource"), _
    Browsable(True), Category("extendedProperties")> _
    Public Property COPYFROM As String
        Get
            Return _from
        End Get
        Set(ByVal value As String)
            _from = value
        End Set
    End Property

    <Description("Path of duplicated file."), DisplayName("FileDestination"), _
   Browsable(True), Category("extendedProperties")> _
    Public Property COPYTO As String
        Get
            Return _to
        End Get
        Set(ByVal value As String)
            _to = value
        End Set
    End Property

    <Description("size"), DisplayName("width of bar"), _
Browsable(True), Category("extendedProperties")> _
    Public Property progbarwidth As Size
        Get
            Return bare.Size
            Return bar.Size
        End Get
        Set(ByVal value As Size)
            bare.Size = value
            bar.Size = value
        End Set
    End Property

    <Description("gradient"), DisplayName("gradientcolor"), _
Browsable(True), Category("extendedProperties")> _
    Public Property grad As Color
        Get
            Return bare.FillGradientColor
        End Get
        Set(ByVal value As Color)
            bare.FillGradientColor = value
        End Set
    End Property

    <Description("Start file copy"), DisplayName("Start copying"), _
   Browsable(True), Category("extendedProperties")> _
    Public Property START As Boolean
        Get
            Return _start
        End Get
        Set(ByVal value As Boolean)
            _start = value
            If START And _from <> "" And _to <> "" Then
                intFileLength = FileLen(COPYFROM) ' get file length in bytes
                ' reset progressbar properties
                barval(0)
                ' start copy process
                CopyFile()
            End If
        End Set
    End Property


    Function barval(ByVal v As String)
        bar.Width = v / 100 * bare.Width - 3
        Return bar.Width
    End Function

    ' ############### Private SUBS
    ' ############################

    Private Sub CopyFile()

        ' (C) This code is based on an idea of a developer published:
        ' http://www.vb-paradise.de/index.php/Thread/29443-Datein-kopieren-mit-Fortschritt-und-verbleibender-Zeit/

        Try
            Cursor.Current = Cursors.WaitCursor

            ' check file, if exists delete it
            If File.Exists(COPYTO) Then
                File.Delete(COPYTO)
            End If
            ' check original file if exists copy it
            If File.Exists(COPYFROM) Then

                ' Open filestrams for reading original file and writing the copy
                fromStream = New FileStream(COPYFROM, FileMode.Open)
                toStream = New FileStream(COPYTO, FileMode.CreateNew)

                ' get file length in byte
                total = fromStream.Length

                ' Get Time
                startTime = DateTime.Now

                ' convert file length to KB-MB-GB-TB
                If total <= KB Then
                    msg1 = total.ToString & " Byte"
                ElseIf total > KB And total <= MB Then
                    intTemp = Math.Round(total / KB, 0)
                    msg1 = intTemp.ToString & " KB"
                ElseIf total > MB And total <= GB Then
                    intTemp = Math.Round(total / MB, 0)
                    msg1 = intTemp.ToString & " MB"
                ElseIf total > GB And total <= TB Then
                    intTemp = Math.Round(total / GB, 0)
                    msg1 = intTemp.ToString & " GB"
                ElseIf total >= TB Then
                    intTemp = Math.Round(total / TB, 0)
                    msg1 = intTemp.ToString & " TB"
                End If

                Do ' copy byte by byte
                    '  check if cancelled
                    If cancel Then
                        fromStream.Close()
                        toStream.Close()
                        Exit Sub
                    End If

                    ' read original byte
                    Dim read As Integer = fromStream.Read(buffer, 0, buffer.Length)
                    ' create the copy and write the byte into the copy
                    toStream.Write(buffer, 0, read)
                    ' monitor read status
                    current += read
                    ' compute done percentage for progressbar
                    Dim Prozent As Integer = current * 100 / total
                    barval(Prozent)
                    ' compute time used
                    eta = startTime.Subtract(DateTime.Now)
                    ' compute remaining kilobytes to copy and remaining time
                    kbRemaining = (current - total) / 1024
                    If eta.Seconds <> 0 Then
                        'KB/sec
                        kbs = Math.Round((current / 1024) / (eta.Seconds), 2)
                        secRemaining = kbRemaining / kbs
                    End If

                    ' convert current to KB-MB-GB-TB
                    If current <= KB Then
                        msg2 = FileLength.ToString & " Byte"
                    ElseIf current > KB And current <= MB Then
                        intTemp = Math.Round(current / KB, 0)
                        msg2 = intTemp.ToString & " KB"
                    ElseIf current > MB And current <= GB Then
                        intTemp = Math.Round(current / MB, 0)
                        msg2 = intTemp.ToString & " MB"
                    ElseIf current > GB And current <= TB Then
                        intTemp = Math.Round(current / GB, 0)
                        msg2 = intTemp.ToString & " GB"
                    ElseIf current >= TB Then
                        intTemp = Math.Round(current / TB, 0)
                        msg2 = intTemp.ToString & " TB"
                    End If

                    ' convert kb/s to MB/s
                    If kbs < 0 Then kbs = kbs * -1
                    If kbs > 1000 Then
                        kbs = Math.Round(kbs / 1000, 0)
                        msg3 = kbs.ToString & " MB/s"
                    ElseIf kbs < 1000 Then
                        msg3 = kbs.ToString & " KB/s"
                    End If

                    ' convert remaining time to M-H-D
                    If secRemaining < M Then
                        msg4 = secRemaining.ToString & " " & _msgStrings(0)
                    ElseIf secRemaining < H Then
                        intTemp = Math.Round(secRemaining / M, 0)
                        msg4 = intTemp.ToString & " " & _msgStrings(1)
                    ElseIf secRemaining < D Then
                        intTemp = Math.Round(secRemaining / H, 0)
                        msg4 = intTemp.ToString & " " & _msgStrings(2)
                    ElseIf secRemaining >= D Then
                        intTemp = Math.Round(secRemaining / D, 0)
                        msg4 = intTemp.ToString & " " & _msgStrings(3)
                    End If

                    ' build message string
                    Dim strTemp As String = ""
                    If InStr(msgFormat, "T") Then strTemp = msg1
                    If InStr(msgFormat, "C") Then
                        If strTemp <> "" Then strTemp = strTemp & " | "
                        strTemp = strTemp & msg2
                    End If
                    If InStr(msgFormat, "S") Then
                        If strTemp <> "" Then strTemp = strTemp & " | "
                        strTemp = strTemp & msg3
                    End If
                    If InStr(msgFormat, "R") Then
                        If strTemp <> "" Then strTemp = strTemp & " | "
                        strTemp = strTemp & msg4
                    End If

                    ' show info
                    lblms.Text = strTemp

                    ' let application release pending actions
                    Application.DoEvents()

                Loop While (total <> current)

                ' finalize process
                cancel = False
                fromStream.Close()
                toStream.Close()
                ' reset property
                START = False
            End If
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, _msgStrings(4))
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' ############### Controls New
    ' ############################

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Transfer usercontrol property values to label control
        With lblms
            .Font = Me.Font
            .ForeColor = Me.ForeColor
            .BackColor = Me.BackColor
            .Image = Me.BackgroundImage
        End With

        ' ini message string array
        _msgStrings(0) = " Sec."
        _msgStrings(1) = " Min."
        _msgStrings(2) = " Hrs."
        _msgStrings(3) = " Days"
        _msgStrings(4) = "Error!"
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblms.Click

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblms.Click

    End Sub

    Private Sub copyprogressbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub copyprogressbar_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        bare.Width = Me.Width - 5

    End Sub
End Class



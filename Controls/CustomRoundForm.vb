Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Class CustomRoundForm
    Inherits UserControl

#Region " Enums "

    Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
        Block = 3
    End Enum

#End Region
#Region " Variables "

    Private HeaderRect As Rectangle
    Protected State As MouseState
    Private MoveHeight As Integer
    Private MouseP As Point = New Point(0, 0)
    Private Cap As Boolean = False
    Private HasShown As Boolean

#End Region
#Region " Properties "
    Private Barcolor As Color = Color.FromArgb(45, 45, 45)
    Private BGColor As Color = Color.FromArgb(54, 54, 54)
    Private TextColor As Color = Color.FromArgb(255, 255, 255)
    Private _Sizable As Boolean = True

    <ToolboxItem(True)>
    <Category("Colors")>
    Property TitleBarColor As Color
        Get
            Return Barcolor
        End Get
        Set(ByVal value As Color)
            Barcolor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property TxtColor As Color
        Get
            Return TextColor
        End Get
        Set(ByVal value As Color)
            TextColor = value
            Invalidate()
            Update()
        End Set
    End Property

    <Category("Colors")>
    Property BacColor As Color
        Get
            Return BGColor
        End Get
        Set(ByVal value As Color)
            BGColor = value
            Invalidate()
            Update()
        End Set
    End Property

    Property reizable() As Boolean
        Get
            Return _Sizable
        End Get
        Set(ByVal value As Boolean)
            _Sizable = value
        End Set
    End Property

    Private _SmartBounds As Boolean = True
    Property AddBounds() As Boolean
        Get
            Return _SmartBounds
        End Get
        Set(ByVal value As Boolean)
            _SmartBounds = value
            Invalidate()
            Update()
        End Set
    End Property

    Private _RoundCorners As Boolean = True
    Property RoundCorners() As Boolean
        Get
            Return _RoundCorners
        End Get
        Set(ByVal value As Boolean)
            _RoundCorners = value
            Invalidate()
            Update()
        End Set
    End Property

    Private _IsParentForm As Boolean
    Protected ReadOnly Property FormParent As Boolean
        Get
            Return _IsParentForm
        End Get
    End Property

    Protected ReadOnly Property MakeMdiForm As Boolean
        Get
            If Parent Is Nothing Then Return False
            Return Parent.Parent IsNot Nothing
        End Get
    End Property

    Private _ControlMode As Boolean

    Private _StartPosition As FormStartPosition
    Property StartPosition As FormStartPosition
        Get
            If _IsParentForm AndAlso Not _ControlMode Then Return ParentForm.StartPosition Else Return _StartPosition
        End Get
        Set(ByVal value As FormStartPosition)
            _StartPosition = value

            If _IsParentForm AndAlso Not _ControlMode Then
                ParentForm.StartPosition = value
            End If
        End Set
    End Property

#End Region
#Region " EventArgs "

    Protected NotOverridable Overrides Sub OnParentChanged(ByVal e As EventArgs)
        MyBase.OnParentChanged(e)

        If Parent Is Nothing Then Return
        _IsParentForm = TypeOf Parent Is Form

        If Not _ControlMode Then
            InitializeMessages()

            If _IsParentForm Then
                Me.ParentForm.FormBorderStyle = FormBorderStyle.None
                Me.ParentForm.TransparencyKey = Color.Fuchsia

                If Not DesignMode Then
                    AddHandler ParentForm.Shown, AddressOf FormShown
                End If
            End If
            Parent.BackColor = BackColor
            '   Parent.MinimumSize = New Size(261, 65)
        End If
    End Sub

    Protected NotOverridable Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Not _ControlMode Then HeaderRect = New Rectangle(0, 0, Width - 14, MoveHeight - 7)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Focus()
        If e.Button = Windows.Forms.MouseButtons.Left Then SetState(MouseState.Down)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized OrElse _ControlMode) Then
            If HeaderRect.Contains(e.Location) Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(0))
            ElseIf _Sizable AndAlso Not Previous = 0 Then
                Capture = False
                WM_LMBUTTONDOWN = True
                DefWndProc(Messages(Previous))
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Not (_IsParentForm AndAlso ParentForm.WindowState = FormWindowState.Maximized) Then
            If _Sizable AndAlso Not _ControlMode Then InvalidateMouse()
        End If
        If Cap Then
            Parent.Location = MousePosition - MouseP
        End If
    End Sub

    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)
        ParentForm.Text = Text
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Private Sub FormShown(ByVal sender As Object, ByVal e As EventArgs)
        If _ControlMode OrElse HasShown Then Return

        If _StartPosition = FormStartPosition.CenterParent OrElse _StartPosition = FormStartPosition.CenterScreen Then
            Dim SB As Rectangle = Screen.PrimaryScreen.Bounds
            Dim CB As Rectangle = ParentForm.Bounds
            ParentForm.Location = New Point(SB.Width \ 2 - CB.Width \ 2, SB.Height \ 2 - CB.Width \ 2)
        End If
        HasShown = True
    End Sub

#End Region
#Region " Mouse & Size "

    Private Sub SetState(ByVal current As MouseState)
        State = current
        Invalidate()
    End Sub

    Private GetIndexPoint As Point
    Private B1x, B2x, B3, B4 As Boolean
    Private Function GetIndex() As Integer
        GetIndexPoint = PointToClient(MousePosition)
        B1x = GetIndexPoint.X < 7
        B2x = GetIndexPoint.X > Width - 7
        B3 = GetIndexPoint.Y < 7
        B4 = GetIndexPoint.Y > Height - 7

        If B1x AndAlso B3 Then Return 4
        If B1x AndAlso B4 Then Return 7
        If B2x AndAlso B3 Then Return 5
        If B2x AndAlso B4 Then Return 8
        If B1x Then Return 1
        If B2x Then Return 2
        If B3 Then Return 3
        If B4 Then Return 6
        Return 0
    End Function

    Private Current, Previous As Integer
    Private Sub InvalidateMouse()
        Current = GetIndex()
        If Current = Previous Then Return

        Previous = Current
        Select Case Previous
            Case 0
                Cursor = Cursors.Default
            Case 6
                Cursor = Cursors.SizeNS
            Case 8
                Cursor = Cursors.SizeNWSE
            Case 7
                Cursor = Cursors.SizeNESW
        End Select
    End Sub

    Private Messages(8) As Message
    Private Sub InitializeMessages()
        Messages(0) = Message.Create(Parent.Handle, 161, New IntPtr(2), IntPtr.Zero)
        For I As Integer = 1 To 8
            Messages(I) = Message.Create(Parent.Handle, 161, New IntPtr(I + 9), IntPtr.Zero)
        Next
    End Sub

    Private Sub CorrectBounds(ByVal bounds As Rectangle)
        If Parent.Width > bounds.Width Then Parent.Width = bounds.Width
        If Parent.Height > bounds.Height Then Parent.Height = bounds.Height

        Dim X As Integer = Parent.Location.X
        Dim Y As Integer = Parent.Location.Y

        If X < bounds.X Then X = bounds.X
        If Y < bounds.Y Then Y = bounds.Y

        Dim Width As Integer = bounds.X + bounds.Width
        Dim Height As Integer = bounds.Y + bounds.Height

        If X + Parent.Width > Width Then X = Width - Parent.Width
        If Y + Parent.Height > Height Then Y = Height - Parent.Height

        Parent.Location = New Point(X, Y)
    End Sub

    Private WM_LMBUTTONDOWN As Boolean
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If WM_LMBUTTONDOWN AndAlso m.Msg = 513 Then
            WM_LMBUTTONDOWN = False

            SetState(MouseState.Over)
            If Not _SmartBounds Then Return

            If MakeMdiForm Then
                CorrectBounds(New Rectangle(Point.Empty, Parent.Parent.Size))
            Else
                CorrectBounds(Screen.FromControl(Parent).WorkingArea)
            End If
        End If
    End Sub

#End Region

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub

    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        BackColor = Color.FromArgb(50, 50, 50)
        Padding = New Padding(10, 70, 10, 9)
        DoubleBuffered = True
        Dock = DockStyle.Fill
        MoveHeight = 66
        Font = New Font("Segoe UI", 9)
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics

        G.Clear(BGColor)
        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(0, 0, Width, 60))

        If _RoundCorners = True Then
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), 1, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 1, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 2, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 3, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 3, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 4, 1, 1, 1)

            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 3, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 2, Height - 2, 1, 1)


            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 4, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 3, Height - 2, 1, 1)
        End If

        G.DrawString(Text, New Font("Segoe UI", 10, FontStyle.Bold), New SolidBrush(TextColor), New Rectangle(20, 20, Width - 1, Height), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
    End Sub

    Private Sub CustomRoundForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CustomRoundForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics

        G.Clear(BGColor)
        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(0, 0, Width, 60))

        If _RoundCorners = True Then
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), 1, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 1, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 2, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), 3, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1)

            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 3, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 2, 2, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 3, 1, 1, 1)
            G.FillRectangle(New SolidBrush(Barcolor), Width - 4, 1, 1, 1)

            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 1, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 3, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), 2, Height - 2, 1, 1)


            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1)
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1)

            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 3, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 2, Height - 4, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 4, Height - 2, 1, 1)
            G.FillRectangle(New SolidBrush(BGColor), Width - 3, Height - 2, 1, 1)
        End If

        G.DrawString(Text, New Font("Segoe UI", 10, FontStyle.Bold), New SolidBrush(TextColor), New Rectangle(20, 20, Width - 1, Height), New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near})
    End Sub
End Class

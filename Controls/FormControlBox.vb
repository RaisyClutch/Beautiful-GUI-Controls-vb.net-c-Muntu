Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Class FormControlBox
    Inherits UserControl

#Region " Enums "

    Enum ButtonHoverState
        Minimize
        Maximize
        Close
        None
    End Enum

#End Region
#Region " Variables "

    Private ButtonHState As ButtonHoverState = ButtonHoverState.None

#End Region
#Region " Properties "
    Private Barcolor As Color = Color.FromArgb(45, 45, 45)
    Private BGColor As Color = Color.FromArgb(54, 54, 54)
    Private FormSignColor As Color = Color.FromArgb(250, 250, 250)

    <ToolboxItem(True)>
    <Category("Colors")>
    Property ButtonsColor As Color
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
    Property FormSignColors As Color
        Get
            Return FormSignColor
        End Get
        Set(ByVal value As Color)
            FormSignColor = value
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
    Private _EnableMaximize As Boolean = True
    Property AllowMaximize() As Boolean
        Get
            Return _EnableMaximize
        End Get
        Set(ByVal value As Boolean)
            _EnableMaximize = value
            Invalidate()
        End Set
    End Property

    Private _EnableMinimize As Boolean = True
    Property AllowMinimize() As Boolean
        Get
            Return _EnableMinimize
        End Get
        Set(ByVal value As Boolean)
            _EnableMinimize = value
            Invalidate()
        End Set
    End Property

    Private _EnableHoverHighlight As Boolean = False
    Property EnableHover() As Boolean
        Get
            Return _EnableHoverHighlight
        End Get
        Set(ByVal value As Boolean)
            _EnableHoverHighlight = value
            Invalidate()
            Update()
        End Set
    End Property

#End Region
#Region " EventArgs "

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(100, 25)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim X As Integer = e.Location.X
        Dim Y As Integer = e.Location.Y
        If Y > 0 AndAlso Y < (Height - 2) Then
            If X > 0 AndAlso X < 34 Then
                ButtonHState = ButtonHoverState.Minimize
            ElseIf X > 33 AndAlso X < 65 Then
                ButtonHState = ButtonHoverState.Maximize
            ElseIf X > 64 AndAlso X < Width Then
                ButtonHState = ButtonHoverState.Close
            Else
                ButtonHState = ButtonHoverState.None
            End If
        Else
            ButtonHState = ButtonHoverState.None
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Select Case ButtonHState
            Case ButtonHoverState.Close
                Parent.FindForm().Close()
            Case ButtonHoverState.Minimize
                If _EnableMinimize = True Then
                    Parent.FindForm().WindowState = FormWindowState.Minimized
                End If
            Case ButtonHoverState.Maximize
                If _EnableMaximize = True Then
                    If Parent.FindForm().WindowState = FormWindowState.Normal Then
                        Parent.FindForm().WindowState = FormWindowState.Maximized
                    Else
                        Parent.FindForm().WindowState = FormWindowState.Normal
                    End If
                End If
        End Select
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        ButtonHState = ButtonHoverState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Focus()
    End Sub

#End Region

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Try
            Location = New Point(Parent.Width - 112, 15)
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim G As Graphics = e.Graphics
        G.Clear(Barcolor)

        If _EnableHoverHighlight = True Then
            Select Case ButtonHState
                Case ButtonHoverState.None
                    G.Clear(Barcolor)
                Case ButtonHoverState.Minimize
                    If _EnableMinimize = True Then
                        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(3, 0, 30, Height))
                    End If
                Case ButtonHoverState.Maximize
                    If _EnableMaximize = True Then
                        G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(35, 0, 30, Height))
                    End If
                Case ButtonHoverState.Close
                    G.FillRectangle(New SolidBrush(Barcolor), New Rectangle(66, 0, 35, Height))
            End Select
        End If

        'Close
        G.DrawString("r", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(Width - 16, 8), New StringFormat With {.Alignment = StringAlignment.Center})

        'Maximize
        Select Case Parent.FindForm().WindowState
            Case FormWindowState.Maximized
                If _EnableMaximize = True Then
                    G.DrawString("2", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                Else
                    G.DrawString("2", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                End If
            Case FormWindowState.Normal
                If _EnableMaximize = True Then
                    G.DrawString("1", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                Else
                    G.DrawString("1", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(51, 7), New StringFormat With {.Alignment = StringAlignment.Center})
                End If
        End Select

        'Minimize
        If _EnableMinimize = True Then
            G.DrawString("0", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        Else
            G.DrawString("0", New Font("Marlett", 12), New SolidBrush(FormSignColor), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        End If
    End Sub

    Private Sub FormControlBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

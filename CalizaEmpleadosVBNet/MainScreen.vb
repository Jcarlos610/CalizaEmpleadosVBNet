Public Class MainScreen
    Private Function TheFormIsAlreadyLoaded(ByVal pFormName As String) As Boolean

        If FirstName Is Nothing AndAlso pFormName <> "LoginScreen" Then
            Return False
        End If

        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals(pFormName) Then
                Return False
            End If
        Next

        Return True

    End Function

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginScreen.MdiParent = Me
        LoginScreen.Show()

        AsignarEventosMenu(MenuStrip1.Items)
    End Sub

    Private Sub AsignarEventosMenu(items As ToolStripItemCollection)

        For Each item As ToolStripItem In items

            If TypeOf item Is ToolStripMenuItem Then

                Dim menu As ToolStripMenuItem = CType(item, ToolStripMenuItem)


                If menu.DropDownItems.Count > 0 Then
                    AsignarEventosMenu(menu.DropDownItems)
                Else

                    If menu.Tag IsNot Nothing Then
                        AddHandler menu.Click, AddressOf Menu_Click
                    End If
                End If

            End If

        Next

    End Sub



    Private Sub Menu_Click(sender As Object, e As EventArgs)

        Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim formName As String = item.Tag.ToString()

        Dim user As New CL_Users()


        If Not user.TienePermiso(GlobalUserID, formName) Then
            MessageBox.Show("No tienes permiso para acceder a este formulario", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            'Dim frmType As Type = Type.GetType("CalizaEmpleadosVBNet." & formName)

            Dim frmType As Type = Nothing

            For Each t In System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                If t.Name = formName Then
                    frmType = t
                    Exit For
                End If
            Next



            If frmType IsNot Nothing Then
                Dim frm As Form = CType(Activator.CreateInstance(frmType), Form)
                frm.MdiParent = Me
                frm.Show()
            Else
                MessageBox.Show("No se encontró el formulario: " & formName)

            End If


        Catch ex As Exception
            MessageBox.Show("Error al abrir: " & ex.Message)
        End Try

    End Sub


    Public Sub aplicarpermisos()



        Dim user As New CL_Users()

        For Each item As ToolStripMenuItem In MenuStrip1.Items
            AplicarPermisosMenu(item, user)
        Next



    End Sub


    Private Sub AplicarPermisosMenu(item As ToolStripMenuItem, user As CL_Users)


        If item.DropDownItems.Count > 0 Then


            item.Visible = True

            For Each subItem As ToolStripItem In item.DropDownItems

                If TypeOf subItem Is ToolStripMenuItem Then

                    Dim menuHijo As ToolStripMenuItem = CType(subItem, ToolStripMenuItem)

                    If menuHijo.Tag IsNot Nothing Then

                        If user.TienePermiso(GlobalUserID, menuHijo.Tag.ToString()) Then
                            menuHijo.Visible = True
                        Else
                            menuHijo.Visible = False
                        End If

                    End If

                End If

            Next

        Else

            If item.Tag IsNot Nothing Then

                If user.TienePermiso(GlobalUserID, item.Tag.ToString()) Then
                    item.Visible = True
                Else
                    item.Visible = False
                End If

            End If
        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim result = MessageBox.Show("¿Deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then


            GlobalUserID = 0
            GlobalUserName = ""
            AppUser = ""
            FirstName = ""
            LastName = ""


            For Each f As Form In Me.MdiChildren
                f.Close()
            Next


            Me.Text = "Sistema"


            For Each item As ToolStripMenuItem In MenuStrip1.Items
                item.Visible = False
            Next


            Dim login As New LoginScreen()
            login.MdiParent = Me
            login.Show()

        End If

    End Sub

End Class
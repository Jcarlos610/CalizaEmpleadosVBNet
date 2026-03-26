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



    Private Sub AltaDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaDeUsuariosToolStripMenuItem.Click
        Dim NewScreen = New ST_INS_Users
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarUsuarioToolStripMenuItem.Click
        Dim NewScreen = New ST_UPD_Users
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearEmpresaToolStripMenuItem.Click
        Dim NewScreen = New ST_INS_Companies
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarEmpresaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarEmpresaToolStripMenuItem1.Click
        Dim NewScreen = New ST_UPD_Companies
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginScreen.MdiParent = Me
        LoginScreen.Show()

        AsignarEventosMenu(MenuStrip1.Items)
    End Sub

    Private Sub AsignarEventosMenu(items As ToolStripItemCollection)

        For Each item As ToolStripItem In items

            If TypeOf item Is ToolStripMenuItem Then

                Dim menu As ToolStripMenuItem = CType(item, ToolStripMenuItem)

                ' Si tiene hijos → recorrerlos
                If menu.DropDownItems.Count > 0 Then
                    AsignarEventosMenu(menu.DropDownItems)
                Else
                    ' Si tiene Tag → asignar click automático
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

        ' 🔥 VALIDAR PERMISO ANTES DE ABRIR
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

        ' 🔹 SOLO validar si tiene hijos (submenús)
        If item.DropDownItems.Count > 0 Then

            ' El padre SIEMPRE visible
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
            ' 🔹 Si NO tiene hijos (es un botón solo)
            If item.Tag IsNot Nothing Then

                If user.TienePermiso(GlobalUserID, item.Tag.ToString()) Then
                    item.Visible = True
                Else
                    item.Visible = False
                End If

            End If
        End If

    End Sub






    Private Sub CrearNuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CrearNuevoToolStripMenuItem1.Click
        Dim NewScreen = New MD_INS_Benefits
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarExistenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarExistenteToolStripMenuItem1.Click
        Dim NewScreen = New MD_UPD_Benefits
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearNuevaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearNuevaToolStripMenuItem.Click
        Dim NewScreen = New MD_INS_Banns
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarExistenteToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EditarExistenteToolStripMenuItem2.Click
        Dim NewScreen = New MD_UPD_Banns
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearPuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearPuestoToolStripMenuItem.Click
        Dim NewScreen = New MD_INS_Position
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If

    End Sub

    Private Sub ActualizarPuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarPuestoToolStripMenuItem.Click
        Dim NewScreen = New MD_UPD_Position
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If

    End Sub

    Private Sub RegistrarNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarNToolStripMenuItem.Click
        Dim NewScreen = New MD_INS_Employees
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub AsignarBeneficiosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AsignarBeneficiosToolStripMenuItem1.Click
        Dim NewScreen = New OP_INS_BENEFITSPEREMPLOYEE
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub PorArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorArchivoToolStripMenuItem.Click
        Dim NewScreen = New OP_INS_TIMERECORDS
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearDescuentoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CrearDescuentoToolStripMenuItem.Click
        Dim NewScreen = New MD_INS_Discounts
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarExistenteToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EditarExistenteToolStripMenuItem3.Click
        Dim NewScreen = New MD_UPD_Discounts
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarEmpleadoToolStripMenuItem.Click
        Dim NewScreen = New MD_UPD_Employees
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub ReportesToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem7.Click
        Dim NewScreen = New MD_RPT_Employees
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearDepartamentoToolStripMenuItem.Click
        Dim NewScreen = New MD_INS_Departments
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarExistenteToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles EditarExistenteToolStripMenuItem4.Click
        Dim NewScreen = New MD_UPD_Departments
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub RegistroManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroManualToolStripMenuItem.Click
        Dim NewScreen = New OP_INS_TIMERECORDSMANUALLY
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub RegistroManualToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistroManualToolStripMenuItem1.Click
        Dim NewScreen = New OP_INS_MANUALLUNCHHOURS
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub AnalisisSemanalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalisisSemanalToolStripMenuItem.Click
        Dim NewScreen = New OP_SEL_MainWeekReport
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub CrearNuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearNuevoToolStripMenuItem.Click
        Dim NewScreen = New ST_INS_Roles
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub

    Private Sub EditarExistenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarExistenteToolStripMenuItem.Click
        Dim NewScreen = New ST_UPD_Roles
        If TheFormIsAlreadyLoaded(NewScreen.Name) Then
            NewScreen.MdiParent = Me
            NewScreen.Show()
        End If
    End Sub
End Class
Public Class MainScreen
    Private Function TheFormIsAlreadyLoaded(ByVal pFormName As String) As Boolean

        TheFormIsAlreadyLoaded = False

        'If FirstName Is Nothing And pFormName IsNot "LoginScreen" Then
        '    TheFormIsAlreadyLoaded = True
        '    Exit Function
        'End If

        'Temporal FULL access
        TheFormIsAlreadyLoaded = True
        Exit Function

        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals(pFormName) Then
                TheFormIsAlreadyLoaded = True
                Exit Function
            End If
        Next

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
End Class
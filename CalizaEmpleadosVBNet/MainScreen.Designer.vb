<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        SistemaToolStripMenuItem = New ToolStripMenuItem()
        UsuariosToolStripMenuItem = New ToolStripMenuItem()
        AltaDeUsuariosToolStripMenuItem = New ToolStripMenuItem()
        EditarUsuarioToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem5 = New ToolStripMenuItem()
        RolesToolStripMenuItem = New ToolStripMenuItem()
        CrearNuevoToolStripMenuItem = New ToolStripMenuItem()
        EditarExistenteToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem6 = New ToolStripMenuItem()
        DatosMaestrosToolStripMenuItem = New ToolStripMenuItem()
        EmpresasToolStripMenuItem1 = New ToolStripMenuItem()
        CrearEmpresaToolStripMenuItem = New ToolStripMenuItem()
        EditarEmpresaToolStripMenuItem1 = New ToolStripMenuItem()
        CatálogosToolStripMenuItem = New ToolStripMenuItem()
        BeneficiosToolStripMenuItem = New ToolStripMenuItem()
        CrearNuevoToolStripMenuItem1 = New ToolStripMenuItem()
        EditarExistenteToolStripMenuItem1 = New ToolStripMenuItem()
        AmonestacionesToolStripMenuItem = New ToolStripMenuItem()
        CrearNuevaToolStripMenuItem = New ToolStripMenuItem()
        EditarExistenteToolStripMenuItem2 = New ToolStripMenuItem()
        PuestosToolStripMenuItem = New ToolStripMenuItem()
        CrearPuestoToolStripMenuItem = New ToolStripMenuItem()
        ActualizarPuestoToolStripMenuItem = New ToolStripMenuItem()
        DescuentosToolStripMenuItem = New ToolStripMenuItem()
        CrearDescuentoToolStripMenuItem = New ToolStripMenuItem()
        EditarExistenteToolStripMenuItem3 = New ToolStripMenuItem()
        MovimientosToolStripMenuItem = New ToolStripMenuItem()
        CrearMovimientoToolStripMenuItem = New ToolStripMenuItem()
        EditarMovimientoToolStripMenuItem = New ToolStripMenuItem()
        EmpleadosToolStripMenuItem = New ToolStripMenuItem()
        EmpleadoToolStripMenuItem = New ToolStripMenuItem()
        RegistrarNToolStripMenuItem = New ToolStripMenuItem()
        EditarEmpleadoToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem7 = New ToolStripMenuItem()
        AsignarBeneficiosToolStripMenuItem = New ToolStripMenuItem()
        AsignarBeneficiosToolStripMenuItem1 = New ToolStripMenuItem()
        IncidenciasToolStripMenuItem = New ToolStripMenuItem()
        IncidenciasToolStripMenuItem1 = New ToolStripMenuItem()
        PorArchivoToolStripMenuItem = New ToolStripMenuItem()
        RegistroManualToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem4 = New ToolStripMenuItem()
        RegistroDeHorasDeComidaToolStripMenuItem = New ToolStripMenuItem()
        RegistroManualToolStripMenuItem1 = New ToolStripMenuItem()
        ReporteToolStripMenuItem = New ToolStripMenuItem()
        PermisosToolStripMenuItem = New ToolStripMenuItem()
        RegistrarPermisoToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem3 = New ToolStripMenuItem()
        BeneficiosToolStripMenuItem1 = New ToolStripMenuItem()
        BeneficiosToolStripMenuItem2 = New ToolStripMenuItem()
        RegistroDePrestamoToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem = New ToolStripMenuItem()
        PrestamosToolStripMenuItem = New ToolStripMenuItem()
        RegistrarPrestamoToolStripMenuItem = New ToolStripMenuItem()
        RegistrarAbonoToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem1 = New ToolStripMenuItem()
        PagoAnticipadoToolStripMenuItem = New ToolStripMenuItem()
        RegistrarNuevoToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem2 = New ToolStripMenuItem()
        AnalisisSemanalToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {SistemaToolStripMenuItem, DatosMaestrosToolStripMenuItem, EmpleadosToolStripMenuItem, IncidenciasToolStripMenuItem, BeneficiosToolStripMenuItem1, ReportesToolStripMenuItem2})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1226, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' SistemaToolStripMenuItem
        ' 
        SistemaToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UsuariosToolStripMenuItem, RolesToolStripMenuItem})
        SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        SistemaToolStripMenuItem.Size = New Size(95, 20)
        SistemaToolStripMenuItem.Text = "Configuracion"
        ' 
        ' UsuariosToolStripMenuItem
        ' 
        UsuariosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AltaDeUsuariosToolStripMenuItem, EditarUsuarioToolStripMenuItem, ReportesToolStripMenuItem5})
        UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        UsuariosToolStripMenuItem.Size = New Size(166, 22)
        UsuariosToolStripMenuItem.Text = "Tipos de usuarios"
        ' 
        ' AltaDeUsuariosToolStripMenuItem
        ' 
        AltaDeUsuariosToolStripMenuItem.Name = "AltaDeUsuariosToolStripMenuItem"
        AltaDeUsuariosToolStripMenuItem.Size = New Size(153, 22)
        AltaDeUsuariosToolStripMenuItem.Text = "Crear nuevo"
        ' 
        ' EditarUsuarioToolStripMenuItem
        ' 
        EditarUsuarioToolStripMenuItem.Name = "EditarUsuarioToolStripMenuItem"
        EditarUsuarioToolStripMenuItem.Size = New Size(153, 22)
        EditarUsuarioToolStripMenuItem.Text = "Editar existente"
        ' 
        ' ReportesToolStripMenuItem5
        ' 
        ReportesToolStripMenuItem5.Name = "ReportesToolStripMenuItem5"
        ReportesToolStripMenuItem5.Size = New Size(153, 22)
        ReportesToolStripMenuItem5.Text = "Reportes"
        ' 
        ' RolesToolStripMenuItem
        ' 
        RolesToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearNuevoToolStripMenuItem, EditarExistenteToolStripMenuItem, ReportesToolStripMenuItem6})
        RolesToolStripMenuItem.Name = "RolesToolStripMenuItem"
        RolesToolStripMenuItem.Size = New Size(166, 22)
        RolesToolStripMenuItem.Text = "Roles"
        ' 
        ' CrearNuevoToolStripMenuItem
        ' 
        CrearNuevoToolStripMenuItem.Name = "CrearNuevoToolStripMenuItem"
        CrearNuevoToolStripMenuItem.Size = New Size(153, 22)
        CrearNuevoToolStripMenuItem.Text = "Crear nuevo"
        ' 
        ' EditarExistenteToolStripMenuItem
        ' 
        EditarExistenteToolStripMenuItem.Name = "EditarExistenteToolStripMenuItem"
        EditarExistenteToolStripMenuItem.Size = New Size(153, 22)
        EditarExistenteToolStripMenuItem.Text = "Editar existente"
        ' 
        ' ReportesToolStripMenuItem6
        ' 
        ReportesToolStripMenuItem6.Name = "ReportesToolStripMenuItem6"
        ReportesToolStripMenuItem6.Size = New Size(153, 22)
        ReportesToolStripMenuItem6.Text = "Reportes"
        ' 
        ' DatosMaestrosToolStripMenuItem
        ' 
        DatosMaestrosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {EmpresasToolStripMenuItem1, CatálogosToolStripMenuItem, MovimientosToolStripMenuItem})
        DatosMaestrosToolStripMenuItem.Name = "DatosMaestrosToolStripMenuItem"
        DatosMaestrosToolStripMenuItem.Size = New Size(100, 20)
        DatosMaestrosToolStripMenuItem.Text = "Datos Maestros"
        ' 
        ' EmpresasToolStripMenuItem1
        ' 
        EmpresasToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {CrearEmpresaToolStripMenuItem, EditarEmpresaToolStripMenuItem1})
        EmpresasToolStripMenuItem1.Name = "EmpresasToolStripMenuItem1"
        EmpresasToolStripMenuItem1.Size = New Size(144, 22)
        EmpresasToolStripMenuItem1.Text = "Empresas"
        ' 
        ' CrearEmpresaToolStripMenuItem
        ' 
        CrearEmpresaToolStripMenuItem.Name = "CrearEmpresaToolStripMenuItem"
        CrearEmpresaToolStripMenuItem.Size = New Size(152, 22)
        CrearEmpresaToolStripMenuItem.Text = "Crear Empresa"
        ' 
        ' EditarEmpresaToolStripMenuItem1
        ' 
        EditarEmpresaToolStripMenuItem1.Name = "EditarEmpresaToolStripMenuItem1"
        EditarEmpresaToolStripMenuItem1.Size = New Size(152, 22)
        EditarEmpresaToolStripMenuItem1.Text = "Editar Empresa"
        ' 
        ' CatálogosToolStripMenuItem
        ' 
        CatálogosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {BeneficiosToolStripMenuItem, AmonestacionesToolStripMenuItem, PuestosToolStripMenuItem, DescuentosToolStripMenuItem})
        CatálogosToolStripMenuItem.Name = "CatálogosToolStripMenuItem"
        CatálogosToolStripMenuItem.Size = New Size(144, 22)
        CatálogosToolStripMenuItem.Text = "Catálogos"
        ' 
        ' BeneficiosToolStripMenuItem
        ' 
        BeneficiosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearNuevoToolStripMenuItem1, EditarExistenteToolStripMenuItem1})
        BeneficiosToolStripMenuItem.Name = "BeneficiosToolStripMenuItem"
        BeneficiosToolStripMenuItem.Size = New Size(166, 22)
        BeneficiosToolStripMenuItem.Text = "Beneficios/Bonos"
        ' 
        ' CrearNuevoToolStripMenuItem1
        ' 
        CrearNuevoToolStripMenuItem1.Name = "CrearNuevoToolStripMenuItem1"
        CrearNuevoToolStripMenuItem1.Size = New Size(153, 22)
        CrearNuevoToolStripMenuItem1.Text = "Crear nuevo"
        ' 
        ' EditarExistenteToolStripMenuItem1
        ' 
        EditarExistenteToolStripMenuItem1.Name = "EditarExistenteToolStripMenuItem1"
        EditarExistenteToolStripMenuItem1.Size = New Size(153, 22)
        EditarExistenteToolStripMenuItem1.Text = "Editar existente"
        ' 
        ' AmonestacionesToolStripMenuItem
        ' 
        AmonestacionesToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearNuevaToolStripMenuItem, EditarExistenteToolStripMenuItem2})
        AmonestacionesToolStripMenuItem.Name = "AmonestacionesToolStripMenuItem"
        AmonestacionesToolStripMenuItem.Size = New Size(166, 22)
        AmonestacionesToolStripMenuItem.Text = "Amonestaciones"
        ' 
        ' CrearNuevaToolStripMenuItem
        ' 
        CrearNuevaToolStripMenuItem.Name = "CrearNuevaToolStripMenuItem"
        CrearNuevaToolStripMenuItem.Size = New Size(153, 22)
        CrearNuevaToolStripMenuItem.Text = "Crear nueva"
        ' 
        ' EditarExistenteToolStripMenuItem2
        ' 
        EditarExistenteToolStripMenuItem2.Name = "EditarExistenteToolStripMenuItem2"
        EditarExistenteToolStripMenuItem2.Size = New Size(153, 22)
        EditarExistenteToolStripMenuItem2.Text = "Editar existente"
        ' 
        ' PuestosToolStripMenuItem
        ' 
        PuestosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearPuestoToolStripMenuItem, ActualizarPuestoToolStripMenuItem})
        PuestosToolStripMenuItem.Name = "PuestosToolStripMenuItem"
        PuestosToolStripMenuItem.Size = New Size(166, 22)
        PuestosToolStripMenuItem.Text = "Puestos"
        ' 
        ' CrearPuestoToolStripMenuItem
        ' 
        CrearPuestoToolStripMenuItem.Name = "CrearPuestoToolStripMenuItem"
        CrearPuestoToolStripMenuItem.Size = New Size(153, 22)
        CrearPuestoToolStripMenuItem.Text = "Crear puesto"
        ' 
        ' ActualizarPuestoToolStripMenuItem
        ' 
        ActualizarPuestoToolStripMenuItem.Name = "ActualizarPuestoToolStripMenuItem"
        ActualizarPuestoToolStripMenuItem.Size = New Size(153, 22)
        ActualizarPuestoToolStripMenuItem.Text = "Editar Existente"
        ' 
        ' DescuentosToolStripMenuItem
        ' 
        DescuentosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearDescuentoToolStripMenuItem, EditarExistenteToolStripMenuItem3})
        DescuentosToolStripMenuItem.Name = "DescuentosToolStripMenuItem"
        DescuentosToolStripMenuItem.Size = New Size(166, 22)
        DescuentosToolStripMenuItem.Text = "Descuentos"
        ' 
        ' CrearDescuentoToolStripMenuItem
        ' 
        CrearDescuentoToolStripMenuItem.Name = "CrearDescuentoToolStripMenuItem"
        CrearDescuentoToolStripMenuItem.Size = New Size(160, 22)
        CrearDescuentoToolStripMenuItem.Text = "Crear descuento"
        ' 
        ' EditarExistenteToolStripMenuItem3
        ' 
        EditarExistenteToolStripMenuItem3.Name = "EditarExistenteToolStripMenuItem3"
        EditarExistenteToolStripMenuItem3.Size = New Size(160, 22)
        EditarExistenteToolStripMenuItem3.Text = "Editar existente"
        ' 
        ' MovimientosToolStripMenuItem
        ' 
        MovimientosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CrearMovimientoToolStripMenuItem, EditarMovimientoToolStripMenuItem})
        MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        MovimientosToolStripMenuItem.Size = New Size(144, 22)
        MovimientosToolStripMenuItem.Text = "Movimientos"
        ' 
        ' CrearMovimientoToolStripMenuItem
        ' 
        CrearMovimientoToolStripMenuItem.Name = "CrearMovimientoToolStripMenuItem"
        CrearMovimientoToolStripMenuItem.Size = New Size(172, 22)
        CrearMovimientoToolStripMenuItem.Text = "Crear movimiento"
        ' 
        ' EditarMovimientoToolStripMenuItem
        ' 
        EditarMovimientoToolStripMenuItem.Name = "EditarMovimientoToolStripMenuItem"
        EditarMovimientoToolStripMenuItem.Size = New Size(172, 22)
        EditarMovimientoToolStripMenuItem.Text = "Editar movimiento"
        ' 
        ' EmpleadosToolStripMenuItem
        ' 
        EmpleadosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {EmpleadoToolStripMenuItem, AsignarBeneficiosToolStripMenuItem})
        EmpleadosToolStripMenuItem.Name = "EmpleadosToolStripMenuItem"
        EmpleadosToolStripMenuItem.Size = New Size(77, 20)
        EmpleadosToolStripMenuItem.Text = "Empleados"
        ' 
        ' EmpleadoToolStripMenuItem
        ' 
        EmpleadoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistrarNToolStripMenuItem, EditarEmpleadoToolStripMenuItem, ReportesToolStripMenuItem7})
        EmpleadoToolStripMenuItem.Name = "EmpleadoToolStripMenuItem"
        EmpleadoToolStripMenuItem.Size = New Size(205, 22)
        EmpleadoToolStripMenuItem.Text = "Empleado"
        ' 
        ' RegistrarNToolStripMenuItem
        ' 
        RegistrarNToolStripMenuItem.Name = "RegistrarNToolStripMenuItem"
        RegistrarNToolStripMenuItem.Size = New Size(189, 22)
        RegistrarNToolStripMenuItem.Text = "Registro de empleado"
        ' 
        ' EditarEmpleadoToolStripMenuItem
        ' 
        EditarEmpleadoToolStripMenuItem.Name = "EditarEmpleadoToolStripMenuItem"
        EditarEmpleadoToolStripMenuItem.Size = New Size(189, 22)
        EditarEmpleadoToolStripMenuItem.Text = "Editar Empleado"
        ' 
        ' ReportesToolStripMenuItem7
        ' 
        ReportesToolStripMenuItem7.Name = "ReportesToolStripMenuItem7"
        ReportesToolStripMenuItem7.Size = New Size(189, 22)
        ReportesToolStripMenuItem7.Text = "Reportes"
        ' 
        ' AsignarBeneficiosToolStripMenuItem
        ' 
        AsignarBeneficiosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AsignarBeneficiosToolStripMenuItem1})
        AsignarBeneficiosToolStripMenuItem.Name = "AsignarBeneficiosToolStripMenuItem"
        AsignarBeneficiosToolStripMenuItem.Size = New Size(205, 22)
        AsignarBeneficiosToolStripMenuItem.Text = "Beneficios por Empleado"
        ' 
        ' AsignarBeneficiosToolStripMenuItem1
        ' 
        AsignarBeneficiosToolStripMenuItem1.Name = "AsignarBeneficiosToolStripMenuItem1"
        AsignarBeneficiosToolStripMenuItem1.Size = New Size(171, 22)
        AsignarBeneficiosToolStripMenuItem1.Text = "Asignar Beneficios"
        ' 
        ' IncidenciasToolStripMenuItem
        ' 
        IncidenciasToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {IncidenciasToolStripMenuItem1, RegistroDeHorasDeComidaToolStripMenuItem, PermisosToolStripMenuItem})
        IncidenciasToolStripMenuItem.Name = "IncidenciasToolStripMenuItem"
        IncidenciasToolStripMenuItem.Size = New Size(78, 20)
        IncidenciasToolStripMenuItem.Text = "Incidencias"
        ' 
        ' IncidenciasToolStripMenuItem1
        ' 
        IncidenciasToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {PorArchivoToolStripMenuItem, RegistroManualToolStripMenuItem, ReportesToolStripMenuItem4})
        IncidenciasToolStripMenuItem1.Name = "IncidenciasToolStripMenuItem1"
        IncidenciasToolStripMenuItem1.Size = New Size(224, 22)
        IncidenciasToolStripMenuItem1.Text = "Registro de entradas/salidas"
        ' 
        ' PorArchivoToolStripMenuItem
        ' 
        PorArchivoToolStripMenuItem.Name = "PorArchivoToolStripMenuItem"
        PorArchivoToolStripMenuItem.Size = New Size(168, 22)
        PorArchivoToolStripMenuItem.Text = "Carga por archivo"
        ' 
        ' RegistroManualToolStripMenuItem
        ' 
        RegistroManualToolStripMenuItem.Name = "RegistroManualToolStripMenuItem"
        RegistroManualToolStripMenuItem.Size = New Size(168, 22)
        RegistroManualToolStripMenuItem.Text = "Registro manual"
        ' 
        ' ReportesToolStripMenuItem4
        ' 
        ReportesToolStripMenuItem4.Name = "ReportesToolStripMenuItem4"
        ReportesToolStripMenuItem4.Size = New Size(168, 22)
        ReportesToolStripMenuItem4.Text = "Reportes"
        ' 
        ' RegistroDeHorasDeComidaToolStripMenuItem
        ' 
        RegistroDeHorasDeComidaToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistroManualToolStripMenuItem1, ReporteToolStripMenuItem})
        RegistroDeHorasDeComidaToolStripMenuItem.Name = "RegistroDeHorasDeComidaToolStripMenuItem"
        RegistroDeHorasDeComidaToolStripMenuItem.Size = New Size(224, 22)
        RegistroDeHorasDeComidaToolStripMenuItem.Text = "Registro de horas de comida"
        ' 
        ' RegistroManualToolStripMenuItem1
        ' 
        RegistroManualToolStripMenuItem1.Name = "RegistroManualToolStripMenuItem1"
        RegistroManualToolStripMenuItem1.Size = New Size(160, 22)
        RegistroManualToolStripMenuItem1.Text = "Registro manual"
        ' 
        ' ReporteToolStripMenuItem
        ' 
        ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        ReporteToolStripMenuItem.Size = New Size(160, 22)
        ReporteToolStripMenuItem.Text = "Reportes"
        ' 
        ' PermisosToolStripMenuItem
        ' 
        PermisosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistrarPermisoToolStripMenuItem, ReportesToolStripMenuItem3})
        PermisosToolStripMenuItem.Name = "PermisosToolStripMenuItem"
        PermisosToolStripMenuItem.Size = New Size(224, 22)
        PermisosToolStripMenuItem.Text = "Permisos"
        ' 
        ' RegistrarPermisoToolStripMenuItem
        ' 
        RegistrarPermisoToolStripMenuItem.Name = "RegistrarPermisoToolStripMenuItem"
        RegistrarPermisoToolStripMenuItem.Size = New Size(166, 22)
        RegistrarPermisoToolStripMenuItem.Text = "Registrar Permiso"
        ' 
        ' ReportesToolStripMenuItem3
        ' 
        ReportesToolStripMenuItem3.Name = "ReportesToolStripMenuItem3"
        ReportesToolStripMenuItem3.Size = New Size(166, 22)
        ReportesToolStripMenuItem3.Text = "Reportes"
        ' 
        ' BeneficiosToolStripMenuItem1
        ' 
        BeneficiosToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {BeneficiosToolStripMenuItem2, PrestamosToolStripMenuItem, PagoAnticipadoToolStripMenuItem})
        BeneficiosToolStripMenuItem1.Name = "BeneficiosToolStripMenuItem1"
        BeneficiosToolStripMenuItem1.Size = New Size(73, 20)
        BeneficiosToolStripMenuItem1.Text = "Beneficios"
        ' 
        ' BeneficiosToolStripMenuItem2
        ' 
        BeneficiosToolStripMenuItem2.DropDownItems.AddRange(New ToolStripItem() {RegistroDePrestamoToolStripMenuItem, ReportesToolStripMenuItem})
        BeneficiosToolStripMenuItem2.Name = "BeneficiosToolStripMenuItem2"
        BeneficiosToolStripMenuItem2.Size = New Size(180, 22)
        BeneficiosToolStripMenuItem2.Text = "Ahorros"
        ' 
        ' RegistroDePrestamoToolStripMenuItem
        ' 
        RegistroDePrestamoToolStripMenuItem.Name = "RegistroDePrestamoToolStripMenuItem"
        RegistroDePrestamoToolStripMenuItem.Size = New Size(160, 22)
        RegistroDePrestamoToolStripMenuItem.Text = "Registro manual"
        ' 
        ' ReportesToolStripMenuItem
        ' 
        ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        ReportesToolStripMenuItem.Size = New Size(160, 22)
        ReportesToolStripMenuItem.Text = "Reportes"
        ' 
        ' PrestamosToolStripMenuItem
        ' 
        PrestamosToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistrarPrestamoToolStripMenuItem, RegistrarAbonoToolStripMenuItem, ReportesToolStripMenuItem1})
        PrestamosToolStripMenuItem.Name = "PrestamosToolStripMenuItem"
        PrestamosToolStripMenuItem.Size = New Size(180, 22)
        PrestamosToolStripMenuItem.Text = "Prestamos"
        ' 
        ' RegistrarPrestamoToolStripMenuItem
        ' 
        RegistrarPrestamoToolStripMenuItem.Name = "RegistrarPrestamoToolStripMenuItem"
        RegistrarPrestamoToolStripMenuItem.Size = New Size(173, 22)
        RegistrarPrestamoToolStripMenuItem.Text = "Registrar prestamo"
        ' 
        ' RegistrarAbonoToolStripMenuItem
        ' 
        RegistrarAbonoToolStripMenuItem.Name = "RegistrarAbonoToolStripMenuItem"
        RegistrarAbonoToolStripMenuItem.Size = New Size(173, 22)
        RegistrarAbonoToolStripMenuItem.Text = "Registrar abono"
        ' 
        ' ReportesToolStripMenuItem1
        ' 
        ReportesToolStripMenuItem1.Name = "ReportesToolStripMenuItem1"
        ReportesToolStripMenuItem1.Size = New Size(173, 22)
        ReportesToolStripMenuItem1.Text = "Reportes"
        ' 
        ' PagoAnticipadoToolStripMenuItem
        ' 
        PagoAnticipadoToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {RegistrarNuevoToolStripMenuItem})
        PagoAnticipadoToolStripMenuItem.Name = "PagoAnticipadoToolStripMenuItem"
        PagoAnticipadoToolStripMenuItem.Size = New Size(180, 22)
        PagoAnticipadoToolStripMenuItem.Text = "Pago anticipado"
        ' 
        ' RegistrarNuevoToolStripMenuItem
        ' 
        RegistrarNuevoToolStripMenuItem.Name = "RegistrarNuevoToolStripMenuItem"
        RegistrarNuevoToolStripMenuItem.Size = New Size(156, 22)
        RegistrarNuevoToolStripMenuItem.Text = "Registrar nuevo"
        ' 
        ' ReportesToolStripMenuItem2
        ' 
        ReportesToolStripMenuItem2.DropDownItems.AddRange(New ToolStripItem() {AnalisisSemanalToolStripMenuItem})
        ReportesToolStripMenuItem2.Name = "ReportesToolStripMenuItem2"
        ReportesToolStripMenuItem2.Size = New Size(65, 20)
        ReportesToolStripMenuItem2.Text = "Reportes"
        ' 
        ' AnalisisSemanalToolStripMenuItem
        ' 
        AnalisisSemanalToolStripMenuItem.Name = "AnalisisSemanalToolStripMenuItem"
        AnalisisSemanalToolStripMenuItem.Size = New Size(180, 22)
        AnalisisSemanalToolStripMenuItem.Text = "Analisis Semanal"
        ' 
        ' MainScreen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1226, 529)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "MainScreen"
        Text = "Sistema de registro de empleados - Caliza triturados"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SistemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatosMaestrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CatálogosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IncidenciasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeneficiosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AmonestacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IncidenciasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AltaDeUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RolesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearNuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarExistenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PorArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeHorasDeComidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroManualToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CrearNuevoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditarExistenteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CrearNuevaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarExistenteToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents PermisosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarPermisoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeneficiosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BeneficiosToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents CrearMovimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarMovimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents RegistroDePrestamoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrestamosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarPrestamoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarAbonoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PagoAnticipadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarNuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpleadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmpleadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarNToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarEmpleadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents EmpresasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CrearEmpresaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarEmpresaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PuestosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearPuestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualizarPuestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignarBeneficiosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignarBeneficiosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DescuentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearDescuentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarExistenteToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents AnalisisSemanalToolStripMenuItem As ToolStripMenuItem

End Class
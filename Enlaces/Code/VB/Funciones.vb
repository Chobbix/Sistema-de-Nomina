Option Explicit On
Imports System.Windows
Imports System
Imports System.IO
Public Class Funciones
    Inherits EnlaceBD
    Private aux As String
    Public PblFechaCalendario
    Public PblFechaPresentacion As String
    Public PblFechaAplicacion As String
    Public Cuantos
    Public Importe As Double
    Public DiaPago As String

    Public Shared Sub FormatoCombo(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        cbo.Items.Add(" -- TODOS -- ")
        cbo.Items.Add("HIPER/SUPER")
        cbo.Items.Add("MERCADO/EXPRESS")
        cbo.SelectedIndex = 0
    End Sub
    Public Shared Sub ZonaCombo(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        cbo.Items.Add("Todos")
        cbo.SelectedIndex = 1
    End Sub
    Public Shared Sub RegionCombo(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        cbo.Items.Add("Todos")
        cbo.SelectedIndex = 1
    End Sub
    Public Shared Sub TiendaCombo(ByRef cbo As ComboBox, ByVal tienda As Integer)
        cbo.Items.Clear()
        cbo.Items.Add(" - TODAS - ")

        cbo.DataSource = MuestraTiendas(tienda)
        'cbo.DataTextField = "Servidor"
        'cbo.DataValueField = "Clave"
        'cbo.DataBind()

        'Dim row As DataRow

        'For Each row In tabla.Rows
        '    'cbo.DisplayMember = ""
        '    cbo.Items.Insert(row(0), row(1))
        '    'cbo.Items.Add(row(1))
        '    'cbo.Items.
        'Next

        cbo.SelectedIndex = 0

    End Sub
    Public Shared Sub DeptoCombo(ByRef cbo As ComboBox, ByVal tienda As Integer)
        cbo.Items.Clear()
        cbo.Items.Add(" - TODOS - ")

        cbo.DataSource = MuestraDeptos(tienda)
        'cbo.DataTextField = "Nombre_Depto"
        'cbo.DataValueField = "Depto"
        'cbo.DataBind()

        'cbo.SelectedIndex = 0
    End Sub

    Public Shared Sub AñoCombo(ByRef cbo As ComboBox)
        cbo.Items.Clear()
        cbo.Items.Add(Year(Now) - 1)
        cbo.Items.Add(Year(Now))
        cbo.Items.Add(Year(Now) + 1)
        cbo.SelectedIndex = 1
    End Sub

    Public Shared Sub CargaAnalisis1(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal grid As DataGridView, ByVal Tienda As Integer, ByVal Depto As String)

        grid.DataSource = MuestraAnalisis1(Fecha1, Fecha2, Tienda, Depto)
        'grid.DataBind()

    End Sub

    Public Shared Function MuestraAnalisis1(ByVal Fecha1 As Date, ByVal Fecha2 As Date, ByVal Tienda As Integer, ByVal Depto As String) As DataTable

        Dim conexion As New EnlaceBD
        Dim tabla As New DataTable

        conexion.GeneraAnalisis1(Fecha1, Fecha2, Tienda, Depto)
        tabla = conexion.obtenertabla
        Return tabla

    End Function

    Public Shared Function MuestraTiendas(ByVal tienda As Integer) As DataTable

        Dim conexion As New EnlaceBD
        Dim tabla As New DataTable

        'conexion.ObtenTiendasIntelex(tienda)
        conexion.ObtenTiendas(tienda)
        tabla = conexion.obtenertabla
        Return tabla

    End Function
    Public Shared Function MuestraDeptos(ByVal tienda As Integer) As DataTable

        Dim conexion As New EnlaceBD
        Dim tabla As New DataTable

        conexion.ObtenDeptos(tienda)
        tabla = conexion.obtenertabla
        Return tabla

    End Function
    Public Shared Function MuestraDeptos2() As DataTable

        Dim conexion As New EnlaceBD
        Dim tabla As New DataTable

        'conexion.ObtenDeptos2()
        tabla = conexion.obtenertabla
        Return tabla

    End Function

    Public Shared Function CorrigeFecha(ByVal Fecha As String, ByVal Separador As String) As Date

        Dim pos1, pos2 As Integer
        Dim aa, mm, dd As String

        pos1 = 1
        pos2 = InStr(pos1, Fecha, Separador, CompareMethod.Text)
        dd = Mid(Fecha, pos1, (pos2 - pos1))

        pos1 = pos2 + 1
        pos2 = InStr(pos1, Fecha, Separador, CompareMethod.Text)
        mm = Mid(Fecha, pos1, (pos2 - pos1))

        pos1 = pos2 + 1
        'pos2 = InStr(pos1, Fecha, Separador, CompareMethod.Text)
        aa = Mid(Fecha, pos1)

        Dim Fecha1 As String = aa + "/" + CorrigeMes(mm.Trim) + "/" + dd
        Dim Fecha2 = DateTime.ParseExact(Fecha1, "yy/MM/dd", Nothing)

        Return Fecha2

    End Function

    Public Shared Function CorrigeMes(ByVal strMes As String) As String
        ' vector de tipo String     
        Dim meses As String() = {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"}
        Dim mm As Integer
        Dim Mes As String

        ' recorrer el vector y  mostrar los valores     
        For i As Integer = 0 To meses.Length - 1
            If meses(i) = strMes Then
                mm = i + 1
                Exit For
            End If
        Next

        If mm < 10 Then
            Mes = "0" + mm.ToString
        Else
            Mes = mm.ToString
        End If

        Return Mes

    End Function
    Public Shared Sub FormateaGrid(ByVal gv As DataGrid)
        Dim Valor As String = ""


        'For Each row As DataGrid In gv.Rows
        '    Valor = row.Cells(8).Text.ToString()
        '    Valor = Valor.ToString()
        'Next    'Lee todos los renglones del grid

    End Sub
    Public Sub Suma(ByVal DiaPago As String)

        Cuantos = 0
        Importe = 0

        'Dim conexion As New EnlaceBD
        'Dim tabla As New DataTable

        'conexion.ObtenDatosArchivo("PGOS", 90, DiaPago)
        'tabla = conexion.obtenertabla

        ''consulta la tabla:     rhCorporativoDB..DepositoBanco	

        'For Each row In tabla.Rows
        'Cuantos = row("Cuantos")
        'Importe = CDbl(row("Importe").ToString)
        'Next

        Cuantos = 2
        Importe = 10

    End Sub
    Public Sub ObtieneFechas(ByVal DiaPago As String)

        'Dim conexion As New EnlaceBD
        'Dim tabla As New DataTable

        'conexion.ObtenDatosArchivo("FB", 90, DiaPago)
        'tabla = conexion.obtenertabla

        ''PblFechaAplicacion = Format(tabla.Rows("FechaAplicacion"), "YYYYMMDD").ToString
        ''PblFechaPresentacion = Format(tabla.Rows("FechaPresentacion"), "YYYYMMDD").ToString

        'For Each row In tabla.Rows
        'PblFechaAplicacion = Format(row("FechaAplicacion"), "YYYYMMDD").ToString
        'PblFechaPresentacion = Format(row("FechaPresentacion"), "YYYYMMDD").ToString
        'Next

        PblFechaAplicacion = "20180313"
        PblFechaPresentacion = "20180312"

    End Sub
    Public Function GenerarArchivo() As Boolean
        Dim Stored As String
        Dim Header As String
        Dim Contador                'As Integer
        Dim TotalReg                'As Integer
        Dim Detalle As String
        Dim NombreEmpresa As String
        Dim Cta_Banc As String
        Dim RFC As String
        Dim Tipo_Reg As String
        Dim Fol_Lote As String
        Dim NumSecuencia As String
        Dim FechaAplicacion As String
        Dim CveBcoOrd As String
        Dim OrdTipoCta As String
        Dim CveProceso As String
        Dim CveProducto As String
        Dim CodInstruccion As String
        Dim CodMoneda As String
        Dim LeyendaCgo As String
        Dim CveCanal As String
        Dim CodRechazo As String
        Dim DesRechazo As String
        Dim TPCode As String

        Dim TPCode_det As String
        Dim Tipo_Reg_det As String
        Dim Fol_Lote_det As String
        Dim NumSecuencia_det As String
        Dim FechaAplicacion_det As String
        Dim CveBcoOrd_det As String
        Dim OrdTipoCta_det As String
        Dim Cta_Banc_det As String
        Dim NombreEmpresa_det As String
        Dim RFC_det As String
        Dim CveBcoBen_det As String
        Dim BenTpoCta_det As String
        Dim BenNumCta_det As String
        Dim BenNombre_det As String
        Dim BenCurpRfc_det As String
        Dim VosTpoCta_det As String
        Dim VosNumCta_det As String
        Dim CodMovto_det As String
        Dim TpoPago_det As String
        Dim ImporteOrden_det As String
        Dim ImporteIva_det As String
        Dim RefNumerica_det As String
        Dim TpoOperacion_det As String
        Dim FecExpiracion_det As String
        Dim CodEstatus_det As String
        Dim NumSerial_det As String
        Dim NumFolio_det As String
        Dim CodServicio_det As String
        Dim CodRechazo_det As String
        Dim HeaderLN As String
        Dim LeyendaAbono
        Dim FILE_NAME As String

        'On Error GoTo Error1

        DiaPago = "Otro"
        ObtieneFechas(DiaPago)

        'PblFechaAplicacion = "20170131"
        'PblFechaPresentacion = "20170131"

        Suma(DiaPago)

        Fol_Lote = "0"

        If Cuantos = 0 Then
            MessageBox.Show("Información para Generar el Archivo", "Pago Nomina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            GenerarArchivo = False
            Exit Function
        End If

        ' Configuramos la Barra Progresiva
        TotalReg = (Cuantos + 1) 'El mas uno es porque contiene HEADER

        Contador = 1
        HeaderLN = "01" + Format(Contador, "0000000") + "021E0120000000" & PblFechaPresentacion & Space(150)


        Dim conexion As New EnlaceBD
        Dim tabla As New DataTable

        conexion.ObtenDatosArchivo("HEDS", 90, "")
        tabla = conexion.obtenertabla
        'Return tabla

        Dim a As String
        a = tabla.Rows.Item(0).ToString.Trim

        For Each row In tabla.Rows
            Fol_Lote = row("Fol_Lote").ToString.Trim
            NombreEmpresa = row("NombreEmpresa").ToString
            Cta_Banc = row("Cta_Banc").ToString.Trim
            RFC = row("RFC").ToString
            Tipo_Reg = row("Tipo_Reg").ToString.Trim
            NumSecuencia = row("NumSecuencia").ToString.Trim
            FechaAplicacion = row("FechaAplicacion").ToString.Trim
            CveBcoOrd = row("CveBcoOrd").ToString.Trim
            OrdTipoCta = row("OrdTipoCta").ToString.Trim
            CveProceso = row("CveProceso").ToString.Trim
            CveProducto = row("CveProducto").ToString.Trim
            CodInstruccion = row("CodInstruccion").ToString.Trim
            CodMoneda = row("CodMoneda").ToString.Trim
            LeyendaCgo = row("LeyendaCgo").ToString
            CveCanal = row("CveCanal").ToString.Trim
            CodRechazo = row("CodRechazo").ToString.Trim
        Next

        'Fol_Lote = tabla.Rows.Item("Fol_Lote").ToString.Trim
        'NombreEmpresa = tabla.Rows.Item("NombreEmpresa").ToString
        'Cta_Banc = tabla.Rows.Item("Cta_Banc").ToString.Trim
        'RFC = tabla.Rows.Item("RFC").ToString
        'Tipo_Reg = tabla.Rows.Item("Tipo_Reg").ToString.Trim
        'NumSecuencia = tabla.Rows.Item("NumSecuencia").ToString.Trim
        'FechaAplicacion = tabla.Rows.Item("FechaAplicacion").ToString.Trim
        'CveBcoOrd = tabla.Rows.Item("CveBcoOrd").ToString.Trim
        'OrdTipoCta = tabla.Rows.Item("OrdTipoCta").ToString.Trim
        'CveProceso = tabla.Rows.Item("CveProceso").ToString.Trim
        'CveProducto = tabla.Rows.Item("CveProducto").ToString.Trim
        'CodInstruccion = tabla.Rows.Item("CodInstruccion").ToString.Trim
        'CodMoneda = tabla.Rows.Item("CodMoneda").ToString.Trim
        'LeyendaCgo = tabla.Rows.Item("LeyendaCgo").ToString
        'CveCanal = tabla.Rows.Item("CveCanal").ToString.Trim
        'CodRechazo = tabla.Rows.Item("CodRechazo").ToString.Trim

        'DVR 2010/12/15
        Header = Tipo_Reg + Fol_Lote + NumSecuencia + FechaAplicacion +
                 CveBcoOrd + OrdTipoCta + Cta_Banc + NombreEmpresa + RFC +
                 CveProceso + CveProducto + CodInstruccion + CodMoneda + LeyendaCgo +
                 Format(Cuantos, "00000") + Format(Trim((Importe)), "00000000000000000") + CveCanal + Space(1) + CodRechazo +
                 Space(50) +
                 "SORIANASIP " + Space(4) +
                 Space(391) + Chr(13)

        '----------------------------------------------------
        FILE_NAME = "archivo.txt"
        Using fs As New FileStream(FILE_NAME, FileMode.Truncate)
            Using w As New StreamWriter(fs)
                w.Write(Header)

                Dim conexion2 As New EnlaceBD
                Dim tabla2 As New DataTable

                conexion2.ObtenDatosArchivo("DETS", 90, DiaPago)
                tabla2 = conexion2.obtenertabla

                'Empieza el For i = 2 porque mete el detalle al archivo

                For Each row In tabla2.Rows
                    Contador = Contador + 1
                    'Armamos el detalle
                    Tipo_Reg_det = row("Tipo_Reg").ToString.Trim
                    Fol_Lote_det = row("Fol_Lote").ToString.Trim
                    NumSecuencia_det = row("NumSecuencia").ToString.Trim
                    FechaAplicacion_det = row("FechaAplicacion").ToString.Trim
                    CveBcoOrd_det = row("CveBcoOrd").ToString.Trim
                    OrdTipoCta_det = row("OrdTipoCta").ToString.Trim
                    Cta_Banc_det = row("Cta_Banc").ToString.Trim
                    NombreEmpresa_det = row("NombreEmpresa")
                    RFC_det = row("RFC").ToString
                    CveBcoBen_det = row("CveBcoBen").ToString.Trim
                    BenTpoCta_det = row("BenTpoCta").ToString.Trim
                    BenNumCta_det = row("BenNumCta")
                    BenNombre_det = row("BenNombre")
                    BenCurpRfc_det = row("BenCurpRfc")
                    VosTpoCta_det = row("VosTpoCta").ToString.Trim
                    VosNumCta_det = row("VosNumCta").ToString.Trim
                    CodMovto_det = row("CodMovto").ToString.Trim
                    TpoPago_det = row("TpoPago").ToString.Trim
                    LeyendaAbono = row("LeyendaAbono")
                    ImporteOrden_det = row("ImporteOrden").ToString.Trim
                    ImporteIva_det = row("ImporteIva").ToString.Trim
                    RefNumerica_det = row("RefNumerica").ToString.Trim
                    TpoOperacion_det = row("TpoOperacion").ToString.Trim
                    FecExpiracion_det = row("FecExpiracion").ToString.Trim
                    CodEstatus_det = row("CodEstatus").ToString.Trim
                    NumSerial_det = row("NumSerial").ToString.Trim
                    NumFolio_det = row("NumFolio").ToString.Trim
                    CodServicio_det = row("CodServicio").ToString.Trim
                    CodRechazo_det = row("CodRechazo").ToString.Trim

                    Detalle = Tipo_Reg_det + Fol_Lote_det + NumSecuencia_det + FechaAplicacion_det + CveBcoOrd_det + OrdTipoCta_det + Cta_Banc_det + NombreEmpresa_det +
                    RFC_det + CveBcoBen_det + BenTpoCta_det + BenNumCta_det + BenNombre_det + BenCurpRfc_det +
                    VosTpoCta_det + VosNumCta_det + Space(40) + Space(18) + CodMovto_det + TpoPago_det + LeyendaAbono + ImporteOrden_det + ImporteIva_det + RefNumerica_det + Space(40) + Space(10) + TpoOperacion_det + Space(30) + Space(40) + Space(40) +
                    FecExpiracion_det + CodEstatus_det + Space(8) + NumSerial_det + NumFolio_det + CodServicio_det + Space(10) + Space(30) + CodRechazo_det + Space(50) + Space(5) + Chr(13)

                    'Imprimir detalle del archivo
                    w.Write(Detalle)
                Next
                'Cerrar archivo
                w.Close()
            End Using
        End Using
        MessageBox.Show("El archivo: " + FILE_NAME + " fué generado existosamente", "Genera", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GenerarArchivo = True
        Exit Function

Error1:
        MessageBox.Show("Error", "Genera Archivo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk)
        GenerarArchivo = False
    End Function

    Public Shared Sub Proceso()
        Dim obj As New Funciones
        obj.GenerarArchivo()
    End Sub
End Class

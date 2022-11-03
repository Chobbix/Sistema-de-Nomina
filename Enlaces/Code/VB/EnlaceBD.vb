Imports System.Data
Imports System.Data.SqlClient
Public Class EnlaceBD
    Private aux As String
    Private conexion As SqlConnection
    'Private conexionNomina As SqlConnection
    Private tabla As DataTable = New DataTable
    Private adaptador As SqlDataAdapter = New SqlDataAdapter
    Private comandosql As SqlCommand = New SqlCommand

    Private Sub conectar()
        'Dim DBConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQL").ConnectionString)        
        conexion = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("desarrollo").ConnectionString)
    End Sub

    Private Sub desconectar()
        conexion.Close()
    End Sub

    Public ReadOnly Property obtenertabla() As DataTable
        Get
            Return tabla
        End Get
    End Property
    Public Function Autentificar(ByVal User As String, ByVal Pass As String) As Boolean
        Dim estado As Boolean = False
        Dim qry As String
        Try
            conectar()
            'Dim conect As New SqlConnection("data source=SrvNomina;Initial Catalog=Eslabon;User ID=intra;Password=intra")

            comandosql = New SqlCommand("sp_ConsultaEmpleado_pUP", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pEmpleado", SqlDbType.Int, 8)
            parametro1.Value = CInt(User)
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pClave", SqlDbType.VarChar, 4)
            parametro2.Value = Pass
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pOpcion", SqlDbType.TinyInt, 1)
            parametro3.Value = 1

            comandosql.CommandTimeout = 9000
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

            If tabla.Rows.Count > 0 Then

                If tabla.Rows(0).Item("NumError") = 0 Then

                    'Session("UserName") = tabla.Rows(0).Item("Nombre_Completo").ToString.ToLower

                    Dim tabla2 As DataTable = New DataTable
                    comandosql = New SqlCommand("Mi_Pagina_Datos_Generales_pUP", conexion)
                    comandosql.CommandType = CommandType.StoredProcedure

                    Dim parametro01 As SqlParameter = comandosql.Parameters.Add("@pEmpleado", SqlDbType.Int, 8)
                    parametro01.Value = CInt(User)
                    comandosql.CommandTimeout = 9000
                    adaptador.SelectCommand = comandosql
                    adaptador.Fill(tabla2)
                    If tabla2.Rows.Count > 0 Then
                        ' -- Gerentes de Tienda
                        If tabla2.Rows(0).Item("jerarquia") >= 90 And tabla2.Rows(0).Item("Sucursal") <= 1000 Then
                            estado = True
                        Else
                            ' -- Menor jerarquía que gerente
                            If tabla2.Rows(0).Item("jerarquia") < 90 Then
                                estado = False
                            Else
                                ' -- Mayor jerarquía que gerentes
                                If tabla2.Rows(0).Item("jerarquia") >= 90 Then

                                    estado = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Autentificar = estado
    End Function

    Public Function Autentificar_OLD(ByVal User As String, ByVal Pass As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sps_Sys_ValidaUsuario", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@strNomUsuario", SqlDbType.VarChar, 20)
            parametro1.Value = User
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@strClave", SqlDbType.VarChar, 20)
            parametro2.Value = Pass

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)
            estado = (tabla.Rows.Count > 0)
            'estado = 1
        Catch ex As SqlException
            estado = False
            estado = False
        Finally
            desconectar()

        End Try
        Autentificar_OLD = estado
    End Function
    Public Function ValidaUsuario(ByVal User As String, ByVal Pass As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sps_Sys_ValidaUsuario", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@strNomUsuario", SqlDbType.VarChar, 20)
            parametro1.Value = User
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@strClave", SqlDbType.VarChar, 20)
            parametro2.Value = Pass

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)


        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function AgregaInventario(ByVal dFecha As Date, ByVal strCliente As String, ByVal strNoParte As String,
                                     ByVal strProducto As String, ByVal iPiezasAlm As Integer, ByVal iPiezasCuar As _
                                     Integer, ByVal iPiezasTot As Integer) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
            parametro2.Value = strCliente
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@NoParte", SqlDbType.VarChar, 20)
            parametro3.Value = strNoParte
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Producto", SqlDbType.VarChar, 50)
            parametro4.Value = strProducto
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@PiezasAlm", SqlDbType.Int, 8)
            parametro5.Value = iPiezasAlm
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@PiezasCuar", SqlDbType.Int, 8)
            parametro6.Value = iPiezasCuar
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@PiezasTot", SqlDbType.Int, 8)
            parametro7.Value = iPiezasTot
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@strUsuario", SqlDbType.VarChar, 20)
            'If Session("UserID") Is Nothing Then
            'parametro8.Value = "generic user"
            'Else
            'parametro8.Value = Session("UserID")
            'End If

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function LimpiaInventarioMes(ByVal dFecha As Date) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Delete", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha

            conexion.Open()
            adaptador.DeleteCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function Add_Puesto(ByVal opc As String,
                                    ByVal puesto As String,
                                    ByVal nivel As Decimal) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp_Puestos", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = opc
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 20)
            parametro2.Value = puesto
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nivel", SqlDbType.Decimal, 5)
            parametro3.Value = nivel

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ConsultaInventarioInicial(ByVal dFecha As Date, ByVal strCliente As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFecha
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
            parametro2.Value = strCliente

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ConsultaTonelaje() As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("sp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function GeneraAnalisis1(ByVal dFechaI As Date, ByVal dFechaF As Date, ByVal Tienda As Integer, ByVal Depto As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("dbo.cumhoGeneraAnalisis1", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime, 15)
            parametro1.Value = dFechaI
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime, 15)
            parametro2.Value = dFechaF
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pTienda", SqlDbType.Int, 8)
            parametro3.Value = Tienda
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@pDepto", SqlDbType.VarChar, 10)
            parametro4.Value = Depto

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function ObtenTiendas(ByVal Tienda As Integer) As Boolean
        Dim estado As Boolean = True
        Dim Qry As String = ""

        Qry = "SELECT Id, Nombre FROM Tienda"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.Text

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function

    Public Function ObtenDeptos(ByVal tienda As Integer) As Boolean
        Dim estado As Boolean = True
        Dim Qry As String
        Qry = "sp_Deptos"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function Get_Puestos() As DataTable
        Dim Qry As String
        Dim data As New DataTable

        Try

            conectar()

            Qry = "sp_Puestos"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
            parametro1.Value = "X"


            adaptador.SelectCommand = comandosql
            adaptador.Fill(data)

        Catch ex As SqlException

        Finally
            desconectar()
        End Try
        Return data

    End Function
    Public Function ObtenDatosArchivo(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True
        Dim qry As String
        'qry = "dbo.CtlInt_PagoNomina_pUP"
        qry = "dbo.sp_pruebas"
        Try
            conectar()
            comandosql = New SqlCommand(qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion <> "HEDS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
    Public Function ObtenDatosPago(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
        Dim estado As Boolean = True

        Try
            conectar()
            comandosql = New SqlCommand("dbo.sp_Pruebas", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
            parametro1.Value = CveOperacion
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
            parametro2.Value = TipoPago
            If CveOperacion = "DETS" Then
                Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
                parametro3.Value = DiaPago
            End If
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tabla)

        Catch ex As SqlException
            estado = False
        Finally
            desconectar()
        End Try
        Return estado
    End Function
End Class

Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Web.UI
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.PersistenceFramework

Namespace Web.Presentation.Controls

    <Serializable()> Public Class GridSettingsPersister

        Private gridInstance As RadGrid

        Public Sub New(ByVal gridInstance As RadGrid)
            MyBase.New()
            Me.gridInstance = gridInstance
        End Sub

        'this method should be called on Render
        Public Function SaveSettings() As String
            Try

                Dim gridSettings() As Object = New Object((5) - 1) {}

                'Save groupBy
                Dim groupByExpressions As GridGroupByExpressionCollection = gridInstance.MasterTableView.GroupByExpressions
                Dim groupExpressions() As Object = New Object((groupByExpressions.Count) - 1) {}
                Dim count As Integer = 0
                For Each expression As GridGroupByExpression In groupByExpressions
                    groupExpressions(count) = CType(expression, IStateManager).SaveViewState
                    count = (count + 1)
                Next
                gridSettings(0) = groupExpressions

                'Save sort expressions
                gridSettings(1) = CType(gridInstance.MasterTableView.SortExpressions, IStateManager).SaveViewState

                'Save columns order
                Dim columnsLength As Integer = (gridInstance.MasterTableView.Columns.Count + gridInstance.MasterTableView.AutoGeneratedColumns.Length)
                Dim columnOrder() As Pair = New Pair(columnsLength - 1) {}

                Dim allColumns As ArrayList = New ArrayList(columnsLength)
                allColumns.AddRange(gridInstance.MasterTableView.Columns)
                allColumns.AddRange(gridInstance.MasterTableView.AutoGeneratedColumns)
                Dim i As Integer = 0
                For Each column As GridColumn In allColumns
                    Dim p As Pair = New Pair
                    p.First = column.OrderIndex
                    p.Second = column.HeaderStyle.Width
                    columnOrder(i) = p
                    i = (i + 1)
                Next
                gridSettings(2) = columnOrder

                'Save filter expression
                gridSettings(3) = CType(gridInstance.MasterTableView.FilterExpression, Object)

                Dim formatter As LosFormatter = New LosFormatter
                Dim writer As StringWriter = New StringWriter
                formatter.Serialize(writer, gridSettings)

                ''page size
                'gridSettings(4) = gridInstance.PageSize

                Return writer.ToString()

            Catch ex As Exception
                Return ""
            End Try
        End Function

        'this method should be called on PageInit
        Public Sub LoadSettings(ByVal settings As String)
            Try
                If settings.Trim() = "" Then Exit Sub
                Dim formatter As LosFormatter = New LosFormatter
                Dim reader As StringReader = New StringReader(settings)
                Dim gridSettings() As Object = CType(formatter.Deserialize(reader), Object())

                'Load groupBy
                Dim groupByExpressions As GridGroupByExpressionCollection = Me.gridInstance.MasterTableView.GroupByExpressions
                groupByExpressions.Clear()
                Dim groupExpressionsState() As Object = CType(gridSettings(0), Object())
                Dim count As Integer = 0
                For Each obj As Object In groupExpressionsState
                    Dim expression As GridGroupByExpression = New GridGroupByExpression
                    CType(expression, IStateManager).LoadViewState(obj)
                    groupByExpressions.Add(expression)
                    count = (count + 1)
                Next

                'Load sort expressions
                Me.gridInstance.MasterTableView.SortExpressions.Clear()
                CType(Me.gridInstance.MasterTableView.SortExpressions, IStateManager).LoadViewState(gridSettings(1))

                'Load columns order
                Dim columnsLength As Integer = (Me.gridInstance.MasterTableView.Columns.Count + Me.gridInstance.MasterTableView.AutoGeneratedColumns.Length)
                Dim columnOrder() As Pair = CType(gridSettings(2), Pair())
                If (columnsLength = columnOrder.Length) Then
                    Dim allColumns As ArrayList = New ArrayList(columnsLength)
                    allColumns.AddRange(Me.gridInstance.MasterTableView.Columns)
                    allColumns.AddRange(Me.gridInstance.MasterTableView.AutoGeneratedColumns)
                    Dim i As Integer = 0
                    For Each column As GridColumn In allColumns
                        column.OrderIndex = CType(columnOrder(i).First, Integer)
                        column.HeaderStyle.Width = CType(columnOrder(i).Second, Unit)
                        i = (i + 1)
                    Next
                End If

                'Load filter expression
                Me.gridInstance.MasterTableView.FilterExpression = CType(gridSettings(3), String)

                'Try
                '    Me.gridInstance.PageSize = CType(gridSettings(4), Integer)
                'Catch ex As Exception
                'End Try
            Catch ex As Exception
            End Try
        End Sub

    End Class

    <Serializable()> Public Class TelerikPersistenceStorageProvider
        Implements IStateStorageProvider

        Private _ConnectionString As String = ""
        Private _UserCode As String = ""
        Private _ControlName As String = ""
        Private _Session As System.Web.SessionState.HttpSessionState = HttpContext.Current.Session
        Private _Cookie As System.Web.HttpCookie

        Private _StorageKey As String = ""

        Public WriteOnly Property StorageProviderKey() As String
            Set(value As String)
                Me._StorageKey = value
            End Set
        End Property

        Public Sub SaveStateToStorage(key As String, serializedState As String) Implements IStateStorageProvider.SaveStateToStorage

            Using MyConn As New SqlConnection(Me._ConnectionString)

                Dim MyCommand As New SqlCommand()
                With MyCommand

                    .CommandType = CommandType.Text
                    .CommandText = String.Format("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '{0}' AND [APPLICATION] = 'TELERIK_PERSIST_FX' AND VARIABLE_NAME = '{1}'; " & _
                                                 "INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_ORDER, VARIABLE_VALUE)" & _
                                                 "VALUES ({0}, 'TELERIK_PERSIST_FX', 0, '{1}', 'SERIAL', NULL, '{2}');", Me._UserCode, Me._ControlName, serializedState)
                    .Connection = MyConn

                End With

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

                Me._Session(Me._StorageKey) = serializedState

                If MyConn.State = ConnectionState.Open Then MyConn.Close()

            End Using

        End Sub

        Public Function LoadStateFromStorage(key As String) As String Implements IStateStorageProvider.LoadStateFromStorage

            Dim SerializedState As String = ""
            If Me._Session(Me._StorageKey) IsNot Nothing Then

                SerializedState = Me._Session(Me._StorageKey).ToString()

            Else

                Using MyConn As New SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = String.Format("SELECT VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE USERID = '{0}' AND [APPLICATION] = 'TELERIK_PERSIST_FX' AND VARIABLE_NAME = '{1}';", _
                                                     Me._UserCode, Me._ControlName)
                        .Connection = MyConn

                    End With

                    MyConn.Open()

                    SerializedState = MyCommand.ExecuteScalar()

                    Me._Session(Me._StorageKey) = SerializedState

                    If MyConn.State = ConnectionState.Open Then MyConn.Close()

                End Using

            End If

            Return SerializedState

        End Function

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal ControlName As String)

            Me._ConnectionString = ConnectionString
            Me._UserCode = UserCode
            Me._ControlName = ControlName
            Me._StorageKey = Me._UserCode & Me._ControlName

        End Sub

    End Class

    ''<Serializable()> _
    ''Public Class GridGrouping

    ''    Private _ConnectionString As String = ""
    ''    Private _UserCode As String = ""
    ''    Private _GridName As String = ""

    ''    Public Property GroupingValue As String = ""

    ''    Public Sub Save()

    ''        Using MyConn As New SqlConnection(Me._ConnectionString)

    ''            Dim MyCommand As New SqlCommand()
    ''            With MyCommand

    ''                .CommandType = CommandType.Text
    ''                .CommandText = "usp_wv_SaveEmployeeWallpaper"
    ''                .Connection = MyConn

    ''            End With

    ''            MyConn.Open()

    ''            MyCommand.ExecuteNonQuery()

    ''        End Using

    ''    End Sub
    ''    Public Sub Load()

    ''    End Sub

    ''    Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal GridName As String)

    ''        Me._ConnectionString = ConnectionString
    ''        Me._UserCode = UserCode
    ''        Me._GridName = GridName

    ''    End Sub

    ''End Class

End Namespace

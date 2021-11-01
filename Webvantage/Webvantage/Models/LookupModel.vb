Namespace Models

    Public Class LookupModel

#Region " Enum "

        Public Enum Types
            Task
            ProjectScheduleStatus
            Client
            Division
            Product
            Job
            JobComponent
            ProjectManager
            Employee
            [Function]
            Phase
            ClientContact
        End Enum

        Public Enum Filters
            IsEqualTo
            IsNotEqualTo
            StartsWith
            Contains
            DoesNotContain
            EndsWith
            IsNull
            IsNotNull
            IsEmpty
            IsNotEmpty
        End Enum

#End Region

#Region " Properties "

        Public Property LookupType As Types
        Public Property DataItems As IList
        Public Property DefaultFilter As String ' kendo filters
        Public Property SearchOptions As Generic.List(Of SearchOption)
        Public Property Columns As Generic.List(Of LookupColumn)

#End Region

#Region " Methods "

        Public Sub New(ByVal LookupType As Types)

            Me.LookupType = LookupType

            Me.Columns = New Generic.List(Of LookupColumn)
            Me.SearchOptions = New Generic.List(Of SearchOption)

            Me.Columns.Add(New LookupColumn("CodeAndDescription", "Description", LookupColumn.Types.Default, ""))

        End Sub
        Public Sub SetDefaultFilter(Filter As Filters)

            Select Case Filter

                Case Filters.IsEqualTo

                    Me.DefaultFilter = "eq"

                Case Filters.IsNotEqualTo

                    Me.DefaultFilter = "neq"

                Case Filters.StartsWith

                    Me.DefaultFilter = "startswith"

                Case Filters.Contains

                    Me.DefaultFilter = "contains"

                Case Filters.DoesNotContain

                    Me.DefaultFilter = "doesnotcontain"

                Case Filters.EndsWith

                    Me.DefaultFilter = "endswith"

                Case Filters.IsNull

                    Me.DefaultFilter = "isnull"

                Case Filters.IsNotNull

                    Me.DefaultFilter = "isnotnull"

                Case Filters.IsEmpty

                    Me.DefaultFilter = "isempty"

                Case Filters.IsNotEmpty

                    Me.DefaultFilter = "isnotempty"

            End Select

        End Sub

#End Region

        Public Class LookupColumn

            Public Enum Types
                [Default]
                Checkbox
                Image
            End Enum

            Public Property Field As String
            Public Property Title As String
            Public Property ColumnType As Webvantage.Models.LookupModel.LookupColumn.Types
            Public Property ColumnTemplate As String

            Public Sub New()


            End Sub
            Public Sub New(ByVal Field As String, ByVal Title As String, ByVal ColumnType As Types, ByVal ColumnTemplate As String)

                Me.Field = Field
                Me.Title = Title
                Me.ColumnType = ColumnType
                Me.ColumnTemplate = ColumnTemplate

            End Sub

        End Class
        Public Class SearchOption

            Public Property PropertyName As String
            Public Property DisplayLabel As String
            Public Property CheckedByDefault As Boolean

            Public Sub New(ByVal PropertyName As String, ByVal DisplayLabel As String, ByVal CheckedByDefault As Boolean)

                Me.PropertyName = PropertyName
                Me.DisplayLabel = DisplayLabel
                Me.CheckedByDefault = CheckedByDefault

            End Sub

        End Class

    End Class

End Namespace
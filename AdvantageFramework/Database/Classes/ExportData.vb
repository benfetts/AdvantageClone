Namespace Database.Classes

    <Serializable()>
    Public Class ExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TableName
            CSVRowData
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property TableName() As String

        Public Property CSVRowData() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TableName

        End Function

#End Region

    End Class

End Namespace

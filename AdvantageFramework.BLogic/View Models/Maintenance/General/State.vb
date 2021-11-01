Namespace ViewModels.Maintenance.General.Location

    <Serializable()>
    Public Class State
#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            StateName
            StateCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Id As Integer = 0
        Public Property StateName As String = Nothing
        Public Property StateCode As String = Nothing
        Public Property Country As String = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region
    End Class



End Namespace

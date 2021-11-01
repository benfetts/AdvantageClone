Namespace ViewModels.Maintenance.General

    <Serializable()>
    Public Class TimezoneSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Timezones As Generic.List(Of TimezoneViewModel)
        Public Property DatabaseServerTimezoneID As String = String.Empty
        Public Property AgencyTimezoneID As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

            Timezones = New List(Of TimezoneViewModel)

            Dim DontChangeItem As New TimezoneViewModel

            DontChangeItem.Id = "-1"
            DontChangeItem.StandardName = "[Don't Change]"

            Timezones.Add(DontChangeItem)

        End Sub

#End Region

    End Class
    <Serializable()>
    Public Class TimezoneViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Id As String = String.Empty
        Public Property StandardName As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace


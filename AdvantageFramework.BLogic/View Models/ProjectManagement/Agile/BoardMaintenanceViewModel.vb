Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class BoardMaintenanceViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property Name As String
        Public Property Description As String
        Public Property CreatedBy As String
        Public Property CreatedDate As DateTime?
        Public Property LastModified As DateTime?
        Public Property IsSystem As Boolean?
        Public Property IsSequential As Boolean?
        Public Property ForceAllColumns As Boolean?
        Public Property SwimLaneID As Integer?
        Public Property AlertTemplateID As Integer?
        Public Property IsActive As Boolean?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace



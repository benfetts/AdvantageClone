Namespace Database.Procedures.ClientPortalAlertEmailRecipientComplexType

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DbContext As Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.ComplexTypes.ClientPortalAlertEmailRecipient)

            'objects
            Dim AlertIDObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            AlertIDObjectParameter = New System.Data.Objects.ObjectParameter("AlertID", AlertID)

            Load = DbContext.Database.SqlQuery(Of Database.ComplexTypes.ClientPortalAlertEmailRecipient)("LoadClientPortalAlertEmailRecipients", AlertIDObjectParameter)

        End Function

#End Region

    End Module

End Namespace

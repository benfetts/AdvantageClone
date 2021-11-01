Namespace Database.Procedures.AlertAttachmentView

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

        Public Function LoadByAlertID(ByVal DbContext As Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AlertAttachmentView)

            LoadByAlertID = From AlertAttachmentView In DbContext.GetQuery(Of Database.Views.AlertAttachmentView)
                            Where AlertAttachmentView.AlertID = AlertID
                            Select AlertAttachmentView

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.AlertAttachmentView)

            Load = From AlertAttachmentView In DbContext.GetQuery(Of Database.Views.AlertAttachmentView)
                   Select AlertAttachmentView

        End Function

#End Region

    End Module

End Namespace

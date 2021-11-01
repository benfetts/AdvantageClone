Namespace Database.Procedures.TaskTemplateDetailView

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

        Public Function LoadByTaskTemplateCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateCode As String) As IQueryable(Of AdvantageFramework.Database.Views.TaskTemplateDetail)

            LoadByTaskTemplateCode = From TaskTemplateDetailView In DataContext.TaskTemplateDetailView
                                     Where TaskTemplateDetailView.TaskTemplateCode = TaskTemplateCode
                                     Select TaskTemplateDetailView

        End Function
        Public Function LoadByTaskTemplateDetailViewID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TaskTemplateDetailID As Long) As AdvantageFramework.Database.Views.TaskTemplateDetail

            Try

                LoadByTaskTemplateDetailViewID = (From TaskTemplateDetailView In DataContext.TaskTemplateDetailView
                                                  Where TaskTemplateDetailView.TaskTemplateDetailID = TaskTemplateDetailID
                                                  Select TaskTemplateDetailView).SingleOrDefault

            Catch ex As Exception
                LoadByTaskTemplateDetailViewID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Views.TaskTemplateDetail)

            Load = From TaskTemplateDetailView In DataContext.TaskTemplateDetailView
                   Select TaskTemplateDetailView

        End Function

#End Region

    End Module

End Namespace


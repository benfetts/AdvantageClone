Namespace Controllers.Desktop

    Public Class DocumentManagerController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Desktop/DocumentManager/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        ' Private _Controller As Object = Nothing 'AdvantageFramework.Controller.ProjectManagement.JobJacketController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

            MyBase.Initialize(requestContext)

            ' _Controller = New Object ' New AdvantageFramework.Controller.ProjectManagement.JobJacketController(Me.SecuritySession)

        End Sub

#Region "API"
        <System.Web.Mvc.HttpGet>
        Public Function GetDocuments() As System.Web.Mvc.JsonResult

            'objects
            Dim Documents As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Documents = (From Item In AdvantageFramework.Database.Procedures.Document.Load(DbContext).Include("DocumentType").ToList
                             Select New With {.FileName = Item.FileName,
                                              .FileDescription = Item.Description,
                                              .Type = If(Item.DocumentType IsNot Nothing, Item.DocumentType.Description, String.Empty),
                                              .Size = Item.FileSize,
                                              .UploadedBy = Item.UserCode,
                                              .Date = Item.UploadedDate,
                                              .Private = If(Item.IsPrivate Is Nothing OrElse Item.IsPrivate = 0, False, True)
                                             }).ToList

            End Using

            Return MaxJson(Documents, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
#End Region

#End Region

    End Class

End Namespace


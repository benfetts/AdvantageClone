Namespace ConceptShare.Classes

    <Serializable()>
    Public Class ConceptShareConnection

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
        Private _APIContext As ConceptShareAPI.APIContext = Nothing
        Private _ConceptShareUser As ConceptShareAPI.User = Nothing
        Private _ConceptShareUserID As Integer = 0
        Private _Loaded As Boolean = False

        Private _EmployeeCode As String = String.Empty
        Private _ClientContactID As Integer = 0

        Private _IsClientPortalUser As Boolean = False
        Private _IsAdminAccount As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property APIServiceClient As ConceptShareAPI.APIServiceClient
            Get
                Return _APIServiceClient
            End Get
        End Property
        Public ReadOnly Property APIContext As ConceptShareAPI.APIContext
            Get
                Return _APIContext
            End Get
        End Property
        Public ReadOnly Property ConceptShareUser As ConceptShareAPI.User
            Get
                Return _ConceptShareUser
            End Get
        End Property
        Public ReadOnly Property Loaded As Boolean
            Get
                Return _Loaded
            End Get
        End Property
        Public ReadOnly Property ConceptShareUserID As Integer
            Get
                Return _ConceptShareUserID
            End Get
        End Property
        Public ReadOnly Property AdvantageEmployeeCodeOrClientPortalUserID As String
            Get
                Return _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property IsClientPortalUser As Boolean
            Get
                Return _IsClientPortalUser
            End Get
        End Property
#End Region

#Region " Methods "

        Sub New(ByRef DataContext As AdvantageFramework.Database.DataContext, ByRef Employee As Database.Views.Employee)

            If DataContext IsNot Nothing AndAlso Employee IsNot Nothing Then

                Me._IsClientPortalUser = False
                Me._EmployeeCode = Employee.Code

                Me._Loaded = AdvantageFramework.ConceptShare.CreateUserConecptShareConnection(DataContext, Employee, Me._APIServiceClient, Me._APIContext, Me._ConceptShareUser)

                If Me._Loaded = True AndAlso Me._ConceptShareUser IsNot Nothing Then

                    Me._ConceptShareUserID = Me._ConceptShareUser.UserId

                End If

            End If

        End Sub
        Sub New(ByRef DataContext As AdvantageFramework.Database.DataContext, ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                ByRef ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser)

            If DataContext IsNot Nothing AndAlso ClientPortalUser IsNot Nothing Then

                Me._IsClientPortalUser = True
                Me._ClientContactID = ClientPortalUser.ClientContactID

                Me._Loaded = AdvantageFramework.ConceptShare.CreateUserConecptShareConnection(DataContext, SecurityDbContext, ClientPortalUser, Me._APIServiceClient, Me._APIContext, Me._ConceptShareUser)

                If Me._Loaded = True AndAlso Me._ConceptShareUser IsNot Nothing Then

                    Me._ConceptShareUserID = Me._ConceptShareUser.UserId

                End If

            End If

        End Sub
        Sub New(ByRef DataContext As AdvantageFramework.Database.DataContext)

            Me._IsAdminAccount = True
            Me._IsClientPortalUser = False

            Me._Loaded = AdvantageFramework.ConceptShare.CreateSystemAccountConecptShareConnection(DataContext, Me._APIServiceClient, Me._APIContext)

        End Sub

#End Region

    End Class

End Namespace

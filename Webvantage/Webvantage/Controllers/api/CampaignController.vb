Imports System.Collections.Generic
Imports System.Net
Imports System.Web.Http

Namespace Controllers.ProjectManagement.Campaign
    Public Class CampaignController
        Inherits ApiController

        ' GET: api/Campaign
        Public Function GetValues() As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)
            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Dim Campaigns As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Campaigns = AdvantageFramework.Database.Procedures.Campaign.LoadAllActiveCampaigns(DbContext)
            End Using

            Return Campaigns
        End Function

        ' GET: api/Campaign/5
        Public Function GetValue(ByVal id As Integer) As AdvantageFramework.Database.Entities.Campaign

            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, id)
            End Using

            Return Campaign
        End Function

        ' POST: api/Campaign
        Public Sub PostValue(<FromBody()> ByVal value As AdvantageFramework.Database.Entities.Campaign)
            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                AdvantageFramework.Database.Procedures.Campaign.Insert(DbContext, value)
            End Using
        End Sub

        ' PUT: api/Campaign/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As AdvantageFramework.Database.Entities.Campaign)
            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, value)
            End Using
        End Sub

        ' DELETE: api/Campaign/5
        Public Sub DeleteValue(ByVal id As Integer)
            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                'WTF - should delete by id.....
                'AdvantageFramework.Database.Procedures.Campaign.Delete(DbContext,)
            End Using
        End Sub
    End Class
End Namespace

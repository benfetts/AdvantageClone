Namespace Controller.Media

    Public Class MediaManagerProcessGeneratePurchaseOrderController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function LoadUserSetting(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, SettingCode As String) As String

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim SettingValue As String = Nothing

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, SettingCode)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                SettingValue = UserSetting.StringValue

            End If

            LoadUserSetting = SettingValue

        End Function
        Private Function LoadUserSettingBoolean(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, SettingCode As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim SettingValue As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, SettingCode)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                SettingValue = If(UserSetting.StringValue = "Y", True, False)

            End If

            LoadUserSettingBoolean = SettingValue

        End Function
        Private Function SaveUserSetting(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, SettingCode As String, StringValue As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, SettingCode)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = StringValue

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, SettingCode, StringValue, Nothing, Nothing, UserSetting)

            End If

            SaveUserSetting = Saved

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(MediaManagerGeneratePurchaseOrders As Generic.List(Of DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder)) As AdvantageFramework.ViewModels.Media.MediaManagerProcessGeneratePurchaseOrderViewModel

            'objects
            Dim MediaManagerProcessGeneratePurchaseOrderViewModel As AdvantageFramework.ViewModels.Media.MediaManagerProcessGeneratePurchaseOrderViewModel = Nothing
            Dim MediaManagerGeneratePurchaseOrderVendorContact As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact = Nothing

            MediaManagerProcessGeneratePurchaseOrderViewModel = New AdvantageFramework.ViewModels.Media.MediaManagerProcessGeneratePurchaseOrderViewModel

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailSubject = LoadUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailSubject.ToString)
                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailBody = LoadUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailBody.ToString)
                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultCCSender = LoadUserSettingBoolean(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderCCSender.ToString)
                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultUploadAndSignDocumentWhenSubmitted = LoadUserSettingBoolean(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderUploadAndSignDocumentWhenSubmitted.ToString)
                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultUploadDocumentManager = LoadUserSettingBoolean(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderUploadDocumentManager.ToString)
                MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailExecutedCopyToVendor = LoadUserSettingBoolean(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailExecutedCopyToVendor.ToString)

                For Each MediaManagerGeneratePurchaseOrder In MediaManagerGeneratePurchaseOrders

                    MediaManagerGeneratePurchaseOrderVendorContact = New AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact(MediaManagerGeneratePurchaseOrder)

                    MediaManagerProcessGeneratePurchaseOrderViewModel.MediaManagerGeneratePurchaseOrderVendorContacts.Add(MediaManagerGeneratePurchaseOrderVendorContact)

                Next

            End Using

            Load = MediaManagerProcessGeneratePurchaseOrderViewModel

        End Function
        Public Sub Save(MediaManagerProcessGeneratePurchaseOrderViewModel As AdvantageFramework.ViewModels.Media.MediaManagerProcessGeneratePurchaseOrderViewModel)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailSubject.ToString, MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailSubject)
                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailBody.ToString, MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailBody)

                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderCCSender.ToString, If(MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultCCSender, "Y", "N"))
                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderUploadDocumentManager.ToString, If(MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultUploadDocumentManager, "Y", "N"))
                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderUploadAndSignDocumentWhenSubmitted.ToString, If(MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultUploadAndSignDocumentWhenSubmitted, "Y", "N"))
                SaveUserSetting(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.PurchaseOrderEmailExecutedCopyToVendor.ToString, If(MediaManagerProcessGeneratePurchaseOrderViewModel.DefaultEmailExecutedCopyToVendor, "Y", "N"))

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace

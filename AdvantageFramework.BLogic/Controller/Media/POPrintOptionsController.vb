Namespace Controller.Media

    Public Class POPrintOptionsController
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



#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Media.POPrintOptionsViewModel

            'objects
            Dim POPrintOptionsViewModel As AdvantageFramework.ViewModels.Media.POPrintOptionsViewModel = Nothing
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

            POPrintOptionsViewModel = New AdvantageFramework.ViewModels.Media.POPrintOptionsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Session.UserCode)

                If PurchaseOrderPrintDefault Is Nothing Then

                    PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
                    PurchaseOrderPrintDefault.UserID = Session.UserCode

                    AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Insert(DbContext, PurchaseOrderPrintDefault)

                End If

                POPrintOptionsViewModel.PurchaseOrderPrintDefaults.Add(New AdvantageFramework.DTO.PurchaseOrderPrintDefault(PurchaseOrderPrintDefault))

            End Using

            Load = POPrintOptionsViewModel

        End Function
        Public Function Save(POPrintOptionsViewModel As AdvantageFramework.ViewModels.Media.POPrintOptionsViewModel) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If POPrintOptionsViewModel.PurchaseOrderPrintDefaults IsNot Nothing AndAlso POPrintOptionsViewModel.PurchaseOrderPrintDefaults.Count = 1 Then

                    PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Session.UserCode)

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        POPrintOptionsViewModel.PurchaseOrderPrintDefaults(0).SaveToEntity(PurchaseOrderPrintDefault)

                        DbContext.Entry(PurchaseOrderPrintDefault).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Saved = True

                    End If

                End If

            End Using

            Save = Saved

        End Function

#End Region

#End Region

    End Class

End Namespace

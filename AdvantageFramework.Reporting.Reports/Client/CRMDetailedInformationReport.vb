Imports System.Drawing.Printing

Namespace Client

    Public Class CRMDetailedInformationReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub DetailReportCompanyProfile_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportCompanyProfile.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                    BindingSourceCompanyProfile.DataSource = CompanyProfile

                End Using

            Catch ex As Exception
                DetailReportCompanyProfile.DataSource = Nothing
            End Try

            If DetailReportCompanyProfile.DataSource Is Nothing OrElse CompanyProfile Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportActivitySummary_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportActivitySummary.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                    BindingSourceActivity.DataSource = Activity

                End Using

            Catch ex As Exception
                DetailReportActivitySummary.DataSource = Nothing
            End Try

            If DetailReportActivitySummary.DataSource Is Nothing OrElse Activity Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportCRMActivities_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportCRMActivities.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim CRMActivitySummaryList As Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CRMActivitySummaryList = New Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary)

                    CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Alert.LoadByTypeIDAndClientAndDivisionAndProductCode(DbContext, 11, ClientCode, DivisionCode, ProductCode).ToList
                                                    Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                    CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(DbContext, "C", ClientCode, DivisionCode, ProductCode).ToList
                                                    Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                    BindingSourceCRMActivitySummary.DataSource = CRMActivitySummaryList.OrderByDescending(Function(Entity) Entity.ActivityDate)

                End Using

            Catch ex As Exception
                DetailReportCRMActivities.DataSource = Nothing
            End Try

            If DetailReportCRMActivities.DataSource Is Nothing OrElse CRMActivitySummaryList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelActivitySummary_LastActivityDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_LastActivityDate.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim CRMActivitySummaryList As Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary) = Nothing
            Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CRMActivitySummaryList = New Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary)

                    CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Alert.LoadByTypeIDAndClientAndDivisionAndProductCode(DbContext, 11, ClientCode, DivisionCode, ProductCode).ToList
                                                    Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                    CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(DbContext, "C", ClientCode, DivisionCode, ProductCode).ToList
                                                    Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                End Using

                Try

                    CRMActivitySummary = CRMActivitySummaryList.OrderByDescending(Function(Entity) Entity.ActivityDate).FirstOrDefault

                    If CRMActivitySummary IsNot Nothing Then

                        LabelActivitySummary_LastActivityDate.Text = CRMActivitySummary.ActivityDate

                    End If

                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LabelActivitySummary_LastContactDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_LastContactDate.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                LabelActivitySummary_LastContactDate.Text = If(IsDate(Activity.LastContactDate), CDate(Activity.LastContactDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelActivitySummary_LeadDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_LeadDate.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                LabelActivitySummary_LeadDate.Text = If(IsDate(Activity.LeadDate), CDate(Activity.LeadDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelActivitySummary_LostDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_LostDate.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                LabelActivitySummary_LostDate.Text = If(IsDate(Activity.LostDate), CDate(Activity.LostDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelActivitySummary_SoldDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_SoldDate.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                LabelActivitySummary_SoldDate.Text = If(IsDate(Activity.SoldDate), CDate(Activity.SoldDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub LabelCRMActivities_ActivityDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelCRMActivities_ActivityDate.BeforePrint

            Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

            CRMActivitySummary = TryCast(Me.DetailReportCRMActivities.GetCurrentRow(), AdvantageFramework.Database.Classes.CRMActivitySummary)

            If CRMActivitySummary IsNot Nothing Then

                LabelCRMActivities_ActivityDate.Text = If(IsDate(CRMActivitySummary.ActivityDate), CDate(CRMActivitySummary.ActivityDate).ToShortDateString, "")

            End If

        End Sub
        Private Sub DetailReportCompanyProfileAffiliations_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportCompanyProfileAffiliations.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim CompanyProfileAffiliationList As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing

            Try

                CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow(), AdvantageFramework.Database.Entities.CompanyProfile)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CompanyProfileAffiliationList = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByCompanyProfileID(DbContext, CompanyProfile.ID).Include("Affiliation").ToList

                    BindingSourceCompanyProfileAffiliation.DataSource = CompanyProfileAffiliationList

                End Using

            Catch ex As Exception
                DetailReportCompanyProfileAffiliations.DataSource = Nothing
            End Try

            If DetailReportCompanyProfileAffiliations.DataSource Is Nothing OrElse CompanyProfileAffiliationList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportActivityCompetitors_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportActivityCompetitors.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim ActivityCompetitionList As Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition) = Nothing

            Try

                Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ActivityCompetitionList = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByActivityID(DbContext, Activity.ID).Include("Competition").ToList

                    BindingSourceActivityCompetition.DataSource = ActivityCompetitionList

                End Using

            Catch ex As Exception
                DetailReportActivityCompetitors.DataSource = Nothing
            End Try

            If DetailReportActivityCompetitors.DataSource Is Nothing OrElse ActivityCompetitionList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelActivitySummary_Source_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_Source.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim Source As AdvantageFramework.Database.Entities.Source = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Source = (From Entity In AdvantageFramework.Database.Procedures.Source.Load(DbContext)
                                  Where Entity.ID = Activity.SourceID
                                  Select Entity).SingleOrDefault

                        If Source IsNot Nothing Then

                            LabelActivitySummary_Source.Text = Source.Description

                        End If

                    Catch ex As Exception
                        LabelActivitySummary_Source.Text = ""
                    End Try

                End Using

            End If

        End Sub
        Private Sub LabelActivitySummary_Rating_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_Rating.BeforePrint

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim Rating As AdvantageFramework.Database.Entities.Rating = Nothing

            Activity = TryCast(Me.DetailReportActivitySummary.GetCurrentRow(), AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Rating = (From Entity In AdvantageFramework.Database.Procedures.Rating.Load(DbContext)
                                  Where Entity.ID = Activity.RatingID
                                  Select Entity).SingleOrDefault

                        If Rating IsNot Nothing Then

                            LabelActivitySummary_Rating.Text = Rating.Description

                        End If

                    Catch ex As Exception
                        LabelActivitySummary_Rating.Text = ""
                    End Try

                End Using

            End If

        End Sub
        Private Sub LabelGeneral_ProductStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_ProductStatus.BeforePrint

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Product = TryCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                LabelGeneral_ProductStatus.Text = If(Product.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

            End If

        End Sub
        Private Sub LabelCompanyProfile_Industry_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelCompanyProfile_Industry.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim Industry As AdvantageFramework.Database.Entities.Industry = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Industry = (From Entity In AdvantageFramework.Database.Procedures.Industry.Load(DbContext)
                                    Where Entity.ID = CompanyProfile.IndustryID
                                    Select Entity).SingleOrDefault

                        If Industry IsNot Nothing Then

                            LabelCompanyProfile_Industry.Text = Industry.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Industry.Text = ""
                    End Try

                End Using

            End If

        End Sub
        Private Sub LabelCompanyProfile_Region_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelCompanyProfile_Region.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim PrintSpecRegion As AdvantageFramework.Database.Entities.PrintSpecRegion = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        PrintSpecRegion = (From Entity In AdvantageFramework.Database.Procedures.PrintSpecRegion.Load(DbContext)
                                           Where Entity.Code = CompanyProfile.RegionCode
                                           Select Entity).SingleOrDefault

                        If PrintSpecRegion IsNot Nothing Then

                            LabelCompanyProfile_Region.Text = PrintSpecRegion.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Region.Text = ""
                    End Try

                End Using

            End If

        End Sub
        Private Sub LabelCompanyProfile_Specialty_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelCompanyProfile_Specialty.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim Specialty As AdvantageFramework.Database.Entities.Specialty = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Specialty = (From Entity In AdvantageFramework.Database.Procedures.Specialty.Load(DbContext)
                                     Where Entity.ID = CompanyProfile.SpecialtyID
                                     Select Entity).SingleOrDefault

                        If Specialty IsNot Nothing Then

                            LabelCompanyProfile_Specialty.Text = Specialty.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Specialty.Text = ""
                    End Try

                End Using

            End If

        End Sub
        Private Sub LabelActivitySummary_TotalOpportunity_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelActivitySummary_TotalOpportunity.BeforePrint

            'objects
            Dim TotalAmount As Decimal = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).DivisionCode
                ProductCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Product).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TotalAmount = (From Entity In AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)
                                   Where Entity.IsInactive = False
                                   Select Entity).Sum(Function(Contract) Contract.FeeIncentiveBonus +
                                                                           Contract.FeeProjectHourly +
                                                                           Contract.FeeRetainer +
                                                                           Contract.FeeRoyalty +
                                                                           Contract.MediaCommission +
                                                                           Contract.ProductionCommission)

                End Using

            Catch ex As Exception
                TotalAmount = 0
            End Try

            LabelActivitySummary_TotalOpportunity.Text = TotalAmount.ToString("N2")

        End Sub

        Private Sub LabelCompanyProfile_Type1_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelCompanyProfile_Type1.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim ClientType1 As AdvantageFramework.Database.Entities.ClientType1 = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientType1 = (From Entity In AdvantageFramework.Database.Procedures.ClientType1.Load(DbContext)
                                       Where Entity.ID = CompanyProfile.ClientType1ID
                                       Select Entity).SingleOrDefault

                        If ClientType1 IsNot Nothing Then

                            LabelCompanyProfile_Type1.Text = ClientType1.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Type1.Text = ""
                    End Try

                End Using

            End If

        End Sub

        Private Sub LabelCompanyProfile_Type2_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelCompanyProfile_Type2.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim ClientType2 As AdvantageFramework.Database.Entities.ClientType2 = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientType2 = (From Entity In AdvantageFramework.Database.Procedures.ClientType2.Load(DbContext)
                                       Where Entity.ID = CompanyProfile.ClientType2ID
                                       Select Entity).SingleOrDefault

                        If ClientType2 IsNot Nothing Then

                            LabelCompanyProfile_Type2.Text = ClientType2.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Type2.Text = ""
                    End Try

                End Using

            End If

        End Sub

        Private Sub LabelCompanyProfile_Type3_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelCompanyProfile_Type3.BeforePrint

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim ClientType3 As AdvantageFramework.Database.Entities.ClientType3 = Nothing

            CompanyProfile = TryCast(Me.DetailReportCompanyProfile.GetCurrentRow, AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ClientType3 = (From Entity In AdvantageFramework.Database.Procedures.ClientType3.Load(DbContext)
                                       Where Entity.ID = CompanyProfile.ClientType3ID
                                       Select Entity).SingleOrDefault

                        If ClientType3 IsNot Nothing Then

                            LabelCompanyProfile_Type3.Text = ClientType3.Description

                        End If

                    Catch ex As Exception
                        LabelCompanyProfile_Type3.Text = ""
                    End Try

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace

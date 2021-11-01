Namespace DTO

	Public Class ComboBoxItem
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property Display() As String
		Public Property Value() As String

#End Region

#Region " Methods "

		Public Sub New()

			Me.Display = String.Empty
			Me.Value = String.Empty

		End Sub
        Public Sub New(Display As String, Value As String)

            Me.Display = Display
            Me.Value = Value

        End Sub
        Public Sub New(Employee As AdvantageFramework.Database.Views.Employee)

            Me.Display = Employee.ToString
            Me.Value = Employee.Code

        End Sub
        Public Sub New(Office As AdvantageFramework.Database.Entities.Office)

            Me.Display = Office.Code & " - " & Office.Name
            Me.Value = Office.Code

        End Sub
        Public Sub New(Client As AdvantageFramework.Database.Entities.Client)

            Me.Display = Client.Code & " - " & Client.Name
            Me.Value = Client.Code

		End Sub
		Public Sub New(Division As AdvantageFramework.Database.Entities.Division)

            Me.Display = Division.Code & " - " & Division.Name
            Me.Value = Division.Code

		End Sub
		Public Sub New(Product As AdvantageFramework.Database.Entities.Product)

            Me.Display = Product.Code & " - " & Product.Name
            Me.Value = Product.Code

		End Sub
		Public Sub New(Product As AdvantageFramework.Database.Views.ProductView)

            Me.Display = Product.ProductCode & " - " & Product.ProductDescription
            Me.Value = Product.ProductCode

		End Sub
		Public Sub New(SalesClass As AdvantageFramework.Database.Entities.SalesClass)

			Me.Display = SalesClass.Description
			Me.Value = SalesClass.Code

		End Sub
		Public Sub New(Campaign As AdvantageFramework.Database.Entities.Campaign)

			Me.Display = Campaign.Name
			Me.Value = Campaign.ID

		End Sub
		Public Sub New(MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

			Me.Display = MediaPlan.Description
			Me.Value = MediaPlan.ID

		End Sub
		Public Sub New(MediaBroadcastWorksheetDateType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetDateType)

			Me.Display = MediaBroadcastWorksheetDateType.Name
			Me.Value = MediaBroadcastWorksheetDateType.ID

		End Sub
		Public Sub New(MediaCalendarType As AdvantageFramework.Database.Entities.MediaCalendarType)

			Me.Display = MediaCalendarType.Name
			Me.Value = MediaCalendarType.ID

		End Sub
		Public Sub New(RecordSource As AdvantageFramework.Database.Entities.RecordSource)

			Me.Display = RecordSource.Name
			Me.Value = RecordSource.ID

		End Sub
        Public Sub New(EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            Me.Display = EnumObject.Description
            Me.Value = EnumObject.Code

        End Sub
        Public Sub New(Month As AdvantageFramework.DateUtilities.Months)

            Me.Display = Month.ToString
            Me.Value = AdvantageFramework.EnumUtilities.GetValue(Month)

        End Sub
        Public Sub New(AbbreviatedMonth As AdvantageFramework.DateUtilities.AbbreviatedMonths)

			Me.Display = AbbreviatedMonth.ToString
			Me.Value = AdvantageFramework.EnumUtilities.GetValue(AbbreviatedMonth)

		End Sub
		Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

			Me.Display = MediaDemographic.Description
			Me.Value = MediaDemographic.ID

		End Sub
        Public Sub New(MediaDemographic As AdvantageFramework.DTO.Media.MediaDemographic)

            Me.Display = MediaDemographic.Description
            Me.Value = MediaDemographic.ID

        End Sub
        Public Sub New(NielsenRadioPeriodSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            Me.Display = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Nielsen.Database.Entities.RadioSource), NielsenRadioPeriodSource)
            Me.Value = AdvantageFramework.EnumUtilities.GetValue(NielsenRadioPeriodSource)

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.Display = Market.Code & " - " & Market.Description
            Me.Value = Market.ComscoreNewMarketNumber.Value

        End Sub
        Public Sub New(Daypart As AdvantageFramework.Database.Entities.Daypart)

            Me.Display = Daypart.Description
            Me.Value = Daypart.Code

        End Sub
        Public Sub New(Daypart As AdvantageFramework.DTO.Daypart)

            Me.Display = Daypart.Description
            Me.Value = Daypart.Code

        End Sub
        Public Sub New(EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle)

            Me.Display = EmployeeTitle.Description
            Me.Value = EmployeeTitle.ID

        End Sub
        Public Sub New(DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam)

            Me.Display = DepartmentTeam.Code & " - " & DepartmentTeam.Description
            Me.Value = DepartmentTeam.Code

        End Sub
        Public Sub New(RevenueResourcePlanStaffType As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffType)

            Me.Display = RevenueResourcePlanStaffType.Name
            Me.Value = RevenueResourcePlanStaffType.ID

        End Sub
        Public Sub New(MediaDemoSource As AdvantageFramework.Database.Entities.MediaDemoSourceID)

            Me.Display = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.MediaDemoSourceID), MediaDemoSource)
            Me.Value = AdvantageFramework.EnumUtilities.GetValue(MediaDemoSource)

        End Sub
        Public Sub New(Country As AdvantageFramework.Database.Entities.Country)

            Me.Display = Country.Name
            Me.Value = Country.ID

        End Sub
        Public Sub New(SmtpAuthenticationMethod As AdvantageFramework.Email.SmtpAuthenticationMethods)

            Me.Display = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Email.SmtpAuthenticationMethods), SmtpAuthenticationMethod)
            Me.Value = AdvantageFramework.EnumUtilities.GetValue(SmtpAuthenticationMethod)

        End Sub
        Public Sub New(OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType)

            Me.Display = OutOfHomeType.Code & " - " & OutOfHomeType.Description
            Me.Value = OutOfHomeType.Code

        End Sub
        Public Sub New(AdSize As AdvantageFramework.Database.Entities.AdSize)

            Me.Display = AdSize.Code & " - " & AdSize.Description
            Me.Value = AdSize.Code

        End Sub
        Public Overrides Function ToString() As String

			ToString = Me.Value & " - " & Me.Display

		End Function

#End Region

	End Class

End Namespace

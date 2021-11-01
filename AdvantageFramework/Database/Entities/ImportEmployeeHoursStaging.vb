Namespace Database.Entities

    <Table("IMP_EMP_HOURS_STAGING")>
    Public Class ImportEmployeeHoursStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            EmployeeCode
            VacationHours
            SickHours
            PersonalHours
            VacationDateFrom
            VacationDateTo
            SickDateFrom
            SickDateTo
            PersonalHoursDateFrom
            PersonalHoursDateTo
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("IMPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Column("BATCH_NAME", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BatchName() As String

        <Required>
        <Column("ON_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOnHold() As Boolean

        <Column("EMP_CODE", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode() As String

        <Column("VAC_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        Public Property VacationHours() As Nullable(Of Decimal)

        <Column("SICK_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        Public Property SickHours() As Nullable(Of Decimal)

        <Column("PERS_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        Public Property PersonalHours() As Nullable(Of Decimal)

        <Column("VAC_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateFrom() As Nullable(Of Date)

        <Column("VAC_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateTo() As Nullable(Of Date)

        <Column("SICK_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateFrom() As Nullable(Of Date)

        <Column("SICK_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateTo() As Nullable(Of Date)

        <Column("PERS_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateFrom() As Nullable(Of Date)

        <Column("PERS_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateTo() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Sub SetRequiredFields()

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateFrom.ToString,
                            AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateTo.ToString

                        SetRequired(PropertyDescriptor, Me.VacationDateFrom.HasValue OrElse Me.VacationDateTo.HasValue)

                    Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateFrom.ToString,
                            AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateTo.ToString

                        SetRequired(PropertyDescriptor, Me.SickDateFrom.HasValue OrElse Me.SickDateTo.HasValue)

                    Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateFrom.ToString,
                            AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateTo.ToString

                        SetRequired(PropertyDescriptor, Me.PersonalHoursDateFrom.HasValue OrElse Me.PersonalHoursDateTo.HasValue)

                End Select

            Next

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateTo.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.PersonalHoursDateFrom.HasValue AndAlso DirectCast(PropertyValue, Date) < Me.PersonalHoursDateFrom.Value Then

                        IsValid = False

                        ErrorText = "Personal hours date to must be later than personal hours date from."

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateFrom.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.PersonalHoursDateTo.HasValue AndAlso DirectCast(PropertyValue, Date) > Me.PersonalHoursDateTo.Value Then

                        IsValid = False

                        ErrorText = "Personal hours date from must be earlier than personal hours date to."

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateTo.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.SickDateFrom.HasValue AndAlso DirectCast(PropertyValue, Date) < Me.SickDateFrom.Value Then

                        IsValid = False

                        ErrorText = "Sick date to must be later than sick date from."

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateFrom.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.SickDateTo.HasValue AndAlso DirectCast(PropertyValue, Date) > Me.SickDateTo.Value Then

                        IsValid = False

                        ErrorText = "Sick date from must be earlier than sick date to."

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateTo.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.VacationDateFrom.HasValue AndAlso DirectCast(PropertyValue, Date) < Me.VacationDateFrom.Value Then

                        IsValid = False

                        ErrorText = "Vacation date to must be later than vacation date from."

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateFrom.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.VacationDateTo.HasValue AndAlso DirectCast(PropertyValue, Date) > Me.VacationDateTo.Value Then

                        IsValid = False

                        ErrorText = "Vacation date from must be earlier than vacation date to."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

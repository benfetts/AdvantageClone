Namespace Database.Classes

    <Serializable()>
    Public Class BroadcastOrderVerification
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            VendorCode
            VendorName
            Vendor
            OrderNumber
            OrderLineNumber
            WeekOf
            RevisionNumber
            SequenceNumber
            StartDate
            EndDate
            StartTime
            EndTime
            Days
            Length
            AdNumber
            NetworkID
            GrossRate
            Spots
            ActualSpots
            MatchedSpots
            VariantCodes
            IsBookend
            IsHiatus
            AllowSpotsToBeEntered
            Daypart
            Program
            EstimatedGRP
            ActualGRP
            RatingIndex
            EstimatedImpressions
            ActualImpressions
            ImpressionIndex
            WorksheetLineNumber
            IsDaily
            CanEdit
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line" & vbCrLf & "Number", IsAutoFillProperty:=True)>
        Public Property OrderLineNumber() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Week Of")>
        Public Property WeekOf() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetworkID() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.DaypartID)>
        Public Property Daypart() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Length() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Days() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Program() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", CustomColumnCaption:="Rate")>
        Public Property GrossRate() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Ordered" & vbCrLf & "Spots")>
        Public Property Spots() As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Actual" & vbCrLf & "Spots")>
        Public Property ActualSpots() As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Variance")>
        Public ReadOnly Property Variance() As Integer
            Get
                Variance = Me.ActualSpots.GetValueOrDefault(0) - Me.Spots.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Matched" & vbCrLf & "Spots")>
        Public Property MatchedSpots() As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VariantCodes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Est GRP")>
        Public Property EstimatedGRP() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Act GRP")>
        Public Property ActualGRP() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", CustomColumnCaption:="GRP Index")>
        Public Property RatingIndex() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1", CustomColumnCaption:="Est GIMP" & vbCrLf & "(000)")>
        Public Property EstimatedImpressions() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1", CustomColumnCaption:="Act GIMP" & vbCrLf & "(000)")>
        Public Property ActualImpressions() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", CustomColumnCaption:="GIMP Index")>
        Public Property ImpressionIndex() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RevisionNumber() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsBookend() As Boolean?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsHiatus() As Boolean?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AllowSpotsToBeEntered() As Boolean?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property WorksheetLineNumber() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsDaily() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CanEdit() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.StartTime.ToString, AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.EndTime.ToString, AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.Days.ToString

                        SetRequired(AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.StartTime.ToString, {"Radio", "TV"}.Contains(Me.MediaType))

                End Select

            Next

        End Sub
        Public Sub SetEntityError(EntityError As String)

            _EntityError = EntityError

        End Sub
        Public Sub SetPropertyError(PropertyName As String, ErrorText As String)

            _ErrorHashtable(PropertyName) = ErrorText

            _EntityError = String.Empty

            For Each PropName In _ErrorHashtable.Keys.OfType(Of String)

                If String.IsNullOrWhiteSpace(_ErrorHashtable(PropName)) = False Then

                    _EntityError = IIf(_EntityError = "", _ErrorHashtable(PropName), _EntityError & Environment.NewLine & _ErrorHashtable(PropName))

                End If

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.StartTime.ToString

                    PropertyValue = Value

                    If IsNumeric(PropertyValue) AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order is required and cannot be zero."

                    End If

                Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.OrderLineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line is required and cannot be zero."

                    End If

                Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.GrossRate.ToString

                    PropertyValue = Value

                    If PropertyValue < 0 Then

                        IsValid = False

                        ErrorText = "Gross Rate is required and must be greter or equal to zero."

                    End If

                Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.Length.ToString

                    PropertyValue = Value

                    If PropertyValue < 0 Then

                        IsValid = False

                        ErrorText = "Length is required and must be greter or equal to zero."

                    End If

                Case AdvantageFramework.Database.Classes.BroadcastOrderVerification.Properties.Spots.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue < 0 Then

                        IsValid = False

                        ErrorText = "Spots cannot be less then zero."

                    ElseIf Me.IsBookend.GetValueOrDefault(False) Then

                        If PropertyValue IsNot Nothing AndAlso PropertyValue Mod 2 <> 0 Then

                            IsValid = False

                            ErrorText = "Number of spots must be even for a bookend."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

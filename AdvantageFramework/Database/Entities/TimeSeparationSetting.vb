Namespace Database.Entities

    <Table("TIME_SEPARATION_SETTING")>
    Public Class TimeSeparationSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            InvoiceMatchingSettingID
            Length
            Separation
            CrossLengthSeparationEnabled
            CrossLengthSeparationValue
            InvoiceMatchingSetting
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("BRDCAST_DTL_VERIFICATION_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property InvoiceMatchingSettingID() As Integer
        <Column("TIME_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Length() As Integer
        <Column("TIME_SEPARATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Separation() As Integer
        <Column("CROSS_LENGTH_SEPARATION_ENABLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CrossLengthSeparationEnabled() As Boolean
        <Column("CROSS_LENGTH_SEPARATION_VALUE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property CrossLengthSeparationValue() As Short

        <ForeignKey("InvoiceMatchingSettingID")>
        Public Overridable Property InvoiceMatchingSetting As ICollection(Of Database.Entities.InvoiceMatchingSetting)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.TimeSeparationSetting.Properties.Length.ToString

                    PropertyValue = Value

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).TimeSeparationSettings
                            Where Entity.InvoiceMatchingSettingID = Me.InvoiceMatchingSettingID AndAlso
                                  Entity.Length = CInt(PropertyValue)
                            Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Please enter a unique length."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("IRS_1099_FEDERAL_STATE_CODE")>
    Public Class IRS1099FederalStateCode
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StateCode
            FederalStateCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("STATE_CODE"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.MaxLength(2),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StateCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("FEDERAL_STATE_CODE"),
        System.ComponentModel.DataAnnotations.Required,
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FederalStateCode() As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.StateCode.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.IRS1099FederalStateCode.Properties.StateCode.ToString

                    If Me.DatabaseAction = Database.Action.Inserting Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).IRS1099FederalStateCodes
                            Where Entity.StateCode = DirectCast(PropertyValue, String)
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "State code exists."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.IRS1099FederalStateCode.Properties.FederalStateCode.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 OrElse PropertyValue > 99 Then

                        IsValid = False

                        ErrorText = "Federal state code must be greater than zero and less than 99."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

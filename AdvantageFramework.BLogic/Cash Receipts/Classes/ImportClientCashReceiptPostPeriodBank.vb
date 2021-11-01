Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ImportClientCashReceiptPostPeriodBank
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BankCode
            PostPeriodCode
        End Enum

#End Region

#Region " Variables "

        Private _BankCode As String = Nothing
        Private _PostPeriodCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.BankCode)>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(value As String)
                _BankCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode, CustomColumnCaption:="Posting Period")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal PostPeriodCode As String)

            _PostPeriodCode = PostPeriodCode

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank.Properties.BankCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select an active bank."

                        End If

                    End If

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank.Properties.PostPeriodCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select an open posting period."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
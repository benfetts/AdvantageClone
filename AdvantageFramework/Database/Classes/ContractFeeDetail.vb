Namespace Database.Classes

    <Serializable()>
    Public Class ContractFeeItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ServiceFeeTypeID
            ServiceFeeDescription
            Hours
            Amount
        End Enum

#End Region

#Region " Variables "

        Private _ServiceFeeDescription As String = Nothing
        Private _ContractFee As AdvantageFramework.Database.Entities.ContractFee = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.ContractFee)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ContractFee As AdvantageFramework.Database.Entities.ContractFee
            Get
                ContractFee = _ContractFee
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Service Fee Type")>
        Public Property ServiceFeeTypeID() As Integer
            Get
                ServiceFeeTypeID = _ContractFee.ServiceFeeTypeID
            End Get
            Set(value As Integer)
                _ContractFee.ServiceFeeTypeID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeDescription() As String
            Get
                ServiceFeeDescription = _ServiceFeeDescription
            End Get
            Set(value As String)
                _ServiceFeeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _ContractFee.Hours
            End Get
            Set(value As Nullable(Of Decimal))
                ContractFee.Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _ContractFee.Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _ContractFee.Amount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ContractFee = New AdvantageFramework.Database.Entities.ContractFee

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractFee As AdvantageFramework.Database.Entities.ContractFee)

            Try

                _ServiceFeeDescription = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeID(DbContext, ContractFee.ServiceFeeTypeID).Description

            Catch ex As Exception
                _ServiceFeeDescription = ""
            End Try

            _ContractFee = ContractFee

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Service fee is required and cannot be zero."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

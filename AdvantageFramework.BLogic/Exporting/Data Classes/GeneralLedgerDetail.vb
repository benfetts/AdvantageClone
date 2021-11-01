Namespace Exporting.DataClasses

    <Serializable()>
    Public Class GeneralLedgerDetail
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TransactionID
            AccountCode
            AccountDescription
            Amount
            Remark
            PostPeriodCode
            PostedToSummary
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            Source
        End Enum

#End Region

#Region " Variables "

        Private _TransactionID As Integer = Nothing
        Private _AccountCode As String = Nothing
        Private _AccountDescription As String = Nothing
        Private _Amount As Double = Nothing
        Private _Remark As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _PostedToSummary As Nullable(Of Date) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _Source As String = Nothing
        
#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property TransactionID() As Integer
            Get
                TransactionID = _TransactionID
            End Get
            Set(value As Integer)
                _TransactionID = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property AccountCode() As String
			Get
				AccountCode = _AccountCode
			End Get
			Set(value As String)
				_AccountCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(75)>
		Public Property AccountDescription() As String
			Get
				AccountDescription = _AccountDescription
			End Get
			Set(value As String)
				_AccountDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n", IsReadOnlyColumn:=True)>
		Public Property Amount() As Double
			Get
				Amount = _Amount
			End Get
			Set(value As Double)
				_Amount = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(150)>
		Public Property Remark() As String
			Get
				Remark = _Remark
			End Get
			Set(value As String)
				_Remark = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property PostPeriodCode() As String
			Get
				PostPeriodCode = _PostPeriodCode
			End Get
			Set(value As String)
				_PostPeriodCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F", IsReadOnlyColumn:=True)>
		Public Property PostedToSummary As Nullable(Of Date)
			Get
				PostedToSummary = _PostedToSummary
			End Get
			Set(value As Nullable(Of Date))
				_PostedToSummary = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property ClientName() As String
			Get
				ClientName = _ClientName
			End Get
			Set(value As String)
				_ClientName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property DivisionName() As String
			Get
				DivisionName = _DivisionName
			End Get
			Set(value As String)
				_DivisionName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property ProductDescription() As String
			Get
				ProductDescription = _ProductDescription
			End Get
			Set(value As String)
				_ProductDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set(value As String)
                _Source = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.TransactionID.ToString

        End Function

#End Region

    End Class

End Namespace

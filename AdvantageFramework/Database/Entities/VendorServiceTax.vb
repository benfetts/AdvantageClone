Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.VENDOR_SERVICE_TAX")>
    Public Class VendorServiceTax
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            Type
            Rate
            Threshold
            GLACode
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _Code As String = Nothing
        Private _Description As String = ""
        Private _Type As Nullable(Of Short) = Nothing
        Private _Rate As Decimal = 0
        Private _Threshold As Decimal = 0
        Private _GLACode As String = ""
        Private _IsInactive As Boolean = False

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR_SERVICE_TAX_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CODE", Storage:="_Code", DbType:="varchar"),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(4),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DESCRIPTION", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(100),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property Description() As String
			Get
				Description = _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TYPE", Storage:="_Type", DbType:="smallint"),
		System.ComponentModel.DisplayName("Type"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Type() As Nullable(Of Short)
			Get
				Type = _Type
			End Get
			Set(ByVal value As Nullable(Of Short))
				_Type = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RATE", Storage:="_Rate", DbType:="decimal"),
		System.ComponentModel.DisplayName("Rate"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n3", UseMaxValue:=True, MaxValue:=99.999)>
		Public Property Rate() As Decimal
			Get
				Rate = _Rate
			End Get
			Set(ByVal value As Decimal)
				_Rate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="THRESHOLD", Storage:="_Threshold", DbType:="decimal"),
		System.ComponentModel.DisplayName("Threshold"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", UseMaxValue:=True, MaxValue:=999999999999.99)>
		Public Property Threshold() As Decimal
			Get
				Threshold = _Threshold
			End Get
			Set(ByVal value As Decimal)
				_Threshold = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GLACODE", Storage:="_GLACode", DbType:="varchar"),
		System.ComponentModel.DisplayName("GLACode"),
		System.ComponentModel.DataAnnotations.MaxLength(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INACTIVE_FLAG", Storage:="_IsInactive", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsInactive"), _
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)> _
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Boolean)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.VendorServiceTax.Properties.Code.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).VendorServiceTaxes
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique code."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).VendorServiceTaxes _
                                    Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                          Entity.ID <> Me.ID
                                    Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique code."

                            End If

                        End If

                    End If
                   
            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

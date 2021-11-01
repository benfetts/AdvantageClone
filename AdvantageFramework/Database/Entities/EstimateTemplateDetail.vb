Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.PRESET_FUNC")>
    Public Class EstimateTemplateDetail
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateTemplateCode
            FunctionCode
            SuppliedBy
            Hours
            NetAmount
            ID
        End Enum

#End Region

#Region " Variables "

        Private _EstimateTemplateCode As String = ""
        Private _FunctionCode As String = ""
        Private _SuppliedBy As String = ""
        Private _Hours As System.Nullable(Of Decimal) = 0
        Private _NetAmount As System.Nullable(Of Decimal) = 0
        Private _ID As Long = 0

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRESET_CODE", Storage:="_EstimateTemplateCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("EstimateTemplateCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property EstimateTemplateCode() As String
			Get
				EstimateTemplateCode = _EstimateTemplateCode
			End Get
			Set(ByVal value As String)
				_EstimateTemplateCode = value
			End Set
		End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_FunctionCode", DbType:="varchar"),
        System.ComponentModel.DisplayName("FunctionCode"),
        System.ComponentModel.DataAnnotations.MaxLength(6),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUPPLIED_BY", Storage:="_SuppliedBy", DbType:="varchar"),
		System.ComponentModel.DisplayName("SuppliedBy"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SuppliedBy() As String
            Get
                SuppliedBy = _SuppliedBy
            End Get
            Set(ByVal value As String)
                _SuppliedBy = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HRS_QTY", Storage:="_Hours", DbType:="decimal"), _
        System.ComponentModel.DisplayName("Hours"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Quantity / Hours")> _
        Public Property Hours() As System.Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NET_AMOUNT", Storage:="_NetAmount", DbType:="decimal"), _
        System.ComponentModel.DisplayName("NetAmount"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", ShowColumnInGrid:=False)> _
        Public Property NetAmount() As System.Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROWID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateTemplateCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.EstimateTemplateCode.ToString

                    If AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(Me.DbContext, Value) Is Nothing Then

                        IsValid = False
                        ErrorText = "Estimate Template does not exist"

                    End If

                Case AdvantageFramework.Database.Entities.EstimateTemplateDetail.Properties.SuppliedBy.ToString

                    If Value IsNot Nothing AndAlso Value <> "" Then

                        [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(Me.DbContext, Me.FunctionCode)

                        If [Function] IsNot Nothing Then

                            If [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.E.ToString Then

                                If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, Value) Is Nothing Then

                                    IsValid = False
                                    ErrorText = "Employee does not exist"

                                End If

                            ElseIf [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.V.ToString Then

                                If AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(Me.DbContext, Value) Is Nothing Then

                                    IsValid = False
                                    ErrorText = "Vendor does not exist"

                                End If

                            Else

                                IsValid = False
                                ErrorText = "An employee or vendor cannot be chosen for Income Only functions"

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

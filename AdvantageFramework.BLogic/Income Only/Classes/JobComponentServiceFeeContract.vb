Namespace IncomeOnly.Classes

    Public Class JobComponentServiceFeeContract
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            FeeDescription
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            IsServiceFeeJob
            ServiceFeeTypeID
            ServiceFeeTypeCode
            ServiceFeeTypeDescription
            SalesClassCode
            SalesClassDescription
            AccountExecutiveCode
            AccountExecutiveName
            FeeStartDate
            FeeEndDate
            Frequency
            NumberOfFees
            FunctionCode
            FunctionDescription
            Quantity
            Rate
            FeeAmount
            MaxAmount
            ClientComments
            ContractNotes
            HasRecords
            LastRecordGenerated
            CreatedDate
            CreatedBy
            ModifiedDate
            ModifiedBy
            MissingRecords
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _FeeDescription As String = ""
        Private _OfficeCode As String = ""
        Private _OfficeName As String = ""
        Private _ClientCode As String = ""
        Private _ClientName As String = ""
        Private _DivisionCode As String = ""
        Private _DivisionName As String = ""
        Private _ProductCode As String = ""
        Private _ProductName As String = ""
        Private _JobNumber As Integer = 0
        Private _JobDescription As String = ""
        Private _JobComponentNumber As Short = 0
        Private _JobComponentDescription As String = ""
        Private _IsServiceFeeJob As System.Nullable(Of Boolean) = Nothing
        Private _ServiceFeeTypeID As System.Nullable(Of Integer) = Nothing
        Private _ServiceFeeTypeCode As String = ""
        Private _ServiceFeeTypeDescription As String = ""
        Private _SalesClassCode As String = ""
        Private _SalesClassDescription As String = ""
        Private _AccountExecutiveCode As String = ""
        Private _AccountExecutiveName As String = ""
        Private _FeeStartDate As System.Nullable(Of DateTime) = Nothing
        Private _FeeEndDate As System.Nullable(Of DateTime) = Nothing
        Private _Frequency As System.Nullable(Of Short) = Nothing
        Private _NumberOfFees As System.Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = ""
        Private _FunctionDescription As String = ""
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As System.Nullable(Of Decimal) = Nothing
        Private _MaxAmount As System.Nullable(Of Decimal) = Nothing
        Private _ClientComments As String = ""
        Private _ContractNotes As String = ""
        Private _HasRecords As System.Nullable(Of Boolean) = Nothing
        Private _LastRecordGenerated As System.Nullable(Of DateTime) = Nothing
        Private _CreatedDate As System.Nullable(Of DateTime) = Nothing
        Private _CreatedBy As String = ""
        Private _ModifiedDate As System.Nullable(Of DateTime) = Nothing
        Private _ModifiedBy As String = ""
        Private _MissingRecords As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.JobServiceFee)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(ByVal value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FeeDescription() As String
            Get
                FeeDescription = _FeeDescription
            End Get
            Set(ByVal value As String)
                _FeeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Job Comp", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Comp Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Is S/F Job")>
        Public Property IsServiceFeeJob() As System.Nullable(Of Boolean)
            Get
                IsServiceFeeJob = _IsServiceFeeJob
            End Get
            Set(ByVal value As System.Nullable(Of Boolean))
                _IsServiceFeeJob = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="S/F Type")>
        Public Property ServiceFeeTypeID() As System.Nullable(Of Integer)
            Get
                ServiceFeeTypeID = _ServiceFeeTypeID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _ServiceFeeTypeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ServiceFeeTypeCode, CustomColumnCaption:="S/F Type")>
        Public Property ServiceFeeTypeCode() As String
            Get
                ServiceFeeTypeCode = _ServiceFeeTypeCode
            End Get
            Set(ByVal value As String)
                _ServiceFeeTypeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="S/F Type Description")>
        Public Property ServiceFeeTypeDescription() As String
            Get
                ServiceFeeTypeDescription = _ServiceFeeTypeDescription
            End Get
            Set(ByVal value As String)
                _ServiceFeeTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="Sales Class")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="Sales Class Description")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="A/E Code")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="A/E Name")>
        Public Property AccountExecutiveName() As String
            Get
                AccountExecutiveName = _AccountExecutiveName
            End Get
            Set(ByVal value As String)
                _AccountExecutiveName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Contract Start")>
        Public Property FeeStartDate() As System.Nullable(Of DateTime)
            Get
                FeeStartDate = _FeeStartDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _FeeStartDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Contract End")>
        Public Property FeeEndDate() As System.Nullable(Of DateTime)
            Get
                FeeEndDate = _FeeEndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _FeeEndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property Frequency() As System.Nullable(Of Short)
            Get
                Frequency = _Frequency
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _Frequency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="# of Fees")>
        Public Property NumberOfFees() As System.Nullable(Of Integer)
            Get
                NumberOfFees = _NumberOfFees
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _NumberOfFees = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", ShowColumnInGrid:=True)>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4", ShowColumnInGrid:=True)>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", ShowColumnInGrid:=True)>
        Public Property FeeAmount() As System.Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property MaxAmount() As System.Nullable(Of Decimal)
            Get
                MaxAmount = _MaxAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _MaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property ClientComments() As String
            Get
                ClientComments = _ClientComments
            End Get
            Set(ByVal value As String)
                _ClientComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property ContractNotes() As String
            Get
                ContractNotes = _ContractNotes
            End Get
            Set(ByVal value As String)
                _ContractNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasRecords() As Nullable(Of Boolean)
            Get
                HasRecords = _HasRecords
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _HasRecords = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property LastRecordGenerated() As Nullable(Of DateTime)
            Get
                LastRecordGenerated = _LastRecordGenerated
            End Get
            Set(value As Nullable(Of DateTime))
                _LastRecordGenerated = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property CreatedDate() As System.Nullable(Of DateTime)
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _CreatedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property CreatedBy() As String
            Get
                CreatedBy = _CreatedBy
            End Get
            Set(ByVal value As String)
                _CreatedBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ModifiedDate() As System.Nullable(Of DateTime)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _ModifiedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
            Set(ByVal value As String)
                _ModifiedBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property MissingRecords() As Nullable(Of Integer)
            Get
                MissingRecords = _MissingRecords
            End Get
            Set(value As Nullable(Of Integer))
                _MissingRecords = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ServiceFeeContractComplex As AdvantageFramework.Database.Classes.ServiceFeeContractComplex)

            _ID = ServiceFeeContractComplex.ID
            _FeeDescription = ServiceFeeContractComplex.FeeDescription
            _OfficeCode = ServiceFeeContractComplex.OfficeCode
            _OfficeName = ServiceFeeContractComplex.OfficeName
            _ClientCode = ServiceFeeContractComplex.ClientCode
            _ClientName = ServiceFeeContractComplex.ClientName
            _DivisionCode = ServiceFeeContractComplex.DivisionCode
            _DivisionName = ServiceFeeContractComplex.DivisionName
            _ProductCode = ServiceFeeContractComplex.ProductCode
            _ProductName = ServiceFeeContractComplex.ProductName
            _JobNumber = ServiceFeeContractComplex.JobNumber
            _JobDescription = ServiceFeeContractComplex.JobDescription
            _JobComponentNumber = ServiceFeeContractComplex.JobComponentNumber
            _JobComponentDescription = ServiceFeeContractComplex.JobComponentDescription
            _IsServiceFeeJob = ServiceFeeContractComplex.IsServiceFeeJob
            _ServiceFeeTypeID = ServiceFeeContractComplex.ServiceFeeTypeID
            _ServiceFeeTypeCode = ServiceFeeContractComplex.ServiceFeeTypeCode
            _ServiceFeeTypeDescription = ServiceFeeContractComplex.ServiceFeeTypeDescription
            _SalesClassCode = ServiceFeeContractComplex.SalesClassCode
            _SalesClassDescription = ServiceFeeContractComplex.SalesClassDescription
            _AccountExecutiveCode = ServiceFeeContractComplex.AccountExecutiveCode
            _AccountExecutiveName = ServiceFeeContractComplex.AccountExecutiveName
            _FeeStartDate = ServiceFeeContractComplex.FeeStartDate
            _FeeEndDate = ServiceFeeContractComplex.FeeEndDate
            _Frequency = ServiceFeeContractComplex.Frequency
            _NumberOfFees = ServiceFeeContractComplex.NumberOfFees
            _FunctionCode = ServiceFeeContractComplex.FunctionCode
            _FunctionDescription = ServiceFeeContractComplex.FunctionDescription
            _Quantity = ServiceFeeContractComplex.Quantity
            _Rate = ServiceFeeContractComplex.Rate
            _FeeAmount = ServiceFeeContractComplex.FeeAmount
            _MaxAmount = ServiceFeeContractComplex.MaxAmount
            _ClientComments = ServiceFeeContractComplex.ClientComments
            _ContractNotes = ServiceFeeContractComplex.ContractNotes
            _HasRecords = ServiceFeeContractComplex.HasRecords
            _LastRecordGenerated = ServiceFeeContractComplex.LastRecordGenerated
            _CreatedDate = ServiceFeeContractComplex.CreatedDate
            _CreatedBy = ServiceFeeContractComplex.CreatedBy
            _ModifiedDate = ServiceFeeContractComplex.ModifiedDate
            _ModifiedBy = ServiceFeeContractComplex.ModifiedBy
            _MissingRecords = ServiceFeeContractComplex.MissingRecords

        End Sub
        Public Function GetJobServiceFeeEntity() As AdvantageFramework.Database.Entities.JobServiceFee

            'objects
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing

            Try

                JobServiceFee = New AdvantageFramework.Database.Entities.JobServiceFee

                JobServiceFee.ID = Me.ID
                JobServiceFee.JobNumber = Me.JobNumber
                JobServiceFee.JobComponentNumber = Me.JobComponentNumber
                'JobServiceFee.FeeSetupDate = Me.fees
                JobServiceFee.Description = Me.FeeDescription
                JobServiceFee.FeeStartDate = Me.FeeStartDate
                JobServiceFee.FeeEndDate = Me.FeeEndDate
                JobServiceFee.Frequency = Me.Frequency
                JobServiceFee.NumberOfFees = Me.NumberOfFees
                JobServiceFee.FeeType = 0
                JobServiceFee.Media = 0
                JobServiceFee.Production = 0
                JobServiceFee.EmployeeTime = 0
                JobServiceFee.FunctionCode = Me.FunctionCode
                JobServiceFee.Quantity = Me.Quantity
                JobServiceFee.Rate = Me.Rate
                JobServiceFee.FeeAmount = Me.FeeAmount
                JobServiceFee.MaxAmount = Me.MaxAmount
                JobServiceFee.ContractInfo = Me.ContractNotes
                JobServiceFee.ClientComment = Me.ClientComments
                JobServiceFee.CreateDate = Me.CreatedDate
                JobServiceFee.CreatedBy = Me.CreatedBy
                JobServiceFee.ModifiedBy = Me.ModifiedBy
                JobServiceFee.ModifiedDate = Me.ModifiedDate

            Catch ex As Exception
                JobServiceFee = Nothing
            Finally
                GetJobServiceFeeEntity = JobServiceFee
            End Try

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeEndDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.FeeStartDate.HasValue Then

                            If Me.FeeStartDate > CDate(PropertyValue) Then

                                IsValid = False

                                ErrorText = "Fee End Date must be after the Fee Start Date."

                            End If

                        End If

                    End If

                Case AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract.Properties.FeeStartDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.FeeEndDate.HasValue Then

                            If CDate(PropertyValue) > Me.FeeEndDate Then

                                IsValid = False

                                ErrorText = "Fee Start Date must be before the Fee End Date."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

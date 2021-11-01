Namespace Database.Classes

    <Serializable()>
    Public Class ImportAccountPayableJob
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportAccountPayableID
            PONumber
            POLine
            JobNumber
            JobComponentNumber
            FunctionCode
            JobQuantity
            JobNetAmount
            JobVendorTax
            JobComment
            JobOfficeCode
            JobClientCode
            ClientName
            JobDivisionCode
            DivisionName
            JobProductCode
            ProductName
            PreviouslyPostedNetAmount
            PONetAmount
            PONetVariance
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
        Private _ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableJob.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableID() As Integer
            Get
                ImportAccountPayableID = _ImportAccountPayableJob.ImportAccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PONumber() As Nullable(Of Integer)
            Get
                PONumber = _ImportAccountPayableJob.PONumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property POLine() As Nullable(Of Integer)
            Get
                POLine = _ImportAccountPayableJob.POLine
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.POLine = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _ImportAccountPayableJob.JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportAccountPayableJob.JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _ImportAccountPayableJob.JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ImportAccountPayableJob.JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _ImportAccountPayableJob.FunctionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobQuantity() As Nullable(Of Decimal)
            Get
                JobQuantity = _ImportAccountPayableJob.JobQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property JobNetAmount() As Nullable(Of Decimal)
            Get
                JobNetAmount = _ImportAccountPayableJob.JobNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property JobVendorTax() As Nullable(Of Decimal)
            Get
                JobVendorTax = _ImportAccountPayableJob.JobVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.JobVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComment() As String
            Get
                JobComment = _ImportAccountPayableJob.JobComment
            End Get
            Set(value As String)
                _ImportAccountPayableJob.JobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOfficeCode() As String
            Get
                JobOfficeCode = _ImportAccountPayableJob.OfficeCodeDetail
            End Get
            Set(value As String)
                _ImportAccountPayableJob.OfficeCodeDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, CustomColumnCaption:="Client Code")>
        Public Property JobClientCode() As String
            Get
                JobClientCode = _ImportAccountPayableJob.ClientCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ImportAccountPayableJob.ClientName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, CustomColumnCaption:="Division Code")>
        Public Property JobDivisionCode() As String
            Get
                JobDivisionCode = _ImportAccountPayableJob.DivisionCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _ImportAccountPayableJob.DivisionName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, CustomColumnCaption:="Product Code")>
        Public Property JobProductCode() As String
            Get
                JobProductCode = _ImportAccountPayableJob.ProductCode
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name", IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ImportAccountPayableJob.ProductName
            End Get
            Set(value As String)
                _ImportAccountPayableJob.ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PreviouslyPostedNetAmount() As Nullable(Of Decimal)
            Get
                PreviouslyPostedNetAmount = _ImportAccountPayableJob.PreviouslyPostedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PreviouslyPostedNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property PONetAmount() As Nullable(Of Decimal)
            Get
                PONetAmount = _ImportAccountPayableJob.PONetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableJob.PONetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public ReadOnly Property PONetVariance() As Nullable(Of Decimal)
            Get
                If _ImportAccountPayableJob.ID <> 0 Then
                    PONetVariance = PONetAmount.GetValueOrDefault(0) - (JobNetAmount.GetValueOrDefault(0) + JobVendorTax.GetValueOrDefault(0) + PreviouslyPostedNetAmount.GetValueOrDefault(0))
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _ImportAccountPayableHeader.OfficeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableJob = New AdvantageFramework.Database.Entities.ImportAccountPayableJob
            _ImportAccountPayableHeader = New AdvantageFramework.Database.Classes.ImportAccountPayableHeader

        End Sub
        Public Sub New(ByVal ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob, _
                       ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader)

            _ImportAccountPayableJob = ImportAccountPayableJob

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayableJob.ID

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportAccountPayableJob

            GetEntity = _ImportAccountPayableJob

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().SingleOrDefault(Function(PD) PD.Name = AdvantageFramework.Database.Classes.ImportAccountPayableJob.Properties.POLine.ToString)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If PropertyDescriptor IsNot Nothing Then

                If Me.PONumber IsNot Nothing Then

                    SetRequired(PropertyDescriptor, True)

                End If

            End If

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

                Case AdvantageFramework.Database.Classes.ImportAccountPayableJob.Properties.JobOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace


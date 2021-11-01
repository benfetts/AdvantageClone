Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeTimeTemplate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobCompNumber
            JobCompDescription
            FunctionCode
            FunctionDescription
            Comment
            DepartmentTeamCode
            DepartmentTeamDescription
            ProductCategoryCode
            ProductCategoryDescription
            EmployeeHours
            ApplyToDays
            IsClosed
            ClientKey
            ClientDivisionKey
            ClientDivisionProductKey
            ClientJobKey
            ClientDivisionJobKey
            ClientDivisionProductJobKey
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EmployeeCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobCompNumber As Nullable(Of Short) = Nothing
        Private _JobCompDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Comment As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _ProductCategoryDescription As String = Nothing
        Private _EmployeeHours As Nullable(Of Decimal) = Nothing
        Private _ApplyToDays As String = Nothing
        Private _IsClosed As Integer = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsRequired:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientName)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DivisionName)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.ProductName)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobDescription)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobCompNumber() As Nullable(Of Short)
            Get
                JobCompNumber = _JobCompNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobCompNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.JobComponentDescription)>
        Public Property JobCompDescription() As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(value As String)
                _JobCompDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamDescription() As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property ProductCategoryCode() As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(value As String)
                _ProductCategoryCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property ProductCategoryDescription() As String
            Get
                ProductCategoryDescription = _ProductCategoryDescription
            End Get
            Set(value As String)
                _ProductCategoryDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property EmployeeHours() As Nullable(Of Decimal)
            Get
                EmployeeHours = _EmployeeHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ApplyToDays() As String
            Get
                ApplyToDays = _ApplyToDays
            End Get
            Set(value As String)
                _ApplyToDays = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsClosed() As Integer
            Get
                IsClosed = _IsClosed
            End Get
            Set(value As Integer)
                _IsClosed = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EmployeeTimeTemplateComplex As AdvantageFramework.Database.Classes.EmployeeTimeTemplateComplex)

            _ID = EmployeeTimeTemplateComplex.ID
            _EmployeeCode = EmployeeTimeTemplateComplex.EmployeeCode
            _ClientCode = EmployeeTimeTemplateComplex.ClientCode
            _ClientName = EmployeeTimeTemplateComplex.ClientName
            _DivisionCode = EmployeeTimeTemplateComplex.DivisionCode
            _DivisionName = EmployeeTimeTemplateComplex.DivisionName
            _ProductCode = EmployeeTimeTemplateComplex.ProductCode
            _ProductDescription = EmployeeTimeTemplateComplex.ProductDescription
            _JobNumber = EmployeeTimeTemplateComplex.JobNumber
            _JobDescription = EmployeeTimeTemplateComplex.JobDescription
            _JobCompNumber = EmployeeTimeTemplateComplex.JobCompNumber
            _JobCompDescription = EmployeeTimeTemplateComplex.JobCompDescription
            _FunctionCode = EmployeeTimeTemplateComplex.FunctionCode
            _FunctionDescription = EmployeeTimeTemplateComplex.FunctionDescription
            _Comment = EmployeeTimeTemplateComplex.Comment
            _DepartmentTeamCode = EmployeeTimeTemplateComplex.DepartmentTeamCode
            _DepartmentTeamDescription = EmployeeTimeTemplateComplex.DepartmentTeamDescription
            _ProductCategoryCode = EmployeeTimeTemplateComplex.ProductCategoryCode
            _ProductCategoryDescription = EmployeeTimeTemplateComplex.ProductCategoryDescription
            _EmployeeHours = EmployeeTimeTemplateComplex.EmployeeHours
            _ApplyToDays = EmployeeTimeTemplateComplex.ApplyToDays
            _IsClosed = EmployeeTimeTemplateComplex.IsClosed

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.JobNumber.ToString,
                     AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.JobCompNumber.ToString,
                     AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ClientCode.ToString,
                     AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.DivisionCode.ToString,
                     AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCode.ToString

                    SetRequired(PropertyName, Not Me.IsIndirectTime)

                Case AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.FunctionCode.ToString

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If EntityAttribute IsNot Nothing Then

                            If Me.IsIndirectTime = True Then

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.IndirectCategory

                            Else

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.FunctionCode

                            End If

                        End If

                    End If

            End Select

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Private Function IsIndirectTime() As Boolean

            'objects
            Dim IsIndirect As Boolean = False

            If Me.JobNumber.HasValue = False AndAlso _
               Me.JobCompNumber.HasValue = False AndAlso _
               String.IsNullOrEmpty(Me.ClientCode) AndAlso _
               String.IsNullOrEmpty(Me.DivisionCode) AndAlso _
               String.IsNullOrEmpty(Me.ProductCode) Then

                IsIndirect = True

            End If

            IsIndirectTime = IsIndirect

        End Function

#End Region


    End Class

End Namespace



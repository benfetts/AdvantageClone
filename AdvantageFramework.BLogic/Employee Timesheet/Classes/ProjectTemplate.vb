Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class ProjectTemplate
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
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
            TaskDescription
            FunctionCode
            DepartmentTeamCode
            ProductCategoryCode
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobCompNumber As Short = Nothing
        Private _JobCompDescription As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _ProductCategoryCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
         AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property JobCompNumber() As Short
            Get
                JobCompNumber = _JobCompNumber
            End Get
            Set(value As Short)
                _JobCompNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property JobCompDescription() As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(value As String)
                _JobCompDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Task", IsReadOnlyColumn:=True)>
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode, IsRequired:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode, IsRequired:=True)>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="", PropertyType:=BaseClasses.PropertyTypes.ProductCategory)>
        Public Property ProductCategoryCode() As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(value As String)
                _ProductCategoryCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim HoursColumn As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString

                    SetRequired(PropertyName, ProductCategoryRequired())

            End Select

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function

        Protected Function ProductCategoryRequired() As Boolean

            'objects
            Dim IsRequired As Boolean = False
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Try

                If _DbContext IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.Load(_DbContext).EnableProductCategory.GetValueOrDefault(0) = 1 Then

                        If String.IsNullOrEmpty(Me.ClientCode) = False Then

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(_DbContext, Me.ClientCode)

                            If Client IsNot Nothing Then

                                IsRequired = CBool(Client.ProductCategoryInTimesheetRequired.GetValueOrDefault(0))

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                IsRequired = False
            Finally
                ProductCategoryRequired = IsRequired
            End Try

        End Function

#End Region

    End Class

End Namespace


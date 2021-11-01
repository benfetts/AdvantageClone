Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class CommentViewHeader
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Enum "

        Public Enum Properties
            ClientCode
            DivisionCode
            ProductCode
            ProductCategoryCode
            JobNumber
            JobComponentNumber
            FunctionCode
            DepartmentTeamCode
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCategory)>
        Public Property ProductCategoryCode As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(value As String)
                _ProductCategoryCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.JobComponent)>
        Public Property JobComponentNumber As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property IsIndirectTime() As Boolean
            Get

                'objects
                Dim IsIndirect As Boolean = True

                Try

                    If String.IsNullOrEmpty(Me.ClientCode) = False OrElse _
                       String.IsNullOrEmpty(Me.DivisionCode) = False OrElse _
                       String.IsNullOrEmpty(Me.ProductCode) = False OrElse _
                       Me.JobNumber.HasValue OrElse _
                       Me.JobNumber.HasValue Then

                        IsIndirect = False

                    End If

                Catch ex As Exception
                    IsIndirect = False
                Finally
                    IsIndirectTime = IsIndirect
                End Try

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Select Case PropertyName

                Case AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ClientCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.DivisionCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.ProductCode.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobNumber.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.JobComponentNumber.ToString

                    SetRequired(PropertyName, Not Me.IsIndirectTime)

                Case AdvantageFramework.EmployeeTimesheet.Classes.CommentViewHeader.Properties.FunctionCode.ToString

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

#End Region

    End Class

End Namespace

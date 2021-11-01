Namespace AvaTax.Classes

    <Serializable> _
    Public Class AvalaraProductMapping
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SalesClassCode
            SalesClassDescription
            FunctionCode
            FunctionDescription
            AvalaraTaxID
            AvalaraTaxDescription
        End Enum
        
#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _SalesClassCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _AvalaraTaxID As Nullable(Of Integer) = Nothing
        Private _AvalaraTaxDescription As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _SalesClassDescription As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.SalesClassCode, CustomColumnCaption:="Client Sales Class")>
        Public Property SalesClassCode As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property SalesClassDescription As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
       AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.FunctionDescription, IsReadOnlyColumn:=True)>
        Public Property FunctionDescription As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.AvalaraTaxID, CustomColumnCaption:="Avalara Tax Code")>
        Public Property AvalaraTaxID As Nullable(Of Integer)
            Get
                AvalaraTaxID = _AvalaraTaxID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AvalaraTaxID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property AvalaraTaxDescription As String
            Get
                AvalaraTaxDescription = _AvalaraTaxDescription
            End Get
            Set(ByVal value As String)
                _AvalaraTaxDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.FunctionCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.DataContext Is Nothing Then

                            Me.DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                        End If

                        If Me.ID = 0 Then

                            If Me.SalesClassCode IsNot Nothing Then

                                If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraProductMappings.ToList
                                    Where Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                          Entity.SalesClassCode = Me.SalesClassCode
                                    Select Entity).Any Then

                                    IsValid = False

                                    ErrorText = "Please enter a unique sales class code/function code."

                                End If

                            Else

                                If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraProductMappings.ToList
                                    Where Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                          Entity.SalesClassCode Is Nothing
                                    Select Entity).Any Then

                                    IsValid = False

                                    ErrorText = "Please enter a unique function code."

                                End If

                            End If
                            
                        Else

                            If Me.SalesClassCode IsNot Nothing Then

                                If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraProductMappings.ToList
                                    Where Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                          Entity.SalesClassCode = Me.SalesClassCode AndAlso
                                          Entity.ID <> Me.ID
                                    Select Entity).Any Then

                                    IsValid = False

                                    ErrorText = "Please enter a unique sales class code/function code."

                                End If

                            Else

                                If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).AvalaraProductMappings.ToList
                                    Where Entity.FunctionCode = DirectCast(PropertyValue, String) AndAlso
                                          Entity.SalesClassCode Is Nothing AndAlso
                                          Entity.ID <> Me.ID
                                    Select Entity).Any Then

                                    IsValid = False

                                    ErrorText = "Please enter a unique function code."

                                End If

                            End If
                           
                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
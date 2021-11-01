Namespace Database.Classes

    <Serializable()>
    Public Class GLATrailer
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAllocationID
            GLAltCode
            GLADescription
            CDPRequired
            GLAltValue
            GLAltAllocation
            GLAltAmount
            ClientCode
            DivisionCode
            ProductCode
            ID
        End Enum

#End Region

#Region " Variables "

        Private _GLAllocationID As Integer = Nothing
        Private _GLAltCode As String = Nothing
        Private _GLADescription As String = Nothing
        Private _CDPRequired As Nullable(Of Short) = Nothing
        Private _GLAltValue As Nullable(Of Double) = Nothing
        Private _GLAltAllocation As Nullable(Of Double) = Nothing
        Private _GLAltAmount As Nullable(Of Double) = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ID As Integer = Nothing

#End Region

#Region " Properties "

        Public Overrides ReadOnly Property AttachedEntityType As Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Entities.GLATrailer)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLAllocationID() As Integer
            Get
                GLAllocationID = _GLAllocationID
            End Get
            Set(value As Integer)
                _GLAllocationID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLAltCode() As String
            Get
                GLAltCode = _GLAltCode
            End Get
            Set(value As String)
                _GLAltCode = value
                Me.GLADescription = _GLAltCode
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description", DefaultColumnType:=BaseClasses.DefaultColumnTypes.GeneralLedgerAccountDescription)>
        Public Property GLADescription() As String
            Get
                GLADescription = _GLADescription
            End Get
            Set(value As String)
                _GLADescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="C/D/P Required", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property CDPRequired() As Nullable(Of Short)
            Get
                CDPRequired = _CDPRequired
            End Get
            Set(value As Nullable(Of Short))
                _CDPRequired = value
                SetRequiredFields()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f5", CustomColumnCaption:="Percent")>
        Public Property GLAltValue() As Nullable(Of Double)
            Get
                GLAltValue = _GLAltValue
            End Get
            Set(value As Nullable(Of Double))
                _GLAltValue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f5", CustomColumnCaption:="")>
        Public Property GLAltAllocation() As Nullable(Of Double)
            Get
                GLAltAllocation = _GLAltAllocation
            End Get
            Set(value As Nullable(Of Double))
                _GLAltAllocation = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GLAltAmount() As Nullable(Of Double)
            Get
                GLAltAmount = _GLAltAmount
            End Get
            Set(value As Nullable(Of Double))
                _GLAltAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub LoadEntity(ByVal GLATrailer As AdvantageFramework.Database.Entities.GLATrailer)

            Try

                GLATrailer.GLAllocationID = _GLAllocationID
                GLATrailer.GLAltCode = _GLAltCode
                GLATrailer.GLAltValue = _GLAltValue
                GLATrailer.GLAltAllocation = _GLAltAllocation
                GLATrailer.GLAltAmount = _GLAltAmount
                GLATrailer.ClientCode = _ClientCode
                GLATrailer.DivisionCode = _DivisionCode
                GLATrailer.ProductCode = _ProductCode
                GLATrailer.ID = _ID

            Catch ex As Exception

            End Try

        End Sub
        Public Overrides Sub SetRequiredFields()

            SetRequired(AdvantageFramework.Database.Classes.GLATrailer.Properties.ClientCode.ToString, CBool(_CDPRequired.GetValueOrDefault(0)))
            SetRequired(AdvantageFramework.Database.Classes.GLATrailer.Properties.DivisionCode.ToString, CBool(_CDPRequired.GetValueOrDefault(0)))
            SetRequired(AdvantageFramework.Database.Classes.GLATrailer.Properties.ProductCode.ToString, CBool(_CDPRequired.GetValueOrDefault(0)))

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyValue As Object = Nothing
            Dim ErrorText As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.GLATrailer.Properties.GLAltCode.ToString

                    PropertyValue = Value

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).GLATrailers _
                        Where Entity.GLAltCode = DirectCast(PropertyValue, String) AndAlso _
                              Entity.GLAllocationID = _GLAllocationID AndAlso _
                              Entity.ID <> _ID
                        Select Entity.GLAllocationID).Any Then

                        IsValid = False
                        ErrorText = "Please enter a unique account code."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
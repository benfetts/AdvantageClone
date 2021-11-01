Namespace AccountPayable.Classes

    <Serializable()>
    Public Class IRS1099FederalStateCode
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StateCode
            StateName
            FederalStateCode
        End Enum

#End Region

#Region " Variables "

        Private _IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode = Nothing
        Private _StateName As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode
            Get
                IRS1099FederalStateCode = _IRS1099FederalStateCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.StateCode)>
        Public Property StateCode As String
            Get
                StateCode = _IRS1099FederalStateCode.StateCode
            End Get
            Set(value As String)
                _IRS1099FederalStateCode.StateCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.StateName, IsReadOnlyColumn:=True)>
        Public Property StateName As String
            Get
                StateName = _StateName
            End Get
            Set(value As String)
                _StateName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMaxValue:=True, MaxValue:=99, UseMinValue:=True, MinValue:=0)>
        Public Property FederalStateCode As Short
            Get
                FederalStateCode = _IRS1099FederalStateCode.FederalStateCode
            End Get
            Set(value As Short)
                _IRS1099FederalStateCode.FederalStateCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _IRS1099FederalStateCode = New AdvantageFramework.Database.Entities.IRS1099FederalStateCode

            _IRS1099FederalStateCode.DatabaseAction = Database.Methods.Action.Inserting

        End Sub
        Public Sub New(IRS1099FederalStateCode As AdvantageFramework.Database.Entities.IRS1099FederalStateCode, States As Generic.List(Of AdvantageFramework.Database.Entities.State))

            _IRS1099FederalStateCode = IRS1099FederalStateCode

            Try

                _StateName = States.Where(Function(Entity) Entity.StateCode = IRS1099FederalStateCode.StateCode).SingleOrDefault.StateName

            Catch ex As Exception

            End Try

        End Sub
        Public Overrides Function ToString() As String

            ToString = _IRS1099FederalStateCode.StateCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.StateCode.ToString

                    PropertyValue = Value

                    _IRS1099FederalStateCode.DbContext = Me.DbContext

                    ErrorText = _IRS1099FederalStateCode.ValidateCustomProperties(AdvantageFramework.Database.Entities.IRS1099FederalStateCode.Properties.StateCode.ToString, IsValid, PropertyValue)

                Case AdvantageFramework.AccountPayable.Classes.IRS1099FederalStateCode.Properties.FederalStateCode.ToString

                    PropertyValue = Value

                    _IRS1099FederalStateCode.DbContext = Me.DbContext

                    ErrorText = _IRS1099FederalStateCode.ValidateCustomProperties(AdvantageFramework.Database.Entities.IRS1099FederalStateCode.Properties.FederalStateCode.ToString, IsValid, PropertyValue)

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace


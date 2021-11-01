Namespace Database.Classes

    <Serializable()>
    Public Class AccountExecutiveUpdate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CurrentAccountExecutive
            NewAccountExecutive
            Client
            Division
            Product
            UpdateInformation
        End Enum

#End Region

#Region " Variables "

        Private _CurrentAccountExecutive As String = Nothing
        Private _NewAccountExecutive As String = Nothing
        Private _Client As String = Nothing
        Private _Division As String = Nothing
        Private _Product As String = Nothing
        Private _UpdateInformation As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentAccountExecutive() As String
            Get
                CurrentAccountExecutive = _CurrentAccountExecutive
            End Get
            Set(value As String)
                _CurrentAccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewAccountExecutive() As String
            Get
                NewAccountExecutive = _NewAccountExecutive
            End Get
            Set(value As String)
                _NewAccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Client() As String
            Get
                Client = _Client
            End Get
            Set(value As String)
                _Client = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Division() As String
            Get
                Division = _Division
            End Get
            Set(value As String)
                _Division = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Product() As String
            Get
                Product = _Product
            End Get
            Set(value As String)
                _Product = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UpdateInformation() As String
            Get
                UpdateInformation = _UpdateInformation
            End Get
            Set(value As String)
                _UpdateInformation = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal CurrentAccountExecutive As String, ByVal NewAccountExecutive As String, ByVal Client As String, _
                       ByVal Division As String, ByVal Product As String, ByVal UpdateInformation As String)

            _CurrentAccountExecutive = CurrentAccountExecutive
            _NewAccountExecutive = NewAccountExecutive
            _Client = Client
            _Division = Division
            _Product = Product
            _UpdateInformation = UpdateInformation

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.NewAccountExecutive

        End Function

#End Region

    End Class

End Namespace


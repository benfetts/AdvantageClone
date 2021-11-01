Namespace Security.Database.Classes

    <Serializable()>
    Public Class UserClientDivisionProductAccess

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            OfficeCode
            Office
            ClientCode
            Client
            DivisionCode
            Division
            ProductCode
            Product
            AllowTimeEntryOnly
            IsInactive
            HasCDPSecurityGroup
            CDPSecurityGroup
        End Enum

#End Region

#Region " Variables "

        Private _UserCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _Office As String = Nothing
        Private _ClientCode As String = Nothing
        Private _Client As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _Division As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Product As String = Nothing
        Private _AllowTimeEntryOnly As Boolean = Nothing
        Private _IsInactive As Boolean = False
        Private _HasCDPSecurityGroup As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office Name")>
        Public ReadOnly Property Office() As String
            Get
                Office = _Office
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Name")>
        Public ReadOnly Property Client() As String
            Get
                Client = _Client
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division Name")>
        Public ReadOnly Property Division() As String
            Get
                Division = _Division
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product Name")>
        Public ReadOnly Property Product() As String
            Get
                Product = _Product
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowTimeEntryOnly() As Boolean
            Get
                AllowTimeEntryOnly = _AllowTimeEntryOnly
            End Get
            Set(ByVal value As Boolean)
                _AllowTimeEntryOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property HasCDPSecurityGroup() As Boolean
            Get
                HasCDPSecurityGroup = _HasCDPSecurityGroup
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CDPSecurityGroup() As String

#End Region

#Region " Methods "

        Public Sub New(ByVal Product As AdvantageFramework.Security.Database.Classes.Product, EmployeeCodes As String())

            _UserCode = ""
            _OfficeCode = Product.OfficeCode
            _Office = Product.OfficeName
            _ClientCode = Product.ClientCode
            _Client = Product.ClientName
            _DivisionCode = Product.DivisionCode
            _Division = Product.DivisionName
            _ProductCode = Product.ProductCode
            _Product = Product.ProductDescription
            _AllowTimeEntryOnly = False

            _IsInactive = False

            If Product.ClientActiveFlag.GetValueOrDefault(0) = 0 Then

                _IsInactive = True

            ElseIf Product.DivisionActiveFlag.GetValueOrDefault(0) = 0 Then

                _IsInactive = True

            ElseIf Product.ProductActiveFlag.GetValueOrDefault(0) = 0 Then

                _IsInactive = True

            End If

            If Product.CDPSecurityGroupID.GetValueOrDefault(0) > 0 AndAlso
                    Product.CDPSecurityGroupEmployeeCodes.Any(Function(CDPSecurityGroupEmployeeCode) EmployeeCodes.Contains(CDPSecurityGroupEmployeeCode)) Then

                _HasCDPSecurityGroup = True
                Me.CDPSecurityGroup = Product.CDPSecurityGroupName

            Else

                _HasCDPSecurityGroup = False
                Me.CDPSecurityGroup = String.Empty

            End If

        End Sub
        Public Sub New(ByVal UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess, EmployeeCode As String)

            _UserCode = UserClientDivisionProductAccess.UserCode
            _OfficeCode = UserClientDivisionProductAccess.Product.OfficeCode
            _Office = UserClientDivisionProductAccess.Product.Office.Name
            _ClientCode = UserClientDivisionProductAccess.ClientCode
            _Client = UserClientDivisionProductAccess.Product.Client.Name
            _DivisionCode = UserClientDivisionProductAccess.DivisionCode
            _Division = UserClientDivisionProductAccess.Product.Division.Name
            _ProductCode = UserClientDivisionProductAccess.ProductCode
            _Product = UserClientDivisionProductAccess.Product.Name
            _AllowTimeEntryOnly = UserClientDivisionProductAccess.AllowTimeEntryOnly.GetValueOrDefault(0)

            If UserClientDivisionProductAccess.Product.Client.IsActive.GetValueOrDefault(0) = 0 OrElse
                UserClientDivisionProductAccess.Product.Division.IsActive.GetValueOrDefault(0) = 0 OrElse
                UserClientDivisionProductAccess.Product.IsActive.GetValueOrDefault(0) = 0 Then

                _IsInactive = True

            Else

                _IsInactive = False

            End If

            If UserClientDivisionProductAccess.Product.CDPSecurityGroup IsNot Nothing AndAlso
                    UserClientDivisionProductAccess.Product.CDPSecurityGroup.CDPSecurityGroupEmployees IsNot Nothing AndAlso
                    UserClientDivisionProductAccess.Product.CDPSecurityGroup.CDPSecurityGroupEmployees.Any(Function(Entity) Entity.EmployeeCode = EmployeeCode) Then

                _HasCDPSecurityGroup = (UserClientDivisionProductAccess.Product.CDPSecurityGroupID.GetValueOrDefault(0) > 0)
                Me.CDPSecurityGroup = If(UserClientDivisionProductAccess.Product.CDPSecurityGroup IsNot Nothing, UserClientDivisionProductAccess.Product.CDPSecurityGroup.Name, String.Empty)

            Else

                _HasCDPSecurityGroup = False
                Me.CDPSecurityGroup = String.Empty

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

    End Class

End Namespace

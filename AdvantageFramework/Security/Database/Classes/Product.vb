Namespace Security.Database.Classes

    Public Class Product

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
            OfficeCode
            OfficeName
            IsActive
            ClientActiveFlag
            DivisionActiveFlag
            CDPSecurityGroupID
            CDPSecurityGroupName
            CDPSecurityGroupEmployeeCodes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property ClientName() As String
        <Key>
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <Key>
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Code")>
        Public Property ProductCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Name")>
        Public Property ProductDescription() As String
        <Required>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property IsInactive() As Boolean
            Get

                IsInactive = False

                If Me.ClientActiveFlag.GetValueOrDefault(0) = 0 Then

                    IsInactive = True

                ElseIf Me.DivisionActiveFlag.GetValueOrDefault(0) = 0 Then

                    IsInactive = True

                ElseIf Me.ProductActiveFlag.GetValueOrDefault(0) = 0 Then

                    IsInactive = True

                End If

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientActiveFlag() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DivisionActiveFlag() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ProductActiveFlag() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupEmployeeCodes() As String()


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & "-" & Me.DivisionCode.ToString & "-" & Me.ProductCode.ToString

        End Function

#End Region

    End Class

End Namespace

Namespace DTO.ProjectManagement.Campaign

    Public Class Campaign

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            StartDate
            EndDate
            ClientCode
            ClientName
            DivisionCode
            ProductCode
            OfficeCode
            OfficeName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <System.ComponentModel.DataAnnotations.Required>
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <System.ComponentModel.DataAnnotations.MaxLength(60)>
        Public Property Name() As String
        Public Property StartDate() As Nullable(Of Date)
        Public Property EndDate() As Nullable(Of Date)
        <System.ComponentModel.DataAnnotations.Required>
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        Public Property ClientName() As String
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
        <System.ComponentModel.DataAnnotations.MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
        Public Property OfficeName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Code = String.Empty
            Me.Name = String.Empty
            Me.StartDate = Nothing
            Me.EndDate = Nothing
            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.ProductCode = String.Empty
            Me.OfficeCode = String.Empty
            Me.OfficeName = String.Empty

        End Sub
        Public Sub New(Campaign As AdvantageFramework.Database.Entities.Campaign)

            Me.ID = Campaign.ID
            Me.Code = Campaign.Code
            Me.Name = Campaign.Name
            Me.StartDate = Campaign.StartDate
            Me.EndDate = Campaign.EndDate
            Me.ClientCode = Campaign.ClientCode
            Me.ClientName = If(Campaign.Client IsNot Nothing, Campaign.Client.Name, String.Empty)
            Me.DivisionCode = Campaign.DivisionCode
            Me.ProductCode = Campaign.ProductCode
            Me.OfficeCode = Campaign.OfficeCode
            Me.OfficeName = If(Campaign.Office IsNot Nothing, Campaign.Office.Name, String.Empty)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace


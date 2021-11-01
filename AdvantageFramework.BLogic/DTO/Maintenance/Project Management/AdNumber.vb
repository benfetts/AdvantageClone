Namespace DTO.Maintenance.ProjectManagement

    Public Class AdNumber
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
            IsInactive
            BlackplateCode1
            BlackplateCode2
            ClientCode
            DivisionCode
            ProductCode
            DocumentID
            Color
            MediaType
            Length
            StartDate
            ExpirationDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Number")>
        Public Property Number() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Blackplate 1", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Blackplate)>
        Public Property BlackplateCode1() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Blackplate 2", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Blackplate)>
        Public Property BlackplateCode2() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", PropertyType:=BaseClasses.Methods.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", PropertyType:=BaseClasses.Methods.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DocumentID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Color() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Length() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpirationDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DocumentName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DocumentIsURL() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Ad As AdvantageFramework.Database.Entities.Ad, DbContext As AdvantageFramework.Database.DbContext)

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Me.Number = Ad.Number
            Me.Description = Ad.Description
            Me.IsInactive = If(Ad.IsInactive.GetValueOrDefault(1) = 1, False, True)
            Me.BlackplateCode1 = Ad.BlackplateCode1
            Me.BlackplateCode2 = Ad.BlackplateCode2
            Me.ClientCode = Ad.ClientCode
            Me.DivisionCode = Ad.DivisionCode
            Me.ProductCode = Ad.ProductCode
            Me.Color = Ad.Color
            Me.MediaType = Ad.MediaType
            Me.Length = Ad.Length
            Me.StartDate = Ad.StartDate
            Me.ExpirationDate = Ad.ExpirationDate

            If Ad.DocumentID.HasValue Then

                Document = DbContext.Documents.Find(Ad.DocumentID.Value)

                If Document IsNot Nothing Then

                    Me.DocumentID = Ad.DocumentID
                    Me.DocumentName = Document.FileName

                    If Document.MIMEType = "URL" Then

                        Me.DocumentIsURL = True

                    End If

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef Ad As AdvantageFramework.Database.Entities.Ad)

            Ad.Number = Me.Number
            Ad.Description = Me.Description
            Ad.IsInactive = If(Me.IsInactive, 0, 1)
            Ad.BlackplateCode1 = Me.BlackplateCode1
            Ad.BlackplateCode2 = Me.BlackplateCode2
            Ad.ClientCode = Me.ClientCode
            Ad.DivisionCode = Me.DivisionCode
            Ad.ProductCode = Me.ProductCode
            'Ad.DocumentID = Me.DocumentID
            Ad.Color = Me.Color
            Ad.MediaType = Me.MediaType
            Ad.Length = Me.Length
            Ad.StartDate = Me.StartDate
            Ad.ExpirationDate = Me.ExpirationDate

        End Sub

#End Region

    End Class

End Namespace



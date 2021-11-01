Namespace DTO.Media.RFP

    <Serializable()>
    Public Class EmailVendorRepContact

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Include
            Name
            Email
            VendorRepCode
            VendorContactCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Include() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Email() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorRepCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorContactCode() As String

#End Region

#Region " Methods "

        Public Sub New(VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative)

            Me.Include = True
            Me.Name = VendorRepresentative.ToString
            Me.Email = VendorRepresentative.EmailAddress
            Me.VendorRepCode = VendorRepresentative.Code

        End Sub
        Public Sub New(VendorContact As AdvantageFramework.Database.Entities.VendorContact)

            Me.Include = True
            Me.Name = VendorContact.ToString
            Me.Email = VendorContact.Email
            Me.VendorContactCode = VendorContact.Code

        End Sub

#End Region

    End Class

End Namespace
Namespace Database.Entities

    <Table("GLENTHDR_EXTERNAL_GLIFACE_XREF")>
    Public Class GeneralLedgerExternalGLIFaceCrossReference
        Inherits BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            GLTransaction
            ExternalGLIFaceID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("GLENTHDR_EXTERNAL_GLIFACE_XREF_ID")>
        Public Property ID() As Integer

        <Column("GLEHXACT")>
        <Required>
        Public Property GLTransaction() As Integer

        <Column("EXTERNAL_GLIFACE_ID")>
        <Required>
        Public Property ExternalGLIFaceID() As Integer

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

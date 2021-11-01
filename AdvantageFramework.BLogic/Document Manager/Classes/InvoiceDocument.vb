Namespace DocumentManager.Classes

    <Serializable()>
    Public Class InvoiceDocument

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            InvoiceDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property DocumentID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property InvoiceDate() As Date

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


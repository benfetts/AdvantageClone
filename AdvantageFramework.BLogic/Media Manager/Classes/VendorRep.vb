Namespace MediaManager.Classes

    <Serializable()>
    Public Class VendorRep
        Inherits AdvantageFramework.Database.Classes.VendorRep

#Region " Constants "



#End Region

#Region " Enum "

        Public Shadows Enum Properties
            IsOrderRep1
            IsOrderRep2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order Rep 1")>
        Public Property IsOrderRep1 As Boolean = False
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order Rep 2")>
        Public Property IsOrderRep2 As Boolean = False

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
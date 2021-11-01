Namespace MediaManager.Classes

    <Serializable()>
    Public Class OtherUserSelection

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeName
            OrderNumber
            ClientCode
            DivisionCode
            ProductCode
            UserID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeName As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber As Integer = Nothing

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property UserID As Integer = Nothing

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

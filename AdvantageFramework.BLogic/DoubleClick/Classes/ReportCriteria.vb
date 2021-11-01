Namespace DoubleClick.Classes

    <Serializable()>
    Public Class ReportCriteria
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DoubleClickReportRelativeDateRange
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.DoubleClickReportRelativeDateRange)>
        Public Property DoubleClickReportRelativeDateRange() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
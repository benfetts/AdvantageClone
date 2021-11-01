Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_MGR_SEARCH_SETTING")>
    Public Class MediaManagerSearchSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            SelectBy
            SelectNewspaper
            SelectMagazine
            SelectInternet
            SelectOutOfHome
            SelectRadio
            SelectTV
            IncludeOrderQuoteBoth
            IncludeOrderLineDates
            OrderLineStartDate
            OrderLineEndDate
            IncludeJobMediaDateToBill
            JobMediaStartDate
            JobMediaEndDate
            FilterBy
            MediaMonthStart
            MediaMonthEnd
            SelectPO
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.Column("MEDIA_MGR_SEARCH_SETTING_USER_CODE"),
        System.ComponentModel.DataAnnotations.Key,
        System.ComponentModel.DataAnnotations.Required,
        System.ComponentModel.DataAnnotations.MaxLength(100),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode() As String

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_BY"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SelectBy() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_NEWSPAPER"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectNewspaper() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_MAGAZINE"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectMagazine() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_INTERNET"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectInternet() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_OUTOFHOME"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectOutOfHome() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_RADIO"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectRadio() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("SELECT_TV"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectTV() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_ORDER_QUOTE_BOTH"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeOrderQuoteBoth() As Short

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_ORDER_LINE_DATES"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeOrderLineDates() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_LINE_START_DATE", TypeName:="smalldatetime"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderLineStartDate() As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Schema.Column("ORDER_LINE_END_DATE", TypeName:="smalldatetime"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderLineEndDate() As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_JOB_MEDIA_DATE_TO_BILL"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeJobMediaDateToBill() As Boolean

        <System.ComponentModel.DataAnnotations.Schema.Column("JOB_MEDIA_START_DATE", TypeName:="smalldatetime"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobMediaStartDate() As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Schema.Column("JOB_MEDIA_END_DATE", TypeName:="smalldatetime"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobMediaEndDate() As Nullable(Of Date)

        <System.ComponentModel.DataAnnotations.Schema.Column("INCLUDE_CLOSED_ORDERS"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeClosedOrders() As Boolean

        <Column("FILTER_BY")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FilterBy() As Short

        <Column("MEDIA_MONTH_START", TypeName:="smalldatetime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMonthStart() As Nullable(Of Date)

        <Column("MEDIA_MONTH_END", TypeName:="smalldatetime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMonthEnd() As Nullable(Of Date)

        <Column("SELECT_PO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SelectPO() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode.ToString

        End Function

#End Region

    End Class

End Namespace

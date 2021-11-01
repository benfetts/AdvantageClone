Namespace DTO.Media.Traffic

    Public Class Generate
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaTrafficVendorID
            MediaTrafficRevisionID
            DefaultCorrespondenceMethod
            VendorCode
            VendorName
            Instruction
            TrafficStatus
            CreatedDate
            LastGeneratedDate
            Status
            RecipientCount
            'CommentToVendor
            AlertRecipients
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficVendorID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficRevisionID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Print/Email")>
        Public Property DefaultCorrespondenceMethod() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Code")>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor" & vbCrLf & "Name")>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Traffic" & vbCrLf & "Instruction")>
        Public Property Instruction() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Traffic" & vbCrLf & "Status")>
        Public Property TrafficStatus() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Created" & vbCrLf & "Date", DisplayFormat:="g")>
        Public Property CreatedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Last Generated" & vbCrLf & "Date", DisplayFormat:="g")>
        Public Property LastGeneratedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Status")>
        Public Property Status() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Recipient" & vbCrLf & "Count")>
        Public Property RecipientCount() As Integer
        '<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        'Public Property CommentToVendor() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertRecipients() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertRecipientEmployeeCodes() As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

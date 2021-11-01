Namespace Security.LicenseKey.Classes
    ''' <summary>
    ''' FOR INTERNAL ADVANTAGE USE ONLY!!!!
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()>
    Public Class ComscoreLicenseKeyHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            AgencyName
            UserCode
            EmployeeCode
            EmployeeName
            CreatedDate
            ComscoreClientID
            EncrpytedLicenseKey
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property AgencyName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property UserCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property CreatedDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property ComscoreClientID() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property EncrpytedLicenseKey() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace

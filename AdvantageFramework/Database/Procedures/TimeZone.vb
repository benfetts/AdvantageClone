Namespace Database.Procedures.TimeZone

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        ''Public Function LoadByTimeZoneID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal TimeZoneID As Integer) As Database.Entities.TimeZone

        ''    LoadByTimeZoneID = (From TimeZone In DataContext.TimeZones
        ''                        Where TimeZone.ID = TimeZoneID
        ''                        Select TimeZone).SingleOrDefault

        ''End Function
        ''Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.TimeZone)

        ''    Load = From TimeZone In DataContext.TimeZones
        ''           Select TimeZone

        ''End Function

        Public Function LoadSystemTimeZones() As System.Collections.Generic.List(Of TimeZoneInfo)

            LoadSystemTimeZones = TimeZoneInfo.GetSystemTimeZones.ToList

        End Function

#End Region

    End Module

End Namespace

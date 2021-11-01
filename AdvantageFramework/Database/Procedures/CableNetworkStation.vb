Namespace Database.Procedures.CableNetworkStation

	<HideModuleName()>
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

		Public Function LoadByCableNetworkStationID(DbContext As Database.DbContext, CableNetworkStationID As Integer) As Database.Entities.CableNetworkStation

			LoadByCableNetworkStationID = (From CableNetworkStation In DbContext.GetQuery(Of Database.Entities.CableNetworkStation)
										   Where CableNetworkStation.ID = CableNetworkStationID
										   Select CableNetworkStation).SingleOrDefault

		End Function
		Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CableNetworkStation)

			Load = From CableNetworkStation In DbContext.GetQuery(Of Database.Entities.CableNetworkStation)
				   Select CableNetworkStation

		End Function

#End Region

	End Module

End Namespace

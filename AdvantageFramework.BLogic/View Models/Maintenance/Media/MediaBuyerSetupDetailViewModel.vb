Namespace ViewModels.Maintenance.Media

	Public Class MediaBuyerSetupDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeCode
			EmployeeName
			IsInactive
		End Enum

#End Region

#Region " Variables "

		Private _MediaBuyer As AdvantageFramework.Database.Entities.MediaBuyer = Nothing
        Private _EmployeeName As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _MediaBuyer.ID
            End Get
            Set(value As Integer)
                _MediaBuyer.ID = value
            End Set
        End Property
        <System.ComponentModel.DataAnnotations.MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _MediaBuyer.EmployeeCode
            End Get
            Set(value As String)
                _MediaBuyer.EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.EmployeeName)>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _MediaBuyer.IsInactive
            End Get
            Set(value As Boolean)
                _MediaBuyer.IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _MediaBuyer = New AdvantageFramework.Database.Entities.MediaBuyer

        End Sub
		Public Sub New(MediaBuyer As AdvantageFramework.Database.Entities.MediaBuyer)

            _MediaBuyer = MediaBuyer
            _EmployeeName = MediaBuyer.Employee.ToString

        End Sub
		Public Function GetMediaBuyerEntity() As AdvantageFramework.Database.Entities.MediaBuyer

            GetMediaBuyerEntity = _MediaBuyer

		End Function

#End Region

	End Class

End Namespace


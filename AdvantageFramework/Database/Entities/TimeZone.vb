Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.TIME_ZONE")>
    Public Class TimeZone
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            UtcOffsetTicks
            OffsetHours
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _UtcOffsetTicks As Integer = 0
        Private _OffsetHours As Decimal = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ID", Storage:="_ID", DBType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NAME", Storage:="_Name", DbType:="varchar"),
		System.ComponentModel.DisplayName("Name"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="UTC_OFFSET_TICKS", Storage:="_UtcOffsetTicks", DBType:="int"), _
        System.ComponentModel.DisplayName("UtcOffsetTicks")> _
        Public Property UtcOffsetTicks() As Integer
            Get
                UtcOffsetTicks = _UtcOffsetTicks
            End Get
            Set(ByVal value As Integer)
                _UtcOffsetTicks = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFFSET_HOURS", Storage:="_OffsetHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("OffsetHours")> _
        Public Property OffsetHours() As Decimal
            Get
                OffsetHours = _OffsetHours
            End Get
            Set(ByVal value As Decimal)
                _OffsetHours = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


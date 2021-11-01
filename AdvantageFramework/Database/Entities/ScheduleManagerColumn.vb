Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table()>
    Public Class ScheduleManagerColumn
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Column
        End Enum

#End Region

#Region " Variables "

        Private _Column As String = ""

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="", Storage:="_Column", DbType:="varchar"),
		System.ComponentModel.DisplayName("Column"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property Column() As String
            Get
                Column = _Column
            End Get
            Set(ByVal value As String)
                _Column = value
            End Set
        End Property

#End Region

#Region " Methods "

#End Region

    End Class

End Namespace


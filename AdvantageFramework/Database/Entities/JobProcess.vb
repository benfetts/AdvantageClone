Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.JOB_PROC_CONTROLS")>
    Public Class JobProcess
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
        End Enum

#End Region

#Region " Variables "

        Private _ID As Short = 0
        Private _Description As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_PROCESS_CONTRL", Storage:="_ID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Short
            Get
                ID = _ID
            End Get
            Set(ByVal value As Short)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_PROCESS_DESC", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

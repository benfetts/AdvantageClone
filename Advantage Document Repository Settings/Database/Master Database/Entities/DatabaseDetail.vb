Namespace Database.MasterDatabase.Entities

    <System.ComponentModel.DataAnnotations.Schema.NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="sys.databases")>
    Public Class DatabaseDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            Collation
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _Name As String = ""
        Private _Collation As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="database_id", Storage:="_ID", DbType:="int"),
        System.ComponentModel.DisplayName("ID")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="name", Storage:="_Name", DbType:="varchar"),
        System.ComponentModel.DisplayName("Name")>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="collation_name", Storage:="_Collation", DbType:="varchar"),
        System.ComponentModel.DisplayName("Collation")>
        Public Property Collation() As String
            Get
                Collation = _Collation
            End Get
            Set(value As String)
                _Collation = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace

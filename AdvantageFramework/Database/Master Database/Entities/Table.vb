Namespace Database.MasterDatabase.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="sys.tables")>
    Public Class Table

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ObjectID
            Name
        End Enum

#End Region

#Region " Variables "

        Private _ObjectID As Long = 0
        Private _Name As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="object_id", Storage:="_ObjectID", DbType:="int"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ObjectID() As Long
            Get
                ObjectID = _ObjectID
            End Get
            Set(ByVal value As Long)
                _ObjectID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="name", Storage:="_Name"),
		System.ComponentModel.DisplayName("Name"),
		System.ComponentModel.DataAnnotations.MaxLength(-1)>
		Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
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

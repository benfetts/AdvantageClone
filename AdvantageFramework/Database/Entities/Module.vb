Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ADVANTAGE_MODULES")>
    Public Class [Module]
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            SecurityCode
            IconNumber
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = ""
        Private _Description As String = ""
        Private _SecurityCode As String = ""
        Private _IconNumber As System.Nullable(Of Long) = 0

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MODULE", Storage:="_Code", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MODULE_DESC", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Description() As String
			Get
				Description = _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="APP_SECURITY_COL", Storage:="_SecurityCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Security Code"),
		System.ComponentModel.DataAnnotations.MaxLength(25)>
		Public Property SecurityCode() As String
            Get
                SecurityCode = _SecurityCode
            End Get
            Set(ByVal value As String)
                _SecurityCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ICON", Storage:="_IconNumber", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Icon Number")> _
        Public Property IconNumber() As System.Nullable(Of Long)
            Get
                IconNumber = _IconNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IconNumber = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

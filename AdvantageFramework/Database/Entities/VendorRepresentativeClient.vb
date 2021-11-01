Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.VEN_REP_CLIENTS")>
    Public Class VendorRepresentativeClient
        Inherits BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            VendorRepCode
            ClientCode
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = ""
        Private _VendorRepCode As String = ""
        Private _ClientCode As String = ""

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_CODE", Storage:="_VendorCode", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("VendorCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property VendorCode() As String
			Get
				VendorCode = _VendorCode
			End Get
			Set(ByVal value As String)
				_VendorCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE", Storage:="_VendorRepCode", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("VendorRepCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property VendorRepCode() As String
			Get
				VendorRepCode = _VendorRepCode
			End Get
			Set(ByVal value As String)
				_VendorRepCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
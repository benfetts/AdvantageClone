Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.OFF_ASSIGN")>
    Public Class OfficeOverheadSet
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            OverheadAccountCode
            OfficeCode
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _OverheadAccountCode As String = Nothing
        Private _OfficeCode As String = Nothing

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFF_ASSIGN_CODE", Storage:="_Code", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(24)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OH_SET_ID", Storage:="_OverheadAccountCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("OverheadAccountCode"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property OverheadAccountCode() As String
			Get
				OverheadAccountCode = _OverheadAccountCode
			End Get
			Set(ByVal value As String)
				_OverheadAccountCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OFF_CODE", Storage:="_OfficeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("OfficeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

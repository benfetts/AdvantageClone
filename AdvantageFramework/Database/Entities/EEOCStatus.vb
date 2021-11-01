Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.EEOC_STATUS")>
    Public Class EEOCStatus
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            EEOCCode
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = ""
        Private _EEOCCode As String = ""

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR", Storage:="_VendorCode", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EEOC_CODE", Storage:="_EEOCCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("EEOCCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property EEOCCode() As String
            Get
                EEOCCode = _EEOCCode
            End Get
            Set(ByVal value As String)
                _EEOCCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
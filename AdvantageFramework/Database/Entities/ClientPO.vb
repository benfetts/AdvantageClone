Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.CLIENT_PO")>
    Public Class ClientPO
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            ProductCode
            ClientPONumber
            ClientPODescription
            CreateDate
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ClientPONumber As String = Nothing
        Private _ClientPODescription As String = Nothing
        Private _CreateDate As DateTime = "1/1/1900"
        Private _IsInactive As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLIENT_PO_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"),
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRD_CODE", Storage:="_ProductCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ProductCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLIENT_PO_NUMBER", Storage:="_ClientPONumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientPONumber"),
		System.ComponentModel.DataAnnotations.MaxLength(25),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property ClientPONumber() As String
			Get
				ClientPONumber = _ClientPONumber
			End Get
			Set(ByVal value As String)
				_ClientPONumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLIENT_PO_DESCRIPTION", Storage:="_ClientPODescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientPODescription"),
		System.ComponentModel.DataAnnotations.MaxLength(30),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property ClientPODescription() As String
            Get
                ClientPODescription = _ClientPODescription
            End Get
            Set(ByVal value As String)
                _ClientPODescription = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CREATE_DATE", Storage:="_CreateDate", DbType:="smalldatetime"),
        System.ComponentModel.DisplayName("CreateDate"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property CreateDate() As DateTime
            Get
                CreateDate = _CreateDate
            End Get
            Set(ByVal value As DateTime)
                _CreateDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_INACTIVE", Storage:="_IsInactive", DbType:="bit"),
        System.ComponentModel.DisplayName("IsInactive"),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Long
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Long)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

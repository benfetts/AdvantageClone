Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.DIVISION_DOCUMENTS")>
    Public Class DivisionDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            DivisionCode
            ClientCode
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _DivisionCode As String = ""
        Private _ClientCode As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("DocumentID")> _
        Public Property DocumentID() As Long
            Get
                DocumentID = _DocumentID
            End Get
            Set(ByVal value As Long)
                _DocumentID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DIV_CODE", Storage:="_DivisionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("DivisionCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CL_CODE", Storage:="_ClientCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("ClientCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
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

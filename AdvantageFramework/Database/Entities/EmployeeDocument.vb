Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.EMPLOYEE_DOCUMENTS")>
    Public Class EmployeeDocument
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentID
            EmployeeCode
        End Enum

#End Region

#Region " Variables "

        Private _DocumentID As Long = 0
        Private _EmployeeCode As String = ""

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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("EmployeeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
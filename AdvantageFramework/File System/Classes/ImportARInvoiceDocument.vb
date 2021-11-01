Namespace FileSystem.Classes

    <Serializable()>
    Public Class ImportARInvoiceDocument
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FileName
            InvoiceNumber
            SequenceNumber
            Type
            ClientCode
            FileInfo
        End Enum

#End Region

#Region " Variables "

        Private _FileName As String = ""
        Private _InvoiceNumber As Integer = 0
        Private _SequenceNumber As Short = 0
        Private _Type As String = ""
        Private _ClientCode As String = ""
        Private _FileInfo As System.IO.FileInfo = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property FileName As String
            Get
                FileName = _FileName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.AccountReceivable)>
        Public Property InvoiceNumber As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.AccountReceivableSequenceNumber, IsReadOnlyColumn:=True)>
        Public Property SequenceNumber As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.AccountReceivableType, IsReadOnlyColumn:=True)>
        Public Property Type As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.AccountReceivableClientCode, IsReadOnlyColumn:=True)>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property FileInfo As System.IO.FileInfo
            Get
                FileInfo = _FileInfo
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal FileInfo As System.IO.FileInfo, ByVal InvoiceNumber As Integer, ByVal SequenceNumber As Short, ByVal Type As String, ByVal ClientCode As String)

            _FileInfo = FileInfo
            _FileName = FileInfo.Name
            _InvoiceNumber = InvoiceNumber
            _SequenceNumber = SequenceNumber
            _Type = Type
            _ClientCode = ClientCode

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorMessage As String = Nothing

            IsValid = False

            If Me.FileInfo IsNot Nothing Then

                If Me.FileInfo.Exists Then

                    If AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumber(DbContext, Me.InvoiceNumber, Me.SequenceNumber) IsNot Nothing Then

                        AdvantageFramework.FileSystem.CheckRepositoryConstraints(DbContext, Me.FileInfo.FullName, IsValid, ErrorMessage)

                    Else

                        ErrorMessage = "Invalid invoice."

                    End If

                Else

                    ErrorMessage = "File does not exists."

                End If

            Else

                ErrorMessage = "Invalid file."

            End If

            _EntityError = ErrorMessage

            ValidateEntity = ErrorMessage

        End Function

#End Region

    End Class

End Namespace
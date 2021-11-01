Namespace FileSystem.Classes

    <Serializable()>
    Public Class Proof

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FileID
            FileName
            Folder
            Version
            Owner
            Decision
            FileSize
        End Enum

#End Region

#Region " Variables "

        Private _FileID As Integer = Nothing
        Private _FileName As String = Nothing
        Private _Folder As String = Nothing
        Private _Version As Integer = Nothing
        Private _Owner As String = Nothing
        Private _Decision As String = Nothing
        Private _FileSize As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FileID As Integer
            Get
                FileID = _FileID
            End Get
            Set(value As Integer)
                _FileID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FileName As String
            Get
                FileName = _FileName
            End Get
            Set(value As String)
                _FileName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Folder() As String
            Get
                Folder = _Folder
            End Get
            Set(value As String)
                _Folder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Version As Integer
            Get
                Version = _Version
            End Get
            Set(value As Integer)
                _Version = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Owner As String
            Get
                Owner = _Owner
            End Get
            Set(value As String)
                _Owner = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Decision As String
            Get
                Decision = _Decision
            End Get
            Set(value As String)
                _Decision = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FileSize As String
            Get
                FileSize = _FileSize
            End Get
            Set(value As String)
                _FileSize = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal SOAPFileObject As AdvantageFramework.ProofHQRef.SOAPFileObject)

            Me.FileID = SOAPFileObject.file_id
            Me.FileName = SOAPFileObject.filename
            Me.Folder = SOAPFileObject.workspace_name
            Me.Version = SOAPFileObject.version
            Me.Owner = SOAPFileObject.owner
            Me.Decision = SOAPFileObject.decision
            Me.FileSize = SOAPFileObject.filesize

        End Sub

#End Region

    End Class

End Namespace

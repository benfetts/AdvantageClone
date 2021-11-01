Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerOrderLineComment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            OrderNumber
            LineNumber
            OrderDescription
            Instructions
            OrderCopy
            MaterialNotes
            PositionInformation
            CloseInformation
            RateInformation
            MiscellaneousInformation
            InHouseComments
            OrderType
        End Enum

#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _OrderDescription As String = Nothing
        Private _Instructions As String = Nothing
        Private _OrderCopy As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _PositionInformation As String = Nothing
        Private _CloseInformation As String = Nothing
        Private _RateInformation As String = Nothing
        Private _MiscellaneousInformation As String = Nothing
        Private _InHouseComments As String = Nothing
        Private _OrderType As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property MediaType() As String
            Get

                Dim MedType As String = Nothing

                Select Case _OrderType

                    Case "I"
                        MedType = "Internet"

                    Case "M"
                        MedType = "Magazine"

                    Case "N"
                        MedType = "Newspaper"

                    Case "O"
                        MedType = "Out Of Home"

                    Case "R"
                        MedType = "Radio"

                    Case "T"
                        MedType = "TV"

                End Select

                MediaType = MedType

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property Instructions() As String
            Get
                Instructions = _Instructions
            End Get
            Set(value As String)
                _Instructions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property OrderCopy() As String
            Get
                OrderCopy = _OrderCopy
            End Get
            Set(value As String)
                _OrderCopy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set(value As String)
                _MaterialNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property PositionInformation() As String
            Get
                PositionInformation = _PositionInformation
            End Get
            Set(value As String)
                _PositionInformation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property CloseInformation() As String
            Get
                CloseInformation = _CloseInformation
            End Get
            Set(value As String)
                _CloseInformation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property RateInformation() As String
            Get
                RateInformation = _RateInformation
            End Get
            Set(value As String)
                _RateInformation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property MiscellaneousInformation() As String
            Get
                MiscellaneousInformation = _MiscellaneousInformation
            End Get
            Set(value As String)
                _MiscellaneousInformation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property InHouseComments() As String
            Get
                InHouseComments = _InHouseComments
            End Get
            Set(value As String)
                _InHouseComments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderType() As String
            Get
                OrderType = _OrderType
            End Get
            Set(value As String)
                _OrderType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property OrderNumberLineNumber() As String
            Get
                OrderNumberLineNumber = Me.OrderNumber.ToString & "|" & Me.LineNumber.ToString
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function Copy() As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment

            Dim ClassCopy As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(Me.GetType)
            MemoryStream = New System.IO.MemoryStream

            XmlSerializer.Serialize(MemoryStream, Me)
            MemoryStream.Seek(0, IO.SeekOrigin.Begin)

            Try

                ClassCopy = CType(XmlSerializer.Deserialize(MemoryStream), AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            Catch ex As Exception
                ClassCopy = Nothing
            End Try

            Copy = ClassCopy

        End Function

#End Region

    End Class

End Namespace
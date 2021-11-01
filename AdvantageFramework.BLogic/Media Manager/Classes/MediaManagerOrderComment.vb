Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerOrderComment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            OrderNumber
            OrderDescription
            OrderComment
            InHouseComment
            OrderType
        End Enum

#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderComment As String = Nothing
        Private _InHouseComment As String = Nothing
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
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set(value As String)
                _OrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo, IsAutoFillProperty:=True)>
        Public Property InHouseComment() As String
            Get
                InHouseComment = _InHouseComment
            End Get
            Set(value As String)
                _InHouseComment = value
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

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function Copy() As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment

            Dim ClassCopy As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(Me.GetType)
            MemoryStream = New System.IO.MemoryStream

            XmlSerializer.Serialize(MemoryStream, Me)
            MemoryStream.Seek(0, IO.SeekOrigin.Begin)

            Try

                ClassCopy = CType(XmlSerializer.Deserialize(MemoryStream), AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            Catch ex As Exception
                ClassCopy = Nothing
            End Try

            Copy = ClassCopy

        End Function

#End Region

    End Class

End Namespace
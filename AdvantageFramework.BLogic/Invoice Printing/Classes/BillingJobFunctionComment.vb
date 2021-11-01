Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class BillingJobFunctionComment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            JobComponent
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            FunctionSource
            Comment
            CommentSource
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _JobComponent As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionSource As Nullable(Of Short) = Nothing
        Private _Comment As String = Nothing
        Private _CommentSource As Nullable(Of Short) = Nothing
        Private _InvoiceJobFunctionDescription As String = Nothing
        Private _InvoiceJobFunctionComment As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Job/Component")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(value As String)
                _JobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Component Description")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property FunctionSource() As Nullable(Of Short)
            Get
                FunctionSource = _FunctionSource
            End Get
            Set(value As Nullable(Of Short))
                _FunctionSource = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property CommentSource() As Nullable(Of Short)
            Get
                CommentSource = _CommentSource
            End Get
            Set(value As Nullable(Of Short))
                _CommentSource = value
            End Set
        End Property

#End Region

#Region " Methods "

        Protected Sub New()



        End Sub
        Public Sub New(ByVal InvoiceJobFunctionComment As AdvantageFramework.Database.Views.InvoiceJobFunctionComment)

            Me.InvoiceNumber = InvoiceJobFunctionComment.InvoiceNumber
            Me.JobComponent = CStr(CStr(AdvantageFramework.StringUtilities.PadWithCharacter(InvoiceJobFunctionComment.JobNumber, 6, "0", True, True)).Trim & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(InvoiceJobFunctionComment.JobComponentNumber, 3, "0", True, True)).Trim
            Me.JobNumber = InvoiceJobFunctionComment.JobNumber
            Me.JobDescription = InvoiceJobFunctionComment.JobDescription
            Me.JobComponentNumber = InvoiceJobFunctionComment.JobComponentNumber
            Me.JobComponentDescription = InvoiceJobFunctionComment.JobComponentDescription
            Me.FunctionCode = InvoiceJobFunctionComment.FunctionCode
            Me.FunctionDescription = InvoiceJobFunctionComment.FunctionDescription
            Me.FunctionSource = InvoiceJobFunctionComment.FunctionSource
            Me.Comment = InvoiceJobFunctionComment.Comment
            Me.CommentSource = InvoiceJobFunctionComment.CommentSource

            _InvoiceJobFunctionDescription = InvoiceJobFunctionComment.FunctionDescription
            _InvoiceJobFunctionComment = InvoiceJobFunctionComment.Comment

        End Sub
        Public Function HasFunctionDescriptionChanged() As Boolean

            'objects
            Dim HasChanged As Boolean = False

            If _InvoiceJobFunctionDescription <> Me.FunctionDescription Then

                HasChanged = True

            End If

            HasFunctionDescriptionChanged = HasChanged

        End Function
        Public Function HasCommentChanged() As Boolean

            'objects
            Dim HasChanged As Boolean = False

            If _InvoiceJobFunctionComment <> Me.Comment Then

                HasChanged = True

            End If

            HasCommentChanged = HasChanged

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace


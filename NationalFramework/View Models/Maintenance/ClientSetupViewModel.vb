Namespace ViewModels.Maintenance

    Public Class ClientSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property CancelEnabled As Boolean
            Get
                CancelEnabled = Me.IsNewRow
            End Get
        End Property
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = Not Me.IsNewRow AndAlso Me.SelectedClient IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property ExportEnabled As Boolean
            Get
                ExportEnabled = Me.Clients IsNot Nothing AndAlso Me.Clients.Count > 0
            End Get
        End Property
        Public ReadOnly Property ViewOrdersEnabled As Boolean
            Get
                ViewOrdersEnabled = Not Me.IsNewRow AndAlso Me.HasASelectedClient
            End Get
        End Property

        Public Property SaveEnabled As Boolean

        Public ReadOnly Property HasASelectedClient As Boolean
            Get
                HasASelectedClient = (SelectedClient IsNot Nothing)
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property Clients As Generic.List(Of DTO.Client)
        Public Property SelectedClient As DTO.Client

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace


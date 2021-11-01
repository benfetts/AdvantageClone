Namespace WinForm.Presentation.Controls.Interfaces

    Public Interface IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        ReadOnly Property UserEntryChanged As Boolean
        WriteOnly Property ByPassUserEntryChanged As Boolean
        WriteOnly Property SuspendedForLoading As Boolean

#End Region

#Region " Methods "

        Sub ClearChanged()

#End Region

    End Interface

End Namespace
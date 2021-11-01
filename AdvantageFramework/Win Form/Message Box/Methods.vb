Namespace WinForm.MessageBox

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum DialogResults
            [Yes] = 6
            [No] = 7
            [Cancel] = 2
            [OK] = 1
        End Enum

        Public Enum MessageBoxButtons
            [OK] = 0
            [YesNoCancel] = 3
            [YesNo] = 4
            [OKCancel] = 1
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SuppressMessageBox As Boolean = False

#End Region

#Region " Methods "



#End Region

    End Module

End Namespace


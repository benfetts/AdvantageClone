Namespace WinForm.Presentation.Controls

    Public Class ButtonItem
        Inherits DevComponents.DotNetBar.ButtonItem

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecurityEnabled As Boolean = True

#End Region

#Region " Properties "

        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

                End If

            End Set
        End Property
        Public Property SecurityEnabled As Boolean
            Get
                SecurityEnabled = _SecurityEnabled
            End Get
            Set(ByVal value As Boolean)
                _SecurityEnabled = value
                Me.Enabled = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

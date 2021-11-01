Namespace WinForm.Presentation.Controls

    Public Class RibbonBar
        Inherits DevComponents.DotNetBar.RibbonBar

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

        Public Sub New()

            Me.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            'Me.BackgroundMouseOverStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            'Me.BackgroundMouseOverStyle.BorderLeftWidth = 2
            Me.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.BackgroundMouseOverStyle.BorderRightWidth = 2

            Me.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            'Me.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            'Me.BackgroundStyle.BorderLeftWidth = 2
            Me.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.BackgroundStyle.BorderRightWidth = 2

        End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

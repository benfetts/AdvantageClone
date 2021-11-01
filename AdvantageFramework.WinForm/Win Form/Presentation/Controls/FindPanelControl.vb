Namespace WinForm.Presentation.Controls

    Public Class FindPanel
        Inherits DevExpress.XtraGrid.Controls.FindControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Public Sub New()

        '    MyBase.New()

        '    teFind.Properties.Buttons(0).Visible = False

        '    Me.LookAndFeel.SkinName = "Office 2016 Colorful"
        '    Me.LookAndFeel.UseDefaultLookAndFeel = False
        '    Me.DoubleBuffered = True

        '    AddHandler teFind.EditValueChanging, AddressOf EditValueChanging

        'End Sub
        Public Sub New(ByVal ColumnView As DevExpress.XtraGrid.Views.Base.ColumnView, ByVal Properties As Object)

            MyBase.New(ColumnView, Properties)

            Me.FindEdit.Properties.Buttons(0).Visible = False
            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True

            AddHandler Me.FindEdit.EditValueChanging, AddressOf EditValueChanging

        End Sub
        Public Sub EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            Try

                If String.IsNullOrEmpty(e.NewValue) = False Then

                    If TypeOf Me.View Is AdvantageFramework.WinForm.Presentation.Controls.GridView Then

                        CType(Me.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).RaiseBeforeLeaveRowEvent()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub

        Private Sub InitializeComponent()
            CType(Me.lciCloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FindEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.lciFind, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.findLayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.findLayoutControl.SuspendLayout()
            CType(Me.lciFindButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.lciClearButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.lcGroupMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btClear
            '
            Me.ClearButton.Location = New System.Drawing.Point(403, 12)
            '
            'teFind
            '
            Me.FindEdit.Size = New System.Drawing.Size(303, 20)
            '
            'lciFind
            '
            Me.lciFind.Size = New System.Drawing.Size(307, 26)
            '
            'findLayoutControl
            '
            Me.findLayoutControl.OptionsView.UseSkinIndents = False
            Me.findLayoutControl.Size = New System.Drawing.Size(492, 45)
            Me.findLayoutControl.Controls.SetChildIndex(Me.CloseButton, 0)
            Me.findLayoutControl.Controls.SetChildIndex(Me.FindButton, 0)
            Me.findLayoutControl.Controls.SetChildIndex(Me.FindEdit, 0)
            Me.findLayoutControl.Controls.SetChildIndex(Me.ClearButton, 0)
            '
            'btFind
            '
            Me.FindButton.Location = New System.Drawing.Point(339, 12)
            '
            'lciFindButton
            '
            Me.lciFindButton.Location = New System.Drawing.Point(327, 0)
            '
            'lciClearButton
            '
            Me.lciClearButton.Location = New System.Drawing.Point(391, 0)
            '
            'lcGroupMain
            '
            Me.lcGroupMain.OptionsItemText.TextToControlDistance = 5
            Me.lcGroupMain.Size = New System.Drawing.Size(475, 46)
            '
            'FindPanel
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.Name = "FindPanel"
            CType(Me.lciCloseButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FindEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.lciFind, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.findLayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.findLayoutControl.ResumeLayout(False)
            CType(Me.lciFindButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.lciClearButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.lcGroupMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace

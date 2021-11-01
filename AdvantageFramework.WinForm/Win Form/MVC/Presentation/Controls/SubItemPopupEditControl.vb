Namespace WinForm.MVC.Presentation.Controls

	Public Class SubItemPopupEditControl
		Inherits DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit

		Public Event QueryPopupNeedAvailableCodes(ByRef AvailableObjects As Object, ByRef OverrideDefault As Boolean)

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum [Type]
			[Default]
			EmployeeSelection
			ClientContactSelection
		End Enum


#End Region

#Region " Variables "

		Protected _ControlType As SubItemPopupEditControl.Type = SubItemPopupEditControl.Type.Default
        Protected _IncludeInactive As Boolean = False
        Protected _ValueType As System.Type = Nothing
		Protected _IsNewValue As Boolean = False
		Protected _EnumType As System.Type = Nothing
		Protected _CancelPopup As Boolean = False

#End Region

#Region " Properties "

		Public Property EnumType() As System.Type
			Get
				EnumType = _EnumType
			End Get
			Set(ByVal value As System.Type)
				_EnumType = value
			End Set
		End Property
		Public Property ValueType() As System.Type
			Get
				ValueType = _ValueType
			End Get
			Set(ByVal value As System.Type)
				_ValueType = value
			End Set
		End Property
        Public Property ControlType() As SubItemPopupEditControl.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemPopupEditControl.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property IncludeInactive() As Boolean
			Get
				IncludeInactive = _IncludeInactive
			End Get
			Set(ByVal value As Boolean)
				_IncludeInactive = value
			End Set
		End Property
		Public Property IsNewValue() As Boolean
			Get
				IsNewValue = _IsNewValue
			End Get
			Set(ByVal value As Boolean)
				_IsNewValue = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.LookAndFeel.SkinName = "Office 2016 Colorful"
			Me.LookAndFeel.UseDefaultLookAndFeel = False

			Me.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
			Me.ValidateOnEnterKey = True
			Me.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.Default
			Me.PopupSizeable = True
			Me.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

		End Sub
		Protected Sub SetControlType()

			'objects
			Dim Control As System.Windows.Forms.Control = Nothing
			Dim PopupContainerControl As DevExpress.XtraEditors.PopupContainerControl = Nothing

			Select Case _ControlType

				Case Type.EmployeeSelection

                    Control = New AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl
                    CType(Control, AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl).ControlType = AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl.Type.Employee

                Case Type.ClientContactSelection

                    Control = New AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl
                    CType(Control, AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl).ControlType = AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl.Type.ClientContact
                    CType(Control, AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl).ValueMemberColumn = AdvantageFramework.Database.Entities.ClientContact.Properties.ContactCode.ToString

            End Select

			FinalizePopupControl(Control)

		End Sub
		Protected Sub FinalizePopupControl(ByVal MainControl As System.Windows.Forms.Control)

			'objects
			Dim PopupContainerControl As DevExpress.XtraEditors.PopupContainerControl = Nothing

			If MainControl IsNot Nothing Then

				Me.PopupControl = Nothing

				PopupContainerControl = New DevExpress.XtraEditors.PopupContainerControl

				CType(PopupContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()

				PopupContainerControl.Padding = New System.Windows.Forms.Padding(5)
				PopupContainerControl.Name = "PopupContainerControl_Main"
				PopupContainerControl.Size = New System.Drawing.Size(500, 300)
				PopupContainerControl.TabIndex = 0

				PopupContainerControl.Controls.Add(MainControl)

				MainControl.Size = New System.Drawing.Size(PopupContainerControl.Size.Width, PopupContainerControl.Size.Height)
				MainControl.Dock = Windows.Forms.DockStyle.Fill
				MainControl.Name = "Control_Main"
				MainControl.TabIndex = 0

				Me.PopupControl = PopupContainerControl

				CType(PopupContainerControl, System.ComponentModel.ISupportInitialize).EndInit()

			End If

		End Sub
		Private Function LoadEditValueList(ByVal PopupContainerEdit As DevExpress.XtraEditors.PopupContainerEdit) As IEnumerable

			'objects
			Dim SelectedObjectCodes As Generic.List(Of String) = Nothing

			Try

				If PopupContainerEdit.EditValue IsNot Nothing Then

					If TypeOf PopupContainerEdit.EditValue Is String Then

						If String.IsNullOrEmpty(PopupContainerEdit.EditValue) = False Then

							SelectedObjectCodes = DirectCast(PopupContainerEdit.EditValue, String).Replace(" ", "").Split(",").ToList

						End If

					End If

				End If

			Catch ex As Exception
				SelectedObjectCodes = Nothing
			Finally
				LoadEditValueList = SelectedObjectCodes
			End Try

		End Function
		Private Function LoadDefaultAvailableObjects() As IEnumerable

			'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

			'	Select Case _ControlType

			'		Case Type.EmployeeSelection

			'			LoadDefaultAvailableObjects = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

			'		Case Type.ClientContactSelection

			'			LoadDefaultAvailableObjects = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext).ToList

			'		Case Else

			LoadDefaultAvailableObjects = Nothing

			'	End Select

			'End Using

		End Function

#Region "  Control Event Handlers "

		Private Sub SubItemPopupEditControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

			If e.KeyCode = Windows.Forms.Keys.F4 Then

				_CancelPopup = False

			ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then

				'If TypeOf sender Is DevExpress.XtraEditors.GridLookUpEdit Then

				'    GridLookUpEdit = DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit)

				'    GridLookUpEdit.SelectAll()

				'    If GridLookUpEdit.Properties.AllowNullInput <> DevExpress.Utils.DefaultBoolean.False Then

				'        GridLookUpEdit.EditValue = Nothing

				'    End If

				'End If

			ElseIf e.KeyCode = Windows.Forms.Keys.Escape Then

				'DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue = DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).OldEditValue

			Else

				_CancelPopup = True

			End If

		End Sub
		Private Sub SubItemPopupEditControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

			If e.Button = Windows.Forms.MouseButtons.Left Then

				_CancelPopup = False

			End If

		End Sub
		Private Sub SubItemPopupEditControl_ParseEditValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue



		End Sub
		Private Sub SubItemPopupEditControl_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.QueryPopUp

			Select Case _ControlType

				Case Type.EmployeeSelection

					MultiSelectControl_QueryPopUp(sender, e)

				Case Type.ClientContactSelection

					MultiSelectControl_QueryPopUp(sender, e)

			End Select

		End Sub
		Private Sub SubItemPopupEditControl_QueryResultValue(sender As Object, e As DevExpress.XtraEditors.Controls.QueryResultValueEventArgs) Handles Me.QueryResultValue

			Select Case _ControlType

				Case Type.EmployeeSelection

					MultiSelectControl_QueryResultValue(sender, e)

				Case Type.ClientContactSelection

					MultiSelectControl_QueryResultValue(sender, e)

			End Select

		End Sub

#End Region

#Region " Popup Container w/ Multi Selection Control "

		Private Sub MultiSelectControl_QueryPopUp(sender As Object, e As Object)

			'objects
			Dim AvailableObjects As IEnumerable = Nothing
			Dim SelectedObjects As IEnumerable = Nothing
			Dim OverrideDefaultSource As Boolean = False

			RaiseEvent QueryPopupNeedAvailableCodes(AvailableObjects, OverrideDefaultSource)

			If OverrideDefaultSource = False Then

				AvailableObjects = LoadDefaultAvailableObjects()

			End If

			SelectedObjects = LoadEditValueList(sender)

            CType(Me.PopupControl.Controls(0), AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl).ClearControl()
            CType(Me.PopupControl.Controls(0), AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl).LoadControl(AvailableObjects, SelectedObjects)

        End Sub
		Private Sub MultiSelectControl_QueryResultValue(sender As Object, e As Object)

            'objects
            Dim MultiSelectControl As AdvantageFramework.WinForm.Presentation.Controls.MultiSelectControl = Nothing

            Try

				MultiSelectControl = DirectCast(sender, DevExpress.XtraEditors.PopupContainerEdit).Properties.PopupControl.Controls(0)

				If MultiSelectControl IsNot Nothing Then

					e.Value = MultiSelectControl.SelectedObjectsCodeString

				End If

			Catch ex As Exception

			End Try

		End Sub

#End Region

#End Region

	End Class

End Namespace
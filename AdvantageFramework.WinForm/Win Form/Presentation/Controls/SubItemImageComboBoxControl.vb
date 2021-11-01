Namespace WinForm.Presentation.Controls

    Public Class SubItemImageComboBox
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            [Default]
            DocumentType
            EmployeeTimeFlag
            TaskStatus
        End Enum

#End Region

#Region " Variables "

        Protected _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Protected _ControlType As SubItemImageComboBox.Type = SubItemImageComboBox.Type.Default
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ImageCollection As DevExpress.Utils.ImageCollection = Nothing

#End Region

#Region " Properties "

        Public Property DbContext() As AdvantageFramework.Database.DbContext
            Get
                DbContext = _DbContext
            End Get
            Set(ByVal value As AdvantageFramework.Database.DbContext)
                _DbContext = value
            End Set
        End Property
        Public Property ControlType() As SubItemImageComboBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemImageComboBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Overrides Function Equals(obj As Object) As Boolean
            Return MyBase.Equals(obj)
        End Function

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

            _ImageCollection = New DevExpress.Utils.ImageCollection

            _ImageCollection.ImageSize = New System.Drawing.Size(16, 16)

            Me.SmallImages = _ImageCollection

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case SubItemImageComboBox.Type.Default



                Case SubItemImageComboBox.Type.DocumentType

                    SubItemImageComboBox_DocumentType()

                Case SubItemImageComboBox.Type.EmployeeTimeFlag

                    SubItemImageComboBox_EmployeeTimeFlags()

                Case SubItemImageComboBox.Type.TaskStatus

                    SubItemImageComboBox_TaskStatus()

            End Select

        End Sub

#Region "  Control Event Handlers "


#End Region

#Region "  Custom Control Event Handlers "

#Region "  Document Types "

        Protected Sub SubItemImageComboBox_DocumentType()

            Dim ImageComboBoxItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = Nothing
            Dim ImageIndex As Short = Nothing

            If _ImageCollection IsNot Nothing Then

                _ImageCollection.Images.Clear()

                ImageIndex = 0

                For Each FileType In System.Enum.GetValues(GetType(AdvantageFramework.FileSystem.FileTypes))

                    ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem

                    _ImageCollection.AddImage(AdvantageFramework.FileSystem.GetFileImage(FileType), FileType.ToString)

                    ImageComboBoxItem.Value = FileType
                    ImageComboBoxItem.ImageIndex = ImageIndex

                    Me.Items.Add(ImageComboBoxItem)

                    ImageIndex = ImageIndex + 1

                Next

                Me.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            End If

        End Sub

#End Region

#Region "  Employee Time Flags "

        Protected Sub SubItemImageComboBox_EmployeeTimeFlags()

            Dim ImageComboBoxItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = Nothing
            Dim ImageIndex As Short = Nothing
            Dim TimeFlagImage As Object = Nothing

            If _ImageCollection IsNot Nothing Then

                _ImageCollection.Images.Clear()

                ImageIndex = 0

                For Each TimeFlag In System.Enum.GetValues(GetType(AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags))

                    ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem

                    Select Case TimeFlag

                        Case AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Billed

                            TimeFlagImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.JobProcessControlIcon, 16, 16).ToBitmap

                        Case AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect

                            TimeFlagImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.EmployeeIcon, 16, 16).ToBitmap

                        Case AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled

                            TimeFlagImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.JobJacketIcon, 16, 16).ToBitmap

                        Case AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.SelectedForBilling

                            TimeFlagImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.JobJacketAlertIcon, 16, 16).ToBitmap

                    End Select

                    _ImageCollection.AddImage(TimeFlagImage, TimeFlag.ToString)

                    ImageComboBoxItem.Description = TimeFlag.ToString
                    ImageComboBoxItem.Value = CInt(TimeFlag)
                    ImageComboBoxItem.ImageIndex = ImageIndex

                    Me.Items.Add(ImageComboBoxItem)

                    ImageIndex = ImageIndex + 1

                Next

                Me.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
                Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            End If

        End Sub

#End Region

#Region "  Task Status "

        Protected Sub SubItemImageComboBox_TaskStatus()

            Dim ImageComboBoxItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = Nothing
            Dim ImageIndex As Short = Nothing
            Dim StatusImage As Object = Nothing

            If _ImageCollection IsNot Nothing Then

                _ImageCollection.Images.Clear()

                ImageIndex = 0

                For Each TaskStatus In System.Enum.GetValues(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))

                    ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem

                    Select Case TaskStatus

                        Case AdvantageFramework.ProjectSchedule.TaskStatus.Active

                            StatusImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.LightBulbOnIcon, 16, 16).ToBitmap

                        Case AdvantageFramework.ProjectSchedule.TaskStatus.HighPriority

                            StatusImage = AdvantageFramework.My.Resources.SmallPriorityHighImage

                        Case AdvantageFramework.ProjectSchedule.TaskStatus.LowPriority

                            StatusImage = AdvantageFramework.My.Resources.SmallPriorityLowImage

                        Case AdvantageFramework.ProjectSchedule.TaskStatus.Projected

                            StatusImage = New System.Drawing.Icon(AdvantageFramework.My.Resources.LightBulbIcon, 16, 16).ToBitmap

                    End Select

                    _ImageCollection.AddImage(StatusImage, TaskStatus.ToString)

                    ImageComboBoxItem.Description = AdvantageFramework.StringUtilities.GetNameAsWords(TaskStatus.ToString)
                    ImageComboBoxItem.Value = AdvantageFramework.EnumUtilities.LoadEnumObject(TaskStatus).Code
                    ImageComboBoxItem.ImageIndex = ImageIndex

                    Me.Items.Add(ImageComboBoxItem)

                    ImageIndex = ImageIndex + 1

                Next

                Me.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near
                Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
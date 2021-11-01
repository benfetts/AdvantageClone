Namespace WinForm.Presentation.Controls

    Public Class LocationControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _LocationID As String = Nothing
        Private _AgencyImportPath As String = ""
        Private _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim AdvTreeParentNode As DevComponents.AdvTree.Node = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                            If _IsAgencyASP Then

                                _AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                            End If

                        End Using

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxRightSection_ID.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.ID)
                            TextBoxRightSection_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.Name)
                            TextBoxRightSection_Email.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.Email)
                            TextBoxRightSection_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.Phone)
                            TextBoxRightSection_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.Fax)
                            AddressControlRightSection_Address.SetStreetPropertySettings(DataContext, AdvantageFramework.Database.Entities.Location.Properties.Address)
                            AddressControlRightSection_Address.SetAddress2PropertySettings(DataContext, AdvantageFramework.Database.Entities.Location.Properties.Address2)
                            AddressControlRightSection_Address.SetCityPropertySettings(DataContext, AdvantageFramework.Database.Entities.Location.Properties.City)
                            AddressControlRightSection_Address.SetStatePropertySettings(DataContext, AdvantageFramework.Database.Entities.Location.Properties.State)
                            AddressControlRightSection_Address.SetZipPropertySettings(DataContext, AdvantageFramework.Database.Entities.Location.Properties.Zip)

                            TextBoxHeaderLogoSelection_Portrait.ControlType = TextBox.Type.Default
                            TextBoxHeaderLogoSelection_Landscape.ControlType = TextBox.Type.Default

                            TextBoxFooterLogoSelection_Portrait.ControlType = TextBox.Type.Default
                            TextBoxFooterLogoSelection_Landscape.ControlType = TextBox.Type.Default

                            TextBoxHeaderLogoSelection_Portrait.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.LogoPath)
                            TextBoxHeaderLogoSelection_Landscape.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.LogoLandscapePath)

                            TextBoxFooterLogoSelection_Portrait.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.FooterLogoPath)
                            TextBoxFooterLogoSelection_Landscape.SetPropertySettings(AdvantageFramework.Database.Entities.Location.Properties.FooterLogoLandscape)

                            TextBoxHeaderLogoSelection_Portrait.ReadOnly = True
                            TextBoxHeaderLogoSelection_Landscape.ReadOnly = True

                            TextBoxFooterLogoSelection_Portrait.ReadOnly = True
                            TextBoxFooterLogoSelection_Landscape.ReadOnly = True

                            TextBoxHeaderLogoSelection_Portrait.ButtonCustom.Visible = False
                            TextBoxHeaderLogoSelection_Landscape.ButtonCustom.Visible = False

                            TextBoxFooterLogoSelection_Portrait.ButtonCustom.Visible = False
                            TextBoxFooterLogoSelection_Landscape.ButtonCustom.Visible = False

                            AddressControlRightSection_Address.DisableCountry = True
                            AddressControlRightSection_Address.DisableCounty = True

                            For Each AdvTreeParentNode In AdvTreeInformation_PrintSpecs.Nodes

                                AdvTreeParentNode.CheckBoxVisible = True

                                For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.LocationPrintInformation))

                                    Node = New DevComponents.AdvTree.Node

                                    Node.Text = EnumObject.Description

                                    Node.Name = EnumObject.Code

                                    Node.CheckBoxVisible = True
                                    Node.Checked = False

                                    AdvTreeParentNode.Nodes.Add(Node)

                                Next

                            Next

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadThumnailLogo(ByVal ImageLocation As String, ByVal PictureBox As System.Windows.Forms.PictureBox)

            If ImageLocation <> "" Then

                Try

                    PictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom
                    PictureBox.Image = System.Drawing.Image.FromFile(ImageLocation)
                    PictureBox.Tag = ImageLocation

                Catch ex As Exception

                    PictureBox.Image = AdvantageFramework.My.Resources.PreviewNotAvailable
                    PictureBox.Tag = Nothing

                End Try

            Else

                PictureBox.Image = Nothing
                PictureBox.Tag = Nothing

            End If

        End Sub
        Private Sub LoadThumnailLogo(Image As Byte(), ByVal PictureBox As System.Windows.Forms.PictureBox)

            If Image IsNot Nothing Then

                Try

                    PictureBox.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom

                    Using MemoryStream = New System.IO.MemoryStream(Image)

                        Using ImageFromStream = System.Drawing.Image.FromStream(MemoryStream)

                            PictureBox.Image = New System.Drawing.Bitmap(ImageFromStream)

                        End Using

                    End Using

                    PictureBox.Tag = Image

                Catch ex As Exception

                    PictureBox.Image = AdvantageFramework.My.Resources.PreviewNotAvailable
                    PictureBox.Tag = Nothing

                End Try

            Else

                PictureBox.Image = Nothing
                PictureBox.Tag = Nothing

            End If

        End Sub
        Private Sub LoadLocationEntity(ByVal Location As AdvantageFramework.Database.Entities.Location)

            Dim HeaderNode As DevComponents.AdvTree.Node = Nothing
            Dim FooterNode As DevComponents.AdvTree.Node = Nothing
            Dim AdvTreeNode As DevComponents.AdvTree.Node = Nothing

            If Location IsNot Nothing Then

                Location.ID = TextBoxRightSection_ID.Text
                Location.Name = TextBoxRightSection_Name.Text
                Location.Email = TextBoxRightSection_Email.Text
                Location.Fax = TextBoxRightSection_Fax.Text
                Location.Phone = TextBoxRightSection_Phone.Text

                Location.Address = AddressControlRightSection_Address.Address
                Location.Address2 = AddressControlRightSection_Address.Address2
                Location.City = AddressControlRightSection_Address.City
                Location.State = AddressControlRightSection_Address.State
                Location.Zip = AddressControlRightSection_Address.Zip

                HeaderNode = AdvTreeInformation_PrintSpecs.Nodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) Node.Name = "NodePrintSpecs_PrintHeader").SingleOrDefault
                FooterNode = AdvTreeInformation_PrintSpecs.Nodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) Node.Name = "NodePrintSpecs_PrintFooter").SingleOrDefault

                Location.PrintHeader = Convert.ToInt16(HeaderNode.Checked)
                Location.PrintFooter = Convert.ToInt16(FooterNode.Checked)

                For Each AdvTreeNode In HeaderNode.Nodes

                    If AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Street.ToString Then

                        Location.PrintAddressHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.POBox.ToString Then

                        Location.PrintAddress2Header = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.City.ToString Then

                        Location.PrintCityHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.State.ToString Then

                        Location.PrintStateHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Zip.ToString Then

                        Location.PrintZipHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Phone.ToString Then

                        Location.PrintPhoneHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Fax.ToString Then

                        Location.PrintFaxHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Email.ToString Then

                        Location.PrintEmailHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Name.ToString Then

                        Location.PrintNameHeader = Convert.ToInt16(AdvTreeNode.Checked)

                    End If

                Next

                For Each AdvTreeNode In FooterNode.Nodes

                    If AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Street.ToString Then

                        Location.PrintAddressFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.POBox.ToString Then

                        Location.PrintAddress2Footer = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.City.ToString Then

                        Location.PrintCityFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.State.ToString Then

                        Location.PrintStateFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Zip.ToString Then

                        Location.PrintZipFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Phone.ToString Then

                        Location.PrintPhoneFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Fax.ToString Then

                        Location.PrintFaxFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Email.ToString Then

                        Location.PrintEmailFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Name.ToString Then

                        Location.PrintNameFooter = Convert.ToInt16(AdvTreeNode.Checked)

                    End If

                Next

                Location.LogoLandscapePath = TextBoxHeaderLogoSelection_Landscape.Text
                Location.LogoPath = TextBoxHeaderLogoSelection_Portrait.Text

                If RadioButtonControlHeaderLogoSelection_Hide.Checked Then

                    Location.LogoLocation = "N"

                Else

                    Location.LogoLocation = "C"

                End If

                Location.FooterLogoLandscape = TextBoxFooterLogoSelection_Landscape.Text
                Location.FooterLogoPath = TextBoxFooterLogoSelection_Portrait.Text

                If RadioButtonControlFooterLogoSelection_Hide.Checked Then

                    Location.FooterLogoLocation = "N"

                Else

                    Location.FooterLogoLocation = "C"

                End If

            End If

        End Sub
        Private Function DeleteLocationLogo(LocationLogoType As AdvantageFramework.Database.Entities.LocationLogoTypes) As Boolean

            'objects
            Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, LocationLogoType)

                    If LocationLogo IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.LocationLogo.Delete(DbContext, LocationLogo)

                    End If

                End Using

            Catch ex As Exception
                Deleted = False
            End Try

            DeleteLocationLogo = Deleted

        End Function
        Private Function SelectFile() As String

            'objects
            Dim File As String = String.Empty
            Dim Files() As String = Nothing

            If _IsAgencyASP Then

                AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyImportPath, Nothing, False, Files)

                If Files IsNot Nothing AndAlso Files.Count > 0 Then

                    Try

                        File = Files(0)

                    Catch ex As Exception
                        File = ""
                    End Try

                End If

            Else

                File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", , "Select Image")

            End If

            SelectFile = File

        End Function
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal LocationID As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
            Dim HeaderNode As DevComponents.AdvTree.Node = Nothing
            Dim FooterNode As DevComponents.AdvTree.Node = Nothing
            Dim AdvTreeNode As DevComponents.AdvTree.Node = Nothing

            _LocationID = LocationID

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If _LocationID <> "" Then

                    TextBoxRightSection_ID.Enabled = False

                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, _LocationID)

                    If Location IsNot Nothing Then

                        TextBoxRightSection_ID.Text = Location.ID
                        TextBoxRightSection_Name.Text = Location.Name
                        TextBoxRightSection_Email.Text = Location.Email
                        TextBoxRightSection_Fax.Text = Location.Fax
                        TextBoxRightSection_Phone.Text = Location.Phone

                        AddressControlRightSection_Address.Address = Location.Address
                        AddressControlRightSection_Address.Address2 = Location.Address2
                        AddressControlRightSection_Address.City = Location.City
                        AddressControlRightSection_Address.State = Location.State
                        AddressControlRightSection_Address.Zip = Location.Zip

                        HeaderNode = AdvTreeInformation_PrintSpecs.Nodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) Node.Name = "NodePrintSpecs_PrintHeader").SingleOrDefault
                        FooterNode = AdvTreeInformation_PrintSpecs.Nodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) Node.Name = "NodePrintSpecs_PrintFooter").SingleOrDefault

                        HeaderNode.Checked = Convert.ToBoolean(Location.PrintHeader.GetValueOrDefault(0))
                        FooterNode.Checked = Convert.ToBoolean(Location.PrintFooter.GetValueOrDefault(0))

                        For Each AdvTreeNode In HeaderNode.Nodes

                            If AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Street.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintAddressHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.POBox.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintAddress2Header.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.City.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintCityHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.State.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintStateHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Zip.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintZipHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Phone.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintPhoneHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Fax.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintFaxHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Email.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintEmailHeader.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Name.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintNameHeader.GetValueOrDefault(0))

                            End If

                            AdvTreeNode.Enabled = HeaderNode.Checked

                        Next

                        For Each AdvTreeNode In FooterNode.Nodes

                            If AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Street.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintAddressFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.POBox.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintAddress2Footer.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.City.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintCityFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.State.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintStateFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Zip.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintZipFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Phone.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintPhoneFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Fax.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintFaxFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Email.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintEmailFooter.GetValueOrDefault(0))

                            ElseIf AdvTreeNode.Name = AdvantageFramework.Database.Entities.LocationPrintInformation.Name.ToString Then

                                AdvTreeNode.Checked = Convert.ToBoolean(Location.PrintNameFooter.GetValueOrDefault(0))

                            End If

                            AdvTreeNode.Enabled = FooterNode.Checked

                        Next

                        TextBoxHeaderLogoSelection_Landscape.Text = Location.LogoLandscapePath
                        TextBoxHeaderLogoSelection_Portrait.Text = Location.LogoPath

                        RadioButtonControlHeaderLogoSelection_Hide.Checked = If(Location.LogoLocation = "N", True, False)
                        RadioButtonControlHeaderLogoSelection_Show.Checked = If(Location.LogoLocation = "C" OrElse Not RadioButtonControlHeaderLogoSelection_Hide.Checked, True, False)

                        TextBoxFooterLogoSelection_Landscape.Text = Location.FooterLogoLandscape
                        TextBoxFooterLogoSelection_Portrait.Text = Location.FooterLogoPath

                        RadioButtonControlFooterLogoSelection_Hide.Checked = If(Location.FooterLogoLocation = "N", True, False)
                        RadioButtonControlFooterLogoSelection_Show.Checked = If(Location.FooterLogoLocation = "C" OrElse Not RadioButtonControlFooterLogoSelection_Hide.Checked, True, False)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If String.IsNullOrWhiteSpace(TextBoxHeaderLogoSelection_Portrait.Text) Then

                                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                                If LocationLogo IsNot Nothing Then

                                    LoadThumnailLogo(LocationLogo.Image, PictureBoxHeaderLogoSelection_Portrait)

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(TextBoxHeaderLogoSelection_Landscape.Text) Then

                                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape)

                                If LocationLogo IsNot Nothing Then

                                    LoadThumnailLogo(LocationLogo.Image, PictureBoxHeaderLogoSelection_Landscape)

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(TextBoxFooterLogoSelection_Portrait.Text) Then

                                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.FooterPortrait)

                                If LocationLogo IsNot Nothing Then

                                    LoadThumnailLogo(LocationLogo.Image, PictureBoxFooterLogoSelection_Portrait)

                                End If

                            End If

                            If String.IsNullOrWhiteSpace(TextBoxFooterLogoSelection_Landscape.Text) Then

                                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, AdvantageFramework.Database.Entities.LocationLogoTypes.FooterLandscape)

                                If LocationLogo IsNot Nothing Then

                                    LoadThumnailLogo(LocationLogo.Image, PictureBoxFooterLogoSelection_Landscape)

                                End If

                            End If

                        End Using

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxRightSection_ID.Enabled = True
                    RadioButtonControlHeaderLogoSelection_Show.Checked = True
                    RadioButtonControlFooterLogoSelection_Show.Checked = True

                    For Each AdvTreeNode In AdvTreeInformation_PrintSpecs.Nodes

                        For Each AdvTreeChildNode In AdvTreeNode.Nodes.OfType(Of DevComponents.AdvTree.Node)()

                            AdvTreeChildNode.Enabled = False

                        Next

                    Next

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean, ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.Location

            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

            Try

                If IsNew Then

                    Location = New AdvantageFramework.Database.Entities.Location

                    LoadLocationEntity(Location)

                Else

                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, _LocationID)

                    If Location IsNot Nothing Then

                        LoadLocationEntity(Location)

                    End If


                End If

            Catch ex As Exception
                Location = Nothing
            End Try

            FillObject = Location

        End Function
        Public Sub ClearControl()

            TextBoxRightSection_ID.Text = ""
            TextBoxRightSection_Name.Text = ""
            TextBoxRightSection_Email.Text = ""
            TextBoxRightSection_Phone.Text = ""
            TextBoxRightSection_Fax.Text = ""
            TextBoxHeaderLogoSelection_Landscape.Text = ""
            TextBoxHeaderLogoSelection_Portrait.Text = ""
            TextBoxFooterLogoSelection_Landscape.Text = ""
            TextBoxFooterLogoSelection_Portrait.Text = ""
            PictureBoxFooterLogoSelection_Landscape.Image = Nothing
            PictureBoxFooterLogoSelection_Portrait.Image = Nothing
            PictureBoxHeaderLogoSelection_Landscape.Image = Nothing
            PictureBoxHeaderLogoSelection_Portrait.Image = Nothing

            For Each Node In AdvTreeInformation_PrintSpecs.SelectedNodes

                CType(Node, DevComponents.AdvTree.Node).Checked = False

                For Each ChildNode In Node.Nodes

                    CType(ChildNode, DevComponents.AdvTree.Node).Enabled = False
                    CType(ChildNode, DevComponents.AdvTree.Node).Checked = False

                Next

            Next

            AddressControlRightSection_Address.ClearControl()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub Save()

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Location = Me.FillObject(False, DataContext)

                    If Location IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Location.Update(DataContext, Location) Then

                            If TextBoxHeaderLogoSelection_Landscape.Text = String.Empty Then

                                SaveLocationLogo(Database.Entities.LocationLogoTypes.HeaderLandscape, PictureBoxHeaderLogoSelection_Landscape)

                            End If

                            If TextBoxHeaderLogoSelection_Portrait.Text = String.Empty Then

                                SaveLocationLogo(Database.Entities.LocationLogoTypes.HeaderPortrait, PictureBoxHeaderLogoSelection_Portrait)

                            End If

                            If TextBoxFooterLogoSelection_Landscape.Text = String.Empty Then

                                SaveLocationLogo(Database.Entities.LocationLogoTypes.FooterLandscape, PictureBoxFooterLogoSelection_Landscape)

                            End If

                            If TextBoxFooterLogoSelection_Portrait.Text = String.Empty Then

                                SaveLocationLogo(Database.Entities.LocationLogoTypes.FooterPortrait, PictureBoxFooterLogoSelection_Portrait)

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub SaveLocationLogo(LocationLogoType As AdvantageFramework.Database.Entities.LocationLogoTypes, PictureBox As System.Windows.Forms.PictureBox)

            'objects
            Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _LocationID, LocationLogoType)

                If PictureBox.Tag IsNot Nothing Then

                    If LocationLogo Is Nothing Then

                        LocationLogo = New AdvantageFramework.Database.Entities.LocationLogo

                        LocationLogo.LocationID = _LocationID
                        LocationLogo.LocationLogoTypeID = LocationLogoType
                        LocationLogo.Image = AdvantageFramework.Images.ImageToByteArray(PictureBox.Image, System.Drawing.Imaging.ImageFormat.Bmp)
                        LocationLogo.Thumbnail = Nothing
                        LocationLogo.IsActive = True
                        LocationLogo.CreateDate = Now
                        LocationLogo.UserCode = _Session.UserCode

                        AdvantageFramework.Database.Procedures.LocationLogo.Insert(DbContext, LocationLogo)

                    Else

                        LocationLogo.Image = AdvantageFramework.Images.ImageToByteArray(PictureBox.Image, System.Drawing.Imaging.ImageFormat.Bmp)
                        LocationLogo.Thumbnail = Nothing
                        LocationLogo.IsActive = True

                        AdvantageFramework.Database.Procedures.LocationLogo.Update(DbContext, LocationLogo)

                    End If

                Else

                    If LocationLogo IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.LocationLogo.Delete(DbContext, LocationLogo)

                    End If

                End If

            End Using

        End Sub
        Public Sub Insert(ByRef LocationID As String)

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Location = Me.FillObject(True, DataContext)

                    If Location IsNot Nothing Then

                        Location.DataContext = DataContext

                        If AdvantageFramework.Database.Procedures.Location.Insert(DataContext, Location) Then

                            LocationID = Location.ID

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Delete()

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Location = Me.FillObject(False, DataContext)

                    If Location IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Location.Delete(DataContext, Location) = False Then

                            ErrorMessage = "The location is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LocationControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'TextBoxHeaderLogoSelection_Portrait.ButtonCustom2.Visible = True
            'TextBoxHeaderLogoSelection_Portrait.ButtonCustom2.Image = AdvantageFramework.My.Resources.SmallDetailDeleteImage

            'TextBoxHeaderLogoSelection_Landscape.ButtonCustom2.Visible = True
            'TextBoxHeaderLogoSelection_Landscape.ButtonCustom2.Image = AdvantageFramework.My.Resources.SmallDetailDeleteImage

            'TextBoxFooterLogoSelection_Portrait.ButtonCustom2.Visible = True
            'TextBoxFooterLogoSelection_Portrait.ButtonCustom2.Image = AdvantageFramework.My.Resources.SmallDetailDeleteImage

            'TextBoxFooterLogoSelection_Landscape.ButtonCustom2.Visible = True
            'TextBoxFooterLogoSelection_Landscape.ButtonCustom2.Image = AdvantageFramework.My.Resources.SmallDetailDeleteImage

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TextBoxHeaderLogoSelection_Portrait_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxHeaderLogoSelection_Portrait.TextChanged

            LoadThumnailLogo(TextBoxHeaderLogoSelection_Portrait.Text, PictureBoxHeaderLogoSelection_Portrait)

        End Sub
        Private Sub TextBoxHeaderLogoSelection_Landscape_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxHeaderLogoSelection_Landscape.TextChanged

            LoadThumnailLogo(TextBoxHeaderLogoSelection_Landscape.Text, PictureBoxHeaderLogoSelection_Landscape)

        End Sub
        Private Sub TextBoxFooterLogoSelection_Portrait_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxFooterLogoSelection_Portrait.TextChanged

            LoadThumnailLogo(TextBoxFooterLogoSelection_Portrait.Text, PictureBoxFooterLogoSelection_Portrait)

        End Sub
        Private Sub TextBoxFooterLogoSelection_Landscape_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxFooterLogoSelection_Landscape.TextChanged

            LoadThumnailLogo(TextBoxFooterLogoSelection_Landscape.Text, PictureBoxFooterLogoSelection_Landscape)

        End Sub
        Private Sub AdvTreeInformation_PrintSpecs_AfterCheck(sender As Object, e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles AdvTreeInformation_PrintSpecs.AfterCheck

            'objects
            Dim ParentNode As DevComponents.AdvTree.Node = Nothing
            Dim ChildNode As DevComponents.AdvTree.Node = Nothing

            For Each ParentNode In AdvTreeInformation_PrintSpecs.Nodes.OfType(Of DevComponents.AdvTree.Node).Where(Function(Node) Node.Nodes.Count > 0)

                For Each ChildNode In ParentNode.Nodes

                    ChildNode.Enabled = ParentNode.Checked

                Next

            Next

        End Sub
        Private Sub TextBoxFooterLogoSelection_Landscape_ButtonCustom2Click(sender As Object, e As EventArgs) Handles TextBoxFooterLogoSelection_Landscape.ButtonCustom2Click

            TextBoxFooterLogoSelection_Landscape.Text = Nothing

        End Sub
        Private Sub TextBoxFooterLogoSelection_Portrait_ButtonCustom2Click(sender As Object, e As EventArgs) Handles TextBoxFooterLogoSelection_Portrait.ButtonCustom2Click

            TextBoxFooterLogoSelection_Portrait.Text = Nothing

        End Sub
        Private Sub TextBoxHeaderLogoSelection_Landscape_ButtonCustom2Click(sender As Object, e As EventArgs) Handles TextBoxHeaderLogoSelection_Landscape.ButtonCustom2Click

            TextBoxHeaderLogoSelection_Landscape.Text = Nothing

        End Sub
        Private Sub TextBoxHeaderLogoSelection_Portrait_ButtonCustom2Click(sender As Object, e As EventArgs) Handles TextBoxHeaderLogoSelection_Portrait.ButtonCustom2Click

            TextBoxHeaderLogoSelection_Portrait.Text = Nothing

        End Sub
        Private Sub ButtonFooterLogo_LandscapeSelect_Click(sender As Object, e As EventArgs) Handles ButtonFooterLogo_LandscapeSelect.Click

            'objects
            Dim File As String = String.Empty

            File = SelectFile()

            If String.IsNullOrWhiteSpace(File) = False Then

                LoadThumnailLogo(File, PictureBoxFooterLogoSelection_Landscape)

                TextBoxFooterLogoSelection_Landscape.Text = String.Empty

                TextBoxFooterLogoSelection_Landscape.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonFooterLogo_LandscapeDelete_Click(sender As Object, e As EventArgs) Handles ButtonFooterLogo_LandscapeDelete.Click

            If PictureBoxFooterLogoSelection_Landscape.Image IsNot Nothing Then

                If String.IsNullOrWhiteSpace(TextBoxFooterLogoSelection_Landscape.Text) = False Then

                    TextBoxFooterLogoSelection_Landscape.Text = String.Empty

                    PictureBoxFooterLogoSelection_Landscape.Image = Nothing
                    PictureBoxFooterLogoSelection_Landscape.Tag = Nothing

                Else

                    PictureBoxFooterLogoSelection_Landscape.Image = Nothing
                    PictureBoxFooterLogoSelection_Landscape.Tag = Nothing

                End If

                TextBoxFooterLogoSelection_Landscape.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonFooterLogo_PortraitSelect_Click(sender As Object, e As EventArgs) Handles ButtonFooterLogo_PortraitSelect.Click

            'objects
            Dim File As String = String.Empty

            File = SelectFile()

            If String.IsNullOrWhiteSpace(File) = False Then

                LoadThumnailLogo(File, PictureBoxFooterLogoSelection_Portrait)

                TextBoxFooterLogoSelection_Portrait.Text = String.Empty

                TextBoxFooterLogoSelection_Portrait.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonFooterLogo_PortraitDelete_Click(sender As Object, e As EventArgs) Handles ButtonFooterLogo_PortraitDelete.Click

            If PictureBoxFooterLogoSelection_Portrait.Image IsNot Nothing Then

                If String.IsNullOrWhiteSpace(TextBoxFooterLogoSelection_Portrait.Text) = False Then

                    TextBoxFooterLogoSelection_Portrait.Text = String.Empty

                    PictureBoxFooterLogoSelection_Portrait.Image = Nothing
                    PictureBoxFooterLogoSelection_Portrait.Tag = Nothing

                Else

                    PictureBoxFooterLogoSelection_Portrait.Image = Nothing
                    PictureBoxFooterLogoSelection_Portrait.Tag = Nothing

                End If

                TextBoxFooterLogoSelection_Portrait.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonHeaderLogo_LandscapeSelect_Click(sender As Object, e As EventArgs) Handles ButtonHeaderLogo_LandscapeSelect.Click

            'objects
            Dim File As String = String.Empty

            File = SelectFile()

            If String.IsNullOrWhiteSpace(File) = False Then

                LoadThumnailLogo(File, PictureBoxHeaderLogoSelection_Landscape)

                TextBoxHeaderLogoSelection_Landscape.Text = String.Empty

                TextBoxHeaderLogoSelection_Landscape.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonHeaderLogo_LandscapeDelete_Click(sender As Object, e As EventArgs) Handles ButtonHeaderLogo_LandscapeDelete.Click

            If PictureBoxHeaderLogoSelection_Landscape.Image IsNot Nothing Then

                If String.IsNullOrWhiteSpace(TextBoxHeaderLogoSelection_Landscape.Text) = False Then

                    TextBoxHeaderLogoSelection_Landscape.Text = String.Empty

                    PictureBoxHeaderLogoSelection_Landscape.Image = Nothing
                    PictureBoxHeaderLogoSelection_Landscape.Tag = Nothing

                Else

                    PictureBoxHeaderLogoSelection_Landscape.Image = Nothing
                    PictureBoxHeaderLogoSelection_Landscape.Tag = Nothing

                End If

                TextBoxHeaderLogoSelection_Landscape.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonHeaderLogo_PortraitSelect_Click(sender As Object, e As EventArgs) Handles ButtonHeaderLogo_PortraitSelect.Click

            'objects
            Dim File As String = String.Empty

            File = SelectFile()

            If String.IsNullOrWhiteSpace(File) = False Then

                LoadThumnailLogo(File, PictureBoxHeaderLogoSelection_Portrait)

                TextBoxHeaderLogoSelection_Portrait.Text = String.Empty

                TextBoxHeaderLogoSelection_Portrait.SetUserEntryChanged()

            End If

        End Sub
        Private Sub ButtonHeaderLogo_PortraitDelete_Click(sender As Object, e As EventArgs) Handles ButtonHeaderLogo_PortraitDelete.Click

            If PictureBoxHeaderLogoSelection_Portrait.Image IsNot Nothing Then

                If String.IsNullOrWhiteSpace(TextBoxHeaderLogoSelection_Portrait.Text) = False Then

                    TextBoxHeaderLogoSelection_Portrait.Text = String.Empty

                    PictureBoxHeaderLogoSelection_Portrait.Image = Nothing
                    PictureBoxHeaderLogoSelection_Portrait.Tag = Nothing

                Else

                    PictureBoxHeaderLogoSelection_Portrait.Image = Nothing
                    PictureBoxHeaderLogoSelection_Portrait.Tag = Nothing

                End If

                TextBoxHeaderLogoSelection_Portrait.SetUserEntryChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace

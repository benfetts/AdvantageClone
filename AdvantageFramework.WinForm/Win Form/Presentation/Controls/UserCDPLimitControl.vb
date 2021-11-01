Namespace WinForm.Presentation.Controls

    Public Class UserCDPLimitControl

        Public Event CDPsChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserCodes As Generic.List(Of String) = Nothing
        Private _IsControlClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property HasLimitedCDPs As Boolean
            Get
                HasLimitedCDPs = DataGridViewRightSection_SelectedCDPs.HasRows
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewLeftSection_AvailableCDPs.ClearDatasource(New Generic.List(Of AdvantageFramework.Security.Database.Classes.Product))
                        DataGridViewRightSection_SelectedCDPs.ClearDatasource(New Generic.List(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess))

                    End Using

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadCDPs()

            'objects
            Dim ClientDivisionProductList As Generic.List(Of AdvantageFramework.Security.Database.Classes.Product) = Nothing
            Dim Product As AdvantageFramework.Security.Database.Classes.Product = Nothing
            Dim AllClientDivisionProductAccessesList As Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)) = Nothing
            Dim AddClientDivisionProductAccess As Boolean = True
            Dim FinalClientDivisionProductAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess) = Nothing
            Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
            Dim ClientDivisionProductAccess As AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Security.Database.Classes.Product) = Nothing
            Dim AllUserClientDivisionProductAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UserCode As String = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim HasLimitedOfficeCodes As Boolean = False
            Dim AccessibleOfficeCodes As Generic.List(Of String) = Nothing
            Dim AllowTimeEntryOnly As Boolean = False
            'Dim StartTime As Date = Date.MinValue
            'Dim TotalTime As TimeSpan = TimeSpan.MinValue

            'StartTime = Now

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SecurityDbContext.Database.Connection.Open()
                    DbContext.Database.Connection.Open()

                    If _UserCodes IsNot Nothing AndAlso _UserCodes.Count > 0 Then

                        EmployeeCodes = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Where(Function(Entity) _UserCodes.Contains(Entity.UserCode)).Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList

                        'AllUserClientDivisionProductAccessesList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext).ToList

                        'AllUserClientDivisionProductAccessesList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess)

                        'For Each UserCode In _UserCodes

                        '    AllUserClientDivisionProductAccessesList.AddRange(AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList)

                        'Next

                        AllUserClientDivisionProductAccessesList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext).Where(Function(Entity) _UserCodes.Contains(Entity.UserCode)).ToList

                        'AllClientDivisionProductAccessesList = New Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess))

                        'For Each UserCode In _UserCodes

                        '    AllClientDivisionProductAccessesList.Add(AllUserClientDivisionProductAccessesList.Where(Function(UCDP) UCDP.UserCode = UserCode).ToList)

                        'Next

                        ClientDivisionProductList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.Product)

                        Try

                            HasLimitedOfficeCodes = SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_OFFICE WHERE EMP_CODE IN ('{0}')", Join(EmployeeCodes.ToArray, "', '"))).FirstOrDefault

                        Catch ex As Exception
                            HasLimitedOfficeCodes = False
                        End Try

                        Try

                            AccessibleOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT
		                                                                                                                    O.OFFICE_CODE
	                                                                                                                    FROM 
		                                                                                                                    [dbo].[EMPLOYEE] AS E CROSS JOIN 
		                                                                                                                    [dbo].[OFFICE] AS O LEFT OUTER JOIN 
		                                                                                                                    [dbo].[EMP_OFFICE] AS EO ON EO.EMP_CODE = E.EMP_CODE
	                                                                                                                    WHERE
		                                                                                                                    E.EMP_CODE IN ('{0}') AND
		                                                                                                                    (EO.OFFICE_CODE = O.OFFICE_CODE OR
		                                                                                                                     (O.OFFICE_CODE IS NOT NULL AND 
		                                                                                                                      EO.OFFICE_CODE IS NULL))", Join(EmployeeCodes.ToArray, "', '"))).ToList

                        Catch ex As Exception
                            AccessibleOfficeCodes = New Generic.List(Of String)
                        End Try

                        If AccessibleOfficeCodes IsNot Nothing Then

                            AccessibleOfficeCodes = AccessibleOfficeCodes.Distinct.ToList

                        End If

                        FinalClientDivisionProductAccessesList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess)

                        ProductList = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division").Include("CDPSecurityGroup").Include("CDPSecurityGroup.CDPSecurityGroupEmployees").
                                                Select(Function(Entity) New With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID,
                                                                                  .CDPSecurityGroupName = If(Entity.CDPSecurityGroup IsNot Nothing, Entity.CDPSecurityGroup.Name, String.Empty),
                                                                                  .CDPSecurityGroup = Entity.CDPSecurityGroup,
                                                                                  .OfficeCode = Entity.OfficeCode,
                                                                                  .OfficeName = Entity.Office.Name,
                                                                                  .ClientCode = Entity.ClientCode,
                                                                                  .ClientName = Entity.Client.Name,
                                                                                  .ClientIsActive = Entity.Client.IsActive,
                                                                                  .DivisionCode = Entity.DivisionCode,
                                                                                  .DivisionName = Entity.Division.Name,
                                                                                  .DivisionIsActive = Entity.Division.IsActive,
                                                                                  .ProductCode = Entity.Code,
                                                                                  .ProductName = Entity.Name,
                                                                                  .IsActive = Entity.IsActive}).ToList.
                                                Select(Function(Entity) New AdvantageFramework.Security.Database.Classes.Product With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID.GetValueOrDefault(0),
                                                                                                                                       .CDPSecurityGroupName = Entity.CDPSecurityGroupName,
                                                                                                                                       .CDPSecurityGroupEmployeeCodes = If(Entity.CDPSecurityGroup IsNot Nothing, Entity.CDPSecurityGroup.CDPSecurityGroupEmployees.Select(Function(CDPSecurityGroupEmployee) CDPSecurityGroupEmployee.EmployeeCode).ToArray, Nothing),
                                                                                                                                       .OfficeCode = Entity.OfficeCode,
                                                                                                                                       .OfficeName = Entity.OfficeName,
                                                                                                                                       .ClientCode = Entity.ClientCode,
                                                                                                                                       .ClientName = Entity.ClientName,
                                                                                                                                       .ClientActiveFlag = Entity.ClientIsActive,
                                                                                                                                       .DivisionCode = Entity.DivisionCode,
                                                                                                                                       .DivisionName = Entity.DivisionName,
                                                                                                                                       .DivisionActiveFlag = Entity.DivisionIsActive,
                                                                                                                                       .ProductCode = Entity.ProductCode,
                                                                                                                                       .ProductDescription = Entity.ProductName,
                                                                                                                                       .ProductActiveFlag = Entity.IsActive}).ToList

                        'ProductList = AdvantageFramework.Database.Procedures.ProductView.Load(DbContext).ToList

                        For Each Product In ProductList

                            AddClientDivisionProductAccess = True

                            For Each UserCode In _UserCodes

                                'UserClientDivisionProductAccess = Nothing

                                'Try

                                '    UserClientDivisionProductAccess = AllUserClientDivisionProductAccessesList.FirstOrDefault(Function(CDP) CDP.UserCode = UserCode AndAlso CDP.ProductCode = Product.ProductCode AndAlso CDP.ClientCode = Product.ClientCode AndAlso CDP.DivisionCode = Product.DivisionCode)

                                'Catch ex As Exception
                                '    UserClientDivisionProductAccess = Nothing
                                'End Try

                                If AllUserClientDivisionProductAccessesList.Any(Function(CDP) CDP.UserCode = UserCode _
                                                                                              AndAlso CDP.ProductCode = Product.ProductCode _
                                                                                              AndAlso CDP.ClientCode = Product.ClientCode _
                                                                                              AndAlso CDP.DivisionCode = Product.DivisionCode) = False Then

                                    AddClientDivisionProductAccess = False
                                    Exit For

                                    'ElseIf UserClientDivisionProductAccess.AllowTimeEntryOnly.GetValueOrDefault(0) = 0 Then

                                    '    AllowTimeEntryOnly = False
                                    '    'Exit For

                                End If

                                'If UserClientDivisionProductAccessesList.Any(Function(CDP) CDP.ProductCode = Product.ProductCode AndAlso CDP.ClientCode = Product.ClientCode AndAlso CDP.DivisionCode = Product.DivisionCode) = False Then

                                '    AddClientDivisionProductAccess = False
                                '    Exit For

                                'End If

                            Next

                            If AddClientDivisionProductAccess Then

                                AllowTimeEntryOnly = AllUserClientDivisionProductAccessesList.All(Function(CDP) CDP.ProductCode = Product.ProductCode AndAlso CDP.ClientCode = Product.ClientCode AndAlso CDP.DivisionCode = Product.DivisionCode AndAlso CDP.AllowTimeEntryOnly.GetValueOrDefault(0) = 1)

                                FinalClientDivisionProductAccessesList.Add(New AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess(Product, EmployeeCodes.ToArray) With {.AllowTimeEntryOnly = AllowTimeEntryOnly})

                            ElseIf HasLimitedOfficeCodes = False OrElse AccessibleOfficeCodes.Contains(Product.OfficeCode) Then

                                ClientDivisionProductList.Add(Product)

                            End If

                        Next

                        'For Each Product In ProductList

                        '    If FinalClientDivisionProductAccessesList.Any(Function(CDP) CDP.ProductCode = Product.ProductCode AndAlso CDP.ClientCode = Product.ClientCode AndAlso CDP.DivisionCode = Product.DivisionCode) = False AndAlso
                        '            (HasLimitedOfficeCodes = False OrElse AccessibleOfficeCodes.Contains(Product.OfficeCode)) Then

                        '        ClientDivisionProductList.Add(Product)

                        '    End If

                        'Next

                        'FinalClientDivisionProductAccessesList.ForEach(Sub(UCDPA As AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess)

                        '                                                   UCDPA.AllowTimeEntryOnly = True

                        '                                                   If AllUserClientDivisionProductAccessesList.Any(Function(UCDP) _UserCodes.Contains(UCDP.UserCode) = True AndAlso UCDP.ProductCode = UCDPA.ProductCode AndAlso
                        '                                                                                                                  UCDP.DivisionCode = UCDPA.DivisionCode AndAlso UCDP.ClientCode = UCDPA.ClientCode AndAlso
                        '                                                                                                                  (UCDP.AllowTimeEntryOnly Is Nothing OrElse UCDP.AllowTimeEntryOnly = 0)) Then

                        '                                                       UCDPA.AllowTimeEntryOnly = False

                        '                                                   End If

                        '                                               End Sub)

                        ButtonRightSection_AddCDP.Enabled = True
                        ButtonRightSection_RemoveCDP.Enabled = True

                    Else

                        FinalClientDivisionProductAccessesList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess)

                        ClientDivisionProductList = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division").Include("CDPSecurityGroup").
                                                              Select(Function(Entity) New With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID,
                                                                                                .CDPSecurityGroupName = If(Entity.CDPSecurityGroup IsNot Nothing, Entity.CDPSecurityGroup.Name, String.Empty),
                                                                                                .OfficeCode = Entity.OfficeCode,
                                                                                                .OfficeName = Entity.Office.Name,
                                                                                                .ClientCode = Entity.ClientCode,
                                                                                                .ClientName = Entity.Client.Name,
                                                                                                .ClientIsActive = Entity.Client.IsActive,
                                                                                                .DivisionCode = Entity.DivisionCode,
                                                                                                .DivisionName = Entity.Division.Name,
                                                                                                .DivisionIsActive = Entity.Division.IsActive,
                                                                                                .ProductCode = Entity.Code,
                                                                                                .ProductName = Entity.Name,
                                                                                                .IsActive = Entity.IsActive}).ToList.
                                                              Select(Function(Entity) New AdvantageFramework.Security.Database.Classes.Product With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID.GetValueOrDefault(0),
                                                                                                                                                     .CDPSecurityGroupName = Entity.CDPSecurityGroupName,
                                                                                                                                                     .OfficeCode = Entity.OfficeCode,
                                                                                                                                                     .OfficeName = Entity.OfficeName,
                                                                                                                                                     .ClientCode = Entity.ClientCode,
                                                                                                                                                     .ClientName = Entity.ClientName,
                                                                                                                                                     .ClientActiveFlag = Entity.ClientIsActive,
                                                                                                                                                     .DivisionCode = Entity.DivisionCode,
                                                                                                                                                     .DivisionName = Entity.DivisionName,
                                                                                                                                                     .DivisionActiveFlag = Entity.DivisionIsActive,
                                                                                                                                                     .ProductCode = Entity.ProductCode,
                                                                                                                                                     .ProductDescription = Entity.ProductName,
                                                                                                                                                     .ProductActiveFlag = Entity.IsActive}).ToList

                        ButtonRightSection_AddCDP.Enabled = False
                        ButtonRightSection_RemoveCDP.Enabled = False

                    End If

                    DataGridViewRightSection_SelectedCDPs.CurrentView.BeginUpdate()
                    DataGridViewLeftSection_AvailableCDPs.CurrentView.BeginUpdate()

                    DataGridViewRightSection_SelectedCDPs.DataSource = FinalClientDivisionProductAccessesList
                    DataGridViewLeftSection_AvailableCDPs.DataSource = ClientDivisionProductList

                    DataGridViewRightSection_SelectedCDPs.CurrentView.EndUpdate()
                    DataGridViewLeftSection_AvailableCDPs.CurrentView.EndUpdate()

                    DataGridViewLeftSection_AvailableCDPs.CurrentView.BestFitColumns()
                    DataGridViewRightSection_SelectedCDPs.CurrentView.BestFitColumns()

                End Using

            End Using

            'TotalTime = Now - StartTime

            'Console.WriteLine(TotalTime.TotalSeconds)

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddCDP.Enabled = DataGridViewLeftSection_AvailableCDPs.HasASelectedRow

            If DataGridViewRightSection_SelectedCDPs.HasASelectedRow Then

                If DataGridViewRightSection_SelectedCDPs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess).Any(Function(Entity) Entity.HasCDPSecurityGroup = True) Then

                    ButtonRightSection_RemoveCDP.Enabled = False

                Else

                    ButtonRightSection_RemoveCDP.Enabled = True

                End If

            Else

                ButtonRightSection_RemoveCDP.Enabled = False

            End If

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal UserCodes As Generic.List(Of String)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _UserCodes = UserCodes

            If _UserCodes IsNot Nothing AndAlso _UserCodes.Count > 0 Then

                LoadCDPs()

            Else

                Loaded = False

            End If

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub CopyCDPLimits(ByVal CopyToUser As Boolean)

            Dim SelectedUserCode As String = Nothing
            Dim Users As IEnumerable = Nothing
            Dim UserClientDivisionProductAccesses As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing

            If CopyToUser Then

                If Me.HasLimitedCDPs Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.User, True, True, Users, True, "Copy To Users") = Windows.Forms.DialogResult.OK Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Try

                            If Users IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    DbContext.Database.Connection.Open()
                                    DbContext.Configuration.AutoDetectChangesEnabled = False

                                    For Each UserCode In _UserCodes

                                        'UserClientDivisionProductAccesses = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(DbContext, UserCode).ToList

                                        For Each SelectedUserCode In Users.OfType(Of Object).Select(Function(Entity) Entity.UserCode).ToList

                                            If String.IsNullOrWhiteSpace(SelectedUserCode) = False AndAlso _UserCodes.Contains(SelectedUserCode) = False Then

                                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.SEC_CLIENT WHERE USER_ID = '{0}' AND CL_CODE + '|' + DIV_CODE  + '|' + PRD_CODE IN (SELECT CL_CODE + '|' + DIV_CODE  + '|' + PRD_CODE FROM dbo.SEC_CLIENT WHERE USER_ID = '{1}')", SelectedUserCode, UserCode))

                                                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.SEC_CLIENT([USER_ID], CL_CODE, DIV_CODE, PRD_CODE)
                                                                                                    SELECT 
	                                                                                                    '{0}', CL_CODE, DIV_CODE, PRD_CODE
                                                                                                    FROM
	                                                                                                    dbo.SEC_CLIENT 
                                                                                                    WHERE 
	                                                                                                    USER_ID = '{1}'",
                                                                                     SelectedUserCode, UserCode))

                                                'For Each UserCDPA In UserClientDivisionProductAccesses

                                                '    UserClientDivisionProductAccess = New AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess

                                                '    UserClientDivisionProductAccess.UserCode = SelectedUserCode
                                                '    UserClientDivisionProductAccess.ClientCode = UserCDPA.ClientCode
                                                '    UserClientDivisionProductAccess.DivisionCode = UserCDPA.DivisionCode
                                                '    UserClientDivisionProductAccess.ProductCode = UserCDPA.ProductCode

                                                '    'AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Insert(DbContext, UserClientDivisionProductAccess)

                                                '    DbContext.UserClientDivisionProductAccesses.Add(UserClientDivisionProductAccess)

                                                'Next

                                            End If

                                        Next

                                    Next

                                End Using

                            End If

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    End If

                End If

            Else

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.User, True, True, Users, False, "Copy From User") = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                    Try

                        Try

                            SelectedUserCode = Users.OfType(Of Object).Select(Function(Entity) Entity.UserCode).FirstOrDefault

                        Catch ex As Exception
                            SelectedUserCode = Nothing
                        End Try

                        If SelectedUserCode IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DbContext.Database.Connection.Open()
                                DbContext.Configuration.AutoDetectChangesEnabled = False

                                'UserClientDivisionProductAccesses = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(DbContext, SelectedUserCode).ToList

                                For Each UserCode In _UserCodes

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.SEC_CLIENT WHERE USER_ID = '{0}' AND CL_CODE + '|' + DIV_CODE  + '|' + PRD_CODE IN (SELECT CL_CODE + '|' + DIV_CODE  + '|' + PRD_CODE FROM dbo.SEC_CLIENT WHERE USER_ID = '{1}')", UserCode, SelectedUserCode))

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.SEC_CLIENT([USER_ID], CL_CODE, DIV_CODE, PRD_CODE)
                                                                                                    SELECT 
	                                                                                                    '{0}', CL_CODE, DIV_CODE, PRD_CODE
                                                                                                    FROM
	                                                                                                    dbo.SEC_CLIENT 
                                                                                                    WHERE 
	                                                                                                    USER_ID = '{1}'",
                                                                                        UserCode, SelectedUserCode))

                                    'For Each UserCDPA In UserClientDivisionProductAccesses

                                    '    If AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(DbContext, UserCode).Any(Function(UCDPA) UCDPA.ClientCode = UserCDPA.ClientCode AndAlso UCDPA.DivisionCode = UserCDPA.DivisionCode AndAlso UCDPA.ProductCode = UserCDPA.ProductCode) = False Then

                                    '        UserClientDivisionProductAccess = New AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess

                                    '        UserClientDivisionProductAccess.DbContext = DbContext
                                    '        UserClientDivisionProductAccess.UserCode = UserCode
                                    '        UserClientDivisionProductAccess.ClientCode = UserCDPA.ClientCode
                                    '        UserClientDivisionProductAccess.DivisionCode = UserCDPA.DivisionCode
                                    '        UserClientDivisionProductAccess.ProductCode = UserCDPA.ProductCode

                                    '        AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Insert(DbContext, UserClientDivisionProductAccess)

                                    '    End If

                                    'Next

                                Next

                            End Using

                            LoadCDPs()

                        End If

                    Catch ex As Exception

                    End Try

                    RaiseEvent CDPsChangedEvent()

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub UserCDPLimitControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewLeftSection_AvailableCDPs.OptionsView.ShowFooter = False
            DataGridViewRightSection_SelectedCDPs.OptionsView.ShowFooter = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddCDP_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddCDP.Click

            'objects
            Dim CDPList As IEnumerable(Of Object) = Nothing
            Dim UserClientDivisionProductAccesses As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            If DataGridViewLeftSection_AvailableCDPs.HasASelectedRow Then

                CDPList = DataGridViewLeftSection_AvailableCDPs.CurrentView.GetSelectedRows.Select(Function(RowHandle) New With {.ProductCode = DataGridViewLeftSection_AvailableCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString),
                                                                                                                                 .DivisionCode = DataGridViewLeftSection_AvailableCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString),
                                                                                                                                 .ClientCode = DataGridViewLeftSection_AvailableCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)}).ToList

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SecurityDbContext.Database.Connection.Open()

                        UserClientDivisionProductAccesses = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext).Where(Function(Entity) _UserCodes.Contains(Entity.UserCode)).ToList

                        For Each UserCode In _UserCodes

                            For Each CDP In CDPList

                                If UserClientDivisionProductAccesses.Any(Function(Entity) Entity.UserCode = UserCode AndAlso Entity.ClientCode = CDP.ClientCode AndAlso Entity.DivisionCode = CDP.DivisionCode AndAlso Entity.ProductCode = CDP.ProductCode) = False Then

                                    AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Insert(SecurityDbContext, UserCode, CDP.ProductCode, CDP.DivisionCode, CDP.ClientCode, Nothing, Nothing)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadCDPs()

                Catch ex As Exception

                End Try

                RaiseEvent CDPsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveCDP_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveCDP.Click

            'objects
            Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
            Dim UserClientDivisionProductAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess) = Nothing
            'Dim CDPList As IEnumerable(Of Object) = Nothing

            If DataGridViewRightSection_SelectedCDPs.HasASelectedRow Then

                UserClientDivisionProductAccessesList = DataGridViewRightSection_SelectedCDPs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess).Where(Function(Entity) Entity.HasCDPSecurityGroup = False).ToList

                'CDPList = DataGridViewRightSection_SelectedCDPs.CurrentView.GetSelectedRows.Select(Function(RowHandle) New With {.ProductCode = DataGridViewRightSection_SelectedCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.ProductCode.ToString),
                '                                                                                                                 .DivisionCode = DataGridViewRightSection_SelectedCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.DivisionCode.ToString),
                '                                                                                                                 .ClientCode = DataGridViewRightSection_SelectedCDPs.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess.Properties.ClientCode.ToString)}).ToList

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SecurityDbContext.Database.Connection.Open()

                        For Each UserCode In _UserCodes

                            For Each UCDPA In UserClientDivisionProductAccessesList

                                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.SEC_CLIENT WHERE USER_ID = '{0}' AND CL_CODE = '{1}' AND DIV_CODE = '{2}' AND PRD_CODE = '{3}'", UserCode, UCDPA.ClientCode, UCDPA.DivisionCode, UCDPA.ProductCode))
                                'UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(SecurityDbContext, UserCode, UCDPA.ProductCode, UCDPA.DivisionCode, UCDPA.ClientCode)

                                'If UserClientDivisionProductAccess IsNot Nothing Then

                                '    AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Delete(SecurityDbContext, UserClientDivisionProductAccess)

                                'End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadCDPs()

                Catch ex As Exception

                End Try

                RaiseEvent CDPsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableCDPs_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableCDPs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedCDPs_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedCDPs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedCDPs_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_SelectedCDPs.CellValueChangingEvent

            'objects
            Dim UserClientDivisionProductAccess As AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess = Nothing
            Dim UserClDivProdAccess As AdvantageFramework.Security.Database.Classes.UserClientDivisionProductAccess = Nothing

            UserClDivProdAccess = DataGridViewRightSection_SelectedCDPs.CurrentView.GetRow(e.RowHandle)

            If UserClDivProdAccess IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each UserCode In _UserCodes

                            UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCodeAndProductCodeAndDivisionCodeAndClientCode(SecurityDbContext, UserCode, UserClDivProdAccess.ProductCode, UserClDivProdAccess.DivisionCode, UserClDivProdAccess.ClientCode)

                            If UserClientDivisionProductAccess IsNot Nothing Then

                                If e.Value = True Then

                                    UserClientDivisionProductAccess.AllowTimeEntryOnly = 1

                                Else

                                    UserClientDivisionProductAccess.AllowTimeEntryOnly = 0

                                End If

                                AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Update(SecurityDbContext, UserClientDivisionProductAccess)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace

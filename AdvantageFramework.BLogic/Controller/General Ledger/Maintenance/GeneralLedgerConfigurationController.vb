Imports AdvantageFramework.BaseClasses
Imports AdvantageFramework.DTO

Namespace Controller.GeneralLedger.Maintenance

    Public Class GeneralLedgerConfigurationController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel

            Dim ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel = Nothing
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing

            ViewModel = New AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel()

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    ViewModel.GeneralLedgerConfiguration = New DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration(GeneralLedgerConfig)

                    ViewModel.IsNew = False

                    ViewModel.EditSegment = False

                    If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[GLACCOUNT]")).FirstOrDefault = 0 Then

                        ViewModel.HasGLAccounts = False

                    Else

                        ViewModel.HasGLAccounts = True

                    End If

                Else

                    ViewModel.GeneralLedgerConfiguration = New DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration()

                    ViewModel.IsNew = True

                    ViewModel.EditSegment = True

                End If

                ViewModel.ComboBoxItemMonths = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.FiscalMonths)).Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            Load = ViewModel

        End Function
        Public Sub RefreshHasGLAccounts(ByRef ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[GLACCOUNT]")).FirstOrDefault = 0 Then

                    ViewModel.HasGLAccounts = False

                Else

                    ViewModel.HasGLAccounts = True

                End If

            End Using

        End Sub
        Private Sub SetNewSegment(NewSegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType, SegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType,
                                  BaseCode As String, DepartmentCode As String, GeneralLedgerOfficeCrossReferenceCode As String, OtherCode As String,
                                  ByRef GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            If SegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base Then

                If NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department Then

                    GeneralLedgerAccount.DepartmentCode = BaseCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                    GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = BaseCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other Then

                    GeneralLedgerAccount.OtherCode = BaseCode

                End If

            ElseIf SegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department Then

                If NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base Then

                    GeneralLedgerAccount.BaseCode = DepartmentCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                    GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = DepartmentCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other Then

                    GeneralLedgerAccount.OtherCode = DepartmentCode

                End If

            ElseIf SegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                If NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department Then

                    GeneralLedgerAccount.DepartmentCode = GeneralLedgerOfficeCrossReferenceCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base Then

                    GeneralLedgerAccount.BaseCode = GeneralLedgerOfficeCrossReferenceCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other Then

                    GeneralLedgerAccount.OtherCode = GeneralLedgerOfficeCrossReferenceCode

                End If

            ElseIf SegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Other Then

                If NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Department Then

                    GeneralLedgerAccount.DepartmentCode = OtherCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Base Then

                    GeneralLedgerAccount.BaseCode = OtherCode

                ElseIf NewSegmentType = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType.Office Then

                    GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode = OtherCode

                End If

            End If

        End Sub
        Public Function Save(ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel, _EditSegment As Boolean, ByRef ErrorMessage As String) As Boolean

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim BaseCode As String = Nothing
            Dim DepartmentCode As String = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing
            Dim OtherCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                GeneralLedgerConfig = Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig IsNot Nothing Then

                    Try
                        DbTransaction = DbContext.Database.BeginTransaction

                        If _EditSegment Then

                            For Each GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext).ToList

                                BaseCode = GeneralLedgerAccount.BaseCode
                                DepartmentCode = GeneralLedgerAccount.DepartmentCode
                                GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode
                                OtherCode = GeneralLedgerAccount.OtherCode

                                If String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment1Format) = False Then

                                    SetNewSegment(ViewModel.GeneralLedgerConfiguration.Segment1Type, GeneralLedgerConfig.Segment1Type, BaseCode, DepartmentCode, GeneralLedgerOfficeCrossReferenceCode, OtherCode, GeneralLedgerAccount)

                                End If

                                If String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment2Format) = False Then

                                    SetNewSegment(ViewModel.GeneralLedgerConfiguration.Segment2Type, GeneralLedgerConfig.Segment2Type, BaseCode, DepartmentCode, GeneralLedgerOfficeCrossReferenceCode, OtherCode, GeneralLedgerAccount)

                                End If

                                If String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment3Format) = False Then

                                    SetNewSegment(ViewModel.GeneralLedgerConfiguration.Segment3Type, GeneralLedgerConfig.Segment3Type, BaseCode, DepartmentCode, GeneralLedgerOfficeCrossReferenceCode, OtherCode, GeneralLedgerAccount)

                                End If

                                If String.IsNullOrWhiteSpace(GeneralLedgerConfig.Segment4Format) = False Then

                                    SetNewSegment(ViewModel.GeneralLedgerConfiguration.Segment4Type, GeneralLedgerConfig.Segment4Type, BaseCode, DepartmentCode, GeneralLedgerOfficeCrossReferenceCode, OtherCode, GeneralLedgerAccount)

                                End If

                                DbContext.Entry(GeneralLedgerAccount).State = System.Data.Entity.EntityState.Modified

                            Next

                            DbContext.SaveChanges()

                        End If

                        ViewModel.GeneralLedgerConfiguration.SaveToEntity(GeneralLedgerConfig)

                        If Database.Procedures.GeneralLedgerConfig.Update(DbContext, GeneralLedgerConfig, ErrorMessage) = False Then

                            Throw New Exception(ErrorMessage)

                        End If

                        Saved = True

                        DbTransaction.Commit()

                    Catch ex As Exception
                        DbTransaction.Rollback()
                    End Try

                Else

                    GeneralLedgerConfig = New Database.Entities.GeneralLedgerConfig

                    ViewModel.GeneralLedgerConfiguration.SaveToEntity(GeneralLedgerConfig)

                    Saved = Database.Procedures.GeneralLedgerConfig.Insert(DbContext, GeneralLedgerConfig, "")

                End If

            End Using

            Save = Saved

        End Function
        Public Function ValidateEntity(GeneralLedgerConfiguration As AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, GeneralLedgerConfiguration, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateDTO(DbContext As DbContext, DataContext As DataContext, ByRef DTO As DTO.BaseClass, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = ""
            Dim GeneralLedgerConfiguration As AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration = Nothing

            If TypeOf DTO Is AdvantageFramework.DTO.GeneralLedger.Maintenance.GeneralLedgerConfiguration Then

                GeneralLedgerConfiguration = DTO

                If (GeneralLedgerConfiguration.Segment1Type = GeneralLedgerConfiguration.Segment2Type OrElse
                        GeneralLedgerConfiguration.Segment1Type = GeneralLedgerConfiguration.Segment3Type OrElse
                        GeneralLedgerConfiguration.Segment1Type = GeneralLedgerConfiguration.Segment4Type OrElse 'Segment1Type
                        GeneralLedgerConfiguration.Segment2Type = GeneralLedgerConfiguration.Segment1Type OrElse
                        GeneralLedgerConfiguration.Segment2Type = GeneralLedgerConfiguration.Segment3Type OrElse
                        GeneralLedgerConfiguration.Segment2Type = GeneralLedgerConfiguration.Segment4Type OrElse 'Segment2Type
                        GeneralLedgerConfiguration.Segment3Type = GeneralLedgerConfiguration.Segment1Type OrElse
                        GeneralLedgerConfiguration.Segment3Type = GeneralLedgerConfiguration.Segment2Type OrElse
                        GeneralLedgerConfiguration.Segment3Type = GeneralLedgerConfiguration.Segment4Type OrElse 'Segment3Type
                        GeneralLedgerConfiguration.Segment4Type = GeneralLedgerConfiguration.Segment1Type OrElse
                        GeneralLedgerConfiguration.Segment4Type = GeneralLedgerConfiguration.Segment2Type OrElse
                        GeneralLedgerConfiguration.Segment4Type = GeneralLedgerConfiguration.Segment3Type) Then  'Segment4Type

                    IsValid = False

                    ErrorText = "You cannot designate more than one segment of the Account Code as the same segment type."

                End If

            End If

            ValidateDTO = ErrorText

        End Function
        Public Sub SetEditSegmentFlag(ByRef ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerConfigurationViewModel, Editable As Boolean)

            ViewModel.EditSegment = Editable

        End Sub
#End Region

#End Region

    End Class

End Namespace

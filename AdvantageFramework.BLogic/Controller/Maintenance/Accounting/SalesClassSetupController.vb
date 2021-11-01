Namespace Controller.Maintenance.Accounting

    Public Class SalesClassSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel

            Dim SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel = Nothing

            SalesClassSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SalesClassSetupViewModel.SalesClasses = GetSalesClasses(DbContext)

            End Using

            Load = SalesClassSetupViewModel

        End Function
        Public Function GetSalesClasses() As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetSalesClasses(DbContext)

            End Using

        End Function
        Public Function GetSalesClasses(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            Return AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

        End Function

        Public Function SalesClassExists(Code As String) As Boolean

            SalesClassExists = False

            Dim SalesClasses As List(Of Database.Entities.SalesClass) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SalesClasses = GetSalesClasses(DbContext).Where(Function(x) x.Code = Code)

            End Using

            If SalesClasses.Count > 0 Then

                SalesClassExists = True

            End If

        End Function
        Public Function Add(ByVal SalesClasses As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, SalesClasses.Select(Function(d) d.ToEntity(Nothing)).ToList)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each SalesClass In SalesClasses

                If SalesClass.IsEntityBeingAdded() Then

                    SalesClass.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.SalesClass.Insert(DbContext, SalesClass) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        Public Function Save(SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, SalesClassSetupViewModel.SalesClasses)

            End Using

        End Function
        Public Function Save(ByVal SalesClasses As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, SalesClasses.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each SalesClass In SalesClasses

                If AdvantageFramework.Database.Procedures.SalesClass.Update(DbContext, SalesClass) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SalesClass In SalesClassSetupViewModel.SelectedSalesClasses

                    If Delete(DbContext, SalesClass) Then

                        Deleted = True

                        If SalesClassSetupViewModel.SalesClasses.Remove(SalesClass) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each SalesClass In SalesClasses

                If Delete(DbContext, SalesClass) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal SalesClasses As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SalesClass In SalesClasses.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, SalesClass) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClass As AdvantageFramework.Database.Entities.SalesClass) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.SalesClass.Delete(DbContext, SalesClass)

            End Using

        End Function


        Public Function UpdateInactiveFlag(SalesClass As AdvantageFramework.Database.Entities.SalesClass, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If SalesClass IsNot Nothing Then

                Try

                    SalesClass.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    SalesClass.IsInactive = SalesClass.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.SalesClass.Update(DbContext, SalesClass)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Sub CancelNewItemRow(SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel)

            SalesClassSetupViewModel.IsNewRow = False
            SalesClassSetupViewModel.CancelEnabled = False
            SalesClassSetupViewModel.DeleteEnabled = SalesClassSetupViewModel.HasASelectedSalesClass

        End Sub
        Public Sub InitNewRowEvent(SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel)

            SalesClassSetupViewModel.IsNewRow = True
            SalesClassSetupViewModel.CancelEnabled = True
            SalesClassSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub TaskSelectionChanged(SalesClassSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.SalesClassSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedSalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass))

            SalesClassSetupViewModel.IsNewRow = IsNewItemRow
            SalesClassSetupViewModel.CancelEnabled = IsNewItemRow
            SalesClassSetupViewModel.DeleteEnabled = Not IsNewItemRow

            SalesClassSetupViewModel.SelectedSalesClasses = SelectedSalesClasses

        End Sub
        Public Function LoadSalesClassTypes() As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType))

            End Using

        End Function

#End Region

#End Region

    End Class

End Namespace

Namespace Database.Procedures.DocumentType

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.DataContextDocumentType)

            Load = From DocumentType In DataContext.DataContextDocumentTypes
                   Select DocumentType
                   Order By DocumentType.Name

        End Function
        Public Function LoadActive(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.DataContextDocumentType)

            LoadActive = From DocumentType In DataContext.DataContextDocumentTypes
                         Where (DocumentType.IsInactive Is Nothing OrElse DocumentType.IsInactive = 0)
                         Select DocumentType
                         Order By DocumentType.Name

        End Function

        Public Function LoadUser(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.DataContextDocumentType)

            LoadUser = From DocumentType In DataContext.DataContextDocumentTypes
                       Where DocumentType.ID > 6
                       Select DocumentType
                       Order By DocumentType.Name

        End Function
        Public Function LoadActiveUser(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.DataContextDocumentType)

            LoadActiveUser = From DocumentType In DataContext.DataContextDocumentTypes
                             Where DocumentType.ID > 6 AndAlso (DocumentType.IsInactive Is Nothing OrElse DocumentType.IsInactive = 0)
                             Select DocumentType
                             Order By DocumentType.Name

        End Function

        Public Function LoadByDocumentTypeID(ByVal DataContext As Database.DataContext, ByVal DocumentTypeID As Integer) As Database.Entities.DataContextDocumentType

            LoadByDocumentTypeID = (From DocumentType In DataContext.DataContextDocumentTypes
                                    Where DocumentType.ID = DocumentTypeID
                                    Select DocumentType).SingleOrDefault()

        End Function

        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DataContextDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DataContextDocumentType.Name <> String.Empty OrElse DataContextDocumentType.Name.Trim().Length > 0 Then

                    If IsInactiveAndDefault(DataContextDocumentType) = False Then

                        Dim NameExists As Boolean = False

                        NameExists = (From Entity In DataContext.DataContextDocumentTypes
                                      Where Entity.Name.Trim().ToUpper() = DataContextDocumentType.Name.Trim().ToUpper()).Count > 0

                        If NameExists = False Then

                            Dim MaxID As Integer = 0

                            MaxID = (From Entity In DataContext.DataContextDocumentTypes
                                     Select Entity.ID).Max + 1

                            DataContextDocumentType.ID = MaxID

                            Inserted = DataContext.ExecuteCommand(String.Format("INSERT INTO DOCUMENT_TYPE (DOCUMENT_TYPE_ID, DOCUMENT_TYPE_DESC, INACTIVE_FLAG, IS_DEFAULT) VALUES ({0}, '{1}', {2}, {3});",
                                                                        MaxID,
                                                                        DataContextDocumentType.Name.Replace("'", "''"),
                                                                        If(DataContextDocumentType.IsInactive Is Nothing OrElse DataContextDocumentType.IsInactive = False, 0, 1),
                                                                        If(DataContextDocumentType.IsDefault Is Nothing OrElse DataContextDocumentType.IsDefault = False, 0, 1))) = 1

                            If Inserted = True AndAlso DataContextDocumentType.IsDefault = True Then

                                DataContext.ExecuteCommand(String.Format("UPDATE DOCUMENT_TYPE SET IS_DEFAULT = 0 WHERE DOCUMENT_TYPE_ID <> {0};", MaxID))

                            End If

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Please choose a different type name.")

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Document type cannot be inactive and default.")

                    End If
                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Type name is required.")

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DataContextDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try
                If DataContextDocumentType.Name <> String.Empty OrElse DataContextDocumentType.Name.Trim().Length > 0 Then

                    'If DataContextDocumentType.ID > 6 Then

                    If IsInactiveAndDefault(DataContextDocumentType) = False Then

                        Dim TypeExists As Boolean = False

                        TypeExists = (From Entity In DataContext.DataContextDocumentTypes
                                      Where Entity.ID <> DataContextDocumentType.ID AndAlso Entity.Name.Trim().ToUpper() = DataContextDocumentType.Name.Trim().ToUpper()).Count > 0

                        If TypeExists = False Then

                            Dim NeedActive As Boolean = False

                            If LoadActive(DataContext).Count <= 1 AndAlso DataContextDocumentType.IsInactive = True Then

                                AdvantageFramework.Navigation.ShowMessageBox("Need at least one active document type.")

                            Else

                                Updated = DataContext.ExecuteCommand(String.Format("UPDATE DOCUMENT_TYPE SET DOCUMENT_TYPE_DESC = '{1}', INACTIVE_FLAG = {2}, IS_DEFAULT = {3} WHERE DOCUMENT_TYPE_ID = {0};",
                                                                           DataContextDocumentType.ID,
                                                                           DataContextDocumentType.Name.Replace("'", "''"),
                                                                           If(DataContextDocumentType.IsInactive Is Nothing OrElse DataContextDocumentType.IsInactive = False, 0, 1),
                                                                           If(DataContextDocumentType.IsDefault Is Nothing OrElse DataContextDocumentType.IsDefault = False, 0, 1))) = 1

                                If Updated = True AndAlso DataContextDocumentType.IsDefault = True Then

                                    DataContext.ExecuteCommand(String.Format("UPDATE DOCUMENT_TYPE SET IS_DEFAULT = 0 WHERE DOCUMENT_TYPE_ID <> {0};", DataContextDocumentType.ID))

                                End If

                            End If

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("Please choose a different type name.")

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Document type cannot be inactive and default.")

                    End If

                    'Else

                    '    AdvantageFramework.Navigation.ShowMessageBox("Cannot modify a core type.")

                    'End If
                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Type name is required.")

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DataContextDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim TypeInUse As Boolean = False

            Try

                'If DataContextDocumentType.ID > 6 Then

                Using oc As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

                    TypeInUse = (From Entity In oc.Documents
                                 Where Entity.DocumentTypeID = DataContextDocumentType.ID).Count > 0

                End Using

                If TypeInUse = False Then

                    Deleted = DataContext.ExecuteCommand(String.Format("DELETE FROM DOCUMENT_TYPE WHERE DOCUMENT_TYPE_ID = {0};",
                                                         DataContextDocumentType.ID)) = 1

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("The type is in use and cannot be deleted.")

                End If

                'Else

                '    AdvantageFramework.Navigation.ShowMessageBox("Cannot delete core type.")

                'End If


            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Private Function IsInactiveAndDefault(ByVal DataContextDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType) As Boolean

            If DataContextDocumentType.IsInactive = True AndAlso DataContextDocumentType.IsDefault = True Then

                Return True

            Else

                Return False

            End If

        End Function

#End Region

    End Module

End Namespace

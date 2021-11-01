Imports System.Collections

Namespace Database.Procedures.BoardColumn

    <HideModuleName()>
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

        Public Function LoadSimpleByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As IEnumerable(Of Object)

            Try

                LoadSimpleByBoardID = From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn).Include("BoardDetails")
                                      Where BoardColumn.BoardHeaderID = BoardID
                                      Order By BoardColumn.SequenceNumber
                                      Select New With {.BoardColumn = BoardColumn,
                                                       .BoardDetails = From Bd In BoardColumn.BoardDetails Join Entity In DbContext.GetQuery(Of Database.Entities.AlertState) On Bd.AlertStateID Equals Entity.ID
                                                                       Select New With {.ID = Bd.ID,
                                                                                        .BoardHeaderID = Bd.BoardHeaderID,
                                                                                        .BoardColumnID = Bd.BoardColumnID,
                                                                                        .SequenceNumber = Bd.SequenceNumber,
                                                                                        .AlertStateID = Bd.AlertStateID,
                                                                                        .AlerstStateName = Entity.Name}}

            Catch ex As Exception
                LoadSimpleByBoardID = Nothing
            End Try

        End Function
        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardColumn)

            LoadByBoardID = From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn).Include("BoardDetails")
                            Where BoardColumn.BoardHeaderID = BoardID
                            Order By BoardColumn.SequenceNumber
                            Select BoardColumn

        End Function
        Public Function LoadByBoardHeaderIDAndColumnName(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal BoardHeaderID As Integer,
                                                            ByVal ColumnName As String) As AdvantageFramework.Database.Entities.BoardColumn

            LoadByBoardHeaderIDAndColumnName = (From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn).Include("BoardDetails")
                                                Where BoardColumn.Name.ToUpper = ColumnName.ToUpper And BoardColumn.BoardHeaderID = BoardHeaderID
                                                Select BoardColumn).SingleOrDefault

        End Function
        Public Function LoadByBoardHeaderIDAndBoardColumnID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal BoardHeaderID As Integer,
                                                            ByVal BoardColumnID As Integer) As AdvantageFramework.Database.Entities.BoardColumn

            LoadByBoardHeaderIDAndBoardColumnID = (From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn).Include("BoardDetails")
                                                   Where BoardColumn.ID = BoardColumnID And BoardColumn.BoardHeaderID = BoardHeaderID
                                                   Select BoardColumn).SingleOrDefault

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal BoardColumnID As Integer) As AdvantageFramework.Database.Entities.BoardColumn

            LoadByID = (From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn).Include("BoardDetails")
                        Where BoardColumn.ID = BoardColumnID
                        Select BoardColumn).SingleOrDefault

        End Function
        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardColumn)

        '    Load = From BoardColumn In DbContext.GetQuery(Of Database.Entities.BoardColumn)
        '           Select BoardColumn

        'End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardColumn As AdvantageFramework.Database.Entities.BoardColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BoardColumns.Add(BoardColumn)

                ErrorText = BoardColumn.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardColumn As AdvantageFramework.Database.Entities.BoardColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BoardColumn)

                ErrorText = BoardColumn.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BoardColumn As AdvantageFramework.Database.Entities.BoardColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.BoardColumn.IsInUse(DataContext, BoardColumn.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.BoardColumnRole.LoadByBoardColumnCode(DataContext, BoardColumn.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(BoardColumn)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module


End Namespace

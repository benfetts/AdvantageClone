Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class BoardDesigner

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BoardColumns As Generic.List(Of AdvantageFramework.Database.Entities.BoardColumn) = Nothing
        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing
        Private _BoardDetails As Generic.List(Of AdvantageFramework.Database.Entities.BoardDetail) = Nothing
        Private _UsedStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing
        Private _AvailableStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing

#End Region

#Region " Properties "

        Public Property BoardHeaderID As Integer?
        Public Property Header As AdvantageFramework.Database.Entities.BoardHeader = Nothing
        Public Property Cards As Generic.List(Of DesignCard)
        Public Property Columns As Generic.List(Of DesignColumn)
        Public Property AssignmentTemplates As Generic.List(Of AssignmentTemplate) = Nothing
        Public Property SelectedTemplateIdIndex As Integer = -1
        Public Property SelectedTemplateName As String = String.Empty
        Public Property HeaderHasTemplate As Boolean = False
        Public Property FilterStates As Boolean = False

        Public Property JobNumber As Integer?
        Public Property JobComponent As Short?

        Public Property FilterAlertTemplateID As Integer?

        Public Property IsInUse As Boolean = False
        Public Property CanDeleteBoard As Boolean = False
        Public Property IsBasicBoard As Boolean = False
        Public Property UsedOnBoardsCount As Integer = 0

        Public ReadOnly Property DeleteMessage As String
            Get
                Return DeleteBoardLayoutMessage(UsedOnBoardsCount)
            End Get
        End Property
#End Region

#Region " Methods "

        Public Sub Load()

            Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                If BoardHeaderID Is Nothing OrElse BoardHeaderID = 0 Then

                    InitializeNew()

                Else

                    Header = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, BoardHeaderID)

                    If Header IsNot Nothing Then

                        If Header.AlertTemplateID Is Nothing Then Header.AlertTemplateID = -1

                        Dim BasicBoardTemplateID As Integer = 0
                        Dim BasicBoardTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing

                        BasicBoardTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadBasicBoardTemplate(DbContext)

                        If BasicBoardTemplate IsNot Nothing Then

                            BasicBoardTemplateID = BasicBoardTemplate.ID

                        End If

                        Cards = New List(Of DesignCard)
                        Columns = New List(Of DesignColumn)

                        Dim StaticColumn As DesignColumn = Nothing

                        'StaticColumn = New DesignColumn
                        'StaticColumn.Name = ProjectBoard.HardCodedColumn.Backlog.ToString
                        'StaticColumn.BoardColumnID = -1
                        'Columns.Add(StaticColumn)
                        'StaticColumn = Nothing

                        _BoardColumns = AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardID(DbContext, BoardHeaderID).ToList

                        If _BoardColumns IsNot Nothing Then

                            Dim DbColumn As DesignColumn = Nothing

                            For Each BoardColumn As AdvantageFramework.Database.Entities.BoardColumn In _BoardColumns

                                DbColumn = New DesignColumn

                                DbColumn.BoardColumnID = BoardColumn.ID
                                DbColumn.Name = BoardColumn.Name

                                Columns.Add(DbColumn)

                                DbColumn = Nothing

                            Next

                        End If

                        StaticColumn = New DesignColumn
                        StaticColumn.Name = ProjectBoard.HardCodedColumn.Completed.ToString
                        StaticColumn.BoardColumnID = -2
                        Columns.Add(StaticColumn)
                        StaticColumn = Nothing

                        StaticColumn = New DesignColumn
                        StaticColumn.Name = "Available States"
                        StaticColumn.BoardColumnID = -3
                        Columns.Add(StaticColumn)
                        StaticColumn = Nothing

                        '''''''''''''''     DATA     '''''''''''''''
                        'states in db
                        _BoardDetails = AdvantageFramework.Database.Procedures.BoardDetail.LoadWithState(DbContext, BoardHeaderID).ToList

                        If _BoardDetails IsNot Nothing AndAlso _BoardDetails.Count > 0 Then

                            Dim AddedState As DesignCard = Nothing

                            For Each BoardDetail As AdvantageFramework.Database.Entities.BoardDetail In _BoardDetails

                                AddedState = New DesignCard

                                AddedState.ID = BoardDetail.ID
                                AddedState.BoardHeaderID = Header.ID
                                AddedState.BoardColumnID = BoardDetail.BoardColumnID
                                AddedState.StateID = BoardDetail.AlertStateID
                                AddedState.Title = BoardDetail.AlertState.Name
                                If BoardDetail.SequenceNumber IsNot Nothing Then
                                    AddedState.SequenceNumber = BoardDetail.SequenceNumber
                                Else
                                    AddedState.SequenceNumber = -1
                                End If

                                Cards.Add(AddedState)

                                AddedState = Nothing

                            Next

                            _UsedStates = (From Entity In _BoardDetails
                                           Select Entity.AlertState).ToList

                            Dim UsedStateIDs As Integer()

                            UsedStateIDs = (From Entity In _UsedStates
                                            Select Entity.ID).ToArray

                            If UsedStateIDs IsNot Nothing AndAlso UsedStateIDs.Count > 0 Then

                                If FilterStates = False Then

                                    If Header.AlertTemplateID IsNot Nothing AndAlso Header.AlertTemplateID > 0 Then

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, Header.AlertTemplateID)
                                                            Where UsedStateIDs.Contains(Entity.ID) = False).ToList

                                    Else

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)
                                                            Where UsedStateIDs.Contains(Entity.ID) = False).ToList

                                    End If

                                Else

                                    If FilterAlertTemplateID Is Nothing OrElse FilterAlertTemplateID <= 0 Then

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)
                                                            Where UsedStateIDs.Contains(Entity.ID) = False).ToList

                                    Else

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, FilterAlertTemplateID)
                                                            Where UsedStateIDs.Contains(Entity.ID) = False).ToList

                                    End If

                                End If

                            Else 'No states in use, show all

                                If FilterStates = False Then

                                    If Header.AlertTemplateID IsNot Nothing AndAlso Header.AlertTemplateID > 0 Then

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, Header.AlertTemplateID)).ToList

                                    Else

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)).ToList

                                    End If

                                Else

                                    If FilterAlertTemplateID Is Nothing OrElse FilterAlertTemplateID <= 0 Then

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)).ToList

                                    Else

                                        _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, FilterAlertTemplateID)).ToList

                                    End If

                                End If

                            End If

                        Else 'No states in use, show all

                            If FilterStates = False Then

                                If Header.AlertTemplateID IsNot Nothing AndAlso Header.AlertTemplateID > 0 Then

                                    _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, Header.AlertTemplateID)).ToList

                                Else

                                    _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)).ToList

                                End If

                            Else

                                If FilterAlertTemplateID Is Nothing OrElse FilterAlertTemplateID <= 0 Then

                                    _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadAllActiveWithNoTemplate(DbContext)).ToList

                                Else

                                    _AvailableStates = (From Entity In AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, FilterAlertTemplateID)).ToList

                                End If

                            End If

                        End If

                        If _AvailableStates IsNot Nothing AndAlso _AvailableStates.Count > 0 Then

                            Dim AvailableState As DesignCard = Nothing

                            For Each State As AdvantageFramework.Database.Entities.AlertState In _AvailableStates

                                AvailableState = New DesignCard

                                AvailableState.ID = -1 * State.ID
                                AvailableState.BoardHeaderID = Header.ID
                                AvailableState.BoardColumnID = -3
                                AvailableState.StateID = State.ID
                                AvailableState.Title = State.Name

                                Cards.Add(AvailableState)

                                AvailableState = Nothing

                            Next

                        End If

                        IsBasicBoard = Header.Name = "Basic Board"
                        UsedOnBoardsCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM BOARD WHERE BOARD_HDR_ID = {0};", Header.ID)).SingleOrDefault

                        CanDeleteBoard = (UsedOnBoardsCount = 0 AndAlso IsBasicBoard = False)

                    End If

                End If

                Dim AlertAssignmentTemplates As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)
                AlertAssignmentTemplates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).ToList
                AssignmentTemplates = New List(Of AssignmentTemplate)

                Dim a As AssignmentTemplate = Nothing
                Dim i As Integer = 1

                a = New AssignmentTemplate
                a.ID = -1
                a.Name = "[Please Select]"
                AssignmentTemplates.Add(a)
                a = Nothing

                If Header IsNot Nothing AndAlso Header.AlertTemplateID IsNot Nothing Then

                    HeaderHasTemplate = True
                    Dim AssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing

                    AssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, Header.AlertTemplateID)

                    If AssignmentTemplate IsNot Nothing Then

                        SelectedTemplateName = AssignmentTemplate.Name

                    End If

                End If

                If AlertAssignmentTemplates IsNot Nothing AndAlso AlertAssignmentTemplates.Count > 0 Then

                    For Each t As AdvantageFramework.Database.Entities.AlertAssignmentTemplate In AlertAssignmentTemplates

                        i += 1

                        a = New AssignmentTemplate
                        a.ID = t.ID
                        a.Name = t.Name
                        AssignmentTemplates.Add(a)
                        a = Nothing

                    Next

                    If HeaderHasTemplate = True Then

                        i = 0
                        For Each u As AdvantageFramework.Database.Entities.AlertAssignmentTemplate In AlertAssignmentTemplates

                            If u.ID = Header.AlertTemplateID Then

                                SelectedTemplateIdIndex = i
                                Exit For

                            Else

                                i += 1

                            End If

                        Next

                    End If

                End If

                If Header IsNot Nothing Then

                    If HeaderHasTemplate = True AndAlso SelectedTemplateIdIndex = -1 Then

                        Dim aat As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing

                        aat = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, Header.AlertTemplateID)

                        If aat IsNot Nothing Then

                            a = New AssignmentTemplate
                            a.ID = aat.ID
                            a.Name = aat.Name
                            AssignmentTemplates.Add(a)
                            a = Nothing

                            SelectedTemplateIdIndex = AssignmentTemplates.Count - 1

                        End If

                    End If

                Else

                    Header = New Database.Entities.BoardHeader
                    Header.ForceAllColumns = False
                    Header.IsSequential = False

                End If

                If Header.ForceAllColumns Is Nothing Then Header.ForceAllColumns = False
                If Header.IsSequential Is Nothing Then Header.IsSequential = False
                If Header.IsActive Is Nothing Then Header.IsActive = True

                If HeaderHasTemplate = False Then

                    SelectedTemplateIdIndex = 0

                End If

                If Columns Is Nothing Then Columns = New List(Of DesignColumn)
                If Cards Is Nothing Then Cards = New List(Of DesignCard)

            End Using

        End Sub
        'Public Function LoadDesignCards(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardHeaderID As Integer) As Generic.List(Of DesignCard)

        '    Dim BoardDetails As Generic.List(Of AdvantageFramework.Database.Entities.BoardDetail) = Nothing

        '    BoardDetails = AdvantageFramework.Database.Procedures.BoardDetail.LoadWithState(DbContext, BoardHeaderID).ToList

        '    If BoardDetails IsNot Nothing AndAlso BoardDetails.Count > 0 Then


        '    End If

        'End Function

        Public Shared Function DeleteBoardLayoutMessage(ByVal BoardCount As Integer) As String
            Select Case BoardCount
                Case 0
                    Return "Delete board layout"
                Case 1
                    Return String.Format("This board layout is used by one board")
                Case > 1
                    Return String.Format("This board layout is used by {0} boards", BoardCount)
                Case Else
                    Return "Delete board layout"
            End Select
        End Function

        Private Sub InitializeNew()

            Header = New Database.Entities.BoardHeader

            If _BoardColumns Is Nothing Then _BoardColumns = New List(Of Database.Entities.BoardColumn)
            If _BoardDetails Is Nothing Then _BoardDetails = New List(Of Database.Entities.BoardDetail)
            If _AvailableStates Is Nothing Then _AvailableStates = New List(Of Database.Entities.AlertState)

            If Columns Is Nothing Then Columns = New List(Of DesignColumn)
            If Cards Is Nothing Then Cards = New List(Of DesignCard)

            CanDeleteBoard = True

        End Sub

        Sub New()

        End Sub
        Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

            _SecuritySession = SecuritySession

        End Sub

#End Region

#Region " Other Classes "

        <Serializable()>
        Public Class DesignColumn

            Public Property BoardColumnID As Integer = 0
            Public Property Name As String = String.Empty

            Public ReadOnly Property key As Integer
                Get
                    Return BoardColumnID
                End Get
            End Property
            Public ReadOnly Property headerText As String
                Get

                    If BoardColumnID > 0 Then

                        Try

                            Return String.Format("<a class='eCustomHeader{0}' href='#' id='rename' onclick='actions({0},&quot;{1}&quot;);' title='Click for actions'>{1}</a>" &
                                                 "&nbsp;<span class='glyphicon glyphicon-remove' onclick='deleteColumn({0},&quot;{1}&quot;);' title='Click to delete this column' style='cursor: pointer;'></span>" &
                                                 "&nbsp;<span class='glyphicon glyphicon-arrow-left' onclick='moveToLeft({0});' title='Move column to left' style='cursor: pointer;'></span>" &
                                                 "&nbsp;<span class='glyphicon glyphicon-arrow-right' onclick='moveToRight({0});' title='Move column to right' style='cursor: pointer;'></span>",
                                                 BoardColumnID,
                                                 Name)

                        Catch ex As Exception
                            Return Name
                        End Try

                    Else

                        Return Name

                    End If

                End Get
            End Property

            Sub New()

            End Sub

        End Class

        <Serializable()>
        Public Class DesignCard

            Public Property ID As Integer = 0
            Public Property BoardHeaderID As Integer = 0
            Public Property BoardColumnID As Integer = 0
            Public Property StateID As Integer = 0
            Public Property Title As String = String.Empty
            Public Property Data As String = String.Empty
            Public Property SequenceNumber As Integer = 0

            Sub New()

            End Sub

        End Class

        <Serializable()>
        Public Class AssignmentTemplate

            Public Property ID As Integer = 0
            Public Property Name As String = String.Empty

            Sub New()

            End Sub
        End Class

#End Region

    End Class

End Namespace

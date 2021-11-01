Namespace Media

    <HideModuleName()>
    Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Friend Function GetRadioBooks(Session As AdvantageFramework.Security.Session, RadioPeriodIDs As Generic.List(Of Integer)) As String

            Dim NielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim Books As String = String.Empty

            If Session.IsNielsenSetup AndAlso RadioPeriodIDs IsNot Nothing Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    For Each RadioBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.Load(NielsenDbContext)
                                           Where RadioPeriodIDs.Contains(Entity.ID)
                                           Select Entity).OrderByDescending(Function(Entity) Entity.EndDate).ToList

                        NielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(RadioBook)

                        Books += NielsenRadioPeriod.Description & ", "

                    Next

                    If Books.Length > 2 Then

                        Books = Mid(Books, 1, Books.Length - 2)

                    End If

                End Using

            End If

            GetRadioBooks = Books

        End Function
        Friend Function GetNielsenTVBooks(Session As AdvantageFramework.Security.Session, BookIDs As Generic.List(Of Integer)) As String

            Dim NielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim Books As String = String.Empty

            If Session.IsNielsenSetup AndAlso BookIDs IsNot Nothing Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    For Each TVBook In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.Load(NielsenDbContext)
                                        Where BookIDs.Contains(Entity.ID)
                                        Select Entity).OrderByDescending(Function(Entity) Entity.EndDateTime).ToList

                        NielsenTVBook = New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(TVBook)

                        Books += NielsenTVBook.Description & ", "

                    Next

                    If Books.Length > 2 Then

                        Books = Mid(Books, 1, Books.Length - 2)

                    End If

                End Using

            End If

            GetNielsenTVBooks = Books

        End Function

#End Region

    End Module

End Namespace

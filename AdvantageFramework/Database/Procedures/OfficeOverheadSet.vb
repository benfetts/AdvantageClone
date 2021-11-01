Namespace Database.Procedures.OfficeOverheadSet

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

        Public Function LoadByOfficeCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal OfficeCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.OfficeOverheadSet)

            LoadByOfficeCode = From OfficeOverheadSet In DataContext.OfficeOverheadSets
                               Where OfficeOverheadSet.OfficeCode = OfficeCode
                               Select OfficeOverheadSet

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.OfficeOverheadSet)

            Load = From OfficeOverheadSet In DataContext.OfficeOverheadSets
                   Select OfficeOverheadSet

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                OfficeOverheadSet.DataContext = DataContext

                OfficeOverheadSet.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.OfficeOverheadSets.InsertOnSubmit(OfficeOverheadSet)

                ErrorText = OfficeOverheadSet.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.OfficeOverheadSets.DeleteOnSubmit(OfficeOverheadSet)

                    DataContext.SubmitChanges()

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

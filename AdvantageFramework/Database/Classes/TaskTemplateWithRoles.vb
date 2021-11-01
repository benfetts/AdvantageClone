Namespace Database.Classes

    <Serializable()>
    Public Class TaskTemplateWithRoles

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PhaseID
            PhaseDescription
            TaskCode
            TaskDescription
            Roles
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PhaseID() As Nullable(Of Integer)

        Public Property PhaseDescription() As String

        Public Property TaskCode() As String

        Public Property TaskDescription() As String

        Public Property Roles() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.PhaseID.ToString

        End Function

#End Region

    End Class

End Namespace

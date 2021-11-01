Namespace Database.Classes

    <Serializable()>
    Public Class MyObjectDefinition

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ObjectDefinitionID
            ObjectID
            ObjectDescription
            ObjectType
            DefinitionID
            DefinitionDescription
            IsStatic
            Checked
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectDefinitionID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ObjectType() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefinitionID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property DefinitionDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsStatic() As Nullable(Of Boolean)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Checked() As Nullable(Of Boolean)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ObjectDefinitionID.ToString

        End Function

#End Region

    End Class

End Namespace

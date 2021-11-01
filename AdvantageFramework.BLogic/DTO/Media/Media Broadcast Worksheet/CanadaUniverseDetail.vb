Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class CanadaUniverseDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CanadaUniverseID
            CanadaUniverseSegment
            Age
            Segment
            Universe
            IsMales
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CanadaUniverseID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CanadaUniverseSegment() As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Age() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property Segment() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, MaxValue:=99000000, MinValue:=0, UseMaxValue:=True, UseMinValue:=True)>
        Public Property Universe() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property IsMales() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.CanadaUniverseID = 0
            Me.CanadaUniverseSegment = AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus
            Me.Age = 0
            Me.Segment = String.Empty
            Me.Universe = 0
            Me.IsMales = False

        End Sub
        Public Sub New(CanadaUniverseSegment As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments)

            'objects
            Dim PropertyName As String = String.Empty
            Dim Age As String = String.Empty

            Me.CanadaUniverseID = 0
            Me.CanadaUniverseSegment = CanadaUniverseSegment

            PropertyName = CanadaUniverseSegment.ToString
            Age = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyName)

            If IsNumeric(Age) Then

                Me.Age = CInt(Age)

            End If

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"
                Me.IsMales = False

            Else

                Me.Segment = "Males " & Age & "+"
                Me.IsMales = True

            End If

            Me.Universe = 0

        End Sub
        Public Sub New(CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse,
                       CanadaUniverseSegment As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments,
                       Universe As Integer)

            'objects
            Dim PropertyName As String = String.Empty
            Dim Age As String = String.Empty

            Me.CanadaUniverseID = CanadaUniverse.ID
            Me.CanadaUniverseSegment = CanadaUniverseSegment

            PropertyName = CanadaUniverseSegment.ToString
            Age = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyName)

            If IsNumeric(Age) Then

                Me.Age = CInt(Age)

            End If

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"
                Me.IsMales = False

            Else

                Me.Segment = "Males " & Age & "+"
                Me.IsMales = True

            End If

            Me.Universe = Universe

        End Sub
        Public Sub New(CanadaUniverse As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CanadaUniverse,
                       CanadaUniverseSegment As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments,
                       Universe As Integer)

            'objects
            Dim PropertyName As String = String.Empty
            Dim Age As String = String.Empty

            Me.CanadaUniverseID = CanadaUniverse.ID
            Me.CanadaUniverseSegment = CanadaUniverseSegment

            PropertyName = CanadaUniverseSegment.ToString
            Age = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyName)

            If IsNumeric(Age) Then

                Me.Age = CInt(Age)

            End If

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"
                Me.IsMales = False

            Else

                Me.Segment = "Males " & Age & "+"
                Me.IsMales = True

            End If

            Me.Universe = Universe

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.CanadaUniverseID.ToString & " - " & Me.CanadaUniverseSegment.ToString

        End Function

#End Region

    End Class

End Namespace

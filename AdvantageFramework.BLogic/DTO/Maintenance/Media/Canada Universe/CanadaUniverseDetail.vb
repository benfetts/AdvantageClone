Namespace DTO.Maintenance.Media.CanadaUniverse

    Public Class CanadaUniverseDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CanadaUniverseID
            CanadaUniverseSegment
            Segment
            Universe
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property Segment() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", MaxValue:=99000000, MinValue:=0, UseMaxValue:=True, UseMinValue:=True)>
        Public Property Universe() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.CanadaUniverseID = 0
            Me.CanadaUniverseSegment = AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus
            Me.Segment = String.Empty
            Me.Universe = 0

        End Sub
        Public Sub New(CanadaUniverseSegment As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments)

            'objects
            Dim PropertyName As String = String.Empty
            Dim Age As String = String.Empty

            Me.CanadaUniverseID = 0
            Me.CanadaUniverseSegment = CanadaUniverseSegment

            PropertyName = CanadaUniverseSegment.ToString
            Age = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyName)

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"

            Else

                Me.Segment = "Males " & Age & "+"

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

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"

            Else

                Me.Segment = "Males " & Age & "+"

            End If

            Me.Universe = Universe

        End Sub
        Public Sub New(CanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse,
                       CanadaUniverseSegment As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments,
                       Universe As Integer)

            'objects
            Dim PropertyName As String = String.Empty
            Dim Age As String = String.Empty

            Me.CanadaUniverseID = CanadaUniverse.ID
            Me.CanadaUniverseSegment = CanadaUniverseSegment

            PropertyName = CanadaUniverseSegment.ToString
            Age = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyName)

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & Age & "+"

            Else

                Me.Segment = "Males " & Age & "+"

            End If

            Me.Universe = Universe

        End Sub
        Public Sub SaveToEntity(ByRef CanadaUniverse As AdvantageFramework.Database.Entities.CanadaUniverse)

            Select Case Me.CanadaUniverseSegment

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus

                    CanadaUniverse.Males2Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males12Plus

                    CanadaUniverse.Males12Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males18Plus

                    CanadaUniverse.Males18Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males25Plus

                    CanadaUniverse.Males25Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males35Plus

                    CanadaUniverse.Males35Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males50Plus

                    CanadaUniverse.Males50Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males55Plus

                    CanadaUniverse.Males55Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males60Plus

                    CanadaUniverse.Males60Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males65Plus

                    CanadaUniverse.Males65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females2Plus

                    CanadaUniverse.Females2Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females12Plus

                    CanadaUniverse.Females12Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females18Plus

                    CanadaUniverse.Females18Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females25Plus

                    CanadaUniverse.Females25Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females35Plus

                    CanadaUniverse.Females35Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females50Plus

                    CanadaUniverse.Females50Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females55Plus

                    CanadaUniverse.Females55Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females60Plus

                    CanadaUniverse.Females60Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females65Plus

                    CanadaUniverse.Females65Plus = Me.Universe

            End Select

        End Sub
        Public Sub SaveToEntity(ByRef CanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse)

            Select Case Me.CanadaUniverseSegment

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males2Plus

                    CanadaUniverse.Males2Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males12Plus

                    CanadaUniverse.Males12Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males18Plus

                    CanadaUniverse.Males18Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males25Plus

                    CanadaUniverse.Males25Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males35Plus

                    CanadaUniverse.Males35Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males50Plus

                    CanadaUniverse.Males50Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males55Plus

                    CanadaUniverse.Males55Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males60Plus

                    CanadaUniverse.Males60Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Males65Plus

                    CanadaUniverse.Males65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females2Plus

                    CanadaUniverse.Females2Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females12Plus

                    CanadaUniverse.Females12Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females18Plus

                    CanadaUniverse.Females18Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females25Plus

                    CanadaUniverse.Females25Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females35Plus

                    CanadaUniverse.Females35Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females50Plus

                    CanadaUniverse.Females50Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females55Plus

                    CanadaUniverse.Females55Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females60Plus

                    CanadaUniverse.Females60Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Segments.Females65Plus

                    CanadaUniverse.Females65Plus = Me.Universe

            End Select

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.CanadaUniverseID.ToString & " - " & Me.CanadaUniverseSegment.ToString

        End Function

#End Region

    End Class

End Namespace

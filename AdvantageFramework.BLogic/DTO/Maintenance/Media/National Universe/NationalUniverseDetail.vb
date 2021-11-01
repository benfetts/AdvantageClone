Namespace DTO.Maintenance.Media.NationalUniverse

    Public Class NationalUniverseDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NationalUniverseID
            NationalUniverseProperty
            Segment
            Universe
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property NationalUniverseID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property NationalUniverseProperty() As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property Segment() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", MaxValue:=99000000, MinValue:=0, UseMaxValue:=True, UseMinValue:=True)>
        Public Property Universe() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.NationalUniverseID = 0
            Me.NationalUniverseProperty = AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Household
            Me.Segment = String.Empty
            Me.Universe = 0

        End Sub
        Public Sub New(NationalUniverseProperty As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties)

            Me.NationalUniverseID = 0
            Me.NationalUniverseProperty = NationalUniverseProperty

            SetSegment(NationalUniverseProperty.ToString)

            Me.Universe = 0

        End Sub
        Public Sub New(NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse,
                       NationalUniverseProperty As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties,
                       Universe As Integer)

            Me.NationalUniverseID = NationalUniverse.ID
            Me.NationalUniverseProperty = NationalUniverseProperty

            SetSegment(NationalUniverseProperty.ToString)

            Me.Universe = Universe

        End Sub
        Public Sub New(NationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse,
                       NationalUniverseProperty As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties,
                       Universe As Integer)

            Me.NationalUniverseID = NationalUniverse.ID
            Me.NationalUniverseProperty = NationalUniverseProperty

            SetSegment(NationalUniverseProperty.ToString)

            Me.Universe = Universe

        End Sub
        Public Sub SaveToEntity(ByRef NationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse)

            Select Case Me.NationalUniverseProperty

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Household

                    NationalUniverse.Household = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females2to5

                    NationalUniverse.Females2to5 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females6to8

                    NationalUniverse.Females6to8 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females9to11

                    NationalUniverse.Females9to11 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females12to14

                    NationalUniverse.Females12to14 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females15to17

                    NationalUniverse.Females15to17 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females18to20

                    NationalUniverse.Females18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females21to24

                    NationalUniverse.Females21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females25to29

                    NationalUniverse.Females25to29 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females30to34

                    NationalUniverse.Females30to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females35to39

                    NationalUniverse.Females35to39 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females40to44

                    NationalUniverse.Females40to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females45to49

                    NationalUniverse.Females45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females50to54

                    NationalUniverse.Females50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females55to64

                    NationalUniverse.Females55to64 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females65Plus

                    NationalUniverse.Females65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males2to5

                    NationalUniverse.Males2to5 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males6to8

                    NationalUniverse.Males6to8 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males9to11

                    NationalUniverse.Males9to11 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males12to14

                    NationalUniverse.Males12to14 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males15to17

                    NationalUniverse.Males15to17 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males18to20

                    NationalUniverse.Males18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males21to24

                    NationalUniverse.Males21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males25to29

                    NationalUniverse.Males25to29 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males30to34

                    NationalUniverse.Males30to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males35to39

                    NationalUniverse.Males35to39 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males40to44

                    NationalUniverse.Males40to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males45to49

                    NationalUniverse.Males45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males50to54

                    NationalUniverse.Males50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males55to64

                    NationalUniverse.Males55to64 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males65Plus

                    NationalUniverse.Males65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen18to20

                    NationalUniverse.WorkingWomen18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen21to24

                    NationalUniverse.WorkingWomen21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen25to34

                    NationalUniverse.WorkingWomen25to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen35to44

                    NationalUniverse.WorkingWomen35to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen45to49

                    NationalUniverse.WorkingWomen45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen50to54

                    NationalUniverse.WorkingWomen50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen55Plus

                    NationalUniverse.WorkingWomen55Plus = Me.Universe

            End Select

        End Sub
        Public Sub SaveToEntity(ByRef NationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse)

            Select Case Me.NationalUniverseProperty

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Household

                    NationalUniverse.Household = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females2to5

                    NationalUniverse.Females2to5 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females6to8

                    NationalUniverse.Females6to8 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females9to11

                    NationalUniverse.Females9to11 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females12to14

                    NationalUniverse.Females12to14 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females15to17

                    NationalUniverse.Females15to17 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females18to20

                    NationalUniverse.Females18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females21to24

                    NationalUniverse.Females21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females25to29

                    NationalUniverse.Females25to29 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females30to34

                    NationalUniverse.Females30to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females35to39

                    NationalUniverse.Females35to39 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females40to44

                    NationalUniverse.Females40to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females45to49

                    NationalUniverse.Females45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females50to54

                    NationalUniverse.Females50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females55to64

                    NationalUniverse.Females55to64 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Females65Plus

                    NationalUniverse.Females65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males2to5

                    NationalUniverse.Males2to5 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males6to8

                    NationalUniverse.Males6to8 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males9to11

                    NationalUniverse.Males9to11 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males12to14

                    NationalUniverse.Males12to14 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males15to17

                    NationalUniverse.Males15to17 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males18to20

                    NationalUniverse.Males18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males21to24

                    NationalUniverse.Males21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males25to29

                    NationalUniverse.Males25to29 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males30to34

                    NationalUniverse.Males30to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males35to39

                    NationalUniverse.Males35to39 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males40to44

                    NationalUniverse.Males40to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males45to49

                    NationalUniverse.Males45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males50to54

                    NationalUniverse.Males50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males55to64

                    NationalUniverse.Males55to64 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.Males65Plus

                    NationalUniverse.Males65Plus = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen18to20

                    NationalUniverse.WorkingWomen18to20 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen21to24

                    NationalUniverse.WorkingWomen21to24 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen25to34

                    NationalUniverse.WorkingWomen25to34 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen35to44

                    NationalUniverse.WorkingWomen35to44 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen45to49

                    NationalUniverse.WorkingWomen45to49 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen50to54

                    NationalUniverse.WorkingWomen50to54 = Me.Universe

                Case AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse.Properties.WorkingWomen55Plus

                    NationalUniverse.WorkingWomen55Plus = Me.Universe

            End Select

        End Sub
        Private Sub SetSegment(PropertyName As String)

            If PropertyName.Contains("Females") Then

                Me.Segment = "Females " & PropertyName.Replace("Females", "").Replace("to", " - ").Replace("Plus", "+")

            ElseIf PropertyName.Contains("Males") Then

                Me.Segment = "Males " & PropertyName.Replace("Males", "").Replace("to", " - ").Replace("Plus", "+")

            ElseIf PropertyName.Contains("WorkingWomen") Then

                Me.Segment = "Males " & PropertyName.Replace("WorkingWomen", "").Replace("to", " - ").Replace("Plus", "+")

            Else

                Me.Segment = PropertyName

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.NationalUniverseID.ToString & " - " & Me.NationalUniverseProperty.ToString

        End Function

#End Region

    End Class

End Namespace



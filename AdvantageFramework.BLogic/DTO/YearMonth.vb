Namespace DTO

    Public Class YearMonth
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = CInt(Me.Year.ToString & Me.Month.ToString.PadLeft(2, "0"))
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Description() As String
            Get
                Description = MonthName(Me.Month, True).ToUpper & Space(1) & Me.Year.ToString
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Year() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Month() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace

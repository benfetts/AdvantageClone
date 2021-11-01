Namespace ViewModels.Media

    Public Class MakegoodDeliveryDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ParentID
            Line
            CableNetwork
            CableNetworkCode
            Days
            StartTime
            EndTime
            Program
            DayPartID
            Length
            Comments
            DaypartDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property ParentID As Integer?
        Public Property Line As String
        Public Property CableNetwork As String
        Public Property CableNetworkCode As Integer?
        Public Property Days As String
        Public Property StartTime As String
        Public Property EndTime As String
        Public Property Program As String
        Public Property DayPartID As Integer?
        Public Property DaypartDescription As String
        Public Property Length As Short?
        Public Property Bookend As Boolean
        Public Property AddedValue As Boolean
        Public Property Comments As String
        Public Property DefaultRate As Decimal
        Public Property PrimaryRating As Decimal
        Public Property SecondaryRating As Decimal
        Public Property PrimaryImpressions As Decimal

        Property Spot0 As Integer
        Property Spot1 As Integer
        Property Spot2 As Integer
        Property Spot3 As Integer
        Property Spot4 As Integer
        Property Spot5 As Integer
        Property Spot6 As Integer
        Property Spot7 As Integer
        Property Spot8 As Integer
        Property Spot9 As Integer
        Property Spot10 As Integer
        Property Spot11 As Integer
        Property Spot12 As Integer
        Property Spot13 As Integer
        Property Spot14 As Integer
        Property Spot15 As Integer
        Property Spot16 As Integer
        Property Spot17 As Integer
        Property Spot18 As Integer
        Property Spot19 As Integer
        Property Spot20 As Integer
        Property Spot21 As Integer
        Property Spot22 As Integer
        Property Spot23 As Integer
        Property Spot24 As Integer
        Property Spot25 As Integer
        Property Spot26 As Integer
        Property Spot27 As Integer
        Property Spot28 As Integer
        Property Spot29 As Integer
        Property Spot30 As Integer
        Property Spot31 As Integer
        Property Spot32 As Integer
        Property Spot33 As Integer
        Property Spot34 As Integer
        Property Spot35 As Integer
        Property Spot36 As Integer
        Property Spot37 As Integer
        Property Spot38 As Integer
        Property Spot39 As Integer
        Property Spot40 As Integer
        Property Spot41 As Integer
        Property Spot42 As Integer
        Property Spot43 As Integer
        Property Spot44 As Integer
        Property Spot45 As Integer
        Property Spot46 As Integer
        Property Spot47 As Integer
        Property Spot48 As Integer
        Property Spot49 As Integer
        Property Spot50 As Integer
        Property Spot51 As Integer
        Property Spot52 As Integer
        Property Spot53 As Integer
        Property Spot54 As Integer
        Property Spot55 As Integer
        Property Spot56 As Integer
        Property Spot57 As Integer
        Property Spot58 As Integer
        Property Spot59 As Integer
        Property Spot60 As Integer
        Property Spot61 As Integer
        Property Spot62 As Integer
        Property Spot63 As Integer
        Property Spot64 As Integer
        Property Spot65 As Integer
        Property Spot66 As Integer
        Property Spot67 As Integer
        Property Spot68 As Integer
        Property Spot69 As Integer
        Property Spot70 As Integer
        Property Spot71 As Integer
        Property Spot72 As Integer
        Property Spot73 As Integer
        Property Spot74 As Integer
        Property Spot75 As Integer
        Property Spot76 As Integer
        Property Spot77 As Integer
        Property Spot78 As Integer
        Property Spot79 As Integer
        Property Spot80 As Integer
        Property Spot81 As Integer
        Property Spot82 As Integer
        Property Spot83 As Integer
        Property Spot84 As Integer
        Property Spot85 As Integer
        Property Spot86 As Integer
        Property Spot87 As Integer
        Property Spot88 As Integer
        Property Spot89 As Integer
        Property Spot90 As Integer
        Property Spot91 As Integer
        Property Spot92 As Integer
        Property Spot93 As Integer
        Property Spot94 As Integer
        Property Spot95 As Integer
        Property Spot96 As Integer
        Property Spot97 As Integer
        Property Spot98 As Integer
        Property Spot99 As Integer
        Property Spot100 As Integer
        Property Spot101 As Integer
        Property Spot102 As Integer
        Property Spot103 As Integer
        Property Spot104 As Integer
        Property Spot105 As Integer
        Property Spot106 As Integer
        Property Spot107 As Integer
        Property Spot108 As Integer
        Property Spot109 As Integer
        Property Spot110 As Integer
        Property Spot111 As Integer
        Property Spot112 As Integer
        Property Spot113 As Integer
        Property Spot114 As Integer
        Property Spot115 As Integer
        Property Spot116 As Integer
        Property Spot117 As Integer
        Property Spot118 As Integer
        Property Spot119 As Integer
        Property Spot120 As Integer
        Property Spot121 As Integer
        Property Spot122 As Integer
        Property Spot123 As Integer
        Property Spot124 As Integer
        Property Spot125 As Integer
        Property Spot126 As Integer
        Property Spot127 As Integer
        Property Spot128 As Integer
        Property Spot129 As Integer
        Property Spot130 As Integer
        Property Spot131 As Integer
        Property Spot132 As Integer
        Property Spot133 As Integer
        Property Spot134 As Integer
        Property Spot135 As Integer
        Property Spot136 As Integer
        Property Spot137 As Integer
        Property Spot138 As Integer
        Property Spot139 As Integer
        Property Spot140 As Integer
        Property Spot141 As Integer
        Property Spot142 As Integer
        Property Spot143 As Integer
        Property Spot144 As Integer
        Property Spot145 As Integer
        Property Spot146 As Integer
        Property Spot147 As Integer
        Property Spot148 As Integer
        Property Spot149 As Integer
        Property Spot150 As Integer
        Property Spot151 As Integer
        Property Spot152 As Integer
        Property Spot153 As Integer
        Property Spot154 As Integer
        Property Spot155 As Integer
        Property Spot156 As Integer
        Property Spot157 As Integer
        Property Spot158 As Integer
        Property Spot159 As Integer
        Property Spot160 As Integer
        Property Spot161 As Integer
        Property Spot162 As Integer
        Property Spot163 As Integer
        Property Spot164 As Integer
        Property Spot165 As Integer
        Property Spot166 As Integer
        Property Spot167 As Integer
        Property Spot168 As Integer
        Property Spot169 As Integer
        Property Spot170 As Integer
        Property Spot171 As Integer
        Property Spot172 As Integer
        Property Spot173 As Integer
        Property Spot174 As Integer
        Property Spot175 As Integer
        Property Spot176 As Integer
        Property Spot177 As Integer
        Property Spot178 As Integer
        Property Spot179 As Integer

        Property Rate0 As Decimal
        Property Rate1 As Decimal
        Property Rate2 As Decimal
        Property Rate3 As Decimal
        Property Rate4 As Decimal
        Property Rate5 As Decimal
        Property Rate6 As Decimal
        Property Rate7 As Decimal
        Property Rate8 As Decimal
        Property Rate9 As Decimal
        Property Rate10 As Decimal
        Property Rate11 As Decimal
        Property Rate12 As Decimal
        Property Rate13 As Decimal
        Property Rate14 As Decimal
        Property Rate15 As Decimal
        Property Rate16 As Decimal
        Property Rate17 As Decimal
        Property Rate18 As Decimal
        Property Rate19 As Decimal
        Property Rate20 As Decimal
        Property Rate21 As Decimal
        Property Rate22 As Decimal
        Property Rate23 As Decimal
        Property Rate24 As Decimal
        Property Rate25 As Decimal
        Property Rate26 As Decimal
        Property Rate27 As Decimal
        Property Rate28 As Decimal
        Property Rate29 As Decimal
        Property Rate30 As Decimal
        Property Rate31 As Decimal
        Property Rate32 As Decimal
        Property Rate33 As Decimal
        Property Rate34 As Decimal
        Property Rate35 As Decimal
        Property Rate36 As Decimal
        Property Rate37 As Decimal
        Property Rate38 As Decimal
        Property Rate39 As Decimal
        Property Rate40 As Decimal
        Property Rate41 As Decimal
        Property Rate42 As Decimal
        Property Rate43 As Decimal
        Property Rate44 As Decimal
        Property Rate45 As Decimal
        Property Rate46 As Decimal
        Property Rate47 As Decimal
        Property Rate48 As Decimal
        Property Rate49 As Decimal
        Property Rate50 As Decimal
        Property Rate51 As Decimal
        Property Rate52 As Decimal
        Property Rate53 As Decimal
        Property Rate54 As Decimal
        Property Rate55 As Decimal
        Property Rate56 As Decimal
        Property Rate57 As Decimal
        Property Rate58 As Decimal
        Property Rate59 As Decimal
        Property Rate60 As Decimal
        Property Rate61 As Decimal
        Property Rate62 As Decimal
        Property Rate63 As Decimal
        Property Rate64 As Decimal
        Property Rate65 As Decimal
        Property Rate66 As Decimal
        Property Rate67 As Decimal
        Property Rate68 As Decimal
        Property Rate69 As Decimal
        Property Rate70 As Decimal
        Property Rate71 As Decimal
        Property Rate72 As Decimal
        Property Rate73 As Decimal
        Property Rate74 As Decimal
        Property Rate75 As Decimal
        Property Rate76 As Decimal
        Property Rate77 As Decimal
        Property Rate78 As Decimal
        Property Rate79 As Decimal
        Property Rate80 As Decimal
        Property Rate81 As Decimal
        Property Rate82 As Decimal
        Property Rate83 As Decimal
        Property Rate84 As Decimal
        Property Rate85 As Decimal
        Property Rate86 As Decimal
        Property Rate87 As Decimal
        Property Rate88 As Decimal
        Property Rate89 As Decimal
        Property Rate90 As Decimal
        Property Rate91 As Decimal
        Property Rate92 As Decimal
        Property Rate93 As Decimal
        Property Rate94 As Decimal
        Property Rate95 As Decimal
        Property Rate96 As Decimal
        Property Rate97 As Decimal
        Property Rate98 As Decimal
        Property Rate99 As Decimal
        Property Rate100 As Decimal
        Property Rate101 As Decimal
        Property Rate102 As Decimal
        Property Rate103 As Decimal
        Property Rate104 As Decimal
        Property Rate105 As Decimal
        Property Rate106 As Decimal
        Property Rate107 As Decimal
        Property Rate108 As Decimal
        Property Rate109 As Decimal
        Property Rate110 As Decimal
        Property Rate111 As Decimal
        Property Rate112 As Decimal
        Property Rate113 As Decimal
        Property Rate114 As Decimal
        Property Rate115 As Decimal
        Property Rate116 As Decimal
        Property Rate117 As Decimal
        Property Rate118 As Decimal
        Property Rate119 As Decimal
        Property Rate120 As Decimal
        Property Rate121 As Decimal
        Property Rate122 As Decimal
        Property Rate123 As Decimal
        Property Rate124 As Decimal
        Property Rate125 As Decimal
        Property Rate126 As Decimal
        Property Rate127 As Decimal
        Property Rate128 As Decimal
        Property Rate129 As Decimal
        Property Rate130 As Decimal
        Property Rate131 As Decimal
        Property Rate132 As Decimal
        Property Rate133 As Decimal
        Property Rate134 As Decimal
        Property Rate135 As Decimal
        Property Rate136 As Decimal
        Property Rate137 As Decimal
        Property Rate138 As Decimal
        Property Rate139 As Decimal
        Property Rate140 As Decimal
        Property Rate141 As Decimal
        Property Rate142 As Decimal
        Property Rate143 As Decimal
        Property Rate144 As Decimal
        Property Rate145 As Decimal
        Property Rate146 As Decimal
        Property Rate147 As Decimal
        Property Rate148 As Decimal
        Property Rate149 As Decimal
        Property Rate150 As Decimal
        Property Rate151 As Decimal
        Property Rate152 As Decimal
        Property Rate153 As Decimal
        Property Rate154 As Decimal
        Property Rate155 As Decimal
        Property Rate156 As Decimal
        Property Rate157 As Decimal
        Property Rate158 As Decimal
        Property Rate159 As Decimal
        Property Rate160 As Decimal
        Property Rate161 As Decimal
        Property Rate162 As Decimal
        Property Rate163 As Decimal
        Property Rate164 As Decimal
        Property Rate165 As Decimal
        Property Rate166 As Decimal
        Property Rate167 As Decimal
        Property Rate168 As Decimal
        Property Rate169 As Decimal
        Property Rate170 As Decimal
        Property Rate171 As Decimal
        Property Rate172 As Decimal
        Property Rate173 As Decimal
        Property Rate174 As Decimal
        Property Rate175 As Decimal
        Property Rate176 As Decimal
        Property Rate177 As Decimal
        Property Rate178 As Decimal
        Property Rate179 As Decimal

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

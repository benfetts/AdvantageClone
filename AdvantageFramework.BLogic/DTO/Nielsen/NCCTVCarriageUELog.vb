﻿Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVCarriageUELog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            Month
            Validated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVCarriageUELog As AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUELog)

            Me.ID = NCCTVCarriageUELog.ID
            Me.Year = NCCTVCarriageUELog.Year
            Me.Month = NCCTVCarriageUELog.Month
            Me.Validated = False

        End Sub

#End Region

    End Class

End Namespace

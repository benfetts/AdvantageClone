﻿<DataContract>
Public Class DirectIndirectTimeAPIResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property Message As String = "Success..."
    <DataMember>
    Public Property IsSuccessful As Boolean = True
    <DataMember>
    Public Property Results As List(Of DirectIndirectTimeAPIReport)

#End Region

#Region " Methods "



#End Region

End Class

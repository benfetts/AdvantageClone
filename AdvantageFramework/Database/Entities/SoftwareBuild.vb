﻿Namespace Database.Entities

    <Table("SOFTWARE_BUILD")>
    Public Class SoftwareBuild

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            VersionID
            Name
            Description
            IsActive

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("BUILD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <Column("VERSION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VersionID() As Integer

        <Required>
        <MaxLength(10)>
        <Column("BUILD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Name() As String

        <MaxLength(100)>
        <Column("BUILD_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String

        <Column("ACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive() As Nullable(Of Boolean)


#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

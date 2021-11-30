'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.CodeDom.Compiler
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.Entity.Infrastructure.MappingViews

<Assembly: DbMappingViewCacheTypeAttribute(
    GetType(AdvantageDocumentRepositorySettings.Database.DbContext),
    GetType(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetsb7f2865fb43f743c3231931120a0a7137ef661296462064c7ac46758919c5e6a))>

Namespace Edm_EntityMappingGeneratedViews

    ''' <summary>
    ''' Implements a mapping view cache.
    ''' </summary>
    <GeneratedCode("Entity Framework 6 Power Tools", "0.9.5.0")>
    Friend NotInheritable Class ViewsForBaseEntitySetsb7f2865fb43f743c3231931120a0a7137ef661296462064c7ac46758919c5e6a
        Inherits DbMappingViewCache

        ''' <summary>
        ''' Gets a hash value computed over the mapping closure.
        ''' </summary>
        Public Overrides ReadOnly Property MappingHashValue As String
            Get
                Return "b7f2865fb43f743c3231931120a0a7137ef661296462064c7ac46758919c5e6a"
            End Get
        End Property

        ''' <summary>
        ''' Gets a view corresponding to the specified extent.
        ''' </summary>
        ''' <param name="extent">The extent.</param>
        ''' <returns>The mapping view, or null if the extent is not associated with a mapping view.</returns>
        Public Overrides Function GetView(extent As EntitySetBase) As DbMappingView
            If extent Is Nothing Then
                Throw New ArgumentNullException("extent")
            End If

            Dim extentName = extent.EntityContainer.Name & "." & extent.Name

            If extentName = "CodeFirstDatabase.Agency" Then
                Return GetView0()
            End If

            If extentName = "DbContext.Agencies" Then
                Return GetView1()
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Gets the view for CodeFirstDatabase.Agency.
        ''' </summary>
        ''' <returns>The mapping view.</returns>
        Private Shared Function GetView0() As DbMappingView
            Return New DbMappingView(
                "" & vbCrLf &
                "    SELECT VALUE -- Constructing Agency" & vbCrLf &
                "        [CodeFirstDatabaseSchema.Agency](T1.Agency_NAME, T1.[Agency.DOC_REPOSITORY_PATH], T1.[Agency.DOC_REPOSITORY_USER_DOMAIN], T1.[Agency.DOC_REPOSITORY_USER_NAME], T1.[Agency.DOC_REPOSITORY_USER_PASSWORD])" & vbCrLf &
                "    FROM (" & vbCrLf &
                "        SELECT " & vbCrLf &
                "            T.Name AS Agency_NAME, " & vbCrLf &
                "            T.FileSystemDirectory AS [Agency.DOC_REPOSITORY_PATH], " & vbCrLf &
                "            T.FileSystemDomain AS [Agency.DOC_REPOSITORY_USER_DOMAIN], " & vbCrLf &
                "            T.FileSystemUserName AS [Agency.DOC_REPOSITORY_USER_NAME], " & vbCrLf &
                "            T.FileSystemPassword AS [Agency.DOC_REPOSITORY_USER_PASSWORD], " & vbCrLf &
                "            True AS _from0" & vbCrLf &
                "        FROM DbContext.Agencies AS T" & vbCrLf &
                "    ) AS T1")
        End Function

        ''' <summary>
        ''' Gets the view for DbContext.Agencies.
        ''' </summary>
        ''' <returns>The mapping view.</returns>
        Private Shared Function GetView1() As DbMappingView
            Return New DbMappingView(
                "" & vbCrLf &
                "    SELECT VALUE -- Constructing Agencies" & vbCrLf &
                "        [AdvantageDocumentRepositorySettings.Database.Agency](T1.Agency_Name, T1.Agency_FileSystemDirectory, T1.Agency_FileSystemDomain, T1.Agency_FileSystemUserName, T1.Agency_FileSystemPassword)" & vbCrLf &
                "    FROM (" & vbCrLf &
                "        SELECT " & vbCrLf &
                "            T.NAME AS Agency_Name, " & vbCrLf &
                "            T.DOC_REPOSITORY_PATH AS Agency_FileSystemDirectory, " & vbCrLf &
                "            T.DOC_REPOSITORY_USER_DOMAIN AS Agency_FileSystemDomain, " & vbCrLf &
                "            T.DOC_REPOSITORY_USER_NAME AS Agency_FileSystemUserName, " & vbCrLf &
                "            T.DOC_REPOSITORY_USER_PASSWORD AS Agency_FileSystemPassword, " & vbCrLf &
                "            True AS _from0" & vbCrLf &
                "        FROM CodeFirstDatabase.Agency AS T" & vbCrLf &
                "    ) AS T1")
        End Function
    End Class
End Namespace

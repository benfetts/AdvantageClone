Namespace Database.Classes

    <Serializable()>
    Public Class AlertGroupCategory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertGroup
            AlertCategory
            IsActive
            GroupLevelSecurity
        End Enum

#End Region

#Region " Variables "

        Private _AlertGroup As String = Nothing
        Private _AlertCategory As String = Nothing
        Private _IsActive As Boolean = Nothing
        Private _GroupLevelSecurity As Short = Nothing
        Private _AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

#End Region

#Region " Properties "

        Public Property AlertGroup() As String
            Get
                AlertGroup = _AlertGroup
            End Get
            Set(ByVal value As String)
                _AlertGroup = value
            End Set
        End Property
        Public Property AlertCategory() As String
            Get
                AlertCategory = _AlertCategory
            End Get
            Set(ByVal value As String)
                _AlertCategory = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = _IsActive
            End Get
            Set(ByVal value As Boolean)
                _IsActive = value

                Try

                    _AlertGroupCategory.IsActive = Convert.ToInt16(value)

                Catch ex As Exception

                End Try

            End Set
        End Property
        Public ReadOnly Property GroupLevelSecurity As Short
            Get
                GroupLevelSecurity = _GroupLevelSecurity
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory)

            _AlertGroup = AlertGroupCategory.AlertGroupCode
            _AlertCategory = AlertGroupCategory.AlertCategory.Description
            _IsActive = Convert.ToBoolean(AlertGroupCategory.IsActive.GetValueOrDefault(0))
            _GroupLevelSecurity = AlertGroupCategory.AlertCategory.GroupLevelSecurityID.GetValueOrDefault(0)
            _AlertGroupCategory = AlertGroupCategory

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AlertGroup.ToString

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.AlertGroupCategory

            GetEntity = _AlertGroupCategory

        End Function

#End Region

    End Class

End Namespace

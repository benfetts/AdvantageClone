Namespace Database.Classes

    <Serializable()>
    Public Class AlertCategorySetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EventSetting
            AlertCategory
            IsActive
            GroupLevelSecurity
        End Enum

#End Region

#Region " Variables "

        Private _IsPDF As Boolean = False
        Private _EventSetting As String = Nothing
        Private _AlertCategory As String = Nothing
        Private _IsActive As Boolean = Nothing
        Private _AlertCategoryEntity As AdvantageFramework.Database.Entities.AlertCategory = Nothing
        Private _GroupLevelSecurity As Short = Nothing

#End Region

#Region " Properties "

        Public Property EventSetting() As String
            Get
                EventSetting = _EventSetting
            End Get
            Set(ByVal value As String)
                _EventSetting = value
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

                    If _IsPDF Then

                        _AlertCategoryEntity.HasPDFAttachment = Convert.ToInt16(value)

                    Else

                        _AlertCategoryEntity.AllowPrompt = Convert.ToInt16(value)

                    End If
                    
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

        Public Sub New(ByVal IsPDF As Boolean, ByVal AlertCategory As AdvantageFramework.Database.Entities.AlertCategory)

            _IsPDF = IsPDF

            If _IsPDF Then

                _EventSetting = "Attach PDF"
                _AlertCategory = AlertCategory.Description
                _IsActive = Convert.ToBoolean(AlertCategory.HasPDFAttachment.GetValueOrDefault(0))

            Else

                _EventSetting = "Open prompt window upon event?"
                _AlertCategory = AlertCategory.Description
                _IsActive = Convert.ToBoolean(AlertCategory.AllowPrompt.GetValueOrDefault(0))

            End If

            _GroupLevelSecurity = AlertCategory.GroupLevelSecurityID.GetValueOrDefault(0)

            _AlertCategoryEntity = AlertCategory

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EventSetting.ToString

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.AlertCategory

            GetEntity = _AlertCategoryEntity

        End Function

#End Region

    End Class

End Namespace

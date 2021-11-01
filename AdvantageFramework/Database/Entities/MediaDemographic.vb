Namespace Database.Entities

    <Table("MEDIA_DEMO")>
    Public Class MediaDemographic
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            Type
            IsChildren
            IsBoys
            IsGirls
            IsMales
            IsFemales
            AgeFrom
            AgeTo
            IsInactive
            IsSystem
            IsWorkingWomen
            MediaDemoSourceID
            ComscoreDemoNumber
            IsComscoreTierA
            IsComscoreTierB
            IsComscoreTierC
            IsComscoreTierD
            IsComscoreNational
            ComscoreGroupNumber
            ComscoreSortOrder
            ComscoreGroupName
            ComscoreGroupSortOrder
            ComscoreGroupOwnerNumber
            ComscoreGroupOwnerName
            UseForCounty
            UseForMarket
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.Code)>
        Public Property Code() As String
        <Required>
        <MaxLength(50)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Required>
        <MaxLength(1)>
        <Column("TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Type() As String
        <Column("IS_CHILDREN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsChildren() As Boolean
        <Column("IS_BOYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsBoys() As Boolean
        <Column("IS_GIRLS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsGirls() As Boolean
        <Column("IS_MALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsMales() As Boolean
        <Column("IS_FEMALES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsFemales() As Boolean
        <Column("AGE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AgeFrom() As Nullable(Of Short)
        <Column("AGE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AgeTo() As Nullable(Of Short)
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
        <Column("IS_SYSTEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsSystem() As Boolean
        <Column("IS_WORKING_WOMEN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsWorkingWomen() As Boolean
        <Required>
        <Column("MEDIA_DEMO_SOURCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaDemoSourceID() As Integer
        <Column("COMSCORE_DEMO_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreDemoNumber() As Nullable(Of Integer)
        <Required>
        <Column("IS_COMSCORE_TIER_A")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComscoreTierA() As Boolean
        <Required>
        <Column("IS_COMSCORE_TIER_B")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComscoreTierB() As Boolean
        <Required>
        <Column("IS_COMSCORE_TIER_C")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComscoreTierC() As Boolean
        <Required>
        <Column("IS_COMSCORE_TIER_D")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComscoreTierD() As Boolean
        <Required>
        <Column("IS_COMSCORE_NATIONAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComscoreNational() As Boolean
        <Column("COMSCORE_GROUP_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreGroupNumber() As Nullable(Of Integer)
        <Column("COMSCORE_SORT_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreSortOrder() As Nullable(Of Integer)
        <Column("COMSCORE_GROUP_NAME", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreGroupName() As String
        <Column("COMSCORE_GROUP_SORT_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreGroupSortOrder() As Nullable(Of Integer)
        <Column("COMSCORE_GROUP_OWNER_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreGroupOwnerNumber() As Nullable(Of Integer)
        <Column("COMSCORE_GROUP_OWNER_NAME", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreGroupOwnerName() As String
        <Required>
        <Column("USE_FOR_COUNTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UseForCounty() As Boolean
        <Required>
        <Column("USE_FOR_MARKET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UseForMarket() As Boolean

        Public Overridable Property MediaDemographicDetails As ICollection(Of Database.Entities.MediaDemographicDetail)

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaDemographicDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaDemographicDetail)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic)
                            Where Entity.IsSystem AndAlso
                                  Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                            IsValid = False

                            ErrorText = "This demographic is a system demo and already exists."

                        ElseIf (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaDemographic)
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                            IsValid = False

                            ErrorText = "This demographic already exists."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsChildren.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("C") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any children ages selected."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsBoys.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("B") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any boys ages selected."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsGirls.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("G") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any girls ages selected."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsMales.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("M") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any males ages selected."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsFemales.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("F") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any females ages selected."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.IsWorkingWomen.ToString

                    PropertyValue = Value

                    If PropertyValue Then

                        If Not GenderExistsInDetail("W") Then

                            IsValid = False

                            ErrorText = "This demographic does not have any working women ages selected."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Private Function GenderExistsInDetail(Gender As String) As Boolean

            'objects
            Dim GenderExists As Boolean = False
            Dim NielsenIDs As IEnumerable(Of Integer) = Nothing

            If Me.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen Then

                NielsenIDs = (From Entity In AdvantageFramework.Database.Procedures.NielsenDemographic.LoadByType(DbContext, Me.Type).ToList
                              Where Entity.Gender = Gender
                              Select Entity.ID).ToArray

                If (From Entity In Me.MediaDemographicDetails
                    Where NielsenIDs.Contains(Entity.NielsenDemographicID)
                    Select Entity).Any Then

                    GenderExists = True

                End If

            Else

                GenderExists = True

            End If

            GenderExistsInDetail = GenderExists

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.ComscoreGroupName.ToString

                        SetRequired(PropertyDescriptor, Me.ComscoreDemoNumber.HasValue)

                    Case AdvantageFramework.Database.Entities.MediaDemographic.Properties.ComscoreGroupOwnerName.ToString

                        SetRequired(PropertyDescriptor, Me.ComscoreDemoNumber.HasValue)

                End Select

            Next

        End Sub

#End Region

    End Class

End Namespace

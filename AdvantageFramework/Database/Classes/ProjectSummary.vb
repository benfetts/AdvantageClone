﻿Namespace Database.Classes

    <Serializable()>
    Public Class ProjectSummary
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ClientContactCode
            ClientContactID
            ClientContact
            AccountExecutiveCode
            AccountExecutive
            ManagerCode
            Manager
            JobNumber
            JobDescription
            ComponentNumber
            JobComponent
            ComponentDescription
            JobQuantity
            JobTypeCode
            JobTypeDescription
            StatusCode
            Status
            GutPercentComplete
            ClientReference
            StartDate
            DueDate
            JobComments
            ProjectScheduleComments
            NextTaskDue
            NextTaskDueDate
            NextTaskDueComment
            EstimateClientContactID
            EstimateClientContact
            EstimateDate
            EstimateApprovedDate
            EstimateApprovedBy
            EstimateAmount
            EstimateAmountWithContingency
            EstimateHours
            QvAPercent
            QvAPercentHours
            QvAPercentWithContingency
            NextMilestoneTaskDue
            NextMilestoneDueDate
            NextMilestoneDueComment
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description
            JobLevelAssignments
            Resources
            UpcomingSteps
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ClientContactCode As String = Nothing
        Private _ClientContactID As System.Nullable(Of Integer) = Nothing
        Private _ClientContact As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ManagerCode As String = Nothing
        Private _Manager As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _JobComponent As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobQuantity As System.Nullable(Of Integer) = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _StatusCode As String = Nothing
        Private _Status As String = Nothing
        Private _GutPercentComplete As System.Nullable(Of Decimal) = Nothing
        Private _ClientReference As String = Nothing
        Private _StartDate As System.Nullable(Of Date) = Nothing
        Private _DueDate As System.Nullable(Of Date) = Nothing
        Private _JobComments As String = Nothing
        Private _ProjectScheduleComments As String = Nothing
        Private _NextTaskDue As String = Nothing
        Private _NextTaskDueDate As System.Nullable(Of Date) = Nothing
        Private _NextTaskDueComment As String = Nothing
        Private _EstimateClientContactID As System.Nullable(Of Integer) = Nothing
        Private _EstimateClientContact As String = Nothing
        Private _EstimateDate As System.Nullable(Of Date) = Nothing
        Private _EstimateApprovedDate As System.Nullable(Of Date) = Nothing
        Private _EstimateApprovedBy As String = Nothing
        Private _EstimateAmount As System.Nullable(Of Decimal) = Nothing
        Private _EstimateAmountWithContingency As System.Nullable(Of Decimal) = Nothing
        Private _EstimateHours As System.Nullable(Of Decimal) = Nothing
        Private _QvAPercent As System.Nullable(Of Decimal) = Nothing
        Private _QvAPercentHours As System.Nullable(Of Decimal) = Nothing
        Private _QvAPercentWithContingency As System.Nullable(Of Decimal) = Nothing
        Private _NextMilestoneTaskDue As String = Nothing
        Private _NextMilestoneDueDate As System.Nullable(Of Date) = Nothing
        Private _NextMilestoneDueComment As String = Nothing
        Private _ClientType1Code As Nullable(Of Integer) = Nothing
        Private _ClientType1Description As String = Nothing
        Private _ClientType2Code As Nullable(Of Integer) = Nothing
        Private _ClientType2Description As String = Nothing
        Private _ClientType3Code As Nullable(Of Integer) = Nothing
        Private _ClientType3Description As String = Nothing
        Private _JobLevelAssignments As String = Nothing
        Private _Resources As String = Nothing
        Private _UpcomingSteps As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCode() As String
            Get
                ClientContactCode = _ClientContactCode
            End Get
            Set(ByVal value As String)
                _ClientContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactID() As System.Nullable(Of Integer)
            Get
                ClientContactID = _ClientContactID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _ClientContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(ByVal value As String)
                _ClientContact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ManagerCode() As String
            Get
                ManagerCode = _ManagerCode
            End Get
            Set(ByVal value As String)
                _ManagerCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Manager() As String
            Get
                Manager = _Manager
            End Get
            Set(ByVal value As String)
                _Manager = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobQuantity() As System.Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(ByVal value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StatusCode() As String
            Get
                StatusCode = _StatusCode
            End Get
            Set(ByVal value As String)
                _StatusCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GutPercentComplete() As System.Nullable(Of Decimal)
            Get
                GutPercentComplete = _GutPercentComplete
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _GutPercentComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As System.Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As System.Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComments() As String
            Get
                JobComments = _JobComments
            End Get
            Set(ByVal value As String)
                _JobComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectScheduleComments() As String
            Get
                ProjectScheduleComments = _ProjectScheduleComments
            End Get
            Set(ByVal value As String)
                _ProjectScheduleComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextTaskDue() As String
            Get
                NextTaskDue = _NextTaskDue
            End Get
            Set(ByVal value As String)
                _NextTaskDue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextTaskDueDate() As System.Nullable(Of Date)
            Get
                NextTaskDueDate = _NextTaskDueDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _NextTaskDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextTaskDueComment() As String
            Get
                NextTaskDueComment = _NextTaskDueComment
            End Get
            Set(ByVal value As String)
                _NextTaskDueComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateClientContactID() As System.Nullable(Of Integer)
            Get
                EstimateClientContactID = _EstimateClientContactID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _EstimateClientContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateClientContact() As String
            Get
                EstimateClientContact = _EstimateClientContact
            End Get
            Set(ByVal value As String)
                _EstimateClientContact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateDate() As System.Nullable(Of Date)
            Get
                EstimateDate = _EstimateDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _EstimateDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateApprovedDate() As System.Nullable(Of Date)
            Get
                EstimateApprovedDate = _EstimateApprovedDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _EstimateApprovedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateApprovedBy() As String
            Get
                EstimateApprovedBy = _EstimateApprovedBy
            End Get
            Set(ByVal value As String)
                _EstimateApprovedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateAmount() As System.Nullable(Of Decimal)
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateAmountWithContingency() As System.Nullable(Of Decimal)
            Get
                EstimateAmountWithContingency = _EstimateAmountWithContingency
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimateAmountWithContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateHours() As System.Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="QvA Percent")>
        Public Property QvAPercent() As System.Nullable(Of Decimal)
            Get
                QvAPercent = _QvAPercent
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QvAPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="QvA Percent Hours")>
        Public Property QvAPercentHours() As System.Nullable(Of Decimal)
            Get
                QvAPercentHours = _QvAPercentHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QvAPercentHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="QvA Percent With Contingency")>
        Public Property QvAPercentWithContingency() As System.Nullable(Of Decimal)
            Get
                QvAPercentWithContingency = _QvAPercentWithContingency
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QvAPercentWithContingency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextMilestoneTaskDue() As String
            Get
                NextMilestoneTaskDue = _NextMilestoneTaskDue
            End Get
            Set(ByVal value As String)
                _NextMilestoneTaskDue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextMilestoneDueDate() As System.Nullable(Of Date)
            Get
                NextMilestoneDueDate = _NextMilestoneDueDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _NextMilestoneDueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextMilestoneDueComment() As String
            Get
                NextMilestoneDueComment = _NextMilestoneDueComment
            End Get
            Set(ByVal value As String)
                _NextMilestoneDueComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Code")>
        Public Property ClientType1Code() As Nullable(Of Integer)
            Get
                ClientType1Code = _ClientType1Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType1Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
        Public Property ClientType1Description() As String
            Get
                ClientType1Description = _ClientType1Description
            End Get
            Set(ByVal value As String)
                _ClientType1Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Code")>
        Public Property ClientType2Code() As Nullable(Of Integer)
            Get
                ClientType2Code = _ClientType2Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType2Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
        Public Property ClientType2Description() As String
            Get
                ClientType2Description = _ClientType2Description
            End Get
            Set(ByVal value As String)
                _ClientType2Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Code")>
        Public Property ClientType3Code() As Nullable(Of Integer)
            Get
                ClientType3Code = _ClientType3Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType3Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
        Public Property ClientType3Description() As String
            Get
                ClientType3Description = _ClientType3Description
            End Get
            Set(ByVal value As String)
                _ClientType3Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Assignments", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property JobLevelAssignments() As String
            Get
                JobLevelAssignments = _JobLevelAssignments
            End Get
            Set(ByVal value As String)
                _JobLevelAssignments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Resources() As String
            Get
                Resources = _Resources
            End Get
            Set(ByVal value As String)
                _Resources = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property UpcomingSteps() As String
            Get
                UpcomingSteps = _UpcomingSteps
            End Get
            Set(ByVal value As String)
                _UpcomingSteps = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace

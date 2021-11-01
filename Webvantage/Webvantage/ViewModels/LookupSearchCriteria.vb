Namespace ViewModels

    Public Class LookupSearchCriteria

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LookupTypes
            [Default] ' none found
            Client
            Division
            Product
            Job
            JobComponent
            [Function]
            GeneralLedgerAccount
            Employee
            Vendor
            VendorContact
            FunctionCategory
            TaxCode
            Estimate
            ProductCategory
            EmployeeTitle
            Assignment
        End Enum

#End Region

#Region " Variables "

        Private _LookupTypeDisplayName As String = Nothing

#End Region

#Region " Properties "

#Region " - Generic - "

        Public Property SecurityModule As String
        Public Property LookupType As String
        Public Property LookupTypeDisplayName As String
            Get
                If [String].IsNullOrWhiteSpace(_LookupTypeDisplayName) Then
                    If Me.GetLookupType <> LookupTypes.Default Then
                        _LookupTypeDisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(Me.LookupType)
                    Else
                        _LookupTypeDisplayName = ""
                    End If
                End If
                LookupTypeDisplayName = _LookupTypeDisplayName
            End Get
            Set(value As String)
                _LookupTypeDisplayName = value
            End Set
        End Property

#End Region

#Region " - Lookup Objects - "

        Public Property JobComponent As ViewModels.LookupObjects.JobComponent
        Public Property [Function] As ViewModels.LookupObjects.Function
        Public Property FunctionCategory As ViewModels.LookupObjects.FunctionCategory
        Public Property GeneralLedgerAccount As ViewModels.LookupObjects.GeneralLedgerAccount
        Public Property Employee As ViewModels.LookupObjects.Employee
        Public Property Vendor As ViewModels.LookupObjects.Vendor
        Public Property VendorContact As ViewModels.LookupObjects.VendorContact
        Public Property Tax As ViewModels.LookupObjects.Tax
        Public Property Estimate As ViewModels.LookupObjects.Estimate
        Public Property ProductCategory As ViewModels.LookupObjects.ProductCategory
        Public Property EmployeeTitle As ViewModels.LookupObjects.EmployeeTitle
        Public Property Assignment As ViewModels.LookupObjects.Assignment

#End Region

#End Region

#Region " Methods "

        Public Sub New()

            If Me.JobComponent Is Nothing Then

                Me.JobComponent = New LookupObjects.JobComponent

            End If

            If Me.Function Is Nothing Then

                Me.Function = New LookupObjects.Function

            End If

            If Me.FunctionCategory Is Nothing Then

                Me.FunctionCategory = New LookupObjects.FunctionCategory

            End If

            If Me.Estimate Is Nothing Then

                Me.Estimate = New LookupObjects.Estimate

            End If

            If Me.Assignment Is Nothing Then

                Me.Assignment = New LookupObjects.Assignment

            End If

        End Sub
        Public Function GetLookupType() As ViewModels.LookupSearchCriteria.LookupTypes

            'objects
            Dim LookupTypeEnum As ViewModels.LookupSearchCriteria.LookupTypes = Nothing
            Dim RealType As String = Nothing

            Try

                If [Enum].GetNames(GetType(ViewModels.LookupSearchCriteria.LookupTypes)).Any(Function(EnumName) EnumName.ToLower = Me.LookupType.ToLower) Then

                    LookupTypeEnum = [Enum].Parse(GetType(ViewModels.LookupSearchCriteria.LookupTypes), Me.LookupType)

                ElseIf Me.LookupType.ToLower.Contains("code") Then

                    RealType = Me.LookupType.ToLower.Remove("code")

                ElseIf Me.LookupType.ToLower.Contains("number") Then

                    RealType = Me.LookupType.ToLower.Remove("number")

                End If

                If LookupTypeEnum = ViewModels.LookupSearchCriteria.LookupTypes.Default AndAlso Not [String].IsNullOrWhiteSpace(RealType) Then

                    Me.LookupType = RealType

                    LookupTypeEnum = GetLookupType()

                    If LookupTypeEnum <> ViewModels.LookupSearchCriteria.LookupTypes.Default Then

                        Me.LookupType = AdvantageFramework.StringUtilities.GetNameAsWords(LookupTypeEnum.ToString)

                    End If

                End If

            Catch ex As Exception
                LookupTypeEnum = ViewModels.LookupSearchCriteria.LookupTypes.Default
            Finally
                GetLookupType = LookupTypeEnum
            End Try

        End Function

#End Region

    End Class

End Namespace



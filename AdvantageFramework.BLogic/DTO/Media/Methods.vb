Namespace DTO.Media

	<HideModuleName()>
	Public Module Methods

#Region " Constants "

        Public Const ConstNielsenRadioFooter As String = "The PPM ratings are based on audience estimates and are the opinion of Nielsen and should not be relied on for precise accuracy or precise representativeness of the demographic or radio market." & vbCrLf &
            "In-Tabs displayed in Summary Data may not reflect all estimates which are reported. Nielsen Summary Radio Data reports Average Daily In-Tab for geographies which include PPM-measured areas.  " &
            "The Average Daily In-Tab is the basis for Average Quarter-Hour Estimates. The Average Weekly In-Tab, which is not included in PPM Summary Data, is the basis for Weekly Cume estimates.  Users can find both Average Daily and Average Weekly In-Tab in the PPM Respondent Data."

        Public Const ConstNielsenTVFooter As String = "* These estimates should be used with caution as they are derived from a sample that does not meet The Nielsen Company’s minimum sample size requirements for reporting."

        Public Const ConstComscoreTVFooter As String = "* Data falls below Comscore high-quality threshold." & vbCrLf & "** Data falls below Comscore reportability threshold."

        Public Const ConstNielsenRadioDiaryFooter As String = "Nielsen Audio strongly recommends against using multi-book averages for this market because the results will be an average of an average."

#End Region

#Region " Enum "

        Public Enum MediaTypes
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("M", "Magazine")>
			Magazine
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Newspaper")>
			Newspaper
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Radio")>
			Radio
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Television")>
			Television
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Out of Home")>
			OutOfHome
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("I", "Internet")>
			Internet
		End Enum

		Public Enum CalendarTypes
			Calendar = 1
			Broadcast = 2
		End Enum

        Public Enum ResearchCriteriaTypes
            SpotTV
            SpotRadio
            SpotRadioCounty
            SpotNational
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Module

End Namespace

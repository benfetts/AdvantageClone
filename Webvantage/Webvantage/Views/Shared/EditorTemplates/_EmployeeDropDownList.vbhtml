@ModelType AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel 

@Html.Kendo().DropDownListFor(Function(md) md.RepositoryEmployeeList).Name("EmployeeDropDownList").DataTextField("LastName").DataValueField("EmployeeCode")

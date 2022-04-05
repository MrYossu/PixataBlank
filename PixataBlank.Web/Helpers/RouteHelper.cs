namespace PixataBlank.Web.Helpers;

public class RouteHelper {
  public const string Home = @"/";

  public const string Login = "/Login";
  public const string Logout = "/Logout";

  public const string Agents = @"/Agents";
  public const string AgentDetails = @"/Agents/AgentDetails/";
  public const string AgentDetailsId = @"/Agents/AgentDetails/{Id:int?}";

  public const string Companies = @"/Companies";
  public const string CompanyDetails = @"/Companies/CompanyDetails/";
  public const string CompanyDetailsId = @"/Companies/CompanyDetails/{Id:int?}";

  public const string Contractors = @"/Contractors";
  public const string ContractorDetails = @"/Contractors/ContractorDetails/";
  public const string ContractorDetailsId = @"/Contractors/ContractorDetails/{Id:int?}";

  public const string Investors = @"/Investors";
  public const string InvestorDetails = @"/Investors/InvestorDetails/";
  public const string InvestorDetailsId = @"/Investors/InvestorDetails/{Id:int?}";

  public const string PropertyGroups = @"/PropertyGroups";
  public const string PropertyGroupDetails = @"/PropertyGroups/PropertyGroupDetails/";
  public const string PropertyGroupDetailsId = @"/PropertyGroups/PropertyGroupDetails/{Id:int?}";
  public const string PropertyDetails = @"/PropertyGroups/PropertyDetails/";
  public const string PropertyDetailsId = @"/PropertyGroups/PropertyDetails/{Id:int}";

  public const string Users = @"/Users";
  public const string UserDetails = @"/Users/UserDetails/";
  public const string UserDetailsId = @"/Users/UserDetails/{Id?}";
}
Namespace Quickbooks.Classes

    Public Class DiscoveryData
        <Newtonsoft.Json.JsonProperty("issuer")>
        Public Property Issuer As String
        <Newtonsoft.Json.JsonProperty("authorization_endpoint")>
        Public Property AuthorizationEndpoint As String
        <Newtonsoft.Json.JsonProperty("token_endpoint")>
        Public Property TokenEndpoint As String
        <Newtonsoft.Json.JsonProperty("userinfo_endpoint")>
        Public Property UserinfoEndpoint As String
        <Newtonsoft.Json.JsonProperty("revocation_endpoint")>
        Public Property RevocationEndpoint As String
        <Newtonsoft.Json.JsonProperty("jwks_uri")>
        Public Property JWKS_uri As String
        <Newtonsoft.Json.JsonProperty("response_types_supported")>
        Public Property ResponseTypesSupported As List(Of String)
        <Newtonsoft.Json.JsonProperty("subject_types_supported")>
        Public Property SubjectTypesSupported As List(Of String)
        <Newtonsoft.Json.JsonProperty("id_token_signing_alg_values_supported")>
        Public Property IdTokenSigningAlgValuesSupported As List(Of String)
        <Newtonsoft.Json.JsonProperty("scopes_supported")>
        Public Property ScopesSupported As List(Of String)
        <Newtonsoft.Json.JsonProperty("token_endpoint_auth_methods_supported")>
        Public Property TokenEndpointAuthMethodsSupported As List(Of String)
        <Newtonsoft.Json.JsonProperty("claims_supported")>
        Public Property ClaimsSupported As List(Of String)
    End Class

End Namespace

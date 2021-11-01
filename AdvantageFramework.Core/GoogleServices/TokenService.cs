using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.GoogleServices
{
    public partial class TokenService
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static Assembly _Assembly = null;
        private static MethodInfo[] _MethodInfos = null;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static Assembly GetServicesAssembly()
        {
            Assembly GetServicesAssemblyRet = default;
            try
            {
                if (_Assembly is null)
                {
                    _Assembly = Assembly.Load("AdvantageFramework.GoogleServices");
                }
            }
            catch (Exception ex)
            {
                _Assembly = null;
            }

            GetServicesAssemblyRet = _Assembly;
            return GetServicesAssemblyRet;
        }

        private static MethodInfo[] GetServiceMethodInfos()
        {
            MethodInfo[] GetServiceMethodInfosRet = default;
            Assembly Assembly = null;
            Type BaseMethodType = null;
            try
            {
                if (_MethodInfos is null)
                {
                    Assembly = GetServicesAssembly();
                    if (Assembly is object)
                    {
                        BaseMethodType = LoadBaseMethodTypeShared(Assembly);
                        if (BaseMethodType is object)
                        {
                            _MethodInfos = BaseMethodType.GetMethods();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _MethodInfos = null;
            }

            GetServiceMethodInfosRet = _MethodInfos;
            return GetServiceMethodInfosRet;
        }

        private static Type LoadBaseMethodTypeShared(Assembly Assembly)
        {
            Type LoadBaseMethodTypeSharedRet = default;

            // objects
            Type BaseMethodType = null;
            try
            {
                BaseMethodType = Assembly.GetTypes().Where(Type => Type.FullName == "AdvantageFramework.GoogleServices.Methods").SingleOrDefault();
            }
            catch (Exception ex)
            {
                BaseMethodType = null;
            }
            finally
            {
                LoadBaseMethodTypeSharedRet = BaseMethodType;
            }

            return LoadBaseMethodTypeSharedRet;
        }

        public static string GetOrRefreshToken(string ConnectionString, bool UseWindowsAuthentication, string EmployeeCode, string[] Scopes, string ClientCode)
        {
            string GetOrRefreshTokenRet = default;

            // objects
            string AccessToken = string.Empty;
            MethodInfo[] MethodInfos = null;
            try
            {
                MethodInfos = GetServiceMethodInfos();
                if (MethodInfos is object)
                {
                    AccessToken = (MethodInfos.Where(Method => Method.Name == "GetOrRefreshToken").SingleOrDefault().Invoke(null, new[] { ConnectionString, (object)UseWindowsAuthentication, EmployeeCode, Scopes, ClientCode })).ToString();
                }
            }
            catch (Exception)
            {
                AccessToken = null;
            }
            finally
            {
                GetOrRefreshTokenRet = AccessToken;
            }

            return GetOrRefreshTokenRet;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}

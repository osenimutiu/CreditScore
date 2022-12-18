using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using IFRSDemo.Authorization.Users;
using IFRSDemo.MultiTenancy;

namespace IFRSDemo.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
using System.Collections.ObjectModel;

namespace Cradle.Application.Common.Authorization
{
    public record AppPermission(string Feature, string Action, string Group, string Description, bool IsBasic = false)
    {
        public string Name => NameFor(Feature, Action);
        public static string NameFor(string feature, string action)
            => $"Permission.{feature}.{action}";
    }

    public class AppPermissions
    {
        private static readonly AppPermission[] _all = new AppPermission[]
        {
            new(AppFeature.Users, AppAction.Create, AppRoleGroup.SystemAccessGroup, "Create Users"),
            new(AppFeature.Users, AppAction.Read, AppRoleGroup.SystemAccessGroup, "Read Users"),
            new(AppFeature.Users, AppAction.Update, AppRoleGroup.SystemAccessGroup, "Update Users"),
            new(AppFeature.Users, AppAction.Delete, AppRoleGroup.SystemAccessGroup, "Delete Users"),


            new(AppFeature.UsersRoles, AppAction.Read, AppRoleGroup.SystemAccessGroup, "Read Users Roles"),
            new(AppFeature.UsersRoles, AppAction.Update, AppRoleGroup.SystemAccessGroup, "Update Users Roles"),

            new(AppFeature.Roles, AppAction.Create, AppRoleGroup.SystemAccessGroup, "Create Roles"),
            new(AppFeature.Roles, AppAction.Read, AppRoleGroup.SystemAccessGroup, "Read Roles"),
            new(AppFeature.Roles, AppAction.Update, AppRoleGroup.SystemAccessGroup, "Update Roles"),
            new(AppFeature.Roles, AppAction.Delete, AppRoleGroup.SystemAccessGroup, "Delete Roles"),


            new(AppFeature.RoleClaims, AppAction.Read, AppRoleGroup.SystemAccessGroup, "Read Claims/Roles"),
            new(AppFeature.RoleClaims, AppAction.Update, AppRoleGroup.SystemAccessGroup, "Update Claims/Roles"),


            new(AppFeature.Course, AppAction.Create, AppRoleGroup.Management, "Create Subject"),
            new(AppFeature.Course, AppAction.Read, AppRoleGroup.Management, "Read Subject"),
            new(AppFeature.Course, AppAction.Update, AppRoleGroup.Management, "Update Subject"),
            new(AppFeature.Course, AppAction.Delete, AppRoleGroup.Management, "Delete Subject"),


            new(AppFeature.Student, AppAction.Create, AppRoleGroup.Management, "Create Student"),
            new(AppFeature.Student, AppAction.Read, AppRoleGroup.Management, "Read Students"),
            new(AppFeature.Student, AppAction.Update, AppRoleGroup.Management, "Update Student"),
            new(AppFeature.Student, AppAction.Delete, AppRoleGroup.Management, "Delete Student"),
        };

        public static IReadOnlyList<AppPermission> AdminPermission { get; } =
           new ReadOnlyCollection<AppPermission>(_all.Where(p => !p.IsBasic).ToArray());

        public static IReadOnlyList<AppPermission> BasicPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_all.Where(p => p.IsBasic).ToArray());
    }
}

CREATE VIEW [dbo].[UserInRoles]
AS
SELECT        dbo.Users.UserName, dbo.webpages_Roles.RoleName
FROM            dbo.webpages_Roles INNER JOIN
                         dbo.webpages_UsersInRoles ON dbo.webpages_Roles.RoleId = dbo.webpages_UsersInRoles.RoleId INNER JOIN
                         dbo.Users ON dbo.webpages_UsersInRoles.UserId = dbo.Users.UserId
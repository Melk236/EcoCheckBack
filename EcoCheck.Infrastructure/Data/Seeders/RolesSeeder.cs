using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EcoCheck.Infrastructure.Data.Seeders
{
    public class RolesSeeder
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ILogger<RolesSeeder> _logger;

        public RolesSeeder(RoleManager<IdentityRole<int>> roleManager, ILogger<RolesSeeder> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task SeedRoles()
        {
            try
            {
                var roles = new[] { "Admin", "User" };
                int rolesCreated = 0;

                foreach (var roleName in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        var result = await _roleManager.CreateAsync(new IdentityRole<int>(roleName));
                        if (result.Succeeded)
                        {
                            _logger.LogInformation("Role '{Role}' created successfully", roleName);
                            rolesCreated++;
                        }
                        else
                        {
                            _logger.LogError("Failed to create role '{Role}': {Errors}", 
                                roleName, string.Join(", ", result.Errors.Select(e => e.Description)));
                        }
                    }
                    else
                    {
                        _logger.LogInformation("Role '{Role}' already exists", roleName);
                    }
                }

                if (rolesCreated > 0)
                {
                    _logger.LogInformation("Successfully created {Count} roles", rolesCreated);
                }
                else
                {
                    _logger.LogInformation("All roles already exist, no new roles created");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding roles");
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EricBlogProject.Data;
using EricBlogProject.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EricBlogProject.Services
{
    public class DataService

    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;


        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task ManageDataAsync()
        {
            // Task 1: Seed roles into the system
            await SeedRolesAsync();

            // Task 2: Seed users into the system
            await SeedUsersAsync();
 
        }

        private async Task SeedRolesAsync()
        {
            // if there are already roles in the system , do nothing
            if (_dbContext.Roles.Any())
            {
                return;
            }

            // otherwise we want to create a few roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                // Need to use the Role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {

        }

        // Task 3: 
    }
}

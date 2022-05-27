using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EricBlogProject.Data;
using EricBlogProject.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EricBlogProject.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EricBlogProject.Services
{
    public class DataService

    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;


        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            // Task: Create the DB from the Migration
            await _dbContext.Database.MigrateAsync();

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
            // if there are already user in the system, do nothing
            if (_dbContext.UserClaims.Any())
            {
                return;
            }

            // Step1 creates a new instance of BlogUser
            // otherwise we want to create a few users
            var adminUser = new BlogUser()
            {
                Email = "zhangzx45@gmail.com",
                UserName = "zhangzx45@gmail.com",
                FirstName = "Eric",
                LastName = "Zhang",
                DisplayName= "The Builder",
                PhoneNumber = "0070070007",
                EmailConfirmed = true

            };

            // Step 2: User the UserMangager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            // Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //-------------------------------------------------------

            // Step 1 repeat: create the moderator user
            var modUser = new BlogUser()
            {
                Email = "xiaomei.mandy.li@gmail.com",
                UserName = "xiaomei.mandy.li@gmail.com",
                FirstName = "Annie",
                LastName = "Li",
                DisplayName="The Decorater",
                PhoneNumber = "0070080007",
                EmailConfirmed = true
            };
            // Step 2: User the UserMangager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(modUser, "Abc&123!");
            // Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }

    }
}

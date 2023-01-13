using Domain;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    internal static class Seed
    {
        private const string DUserId1 = "3c177013-3086-4f27-b700-bf02c1f327dc";
        private const string DUserId2 = "e4eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c";
        private const string DUserId3 = "f07f9516-94bd-4251-8756-822a582e7df6";

        private const string IUserId1 = "4c177013-3086-4f27-b700-bf02c1f327dc";
        private const string IUserId2 = "44eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c";
        private const string IUserId3 = "407f9516-94bd-4251-8756-822a582e7df6";

        private const string FormId1 = "77177013-3086-4f27-b700-bf02c1f327dc";
        private const string FormId2 = "77eb0b1c-3cda-4548-a5bf-7dcc79cf9a4c";
        private const string FormId3 = "77ef9516-94bd-4251-8756-822a582e7df6";

        public static ModelBuilder SeedDomain(this ModelBuilder modelBuilder)
        {
            modelBuilder.CreateDomainUser();
            modelBuilder.CreateForms();

            return modelBuilder;
        }

        public static ModelBuilder SeedIdentity(this ModelBuilder modelBuilder)
        {
            modelBuilder.CreateIdentityUser();

            return modelBuilder;
        }

        private static ModelBuilder CreateDomainUser(this ModelBuilder modelBuilder)
        {
            var users = new List<DomainUser>
            {
                new DomainUser
                {
                    UserName = "seed1.df@gmail.com",
                    Id = Guid.Parse(DUserId1),
                    Email = "seed1.df@gmail.com",
                    UserAuthId = Guid.Parse(IUserId1)
                },
                new DomainUser
                {
                    UserName = "seed2.df@gmail.com",
                    Id = Guid.Parse(DUserId2),
                    Email = "seed2.df@gmail.com",
                    UserAuthId = Guid.Parse(IUserId2)
                },
                new DomainUser
                {
                    UserName = "seed3.df@gmail.com",
                    Id = Guid.Parse(DUserId3),
                    Email = "seed3.df@gmail.com",
                    UserAuthId = Guid.Parse(IUserId3)
                }
            };

            modelBuilder.Entity<DomainUser>().HasData(users);

            return modelBuilder;
        }

        private static ModelBuilder CreateIdentityUser(this ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User
                {
                    UserName = "seed1.df@gmail.com",
                    Id = Guid.Parse(IUserId1),
                    Email = "seed1.df@gmail.com",
                },
                new User
                {
                    UserName = "seed2.df@gmail.com",
                    Id = Guid.Parse(IUserId2),
                    Email = "seed2.df@gmail.com"
                },
                new User
                {
                    UserName = "seed3.df@gmail.com",
                    Id = Guid.Parse(IUserId3),
                    Email = "seed3.df@gmail.com"
                }
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            users = users.Select(x =>
            {
                x.PasswordHash = passwordHasher.HashPassword(x, "SeedPass1*");
                x.NormalizedEmail = x.Email.ToUpper();
                x.NormalizedUserName = x.UserName.ToUpper();
                x.SecurityStamp = Guid.NewGuid().ToString("D");

                return x;
            }).ToList();

            modelBuilder.Entity<User>().HasData(users);

            return modelBuilder;
        }

        private static ModelBuilder CreateForms(this ModelBuilder modelBuilder)
        {

            var forms = new List<Form>
            {
                new Form 
                {
                    Name = "Seed seed1.df Form1",
                    CreatorId = Guid.Parse(DUserId1),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
                new Form
                {
                    Name = "Seed seed1.df Form2",
                    CreatorId = Guid.Parse(DUserId1),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Private
                },
                new Form
                {
                    Name = "Seed seed1.df Form3",
                    CreatorId = Guid.Parse(DUserId1),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
                new Form
                {
                    Name = "Seed seed2.df Form1",
                    CreatorId = Guid.Parse(DUserId2),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
                new Form
                {
                    Name = "Seed seed2.df Form1",
                    CreatorId = Guid.Parse(DUserId2),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Private
                },
                new Form
                {
                    Name = "Seed seed2.df Form1",
                    CreatorId = Guid.Parse(DUserId2),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
                new Form
                {
                    Name = "Seed seed3.df Form1",
                    CreatorId = Guid.Parse(DUserId3),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
                new Form
                {
                    Name = "Seed seed3.df Form1",
                    CreatorId = Guid.Parse(DUserId3),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Private
                },
                new Form
                {
                    Name = "Seed seed3.df Form1",
                    CreatorId = Guid.Parse(DUserId3),
                    DateCreated = DateTimeOffset.Now,
                    Id = Guid.NewGuid(),
                    Visibility = Visibility.Public
                },
            };

            modelBuilder.Entity<Form>().HasData(forms);

            return modelBuilder;
        }
    }
}

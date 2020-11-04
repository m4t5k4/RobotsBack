using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RobotsAPI.Models;

namespace RobotsAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RobotsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Robots.Any())
            {
                return;   // DB has been seeded
            }

            context.Categories.AddRange(
                new Category { Name = "Education", Comment = "This broad category is aimed at the next generation of roboticists, for use at home or in classrooms. It includes hands-on programmable sets from Lego, 3D printers with lesson plans, and even teacher robots like EMYS." },
                new Category { Name = "Drone", Comment = "Also called unmanned aerial vehicles, drones come in different sizes and have different levels of autonomy. Examples include DJI’s popular Phantom series and Parrot’s Anafi, as well as military systems like Global Hawk, used for long-duration surveillance." },
                new Category { Name = "Entertainment", Comment = "These robots are designed to evoke an emotional response and make us laugh or feel surprise or in awe. Among them are robot comedian RoboThespian, Disney’s theme park robots like Navi Shaman, and musically inclined bots like Partner." },
                new Category { Name = "Aerospace", Comment = "This is a broad category. It includes all sorts of flying robots—the SmartBird robotic seagull and the Raven surveillance drone, for example—but also robots that can operate in space, such as Mars rovers and NASA's Robonaut, the humanoid that flew to the International Space Station and is now back on Earth." },
                new Category { Name = "Consumer", Comment = "Consumer robots are robots you can buy and use just for fun or to help you with tasks and chores. Examples are the robot dog Aibo, the Roomba vacuum, AI-powered robot assistants, and a growing variety of robotic toys and kits." }
            );
            context.SaveChanges();

            context.Manufacturers.AddRange(
                new Manufacturer { Name = "Diligent Robotics", Location = "Texas, USA" },
                new Manufacturer { Name = "Boston Dynamics", Location = "Massachusetts, USA" },
                new Manufacturer { Name = "Bluefin Robotics", Location = "Paris, France" },
                new Manufacturer { Name = "Applied Aeronautics", Location = "Austin, USA" },
                new Manufacturer { Name = "Left Hand Robotics", Location = "Longmont, USA" },
                new Manufacturer { Name = "Dronesense", Location = "Brussels, Belgium" },
                new Manufacturer { Name = "Harvest Automation", Location = "Madrid, Spain" },
                new Manufacturer { Name = "Rethink Robotics", Location = "Palo Alto, USA" }
            );
            context.SaveChanges();

            context.Robots.AddRange(
                new Robot { Name = "Marvin", Serialnumber = "addcb35-aee4c5b1cf8-eadb54f7-435aee", ManufacturerID = 1, CategoryID = 3, Image = "robot1.jpg" },
                new Robot { Name = "Unimate", Serialnumber = "addcb35-aee4c5b1cf8-eadb54f7-4335ae", ManufacturerID = 6, CategoryID = 2, Image = "robot8.jpg" },
                new Robot { Name = "S-Bot", Serialnumber = "aeadb35-aee4c5b1cf8-ead35ae7-4eadbe", ManufacturerID = 2, CategoryID = 3, Image = "robot13.jpg" },
                new Robot { Name = "Llia", Serialnumber = "addcb35-aee4c35aef8-eadb54f7-43f82e", ManufacturerID = 5, CategoryID = 1, Image = "robot3.jpg" },
                new Robot { Name = "RB5X", Serialnumber = "addcb35-aee4c5b1cf8-eadb54f7-43eadb", ManufacturerID = 3, CategoryID = 1, Image = "robot7.jpg" },
                new Robot { Name = "Manav", Serialnumber = "addcb35-aee4c35aef8-eadb54f7-43f82e", ManufacturerID = 7, CategoryID = 4, Image = "robot9.jpg" },
                new Robot { Name = "Lilly", Serialnumber = "add35ae-aee4c5b1cf8-eadb54f7-43f82e", ManufacturerID = 3, CategoryID = 1, Image = "robot2.jpg" },
                new Robot { Name = "Rosie", Serialnumber = "addcb35-aee4c5b1cf8-eadb54f7-43f82e", ManufacturerID = 2, CategoryID = 2, Image = "robot6.jpg" },
                new Robot { Name = "Abe", Serialnumber = "addcb35-aee435aef8-eadb54f7-43f82e", ManufacturerID = 8, CategoryID = 2, Image = "robot10.jpg" },
                new Robot { Name = "Eve", Serialnumber = "addcb35-aee4c5b1cf8-ea35aef7-43f82e", ManufacturerID = 1, CategoryID = 3, Image = "robot4.jpg" },
                new Robot { Name = "Kitt", Serialnumber = "aeadb35-aee4c5b1cf8-eadb54f7-43f82e", ManufacturerID = 4, CategoryID = 4, Image = "robot11.jpg" },
                new Robot { Name = "MQ-1", Serialnumber = "addcb35-aee4c5b1cf8-ead35ae7-4feadb", ManufacturerID = 1, CategoryID = 5, Image = "robot12.jpg" },
                new Robot { Name = "Molly", Serialnumber = "aeadb35-aee435aecf8-eadb54f7-43f82e", ManufacturerID = 5, CategoryID = 5, Image = "robot5.jpg" }
            );
            context.SaveChanges();

        }
    }
}
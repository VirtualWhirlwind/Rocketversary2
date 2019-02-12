using System;
using System.IO;
using infrastructure.DB;
using infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace infrastructure.Tests.DbTests
{
    public class DbTest
    {
        public IConfigurationRoot Configuration { get; }
        // public string DBConnection { get { return Configuration["ConnectionStrings:Main"]; } }
        public string DBConnection { get { return "mongodb://localhost:27017/rocketversary_tests"; } }
        public DbMgr DB { get; set; }

        public DbTest()
        {
            // Configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //     .Build();
            DB = new DbMgr(new DbContext(DBConnection));
        }

        [Fact]
        public void SaveSpaceEvent()
        {
            // Arrange
            var SE = new SpaceEvent()
            {
                Name = "Test Event",
                Country = "United States",
                Date = DateTime.Now
            };
            
            // Act
            DB.SaveSpaceEvent(SE);
            
            // Assert
            
        }
    }
}
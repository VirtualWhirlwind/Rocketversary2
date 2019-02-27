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

        [Fact]
        public void SpaceEventGroup()
        {
            //Given
            var SE1 = new SpaceEvent()
            {
                Name = "Test Event 1",
                Country = "United States",
                Date = new DateTime(1969, 1, 1)
            };
            var SE2 = new SpaceEvent()
            {
                Name = "Test Event 2",
                Country = "United States",
                Date = new DateTime(1980, 5, 1)
            };
            var SE2_2 = new SpaceEvent()
            {
                Name = "Test Event 2_2",
                Country = "United States",
                Date = new DateTime(1981, 5, 1)
            };
            var SE3 = new SpaceEvent()
            {
                Name = "Test Event 3",
                Country = "United States",
                Date = new DateTime(2000, 12, 1)
            };
            DB.SaveSpaceEvent(SE1);
            DB.SaveSpaceEvent(SE2);
            DB.SaveSpaceEvent(SE2_2);
            DB.SaveSpaceEvent(SE3);
        
            //When
            var SEGroup = DB.GetGroupForDate(new DateTime(2019, 5, 1));
        
            //Then
            Assert.True(SEGroup.CurrentCount > 1);
            Assert.NotNull(SEGroup.Previous);
            Assert.NotNull(SEGroup.Next);
        }
    }
}
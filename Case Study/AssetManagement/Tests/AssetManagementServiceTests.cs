using System;
using Xunit;
using Asset_Management.Entities;
using dao;
using Exceptions;

namespace Asset_Management.Tests
{
    public class AssetManagementServiceTests
    {
        private readonly AssetManagementServiceImpl service;

        public AssetManagementServiceTests()
        {
            // Use a valid connection string directly (replace with your actual connection string)
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AssetDB;Integrated Security=True;";
            service = new AssetManagementServiceImpl(connectionString);
        }

        [Fact]
        public void Test_AddAsset_Success()
        {
            // Ensure PurchaseDate is a string
            Asset asset = new Asset
            {
                Name = "Test Projector",
                Type = "Electronics",
                SerialNumber = "SN123456",
                PurchaseDate = DateTime.Now.ToString("yyyy-MM-dd"), // Convert to string
                Location = "Training Room 2",
                Status = "Available",
                OwnerId = 1
            };

            bool result = service.AddAsset(asset);
            Assert.True(result);
        }

        [Fact]
        public void Test_PerformMaintenance_Success()
        {
            string maintenanceDate = DateTime.Now.ToString("yyyy-MM-dd"); // Ensure it's string formatted
            bool result = service.PerformMaintenance(1, maintenanceDate, "Routine check", 200);
            Assert.True(result);
        }

        [Fact]
        public void Test_ReserveAsset_Success()
        {
            DateTime now = DateTime.Now;
            DateTime returnDate = now.AddDays(5);

            // Pass DateTime directly to ReserveAsset
            bool result = service.ReserveAsset(1, 1, now, returnDate, "Reserved for onsite visit"); // Pass DateTime values directly
            Assert.True(result);
        }

        [Fact]
        public void Test_AssetNotFoundException_Thrown()
        {
            int invalidAssetId = -99;
            var exception = Assert.Throws<AssetNotFoundException>(() =>
            {
                service.DeleteAsset(invalidAssetId);
            });

            Assert.Equal("Asset ID not found", exception.Message);
        }
    }
}

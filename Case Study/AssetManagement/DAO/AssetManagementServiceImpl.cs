using System;
using Microsoft.Data.SqlClient;
using Asset_Management.Entities;
using Asset_Management.Util;
using Exceptions;

namespace dao
{
    // This class implements the AssetManagementService interface and provides actual logic for asset-related operations
    public class AssetManagementServiceImpl : AssetManagementService
    {
        private string connectionString;

        // Constructor to initialize the database connection string
        public AssetManagementServiceImpl(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Adds a new asset record into the assets table
        public bool AddAsset(Asset asset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO assets (name, type, serial_number, purchase_date, location, status, owner_id) VALUES (@name, @type, @serial, @purchaseDate, @location, @status, @ownerId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", asset.Name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@location", asset.Location);
                cmd.Parameters.AddWithValue("@status", asset.Status);
                cmd.Parameters.AddWithValue("@ownerId", asset.OwnerId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Updates existing asset details using asset ID
        public bool UpdateAsset(Asset asset)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE assets SET name=@name, type=@type, serial_number=@serial, purchase_date=@purchaseDate, location=@location, status=@status, owner_id=@ownerId WHERE asset_id=@assetId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assetId", asset.AssetId);
                cmd.Parameters.AddWithValue("@name", asset.Name);
                cmd.Parameters.AddWithValue("@type", asset.Type);
                cmd.Parameters.AddWithValue("@serial", asset.SerialNumber);
                cmd.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                cmd.Parameters.AddWithValue("@location", asset.Location);
                cmd.Parameters.AddWithValue("@status", asset.Status);
                cmd.Parameters.AddWithValue("@ownerId", asset.OwnerId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Deletes an asset by its ID and throws a custom exception if not found
        public bool DeleteAsset(int assetId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM assets WHERE asset_id=@assetId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assetId", assetId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                    throw new AssetNotFoundException("Asset ID not found");
                return true;
            }
        }

        // Allocates an asset to an employee by inserting a record into asset_allocations table
        public bool AllocateAsset(int assetId, int employeeId, string allocationDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO asset_allocations (asset_id, employee_id, allocation_date) VALUES (@assetId, @employeeId, @allocationDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@allocationDate", allocationDate);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Deallocates an asset from an employee by updating the return_date
        public bool DeallocateAsset(int assetId, int employeeId, string returnDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE asset_allocations SET return_date=@returnDate WHERE asset_id=@assetId AND employee_id=@employeeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@returnDate", returnDate);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Adds a maintenance record for an asset
        public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO maintenance_records (asset_id, maintenance_date, description, cost) VALUES (@assetId, @maintenanceDate, @description, @cost)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@assetId", assetId);
                cmd.Parameters.AddWithValue("@maintenanceDate", maintenanceDate);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@cost", cost);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Reserves an asset for an employee with a reason and a return date
        public bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime returnDate, string reservationReason)
        {
            string query = "INSERT INTO Reservations (asset_id, employee_id, reservation_date, start_date, end_date, status) " +
                           "VALUES (@AssetId, @EmployeeId, @ReservationDate, @StartDate, @EndDate, @Status)";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssetId", assetId);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                command.Parameters.AddWithValue("@StartDate", reservationDate);  // Start date same as reservation date
                command.Parameters.AddWithValue("@EndDate", returnDate);         // End date is the return date
                command.Parameters.AddWithValue("@Status", reservationReason);   // Status could be reason or approval

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cancels a reservation by updating the status to "cancelled"
        public bool WithdrawReservation(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Reservations SET status='cancelled' WHERE reservation_id=@reservationId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservationId", reservationId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

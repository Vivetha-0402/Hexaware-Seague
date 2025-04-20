using Asset_Management.Entities;

using System;

namespace dao
{
    // Interface defining asset management operations
    public interface AssetManagementService
    {
        // Adds a new asset to the system
        bool AddAsset(Asset asset);

        // Updates existing asset details
        bool UpdateAsset(Asset asset);

        // Deletes an asset by its unique asset ID
        bool DeleteAsset(int assetId);

        // Allocates an asset to an employee on a specific date
        bool AllocateAsset(int assetId, int employeeId, string allocationDate);

        // Deallocates an asset from an employee by providing a return date
        bool DeallocateAsset(int assetId, int employeeId, string returnDate);

        // Records a maintenance event for an asset with date, description, and cost
        bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost);

        // Reserves an asset for an employee within a date range and reason
        bool ReserveAsset(int assetId, int employeeId, DateTime reservationDate, DateTime returnDate, string reservationReason);

        // Withdraws a reservation based on reservation ID
        bool WithdrawReservation(int reservationId);
    }
}

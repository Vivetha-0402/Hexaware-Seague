using System;

namespace Asset_Management.Entities
{
    // Represents the allocation of an asset to an employee
    public class AssetAllocation
    {
        // Unique ID for this allocation record
        public int AllocationId { get; set; }

        // ID of the asset being allocated
        public int AssetId { get; set; }

        // ID of the employee to whom the asset is allocated
        public int EmployeeId { get; set; }

        // Date on which the asset was allocated
        public DateTime AllocationDate { get; set; }

        // Nullable return date if the asset has been returned (null if not yet returned)
        public DateTime? ReturnDate { get; set; }

        // Provides a formatted string representing the allocation
        public override string ToString()
        {
            return $"ID: {AllocationId}, Asset ID: {AssetId}, Employee ID: {EmployeeId}, Allocated On: {AllocationDate.ToShortDateString()}";
        }
    }
}

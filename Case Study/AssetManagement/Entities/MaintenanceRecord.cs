namespace Asset_Management.Entities
{
    // Represents a maintenance activity record for an asset
    public class MaintenanceRecord
    {
        // Unique identifier for the maintenance record
        public int RecordId { get; set; }

        // ID of the asset that was maintained
        public int AssetId { get; set; }

        // Description of the maintenance performed
        public string Description { get; set; }

        // Date on which the maintenance was performed
        public string MaintenanceDate { get; set; }

        // Cost incurred for the maintenance
        public double Cost { get; set; }

        // Constructor to initialize all fields of the maintenance record
        public MaintenanceRecord(int recordId, int assetId, string description, string maintenanceDate, double cost)
        {
            RecordId = recordId;
            AssetId = assetId;
            Description = description;
            MaintenanceDate = maintenanceDate;
            Cost = cost;
        }
    }
}

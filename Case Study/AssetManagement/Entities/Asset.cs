namespace Asset_Management.Entities
{
    // Represents an asset in the asset management system
    public class Asset
    {
        // Parameterless constructor for object initializer support
        public Asset() { }

        // Constructor to initialize asset with all necessary details (except AssetId)
        public Asset(string name, string type, string serialNumber, string purchaseDate, string location, string status, int ownerId)
        {
            Name = name;
            Type = type;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Location = location;
            Status = status;
            OwnerId = ownerId;
        }

        // Unique identifier for the asset (used in update/delete operations)
        public int AssetId { get; set; }

        // Name or title of the asset
        public string Name { get; set; } = string.Empty;

        // Type or category of the asset (e.g., Laptop, Printer)
        public string Type { get; set; } = string.Empty;

        // Unique serial number for the asset
        public string SerialNumber { get; set; } = string.Empty;

        // Date when the asset was purchased (stored as string)
        public string PurchaseDate { get; set; } = string.Empty;

        // Location where the asset is currently kept
        public string Location { get; set; } = string.Empty;

        // Status of the asset (e.g., Available, Allocated, Under Maintenance)
        public string Status { get; set; } = string.Empty;

        // Employee ID of the asset owner
        public int OwnerId { get; set; }
    }
}

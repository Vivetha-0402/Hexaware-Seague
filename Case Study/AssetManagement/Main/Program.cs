using System;
using Asset_Management.Entities;
using Exceptions;
using Microsoft.Extensions.Configuration;
using dao;

namespace Asset_Management
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Build the configuration to read appsettings.json
            // The IConfiguration object will help us access the connection string stored in appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path for configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Read the JSON file
                .Build();

            // Fetch the connection string from appsettings.json
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Check if the connection string is null and handle accordingly
            // Exit the program if no valid connection string is found
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: Connection string not found in the configuration.");
                return; // Exit the program or handle accordingly
            }

            // Initialize the service using the fetched connection string
            // The service will interact with the database for asset management operations
            AssetManagementService service = new AssetManagementServiceImpl(connectionString);

            while (true)
            {
                // Display menu options for the user to interact with
                Console.WriteLine("\n===== Digital Asset Management System =====");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("4. Allocate Asset");
                Console.WriteLine("5. Deallocate Asset");
                Console.WriteLine("6. Perform Maintenance");
                Console.WriteLine("7. Reserve Asset");
                Console.WriteLine("8. Withdraw Reservation");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                // Validate input for choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    continue; // Repeat the loop if invalid input is provided
                }

                try
                {
                    // Switch statement to handle the operation based on user's choice
                    switch (choice)
                    {
                        case 1: // Add Asset
                            Console.Write("Enter Asset Name: ");
                            string? name = Console.ReadLine();
                            Console.Write("Enter Asset Type: ");
                            string? type = Console.ReadLine();
                            Console.Write("Enter Asset Serial Number: ");
                            string? serialNumber = Console.ReadLine();
                            Console.Write("Enter Purchase Date (YYYY-MM-DD): ");
                            string? purchaseDate = Console.ReadLine();
                            Console.Write("Enter Asset Location: ");
                            string? location = Console.ReadLine();
                            Console.Write("Enter Asset Status: ");
                            string? status = Console.ReadLine();
                            Console.Write("Enter Owner ID: ");
                            string? ownerIdInput = Console.ReadLine();

                            // Validate fields to ensure none of the required fields are empty
                            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(serialNumber) ||
                                string.IsNullOrEmpty(purchaseDate) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(ownerIdInput))
                            {
                                Console.WriteLine("All fields must be filled out.");
                                break; // Exit the current case if validation fails
                            }

                            // Parse the ownerId with null check and validate it
                            if (!int.TryParse(ownerIdInput, out int ownerId))
                            {
                                Console.WriteLine("Invalid Owner ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Create an Asset object with the provided input values
                            Asset asset = new Asset
                            {
                                Name = name,
                                Type = type,
                                SerialNumber = serialNumber,
                                PurchaseDate = purchaseDate,
                                Location = location,
                                Status = status,
                                OwnerId = ownerId
                            };

                            // Call the service to add the asset to the system
                            if (service.AddAsset(asset))
                                Console.WriteLine("Asset added.");
                            else
                                Console.WriteLine("Failed to add asset.");
                            break;

                        case 2: // Update Asset
                            // Request Asset ID from the user to update an existing asset
                            Console.Write("Enter Asset ID to update: ");
                            string? updateAssetIdInput = Console.ReadLine();
                            if (!int.TryParse(updateAssetIdInput, out int updateAssetId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Request new details for the asset
                            Console.Write("Enter new Asset Name: ");
                            string? updatedName = Console.ReadLine();
                            Console.Write("Enter new Asset Type: ");
                            string? updatedType = Console.ReadLine();
                            Console.Write("Enter new Asset Serial Number: ");
                            string? updatedSerialNumber = Console.ReadLine();
                            Console.Write("Enter new Purchase Date (YYYY-MM-DD): ");
                            string? updatedPurchaseDate = Console.ReadLine();
                            Console.Write("Enter new Asset Location: ");
                            string? updatedLocation = Console.ReadLine();
                            Console.Write("Enter new Asset Status: ");
                            string? updatedStatus = Console.ReadLine();
                            Console.Write("Enter new Owner ID: ");
                            string? updatedOwnerIdInput = Console.ReadLine();

                            // Validate fields for the updated asset details
                            if (string.IsNullOrEmpty(updatedName) || string.IsNullOrEmpty(updatedType) || string.IsNullOrEmpty(updatedSerialNumber) ||
                                string.IsNullOrEmpty(updatedPurchaseDate) || string.IsNullOrEmpty(updatedLocation) || string.IsNullOrEmpty(updatedStatus) || string.IsNullOrEmpty(updatedOwnerIdInput))
                            {
                                Console.WriteLine("All fields must be filled out.");
                                break; // Exit the current case if validation fails
                            }

                            // Parse the updatedOwnerId with null check and validate it
                            if (!int.TryParse(updatedOwnerIdInput, out int updatedOwnerId))
                            {
                                Console.WriteLine("Invalid Owner ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Create an updated Asset object with new details
                            Asset updateAsset = new Asset
                            {
                                AssetId = updateAssetId,
                                Name = updatedName,
                                Type = updatedType,
                                SerialNumber = updatedSerialNumber,
                                PurchaseDate = updatedPurchaseDate,
                                Location = updatedLocation,
                                Status = updatedStatus,
                                OwnerId = updatedOwnerId
                            };

                            // Call the service to update the asset in the system
                            if (service.UpdateAsset(updateAsset))
                                Console.WriteLine("Asset updated.");
                            else
                                Console.WriteLine("Failed to update asset.");
                            break;

                        case 3: // Delete Asset
                            // Request Asset ID to delete
                            Console.Write("Enter Asset ID to delete: ");
                            string? assetIdToDeleteInput = Console.ReadLine();
                            if (!int.TryParse(assetIdToDeleteInput, out int assetIdToDelete))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Call the service to delete the asset from the system
                            if (service.DeleteAsset(assetIdToDelete))
                                Console.WriteLine("Asset deleted.");
                            else
                                Console.WriteLine("Failed to delete asset.");
                            break;

                        case 4: // Allocate Asset
                            // Request Asset ID to allocate
                            Console.Write("Enter Asset ID to allocate: ");
                            string? allocateAssetIdInput = Console.ReadLine();
                            if (!int.TryParse(allocateAssetIdInput, out int allocateAssetId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Request Employee ID for allocation
                            Console.Write("Enter Allocated Employee ID: ");
                            string? employeeIdInput = Console.ReadLine();
                            if (!int.TryParse(employeeIdInput, out int employeeId))
                            {
                                Console.WriteLine("Invalid Employee ID. Please enter a valid number.");
                                break; // Exit the current case if validation fails
                            }

                            // Request Allocation Date
                            Console.Write("Enter Allocation Date (YYYY-MM-DD): ");
                            string? allocationDate = Console.ReadLine();

                            // Validate the allocation date
                            if (string.IsNullOrEmpty(allocationDate))
                            {
                                Console.WriteLine("Allocation date cannot be empty.");
                                break; // Exit the current case if validation fails
                            }

                            // Call the service to allocate the asset to the employee
                            if (service.AllocateAsset(allocateAssetId, employeeId, allocationDate))
                                Console.WriteLine("Asset allocated.");
                            else
                                Console.WriteLine("Failed to allocate asset.");
                            break;

                        
                        case 5: // Deallocate Asset
                            Console.Write("Enter Asset ID to deallocate: ");
                            string? deallocateAssetIdInput = Console.ReadLine();
                            if (!int.TryParse(deallocateAssetIdInput, out int deallocateAssetId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break;
                            }

                            Console.Write("Enter Employee ID for deallocation: ");
                            string? deallocateEmployeeIdInput = Console.ReadLine();
                            if (!int.TryParse(deallocateEmployeeIdInput, out int deallocateEmployeeId))
                            {
                                Console.WriteLine("Invalid Employee ID. Please enter a valid number.");
                                break;
                            }

                            Console.Write("Enter Deallocation Date (YYYY-MM-DD): ");
                            string? deallocationDate = Console.ReadLine();

                            // Validate deallocationDate
                            if (string.IsNullOrEmpty(deallocationDate))
                            {
                                Console.WriteLine("Deallocation date cannot be empty.");
                                break;
                            }

                            if (service.DeallocateAsset(deallocateAssetId, deallocateEmployeeId, deallocationDate))
                                Console.WriteLine("Asset deallocated.");
                            else
                                Console.WriteLine("Failed to deallocate asset.");
                            break;

                        case 6: // Perform Maintenance
                            Console.Write("Enter Asset ID for maintenance: ");
                            string? maintenanceAssetIdInput = Console.ReadLine();
                            if (!int.TryParse(maintenanceAssetIdInput, out int maintenanceAssetId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break;
                            }

                            Console.Write("Enter Maintenance Date (YYYY-MM-DD): ");
                            string? maintenanceDate = Console.ReadLine();
                            if (string.IsNullOrEmpty(maintenanceDate))
                            {
                                Console.WriteLine("Maintenance date cannot be empty.");
                                break;
                            }

                            Console.Write("Enter Maintenance Description: ");
                            string? maintenanceDescription = Console.ReadLine();
                            if (string.IsNullOrEmpty(maintenanceDescription))
                            {
                                Console.WriteLine("Maintenance description cannot be empty.");
                                break;
                            }

                            Console.Write("Enter Maintenance Cost: ");
                            string? maintenanceCostInput = Console.ReadLine();
                            if (!double.TryParse(maintenanceCostInput, out double maintenanceCost))
                            {
                                Console.WriteLine("Invalid maintenance cost. Please enter a valid number.");
                                break;
                            }

                            if (service.PerformMaintenance(maintenanceAssetId, maintenanceDate, maintenanceDescription, maintenanceCost))
                                Console.WriteLine("Maintenance performed successfully.");
                            else
                                Console.WriteLine("Failed to perform maintenance.");
                            break;

                        case 7: // Reserve Asset
                            Console.Write("Enter Asset ID to reserve: ");
                            string? reserveAssetIdInput = Console.ReadLine();
                            if (!int.TryParse(reserveAssetIdInput, out int reserveAssetId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break;
                            }

                            Console.Write("Enter Employee ID: ");
                            string? reserveEmployeeIdInput = Console.ReadLine();
                            if (!int.TryParse(reserveEmployeeIdInput, out int reserveEmployeeId))
                            {
                                Console.WriteLine("Invalid Employee ID. Please enter a valid number.");
                                break;
                            }

                            // Convert reservation date to DateTime
                            Console.Write("Enter Reservation Date (YYYY-MM-DD): ");
                            string? reservationDateInput = Console.ReadLine();
                            if (!DateTime.TryParse(reservationDateInput, out DateTime reservationDate))
                            {
                                Console.WriteLine("Invalid reservation date format. Please enter the date in YYYY-MM-DD format.");
                                break;
                            }

                            // Convert return date to DateTime
                            Console.Write("Enter Expected Return Date (YYYY-MM-DD): ");
                            string? returnDateInput = Console.ReadLine();
                            if (!DateTime.TryParse(returnDateInput, out DateTime returnDate))
                            {
                                Console.WriteLine("Invalid return date format. Please enter the date in YYYY-MM-DD format.");
                                break;
                            }

                            Console.Write("Enter Reservation Reason: ");
                            string? reservationReason = Console.ReadLine();
                            if (string.IsNullOrEmpty(reservationReason))
                            {
                                Console.WriteLine("Reservation reason cannot be empty.");
                                break;
                            }

                            // Assuming ReserveAsset method accepts DateTime objects
                            if (service.ReserveAsset(reserveAssetId, reserveEmployeeId, reservationDate, returnDate, reservationReason))
                                Console.WriteLine("Asset reserved successfully.");
                            else
                                Console.WriteLine("Failed to reserve asset.");
                            break;

                        case 8: // Withdraw Reservation
                            Console.Write("Enter Asset ID to withdraw reservation: ");
                            string? withdrawReservationIdInput = Console.ReadLine();
                            if (!int.TryParse(withdrawReservationIdInput, out int withdrawReservationId))
                            {
                                Console.WriteLine("Invalid Asset ID. Please enter a valid number.");
                                break;
                            }

                            if (service.WithdrawReservation(withdrawReservationId))
                                Console.WriteLine("Reservation withdrawn.");
                            else
                                Console.WriteLine("Failed to withdraw reservation.");
                            break;

                        case 9: // Exit
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (AssetNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (AssetNotMaintainException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }
}
                       
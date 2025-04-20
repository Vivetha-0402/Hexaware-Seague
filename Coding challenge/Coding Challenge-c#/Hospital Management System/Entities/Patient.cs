namespace HospitalManagementSystem.Entities
{
    // Represents a patient entity
    public class Patient
    {
        private int patientId;
        private string? firstName;
        private string? lastName;
        private DateTime dateOfBirth;
        private string? gender;
        private string? contactNumber;
        private string? address;

        // Default constructor
        public Patient() { }

        // Parameterized constructor
        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactNumber, string address)
        {
            this.patientId = patientId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        // Public properties
        public int PatientId { get => patientId; set => patientId = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string? Gender { get => gender; set => gender = value; }
        public string? ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string? Address { get => address; set => address = value; }

        public override string ToString()
        {
            return $"PatientId: {patientId}, Name: {firstName} {lastName}, DOB: {dateOfBirth.ToShortDateString()}, Gender: {gender}, Contact: {contactNumber}, Address: {address}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entity
{
    // Represents a payment made by a student
    public class Payment
    {
        // Unique ID for the payment
        public int PaymentID { get; set; }

        // The student who made the payment
        public Student Student { get; set; }

        // The amount paid
        public decimal Amount { get; set; }

        // The date when the payment was made
        public DateTime PaymentDate { get; set; }

        // Constructor to initialize a payment with details
        public Payment(int paymentID, Student student, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            Student = student;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        // Returns the student who made the payment
        public Student GetStudent() => Student;

        // Returns the amount of the payment
        public decimal GetPaymentAmount() => Amount;

        // Returns the date of the payment
        public DateTime GetPaymentDate() => PaymentDate;
    }
}

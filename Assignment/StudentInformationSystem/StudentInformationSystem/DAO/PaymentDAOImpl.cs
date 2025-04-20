using System;
using System.Collections.Generic;
using System.Linq;
using StudentInformationSystem.DAO;
using StudentInformationSystem.Entity;
using StudentInformationSystem.Exceptions;

namespace StudentInformationSystem.dao
{
    // Implementation of the IPaymentDAO interface
    public class PaymentDaoImpl : IPaymentDAO
    {
        private List<Payment> payments = new List<Payment>();

        // Add a new payment record
        public void AddPayment(Payment payment)
        {
            // Validate payment data before adding it to the list
            if (payment.Student == null || payment.Amount <= 0)
                throw new PaymentValidationException("Invalid payment data.");

            payments.Add(payment);  // Add the validated payment to the list
        }

        // Get a list of payments made by a specific student using the studentId
        public List<Payment> GetPaymentsByStudentId(int studentId)
        {
            // Filter the payments to only include those associated with the given studentId
            var results = payments.Where(p => p.Student.StudentId == studentId).ToList();

            // If no payments are found, throw an exception
            if (results.Count == 0)
                throw new PaymentValidationException("No payments found for this student.");

            return results;  // Return the list of payments for the student
        }
    }
}

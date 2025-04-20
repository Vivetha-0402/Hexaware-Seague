using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.DAO
{
    // Interface for managing payment-related data operations
    public interface IPaymentDAO
    {
        // Add a new payment record for a student
        void AddPayment(Payment payment);

        // Retrieve a list of payments made by a specific student using their StudentId
        List<Payment> GetPaymentsByStudentId(int studentId);
    }
}

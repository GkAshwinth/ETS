using System;
using System.Data;

namespace ETS
{
    public class AdminController
    {
        private readonly Database db;

        public AdminController()
        {
            db = new Database();
        }

        // 1. Get all events with creator name
        public DataTable GetAllEvents()
        {
            string query = @"
                SELECT 
                    E.eventId,
                    E.name AS eventName,
                    E.date,
                    E.location,
                    E.noOfTickets,
                    U.name AS createdBy
                FROM Event E
                JOIN Users U ON E.createdBy = U.id
                ORDER BY E.date DESC;
            ";
            return db.ExecuteQuery(query);
        }

        // 2. Get all payments with user name
        public DataTable GetAllPayments()
        {
            string query = @"
                SELECT 
                    P.paymentId,
                    U.name AS paidBy,
                    P.amount,
                    P.status,
                    P.type
                FROM Payment P
                JOIN Users U ON P.userId = U.id
                ORDER BY P.paymentId DESC;
            ";
            return db.ExecuteQuery(query);
        }

        // 3. Get total sales per event (joined via ticketId → eventId)
        public DataTable GetSalesReport()
        {
            string query = @"
                SELECT 
                    E.name AS eventName,
                    COUNT(AT.id) AS ticketsSold,
                    SUM(T.price) AS totalRevenue
                FROM AttendeeTickets AT
                JOIN Ticket T ON AT.ticketId = T.ticketId
                JOIN Event E ON T.eventId = E.eventId
                GROUP BY E.name
                ORDER BY totalRevenue DESC;
            ";
            return db.ExecuteQuery(query);
        }
    }
}

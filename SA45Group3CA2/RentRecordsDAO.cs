using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class RentRecordsDAO
    {
        SqlConnection cn;       // Declaring Connection object
        SqlCommand cmInsert;



        private static RentRecordsDAO dbInstance;

        private RentRecordsDAO()
        {
            string strCN = @"Data Source=(Localdb)\MSSQLLocalDB;" +
                           @"AttachDbFilename =|DataDirectory|SA45Team03ADLC3CA.mdf;" +
                           @"Integrated Security = true";

            cn = new SqlConnection(strCN);

            initializeSQLCmd();
        }

        private void initializeSQLCmd()
        {
            cmInsert = new SqlCommand();
            cmInsert.CommandText =
          "Insert into RentRecords (RecordsID, StaffID, CustomerID, RentalStartDate,RentalEndDate,ActualReturnDate,BookingDate,VehiclePlateNumber) " +
          " values (@RecordsID, @StaffID, @CustomerID, @RentalStartDate,@RentalEndDate,@ActualReturnDate,@BookingDate,@VehiclePlateNumber)";
            cmInsert.Connection = cn;
        }

        public static RentRecordsDAO getInstance()
        {

            if (dbInstance == null)
                dbInstance = new RentRecordsDAO();

            return dbInstance;
        }

        public void openConnection()
        {
            cn.Open();
        }
        public void CloseConnection()
        {
            if (cn != null)
                cn.Close();
        }
        public void InsertRentRecord(RentRecords r)
        {
            SqlParameter RecordsID =
                 new SqlParameter("@RecordsID", SqlDbType.NVarChar, 10);
            SqlParameter StaffID =
                new SqlParameter("@StaffID", SqlDbType.NVarChar, 10);
            SqlParameter CustomerID =
                new SqlParameter("@CustomerID", SqlDbType.NVarChar, 10);
            SqlParameter RentalStartDate =
                new SqlParameter("@RentalStartDate", SqlDbType.Date);
            SqlParameter RentalEndDate =
                new SqlParameter("@RentalEndDate", SqlDbType.Date);
            SqlParameter ActualReturnDate =
                new SqlParameter("@ActualReturnDate", SqlDbType.Date);
            SqlParameter BookingDate =
                new SqlParameter("@BookingDate", SqlDbType.Date);
            SqlParameter VehiclePlateNumber =
                new SqlParameter("@VehiclePlateNumber", SqlDbType.NVarChar, 10);

            // clear any previous parameters set before adding new parameters
            cmInsert.Parameters.Clear();
            cmInsert.Parameters.AddRange(new SqlParameter[]
                      { RecordsID, StaffID, CustomerID, RentalStartDate,RentalEndDate,ActualReturnDate,BookingDate,VehiclePlateNumber });

            RecordsID.Value = r.RecordsID;
            StaffID.Value = r.StaffID;
            CustomerID.Value = r.CustomerID;
            RentalStartDate.Value = r.RentalStartDate;
            RentalEndDate.Value = r.RentalEndDate;
            ActualReturnDate.Value = r.ActualReturnDate;
            BookingDate.Value = r.BookingDate;
            VehiclePlateNumber.Value = r.VehiclePlateNumber;

            cmInsert.ExecuteNonQuery();
        }
        public void ReturnCar(Vehicle v) { }


    }
}

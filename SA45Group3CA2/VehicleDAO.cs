using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA45Group3CA2
{
    class VehicleDAO
    {
        SqlConnection cn;       // Declaring Connection object
        SqlCommand cmSelbyPK;
        SqlCommand cmSelbyType;
        SqlCommand cmUpdateRentOutStatus;


        private static VehicleDAO dbInstance;

        private VehicleDAO()
        {
            string strCN = @"Data Source=(Localdb)\MSSQLLocalDB;" +
                           @"AttachDbFilename =|DataDirectory|SA45Team03ADLC3CA.mdf;" +
                           @"Integrated Security = true";

            cn = new SqlConnection(strCN);

            initializeSQLCmd();
        }

        private void initializeSQLCmd()
        {
            cmSelbyPK = new SqlCommand();
            cmSelbyType = new SqlCommand();
            cmUpdateRentOutStatus = new SqlCommand();
            cmSelbyPK.CommandText =
               "Select VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Car WHERE VehiclePlateNumber =@vehiclePlateNumber";
            cmSelbyPK.Connection = cn;

            cmSelbyType.CommandText =
            "Select VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Car WHERE RentalStatus = 'Not Active' ";
            cmSelbyType.Connection = cn;
            
            cmUpdateRentOutStatus.CommandText =
            "UPDATE Car SET RentalStatus='Active' WHERE VehiclePlateNumber =@vehiclePlateNumber ";
            cmUpdateRentOutStatus.Connection = cn;
          
        }

        public static VehicleDAO getInstance()
        {

            if (dbInstance == null)
                dbInstance = new VehicleDAO();

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


        public Vehicle RetrieveVehicle(String id)
        {
            SqlParameter pVehiclePlateNumber =
                 new SqlParameter("@VehiclePlateNumber", SqlDbType.NVarChar, 20);
            pVehiclePlateNumber.Value = id;

            // clear any previous parameters set before adding new parameters
            cmSelbyPK.Parameters.Clear();
            cmSelbyPK.Parameters.Add(pVehiclePlateNumber);


            Vehicle v = new Vehicle();

            // execute reader
            SqlDataReader rd = cmSelbyPK.ExecuteReader();
            if (rd.HasRows == false)
            {
                cmSelbyPK.CommandText =
             "Select  VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Bus WHERE vehiclePlateNumber =@vehiclePlateNumber";
                cmSelbyPK.Connection = cn;
                rd.Close();
                rd = cmSelbyPK.ExecuteReader();
                if (rd.HasRows==false)
                {
                    cmSelbyPK.CommandText =
                "Select  VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Truck WHERE vehiclePlateNumber =@vehiclePlateNumber";
                    cmSelbyPK.Connection = cn;
                    rd.Close();
                    rd = cmSelbyPK.ExecuteReader();
                }
            }
            if (rd.Read())
            {
                v.VehiclePlateNumber = rd["VehiclePlateNumber"].ToString();
                v.Model = rd["Model"].ToString();
                v.Colour = rd["Color"].ToString();
                v.EngineSeriaNo = rd["EngineSerialNo"].ToString();
                v.RetialStatus = rd["RentalStatus"].ToString();
            }
            else
            {
                throw new RVMException(RVMMessage.VehicleRecordNotFound);
            }
            // close reader
            rd.Close();
            return v;
        }

        public DataTable RetrieveCustomerList(string type)
        {
            switch (type)
            {
                case "Car":
                    cmSelbyType.CommandText =
                "Select VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Car WHERE RentalStatus = 'Not Active' ";
                    cmSelbyType.Connection = cn;
                    break;
                case "Bus":
                    cmSelbyType.CommandText =
                "Select VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Bus WHERE RentalStatus = 'Not Active' ";
                    cmSelbyType.Connection = cn;
                    break;
                case "Truck":
                    cmSelbyType.CommandText =
                "Select VehiclePlateNumber,Model, Color, EngineSerialNo,RentalStatus from Truck WHERE RentalStatus = 'Not Active' ";
                    cmSelbyType.Connection = cn;
                    break;
                default:
                    MessageBox.Show("Category unvaliabale!");
                    break;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmSelbyType);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vehicle");
            return ds.Tables["Vehicle"];

        }

        public void RentOut(string id)
        {
            SqlParameter pVehiclePlateNumber =
                 new SqlParameter("@VehiclePlateNumber", SqlDbType.NVarChar, 20);
            pVehiclePlateNumber.Value = id;

            // clear any previous parameters set before adding new parameters
            cmUpdateRentOutStatus.Parameters.Clear();
            cmUpdateRentOutStatus.Parameters.Add(pVehiclePlateNumber);
            // execute reader
           int result = cmUpdateRentOutStatus.ExecuteNonQuery();
            if (result<0)
            {
                cmUpdateRentOutStatus.CommandText =
                "UPDATE Bus SET RentalStatus='Active' WHERE VehiclePlateNumber =@vehiclePlateNumber ";
                cmUpdateRentOutStatus.Connection = cn;
                result = cmUpdateRentOutStatus.ExecuteNonQuery();
                if (result < 0)
                {
                    cmUpdateRentOutStatus.CommandText =
                    "UPDATE Truck SET RentalStatus='Active' WHERE VehiclePlateNumber =@vehiclePlateNumber ";
                    cmUpdateRentOutStatus.Connection = cn;
                    cmUpdateRentOutStatus.ExecuteNonQuery();
                }
            }
        }

        public void ReturnCar(Vehicle v) { }
      
    }
}

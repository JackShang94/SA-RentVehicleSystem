using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA45Group3CA2
{
    class VehicleRentalControl
    {
        public Vehicle RetrieveVehicle(String id)
        {

            VehicleDAO vehicleDAO = VehicleDAO.getInstance();
            try
            {
                vehicleDAO.openConnection();
                Vehicle v = vehicleDAO.RetrieveVehicle(id);
                return v;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;           // preserve stack trace     
            }
            finally
            {
                vehicleDAO.CloseConnection();
            }
        }
        public DataTable RetrieveVehicleList(string type)
        {

            VehicleDAO vehicleDAO = VehicleDAO.getInstance();

            try
            {
                vehicleDAO.openConnection();
                DataTable vehicleList = vehicleDAO.RetrieveCustomerList(type);
                return vehicleList;
            }
            catch (Exception)
            {
                throw;           // preserve stack trace     
            }
            finally
            {
                vehicleDAO.CloseConnection();
            }
        }
        public void CreateRentRecords(RentRecords r)
        {
            RentRecordsDAO rentRecordsDAO = RentRecordsDAO.getInstance();
            VehicleDAO vehicleDAO = VehicleDAO.getInstance();
            try
            {
                rentRecordsDAO.openConnection();
                rentRecordsDAO.InsertRentRecord(r);
                //vehicleDAO.RentOut(r.VehiclePlateNumber);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                rentRecordsDAO.CloseConnection();
            }
        }
        public void ReturnCar(Vehicle v)
        {
            RentRecordsDAO rentRecordsDAO = RentRecordsDAO.getInstance();
            VehicleDAO vehicleDAO = VehicleDAO.getInstance();
            try
            {
                rentRecordsDAO.ReturnCar(v);
                vehicleDAO.ReturnCar(v);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
            finally
            {
                rentRecordsDAO.CloseConnection();
            }
        }

    }
}

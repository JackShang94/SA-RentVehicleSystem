using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA45Group3CA2
{
    public partial class RentalUI : Form
    {
        public RentalUI()
        {
            InitializeComponent();
        }

        private void RentalUI_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (RVMUtil.isEmpty(CategoryTextBox.Text))
            {
                MessageBox.Show(RVMMessage.EmptyVehicleCategory);
                return;
            }
            try
            {
                string type = CategoryTextBox.Text;
                VehicleRentalControl mcControl = new VehicleRentalControl();
                DataTable vehicleList = mcControl.RetrieveVehicleList(type);
                dataGridView1.DataSource = vehicleList;

            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(excep.Message);
                Console.WriteLine(excep.StackTrace);
                MessageBox.Show(RVMMessage.GeneralErrorMsg);

                // cancel form load event and close the form
                this.BeginInvoke(new MethodInvoker(this.Close));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (RVMUtil.isEmpty(CustomerIDtextBox.Text))
                {
                    MessageBox.Show(RVMMessage.EmptyCustomerID);
                    return;
                }

                if (RVMUtil.isEmpty(OrderIDtextBox.Text))
                {
                    MessageBox.Show(RVMMessage.EmptyOrderID);
                    return;
                }
                VehicleRentalControl mcControl = new VehicleRentalControl();
                RentRecords r = new RentRecords();
                r.RecordsID = OrderIDtextBox.Text;
                r.StaffID = "S112233D";
                r.CustomerID = CustomerIDtextBox.Text;
                r.RentalStartDate = StartDate.Value;
                r.RentalEndDate = EndDate.Value;
                r.ActualReturnDate = StartDate.Value;
                r.BookingDate = StartDate.Value;
                r.VehiclePlateNumber = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                mcControl.CreateRentRecords(r);
                MessageBox.Show(RVMMessage.VehicleRecordSuccessful);

            }
            catch (RVMException dftExcep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(dftExcep.Message);
                Console.WriteLine(dftExcep.StackTrace);
                MessageBox.Show(dftExcep.Message);
            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception !!!");
                Console.WriteLine(excep.Message);
                Console.WriteLine(excep.StackTrace);
                MessageBox.Show(RVMMessage.GeneralErrorMsg);
            }
        }
    }
}

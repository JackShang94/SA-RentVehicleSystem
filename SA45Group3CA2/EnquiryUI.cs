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
    public partial class EnquiryUI : Form
    {
        public EnquiryUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (RVMUtil.isEmpty(PlateNumberTextBox.Text))
                {
                    MessageBox.Show(RVMMessage.EmptyVehiclePlateNumber);
                    return;
                }
                VehicleRentalControl mcControl = new VehicleRentalControl();
                Vehicle v = mcControl.RetrieveVehicle(PlateNumberTextBox.Text);
                ModelTextBox.Text = v.Model;
                ColorTextBox.Text = v.Colour;
                EngineSerialNoTextBox.Text = v.EngineSeriaNo;
                StatusTextBox.Text = v.RetialStatus;
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

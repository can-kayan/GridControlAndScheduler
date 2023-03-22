using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'weddingAppDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.weddingAppDataSet.Resources);
            // TODO: This line of code loads data into the 'weddingAppDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.weddingAppDataSet.Appointments);

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            schedulerControl1.SelectedAppointments.Clear();
            Appointment apt = null;
            string SelectingDate = string.Empty;
            if (gridView1.RowCount > 0)
                SelectingDate = gridView1.GetFocusedRowCellValue("Subject").ToString();
            int iD = -1;
            for (int i = 0; i < schedulerStorage1.Appointments.Count; i++)
            {
                if (schedulerStorage1.Appointments[i].Subject == SelectingDate)
                {
                    iD = i;
                }
            }
            if (iD != -1)
                apt = schedulerControl1.DataStorage.Appointments[iD];
            if (apt != null)
                schedulerControl1.SelectedAppointments.Add(apt);
            if (this.schedulerControl1.SelectedAppointments.Count > 0)
            {
                apt = this.schedulerControl1.SelectedAppointments[0];
            }
            else
            {
                apt = this.schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);
                apt.Start = this.schedulerControl1.SelectedInterval.Start;
                apt.End = this.schedulerControl1.SelectedInterval.End;
            }
            this.schedulerControl1.ShowEditAppointmentForm(apt);
        }
    }
}

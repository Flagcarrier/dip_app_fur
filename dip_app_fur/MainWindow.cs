using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;

namespace dip_app_fur
{
    
public partial class MainWindow : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainWindow()
        {
            InitializeComponent();

            orderDataGridView.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet1.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet1.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet1.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet1.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.bd_dip_furDataSet.clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.bd_dip_furDataSet.clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.bd_dip_furDataSet.order);

        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (orderDataGridView.Columns[e.ColumnIndex].Name)
            {
                case "dataGridViewTextBoxColumn5":
                    _Rectangle = orderDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;

                    break;
            }
        }

        private void dtp_TextChange (object sender, EventArgs e)
        {
            orderDataGridView.CurrentCell.Value = dtp.Text.ToString();
        }

        private void orderDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void orderDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
        }
    }
}

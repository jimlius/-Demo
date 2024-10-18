using HslCommunication.Secs.Types;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace 倍福读取Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>


    
    public partial class MainWindow : Window
    {
        public ObservableCollection<GridItem2> msg = new ObservableCollection<GridItem2>();

        ExcelHelper2 h2 = new ExcelHelper2();

        public MainWindow()
        {
            InitializeComponent();
            
            

            msg = new ObservableCollection<GridItem2>();

            msg.Add(new GridItem2() { Name="急停", Addr="db100.0", Type="int" });

            

         
            this.DataBeifu.ItemsSource = msg;

            

        }


        private void Connect_Click(object sender, RoutedEventArgs e)
        {

            msg.Add(new GridItem2() { Name = "急停2", Addr = "db110.0", Type = "int" });
          //  this.DataBeifu.SelectedItem = msg;
        }

        private void DisConnect_Click(object sender, RoutedEventArgs e)
        {

        }


      

        private void InportExcel_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                DataTable dt = h2.ReadExcelFile(filePath);



                msg.Clear();


                if (dt.Rows.Count > 0)
                {

                   

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        GridItem2 it = new GridItem2();
                        if (dt.Rows[i][0] == null || dt.Rows[i][1] == null || dt.Rows[i][2] == null)
                        {

                            continue;
                        }

                        it.Name = dt.Rows[i][0].ToString();
                        it.Addr = dt.Rows[i][1].ToString();
                        it.Type = dt.Rows[i][2].ToString();
                        it.Val = dt.Rows[i][3].ToString();



                        msg.Add(it);
                    }
                    this.DataBeifu.ItemsSource = msg;



                    //this.DataBeifu.ItemsSource = dt.DefaultView;

                    //Console.WriteLine("ok");

                    }
                }


            }

        private void ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    DataTable dt = DataGridToTable(this.DataBeifu);


                    h2.WriteExcelFile(filePath, dt);
                    MessageBox.Show("保存成功!");
                }

            }
            catch (Exception e1)
            {

                MessageBox.Show("保存失败\n"+e1.Message.ToString());
            }
            



        }


        public  DataTable DataGridToTable(DataGrid dg)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                dt.Columns.Add(dg.Columns[i].Header.ToString());
            }
            for (int i = 0; i < dg.Items.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dg.Columns.Count; j++)
                {
                    dr[dg.Columns[j].Header.ToString()] = (dg.Columns[j].GetCellContent(dg.Items[i]) as TextBlock).Text.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

       
    }

}

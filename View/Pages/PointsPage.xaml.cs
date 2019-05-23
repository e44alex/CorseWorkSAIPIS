using System;
using System.Collections;
using System.Collections.Generic;
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

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для PointsPage.xaml
    /// </summary>
    public partial class PointsPage : Page
    {
        ArrayList array = new ArrayList();
        public PointsPage()
        {
            InitializeComponent();

            array = ClientServerController.currnetPoints();
            MessageBox.Show(array[0] + "\n" + array[1] + "\n" + array[2]);
            //TimeBlock.Text = array[0].ToString();
            //WeightBlock.Text = array[1].ToString();
            //TwBlock.Text = array[2].ToString();
        }
    }
}

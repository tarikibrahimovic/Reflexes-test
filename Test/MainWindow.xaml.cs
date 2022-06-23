using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Start { get; set; }
        DispatcherTimer timer;
        List<string> Nazivi = new List<string>();
        Random random = new Random();
        Stopwatch stopWatch;

        public int Vrednost { get; set; }
        public int Increment { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Nazivi.Add("tb1");
            Nazivi.Add("tb2");
            Nazivi.Add("tb3");
            Nazivi.Add("tb4");
            glavni.IsEnabled = false;
        }

        private void pokreniIgru_Click(object sender, RoutedEventArgs e)
        {
            Vrednost = random.Next(4, 10);
            Start = 1;
            timer = new DispatcherTimer();
            Increment = 0;
            timer.Start();
            Button btn = sender as Button;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Increment++;
            if (Increment == 1)
            {
                TextBlock tb = (TextBlock)FindName(Nazivi[0]);
                tb.Background = Brushes.Red;
            }
            else if (Increment == 2)
            {
                TextBlock tb = (TextBlock)FindName(Nazivi[1]);
                tb.Background = Brushes.Red;
            }
            else if (Increment == 3)
            {
                TextBlock tb = (TextBlock)FindName(Nazivi[2]);
                tb.Background = Brushes.Red;
            }
            else if (Increment == 4)
            {
                TextBlock tb = (TextBlock)FindName(Nazivi[3]);
                tb.Background = Brushes.Red;
            }
            if (Increment == Vrednost)
            {
                for (int i = 0; i < Nazivi.Count; i++)
                {
                    TextBlock tb = (TextBlock)FindName(Nazivi[i]);
                    tb.Background = Brushes.Green;
                }
                timer.Stop();
                glavni.IsEnabled = true;
                ActivateWatch();
            }
        }

        public void ActivateWatch()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public string GetElapsed()
        {
            stopWatch.Stop();
            double ts = stopWatch.Elapsed.TotalSeconds;
            return ts.ToString();
        }
        private void glavni_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Start = 0;
            string pom = GetElapsed();
            vreme.Content = pom;
            for (int i = 0; i < Nazivi.Count; i++)
            {
                TextBlock tb = (TextBlock)FindName(Nazivi[i]);
                tb.Background = Brushes.White;
            }
        }
    }
}

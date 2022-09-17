using System;
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

namespace Avtoauto.Pages
{
    /// <summary>
    /// Логика взаимодействия для Tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        public Tickets()
        {
            InitializeComponent();
            GenerateTicketButtons();
        }
        public void Close_Button(object sender,RoutedEventArgs e)
        {
            MainWindow.Instance.MenuFrame.Navigate(new MainMenu());
        }
        public void GenerateTicketButtons()
        {
            var buttoncount = 70;
            for (int i = 1; i <= buttoncount; i++)
            {
                var button = new Button();
                button.Width = 300;
                button.Height = 50;
                button.FontSize = 14;
                button.Content = i + "Ticket";
                button.Tag = i;
                button.Margin = new Thickness(10);
                button.Click += TicketButtonClick;
                TicketButtonPanel.Children.Add(button);
            }
        }
        private void TicketButtonClick(object sender,RoutedEventArgs e)
        {
            var button = sender as Button;
            var ticketIndex = (int)button.Tag;

            var Exam = new Examination(ticketIndex);
            MainWindow.Instance.MenuFrame.Navigate(Exam);
        }
    }
}

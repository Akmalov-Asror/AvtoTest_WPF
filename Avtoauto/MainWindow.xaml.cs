
using Avtoauto.Pages;
using System.Windows;

namespace Avtoauto;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public MainWindow()
    {
        InitializeComponent();
        Instance = this;

        var mainmenu = new MainMenu();
        MenuFrame.Navigate(mainmenu);
    }


}

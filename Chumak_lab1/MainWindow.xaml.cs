//Created by Vitaliy Chumak, on 22.02.19
using System.Windows;

namespace Chumak_lab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel();
        }
    }
}

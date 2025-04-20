using System.Windows;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession GameSession;

        public MainWindow()
        {
            InitializeComponent();

            GameSession = new GameSession();

            DataContext = GameSession;
        }
    }
}
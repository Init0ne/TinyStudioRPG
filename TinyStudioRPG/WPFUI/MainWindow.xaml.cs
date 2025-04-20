using System.Windows;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession GameSession;

        public MainWindow()
        {
            InitializeComponent();

            GameSession = new GameSession();

            DataContext = GameSession;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            GameSession.CurrentPlayer.ExperiencePoints += 10;
        }
    }
}
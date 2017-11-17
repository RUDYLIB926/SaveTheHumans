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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaveTheHumans
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            AddEnemy();
        }

        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, Canvas.LeftProperty);
            AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
                random.Next((int)playArea.ActualHeight - 100), Canvas.TopProperty);
            playArea.Children.Add(enemy);
        }

        private void AnimateEnemy(ContentControl enemy, double from, double to, DependencyProperty propertyToAnimate)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
            };
            PropertyPath propertyPath = new PropertyPath(propertyToAnimate);
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, propertyPath);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}

using System;
using System.Windows;

namespace WPFSharedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResourceDictionary res1;
        private ResourceDictionary res2;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                res1 = new ResourceDictionary() { Source = new Uri("pack://application:,,,/WPFSharedTest;component/Resources/ResDictBrush_1.xaml") };
                res2 = new ResourceDictionary() { Source = new Uri("pack://application:,,,/WPFSharedTest;component/Resources/ResDictBrush_2.xaml") };
            };
        }

        private void SetResDict1OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Remove(res1);
            Application.Current.Resources.MergedDictionaries.Remove(res2);
            Application.Current.Resources.MergedDictionaries.Add(res1);
        }

        private void SetResDict2OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Remove(res1);
            Application.Current.Resources.MergedDictionaries.Remove(res2);
            Application.Current.Resources.MergedDictionaries.Add(res2);
        }
    }
}
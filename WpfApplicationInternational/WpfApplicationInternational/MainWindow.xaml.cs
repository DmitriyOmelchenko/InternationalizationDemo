using System;
using System.Collections.Generic;
using System.Globalization;
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
using WPFLocalizeExtension.Engine;

namespace WpfApplicationInternational
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly CultureInfo EnglandCultureInfo =
            CultureInfo.GetCultureInfo("en-GB");
        private static readonly CultureInfo GermanyCultureInfo =
            CultureInfo.GetCultureInfo("de-DE");
        public MainWindow()
        {
            InitializeComponent();
            LocalizeDictionary.Instance.Culture = EnglandCultureInfo;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LocalizeDictionary.Instance.Culture= LocalizeDictionary.Instance.Culture.Equals(EnglandCultureInfo) 
                ? GermanyCultureInfo
                : EnglandCultureInfo;
            var messageText =GetLocalizedObject<string>("Message",LocalizeDictionary.CurrentCulture);
            MessageBox.Show(messageText);
        }

        private static T GetLocalizedObject<T>(string key, CultureInfo culture, string assembly= "WpfApplicationInternational",string resources= "Resources")
        {
            return (T)LocalizeDictionary.Instance.GetLocalizedObject(assembly, resources, key, culture);
        }


    }
}

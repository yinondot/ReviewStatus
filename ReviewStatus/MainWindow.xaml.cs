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
using ReviewStatus.ViewModels;

namespace ReviewStatus
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      MainViewModel vm;
      public MainWindow()
      {
         vm = new MainViewModel();
         this.DataContext = vm;
         InitializeComponent();
         vm.activateWindow += delegate (object sender, EventArgs e)
           {
              this.Activate();
           };
         
      }

    

      private void TbLengthCommentField_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (cbAddCommentField.IsChecked==true)
         {
            var tb = sender as TextBox;
            int result;
            int.TryParse(tb.Text, out result);
            if (result != 0)
            {
               vm.IsFieldLengthValid = true;

            }
            else
            {
               vm.IsFieldLengthValid = false;
            }
         }
       
        
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         this.Activate();
      }

      private void BtnCancel_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }
   }
}

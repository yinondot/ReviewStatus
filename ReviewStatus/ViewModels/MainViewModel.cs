using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ReviewStatus.CommonValues;

namespace ReviewStatus.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      private ReadOnlyCollection<int> numberOfFields;

      public ReadOnlyCollection<int> NumberOfFields
      {
         get { return numberOfFields; }
         set {
            if (numberOfFields != value)
            {
               numberOfFields = value;
               OnPropertyChanged();
            }  
         }
      }

     
      public  MainViewModel()
      {
         try
         {
          //  InitializeAsync();
           Task.Factory.StartNew(() => InitializeAsync()) ;
            Initialize();
         }
         catch (Exception ex)
         {

            System.Windows.MessageBox.Show(ex.Message + " On Initialize");
         }

      }

      private void Initialize()
      {
         
      }

      private async Task InitializeAsync()
      {
        
         NumberOfFields = new ReadOnlyCollection<int>(Values.NumOfFields);
        
      }

     

      private string chosenFile="INITIALIZED.COM";

      public string ChosenFile
      {
         get { return chosenFile; }
         set {
            if (chosenFile != value)
            {
               chosenFile = value;
               OnPropertyChanged();
            }
            
         }
      }


      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged([CallerMemberName] string propName = "")
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
      }

   }
}

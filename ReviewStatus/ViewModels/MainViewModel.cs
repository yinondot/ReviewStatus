using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using ReviewStatus.Commands;
using ReviewStatus.CommonValues;
using Services;

namespace ReviewStatus.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
   {
      ideaServices ideaServices;
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

      #region Commands   
      public RunCommand RunCommand { get; set; }  
      public ChooseFileCommand ChooseFileCommand { get; set; }
      #endregion

      #region command methods
      internal void ChooseFileMethod()
      {
         ChosenFile = ideaServices.ChoosePrimaryFile();
      }
      #endregion
      public MainViewModel()
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
         RunCommand = new RunCommand(this);
         ChooseFileCommand = new ChooseFileCommand(this);
         ideaServices = new ideaServices();
      }

      private async Task InitializeAsync()
      {
        
         NumberOfFields = new ReadOnlyCollection<int>(Values.NumOfFields);
        
      }

     

      private string chosenFile="";
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

      private int commentFieldLength;

      public int CommentFieldLength
      {
         get { return commentFieldLength; }
         set {
            if (commentFieldLength != value)
            {
               commentFieldLength = value;
               OnPropertyChanged();
            }
          

         }
      }

     
  


      private bool isValid;

      public bool IsValid
      {
         get { return isValid; }
         set {
            if (IsValid != value)
            {
               isValid = value;
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ReviewStatus.Commands;
using ReviewStatus.CommonValues;
using Services;

namespace ReviewStatus.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged, IDataErrorInfo
   {
      public event EventHandler activateWindow;
      ideaServices ideaServices;
     
      public ReadOnlyCollection<int> NumberOfFields { get; set; }
    


      public MainViewModel()
      {
         try
         {
            //  InitializeAsync();
            Task.Factory.StartNew(() => InitializeAsync());
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
         chosenFile = ideaServices.GetOpenDataBase();
      }

    

      private async Task InitializeAsync()
      {

         NumberOfFields = new ReadOnlyCollection<int>(Values.NumOfFields);

      }


      #region Commands   
      public RunCommand RunCommand { get; set; }
      public ChooseFileCommand ChooseFileCommand { get; set; }
      #endregion
      #region command methods
      internal void ChooseFileMethod()
      {
         ChosenFile = ideaServices.ChoosePrimaryFile();
         activateWindow(this, new EventArgs());
      }

     public async Task  RunMethod()
      {
         try
         {
            ideaServices.ShowWindow();
            if (isChecked)
            {
               ideaServices.Run(chosenFile, Convert.ToInt32(selectedNumberOfFieldsToAdd), DefaultStatusName, DefaultCommentName, int.Parse(CommentFieldLength));
            }
            else
            {
               ideaServices.Run(chosenFile, Convert.ToInt32(selectedNumberOfFieldsToAdd), DefaultStatusName);
            }
            activateWindow(this,new EventArgs());
            MessageBox.Show("הסתיים בהצלחה");
         }
         catch (Exception ex)
         {

            MessageBox.Show(ex.Message + "On Run method");
         }
 
         
      }
      #endregion


      #region bound properties

      private string defaultCommentName = "COMMENT";
      public string DefaultCommentName
      {
         get { return defaultCommentName; }
         set
         {
            if (defaultCommentName != value)
            {
               defaultCommentName = value;
               OnPropertyChanged();
            }

         }
      }

      private string defaultStatusName = "STATUS";
      public string DefaultStatusName
      {
         get { return defaultStatusName; }
         set
         {
            if (defaultStatusName != value)
            {
               defaultStatusName = value;
               OnPropertyChanged();
            }

         }
      }

      private bool isChecked = true;
      public bool IsChecked
      {
         get { return isChecked; }
         set {
            if (isChecked != value)
            {
               isChecked = value;
               OnPropertyChanged();
            }         
         }
      }

      private object selectedNumberOfFieldsToAdd = 3;
      public object SelectedNumberOfFieldsToAdd
      {
         get { return selectedNumberOfFieldsToAdd; }
         set {
            //if (value==null)
            //{
            //   selectedNumberOfFieldsToAdd = 0;
            //}
            if (selectedNumberOfFieldsToAdd != value)
            {
               selectedNumberOfFieldsToAdd = value;
               OnPropertyChanged();
            }
            
         }
      }

      private string chosenFile = "";
      public string ChosenFile
      {
         get { return chosenFile; }
         set
         {
            if (chosenFile != value)
            {
               chosenFile = value;
               OnPropertyChanged();
            }

         }
      }

      private string commentFieldLength="50";
      public string CommentFieldLength
      {
         get { return commentFieldLength; }
         set
         {
            if (commentFieldLength != value)
            {
               commentFieldLength = value;

               OnPropertyChanged();
            }
         }
      }

      private bool isFieldLengthValid;
      public bool IsFieldLengthValid
      {
         get { return isFieldLengthValid; }
         set
         {
            if (IsFieldLengthValid != value)
            {
               isFieldLengthValid = value;
               OnPropertyChanged();
            }

         }
      }
      #endregion

      public string Error => throw new NotImplementedException();

      public string this[string columnName]
      {
         get
         {
            string result = string.Empty;
            switch (columnName)
            {

               case "CommentFieldLength":
                  {
                     if (CommentFieldLength == "" || CommentFieldLength == null)
                     {
                        IsFieldLengthValid = false;
                        return result;
                     }
                     int value;
                     int.TryParse(CommentFieldLength, out value);
                     if (value == 0)
                     {
                        IsFieldLengthValid = false;
                        result = "The input must be an integer";
                     }
                     else
                     {
                        IsFieldLengthValid = true;
                     }
                     return result;

                  }
               default:
                  return result;

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

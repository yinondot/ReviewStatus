﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
      private ReadOnlyCollection<int> numberOfFields;
      public ReadOnlyCollection<int> NumberOfFields
      {
         get { return numberOfFields; }
         set
         {
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
         activateWindow(this, new EventArgs());
      }
      #endregion

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
      }

      private async Task InitializeAsync()
      {

         NumberOfFields = new ReadOnlyCollection<int>(Values.NumOfFields);

      }

      #region bound properties
      private string chosenFile = "kjghk";
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


      private string commentFieldLength;
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
                     if (CommentFieldLength==""|| CommentFieldLength == null)
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

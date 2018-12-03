using ReviewStatus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReviewStatus.Commands
{
   public class RunCommand : ICommand
   {
      public MainViewModel Vm { get; set; }
      public RunCommand(MainViewModel vm)
      {
         this.Vm = vm;
      }
      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }

      }
      public bool CanExecute(object parameter)
      {
         if (Vm.ChosenFile == "") 
         {
            return false;
         }
         if (Vm.SelectedNumberOfFieldsToAdd==null)
         {
            return false;
         }
         if (!Vm.IsChecked)
         {
            return Vm.DefaultStatusName != ""; 
         }
         else
         {
            return (Vm.DefaultStatusName != "")&& (Vm.DefaultCommentName != "")&& Vm.IsFieldLengthValid;
         }
   
        
       
      
      }
   
      public void Execute(object parameter)
      {
         Vm.RunMethod();
      

      }
   }
}

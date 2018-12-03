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

         return Vm.IsFieldLengthValid;
        
       
      
      }
   
      public void Execute(object parameter)
      {
         //Task task=new Task(()=> Vm.RunMethod());
         // task.Start();
      

      }
   }
}

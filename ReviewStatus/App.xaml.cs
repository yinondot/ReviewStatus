using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Services;

namespace ReviewStatus
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      public App()
      {
         try
         {
            //Task.Factory.StartNew(()=> UtilityCasewareIdea.ShowWindow());
        //    ideaServices.ShowWindow();
         }
         catch (Exception ex)
         {

            MessageBox.Show(ex.Message + "App Start");
         }

      }

   }
}


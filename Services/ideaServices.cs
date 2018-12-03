using Interop.IdeaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtiltyCasewareIdea;

namespace Services
{
    public class ideaServices
    {
      public static string ChoosePrimaryFile()
      {
         IdeaClient client = null;
         CommonDialogs commonDialogs = null;
         try
         {
            client = new IdeaClient();
            UtilityCasewareIdea.ShowWindow();
            commonDialogs = client.CommonDialogs();
            return commonDialogs.FileExplorer();

         }
         catch (Exception)
         {
            return "";
         }
         finally
         {

            UtilityCasewareIdea.DisposeCom(client);
            UtilityCasewareIdea.DisposeCom(commonDialogs);
         }
      }
      public static void ShowWindow()
      {
         UtilityCasewareIdea.ShowWindow();
      }
   }
}

﻿using Interop.IdeaLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UtiltyCasewareIdea;
using COMMONIDEACONTROLSLib;
using COMDBLib;

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

      public void Run(string chosenDB, int numberOfFieldsToAdd, string defaultStatusFieldName, string defaultCommentFieldName = null, int lengthOfCommentField = 0)
      {
         IdeaClient client = null;
         IdeaDatabase db = null;
         TableDef table = null;
         Field field = null;
         dynamic task = null;
         string eqn = "-1";
         try
         {
            client = new IdeaClient();
            db = client.OpenDatabase(chosenDB);
            task = db.TableManagement();
            table = db.TableDef();
            for (int i = 1; i <= numberOfFieldsToAdd; i++)
            {
               field = table.NewField();
               field.name = defaultStatusFieldName+i;
               field.description = "";
               field.type = COMDBLib.VBFieldType.WI_MULTISTATE;
               field.Equation = eqn;
               field.Decimals = 0;
               task.AppendField(field);
               if (defaultCommentFieldName != null)
               {
                  field = table.NewField();
                  eqn = "'a'";

                  field.name = defaultCommentFieldName + i;
                  field.description = "";
                  field.type = COMDBLib.VBFieldType.WI_CHAR_FIELD;
                  field.Equation = eqn;
                  field.Length = lengthOfCommentField;
                  task.AppendField(field);
               }
            }
            task.PerformTask();
         }
         catch (Exception ex)
         {

            throw ex;
         }
         finally
         {
            UtilityCasewareIdea.DisposeCom(client);
            UtilityCasewareIdea.DisposeCom(db);
            UtilityCasewareIdea.DisposeCom(table);
            UtilityCasewareIdea.DisposeCom(field);
            UtilityCasewareIdea.DisposeCom(task);
         }
      }
   }
}

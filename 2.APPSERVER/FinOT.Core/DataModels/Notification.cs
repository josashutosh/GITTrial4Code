﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Core.DataModels
{
   public class EmailM
    {
       public EmailM()
       {
           RecipientAddress = new List<string>();
           CC = new List<string>();           
       }
      private List<DocumentM> _attachments = new List<DocumentM>();
      public int NotificationID { get; set; }
      public List<string> RecipientAddress { get; set; }
      public string Subject { get; set; }
      public string MessageBody { get; set; }
      public List<string> CC { get; set; }
      public string BCC { get; set; }
      public List<DocumentM> Attachments
      {
          get
          {
              return _attachments;
          }
          set
          {
              _attachments = value;
          }
      }
    }

   public class MailM
   {
       public MailM()
       {
           Recipient = new List<string>();           
       }
       private List<DocumentM> _attachments = new List<DocumentM>();
       public int NotificationID { get; set; }
       public string Activity { get; set; }
       public int ActivityID { get; set; }
       public List<string> Recipient { get; set; }
       public string Notes { get; set; }
       public int CityUserID { get; set; }
       public string SentBy { get; set; }
       public int C_ID { get; set; }
       public DateTime? MailingDate { get; set; }
       public List<DocumentM> Attachments
       {
           get
           {
               return _attachments;
           }
           set
           {
               _attachments = value;
           }
       }
   }
}

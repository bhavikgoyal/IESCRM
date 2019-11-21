using System;
using System.Collections.Generic;
using System.Text;

namespace IESCRM_Mobiles.Models
{
 public class getWorkorderDetails
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
      
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string IsTestUnit { get; set; }
        public string CustomerPO { get; set; }
        public string CustomerReference { get; set; }
        public string MexicoJobNumber { get; set; }
        public string SyncToMexico { get; set; }
        public string SalesRepName { get; set; }
        public string REPCODE { get; set; }
        public string JobType { get; set; }
        public string JobStatus { get; set; }
        public string JobOrderDate { get; set; }
        public string QouteDate { get; set; }
        public string ConsignmentInvoice { get; set; }
        public string ApprovedDate { get; set; }
        public string ConsignmentDate { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string DateShipped { get; set; }
        public string CustomerInstructions { get; set; }
        public string View90DayNotes { get; set; }
    }
}

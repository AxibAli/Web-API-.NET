//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages_Details
    {
        public long Message_ID { get; set; }
        public long Product_ID { get; set; }
        public string User_Messages { get; set; }
        public System.DateTime Message_Date { get; set; }
        public long Sent_By { get; set; }
    
        public virtual Product Product { get; set; }
    }
}

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
    
    public partial class Found_Product
    {
        public long Found_Product_ID { get; set; }
        public Nullable<long> Product_ID { get; set; }
        public string Found_Product_Status { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstuctionManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_expensemaster
    {
        public int e_id { get; set; }
        public string e_name { get; set; }
        public Nullable<System.DateTime> e_date { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> project_id { get; set; }
    
        public virtual tbl_project tbl_project { get; set; }
    }
}

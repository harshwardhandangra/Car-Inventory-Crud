//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarInventory.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars_Users_Mapping
    {
        public int Id { get; set; }
        public Nullable<int> CarsId { get; set; }
        public Nullable<int> UsersId { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
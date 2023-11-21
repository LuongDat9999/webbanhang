﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demoapp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderDetail
    {
        public int ID { get; set; }
        public Nullable<int> IDProduct { get; set; }
        public Nullable<int> IDOrder { get; set; }

        [DisplayName("số lượng")]
        public Nullable<int> Quantity { get; set; }

        [DisplayName("đơn giá")]
        public Nullable<double> UnitPrice { get; set; }
    
        public virtual OrderPro OrderPro { get; set; }
        public virtual Product Product { get; set; }
    }
}
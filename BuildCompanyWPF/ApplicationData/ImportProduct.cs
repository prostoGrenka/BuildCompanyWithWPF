//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuildCompanyWPF.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImportProduct
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public Nullable<int> Id_Unit { get; set; }
        public string Price { get; set; }
        public Nullable<int> MaxSizeDiscount { get; set; }
        public Nullable<int> Id_Manufacture { get; set; }
        public Nullable<int> Id_Supplier { get; set; }
        public Nullable<int> Id_ProductCategory { get; set; }
        public Nullable<int> CurrentDiscount { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Description { get; set; }
        public string ImageAddress { get; set; }
    
        public virtual CategoryProduct CategoryProduct { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual UnitTable UnitTable { get; set; }
    }
}

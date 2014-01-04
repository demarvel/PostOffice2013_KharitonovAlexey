//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PostOffice2013_KharitonovAlexey.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class PostOffice
    {
        public PostOffice()
        {
            this.Pensioner = new HashSet<Pensioner>();
            this.Worker = new HashSet<Worker>();
        }
        [Display(Name = "Индекс")]
        public int PostIndex { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string ContactPhone { get; set; }
        [Display(Name = "Время работы")]
        public string OpeningHours { get; set; }
    
        public virtual ICollection<Pensioner> Pensioner { get; set; }
        public virtual ICollection<Worker> Worker { get; set; }
    }
}

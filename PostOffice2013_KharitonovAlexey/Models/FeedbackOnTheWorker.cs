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
    
    public partial class FeedbackOnTheWorker
    {
        [Display(Name = "ИД")]
        public int ID { get; set; }
        [Display(Name = "Вид отзыва")]
        public bool ViewReviews { get; set; }
        [Display(Name = "Текст отзыва")]
        public string TextReview { get; set; }
        [Display(Name = "Ответ администрации")]
        public string AdmResponse { get; set; }
        [Display(Name = "ИД Работника")]
        public int IDWorker { get; set; }
    
        public virtual Worker Worker { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PostOffice2013DBEntities1 : DbContext
    {
        public PostOffice2013DBEntities1()
            : base("name=PostOffice2013DBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BagM> BagM { get; set; }
        public DbSet<Banderoll> Banderoll { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<FeedbackOnTheWorker> FeedbackOnTheWorker { get; set; }
        public DbSet<Letter> Letter { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Packing> Packing { get; set; }
        public DbSet<Pensioner> Pensioner { get; set; }
        public DbSet<PensionPayment> PensionPayment { get; set; }
        public DbSet<Posilka> Posilka { get; set; }
        public DbSet<PostalContainer> PostalContainer { get; set; }
        public DbSet<PostCard> PostCard { get; set; }
        public DbSet<PostItem> PostItem { get; set; }
        public DbSet<PostOffice> PostOffice { get; set; }
        public DbSet<SaleOfGoods> SaleOfGoods { get; set; }
        public DbSet<Secogramma> Secogramma { get; set; }
        public DbSet<SmallPacket> SmallPacket { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBanakMVC2.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BloodBankEntities : DbContext
    {
        public BloodBankEntities()
            : base("name=BloodBankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<userRegistration> userRegistrations { get; set; }
        public virtual DbSet<tbl_userPost> tbl_userPost { get; set; }
        public virtual DbSet<userPost> userPosts { get; set; }
        public virtual DbSet<tbl_UserPosts> tbl_UserPosts { get; set; }
        public virtual DbSet<tbl_DonationRecords> tbl_DonationRecords { get; set; }
    }
}

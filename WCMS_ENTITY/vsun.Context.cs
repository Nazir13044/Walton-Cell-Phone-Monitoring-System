﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCMS_ENTITY
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VsunDBEntities : DbContext
    {
        public VsunDBEntities()
            : base("name=VsunDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<F_CheckItems_Battery> F_CheckItems_Battery { get; set; }
        public virtual DbSet<F_CheckItems_CB> F_CheckItems_CB { get; set; }
        public virtual DbSet<F_CheckItems_Charger> F_CheckItems_Charger { get; set; }
        public virtual DbSet<F_CheckItems_GB> F_CheckItems_GB { get; set; }
        public virtual DbSet<F_CheckItems_GBW> F_CheckItems_GBW { get; set; }
        public virtual DbSet<F_CheckItems_IMEIC> F_CheckItems_IMEIC { get; set; }
        public virtual DbSet<F_CheckItems_IMEIC2> F_CheckItems_IMEIC2 { get; set; }
        public virtual DbSet<F_CheckItems_IMEIP> F_CheckItems_IMEIP { get; set; }
        public virtual DbSet<F_CheckItems_IMEIR> F_CheckItems_IMEIR { get; set; }
        public virtual DbSet<F_CheckItems_IMEIW> F_CheckItems_IMEIW { get; set; }
        public virtual DbSet<F_CheckItems_Pallet> F_CheckItems_Pallet { get; set; }
        public virtual DbSet<F_CheckItems_Relation> F_CheckItems_Relation { get; set; }
        public virtual DbSet<F_Project_e> F_Project_e { get; set; }
        public virtual DbSet<F_Project_E8i> F_Project_E8i { get; set; }
        public virtual DbSet<F_Project_E8i_Coffee> F_Project_E8i_Coffee { get; set; }
        public virtual DbSet<F_Project_E8s> F_Project_E8s { get; set; }
        public virtual DbSet<F_Project_EF6> F_Project_EF6 { get; set; }
        public virtual DbSet<F_Project_EF6_100> F_Project_EF6_100 { get; set; }
        public virtual DbSet<F_Project_EF6_300> F_Project_EF6_300 { get; set; }
        public virtual DbSet<F_Project_EF7> F_Project_EF7 { get; set; }
        public virtual DbSet<F_Project_F7_S> F_Project_F7_S { get; set; }
        public virtual DbSet<F_Project_F7s> F_Project_F7s { get; set; }
        public virtual DbSet<F_Project_F8> F_Project_F8 { get; set; }
        public virtual DbSet<F_Project_GF7> F_Project_GF7 { get; set; }
        public virtual DbSet<F_Project_GM3> F_Project_GM3 { get; set; }
        public virtual DbSet<F_Project_H7s> F_Project_H7s { get; set; }
        public virtual DbSet<F_Project_HM4i> F_Project_HM4i { get; set; }
        public virtual DbSet<F_Project_L_6> F_Project_L_6 { get; set; }
        public virtual DbSet<F_Project_L25> F_Project_L25 { get; set; }
        public virtual DbSet<F_Project_MH17> F_Project_MH17 { get; set; }
        public virtual DbSet<F_Project_ML13> F_Project_ML13 { get; set; }
        public virtual DbSet<F_Project_MM17> F_Project_MM17 { get; set; }
        public virtual DbSet<F_Project_MM18> F_Project_MM18 { get; set; }
        public virtual DbSet<F_Project_NF_3> F_Project_NF_3 { get; set; }
        public virtual DbSet<F_Project_NF3> F_Project_NF3 { get; set; }
        public virtual DbSet<F_Project_Q37> F_Project_Q37 { get; set; }
        public virtual DbSet<F_Project_Q39> F_Project_Q39 { get; set; }
        public virtual DbSet<F_Project_R5> F_Project_R5 { get; set; }
        public virtual DbSet<F_Project_RX6> F_Project_RX6 { get; set; }
        public virtual DbSet<F_Project_S6_Dual> F_Project_S6_Dual { get; set; }
        public virtual DbSet<F_Project_Sample> F_Project_Sample { get; set; }
        public virtual DbSet<F_Project_XXX> F_Project_XXX { get; set; }
        public virtual DbSet<F_Projects> F_Projects { get; set; }
        public virtual DbSet<F_Rework> F_Rework { get; set; }
        public virtual DbSet<F_ReworkBattery> F_ReworkBattery { get; set; }
        public virtual DbSet<F_ReworkCarton> F_ReworkCarton { get; set; }
        public virtual DbSet<F_ReworkCartonWeight> F_ReworkCartonWeight { get; set; }
        public virtual DbSet<F_ReworkCharger> F_ReworkCharger { get; set; }
        public virtual DbSet<F_ReworkCheckIMEIset> F_ReworkCheckIMEIset { get; set; }
        public virtual DbSet<F_ReworkGifBox> F_ReworkGifBox { get; set; }
        public virtual DbSet<F_ReworkGifboxWeight> F_ReworkGifboxWeight { get; set; }
        public virtual DbSet<F_ReworkHandset> F_ReworkHandset { get; set; }
        public virtual DbSet<F_ReworkIMEI> F_ReworkIMEI { get; set; }
        public virtual DbSet<F_ReworkIMEIPrint> F_ReworkIMEIPrint { get; set; }
        public virtual DbSet<F_ReworkOutPallet> F_ReworkOutPallet { get; set; }
        public virtual DbSet<F_ReworkPallet> F_ReworkPallet { get; set; }
        public virtual DbSet<F_ReworkReadset> F_ReworkReadset { get; set; }
        public virtual DbSet<F_ReworkRelationCheck> F_ReworkRelationCheck { get; set; }
        public virtual DbSet<F_UserManagement> F_UserManagement { get; set; }
        public virtual DbSet<F_WOManagement> F_WOManagement { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}

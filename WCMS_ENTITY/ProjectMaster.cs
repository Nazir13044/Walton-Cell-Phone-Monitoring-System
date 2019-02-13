//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ProjectMaster
    {
        public long ProjectMasterId { get; set; }
        public long ProjectTypeId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<long> SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierModelName { get; set; }
        public Nullable<int> NumberOfSample { get; set; }
        public Nullable<System.DateTime> ApproxProjectFinishDate { get; set; }
        public string SupplierTrustLevel { get; set; }
        public Nullable<bool> IsScreenTestComplete { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> ApproxProjectOrderDate { get; set; }
        public Nullable<System.DateTime> ApproxShipmentDate { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public Nullable<bool> IsProjectManagerAssigned { get; set; }
        public string ProjectType { get; set; }
        public Nullable<bool> IsReorder { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public Nullable<decimal> DisplaySize { get; set; }
        public string DisplayName { get; set; }
        public string ProcessorName { get; set; }
        public Nullable<decimal> ProcessorClock { get; set; }
        public string Chipset { get; set; }
        public string FrontCamera { get; set; }
        public string BackCamera { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public string Battery { get; set; }
        public Nullable<int> SimSlotNumber { get; set; }
        public string SlotType { get; set; }
        public string ProjectStatus { get; set; }
        public string RevisedStatus { get; set; }
        public string ManagentComment { get; set; }
        public Nullable<decimal> ApproximatePrice { get; set; }
        public Nullable<long> GivenSampleToScreening { get; set; }
        public Nullable<decimal> FinalPrice { get; set; }
        public Nullable<long> Added { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> Updated { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string ProjectNameForScreening { get; set; }
        public string SourcingType { get; set; }
        public string ScreeningCommentFromCommercial { get; set; }
        public string PcbaVendorName { get; set; }
        public string PcbaFinalVendor { get; set; }
        public string DisplayResulution { get; set; }
        public string DisplaySpeciality { get; set; }
        public string TpVendor { get; set; }
        public string TpFinalVendor { get; set; }
        public string LcdVendor { get; set; }
        public string LcdFinalVendor { get; set; }
        public string HousingVendorName { get; set; }
        public string HousingFinalVendorName { get; set; }
        public string BackCam { get; set; }
        public string BackCamAutoFocus { get; set; }
        public string BackCamSensor { get; set; }
        public string BackCamBsi { get; set; }
        public string FrontCam { get; set; }
        public string FrontCamAutoFocus { get; set; }
        public string FrontCamSensor { get; set; }
        public string FrontCamBsi { get; set; }
        public string CpuName { get; set; }
        public string ChipsetName { get; set; }
        public string ChipsetFrequency { get; set; }
        public Nullable<int> ChipsetBit { get; set; }
        public string ChipsetCore { get; set; }
        public string MemoryBrandName { get; set; }
        public Nullable<bool> Gsensor { get; set; }
        public Nullable<bool> Psensor { get; set; }
        public Nullable<bool> Lsensor { get; set; }
        public Nullable<bool> Compass { get; set; }
        public Nullable<bool> Gyroscope { get; set; }
        public Nullable<bool> HallSensor { get; set; }
        public Nullable<bool> Otg { get; set; }
        public Nullable<bool> Gps { get; set; }
        public string SpecialSensor { get; set; }
        public Nullable<decimal> EarphoneConfirmPrice { get; set; }
        public string EarphoneSupplierName { get; set; }
        public string ChargerRating { get; set; }
        public string ChargerSupplierName { get; set; }
        public Nullable<bool> ThreeLayerScreenProtector { get; set; }
        public string BatteryCoverFinishingType { get; set; }
        public string BatteryCoverLogoType { get; set; }
        public Nullable<bool> OtgCable { get; set; }
        public Nullable<bool> FlashLight { get; set; }
        public string SecondGen { get; set; }
        public string ThirdGen { get; set; }
        public string FourthGenFdd { get; set; }
        public string FourthGenTdd { get; set; }
        public string Cdma { get; set; }
        public string BatteryRating { get; set; }
        public string BatteryType { get; set; }
        public string BatterySupplierName { get; set; }
        public string BateeryPossibleSupplierNames { get; set; }
        public Nullable<decimal> OrderQuantity { get; set; }
        public string Color { get; set; }
        public Nullable<int> OrderNuber { get; set; }
        public string ApprovalReviewRemarks { get; set; }
        public Nullable<System.DateTime> InitialApprovalDate { get; set; }
        public Nullable<System.DateTime> FinalApprovalDate { get; set; }
        public Nullable<System.DateTime> ScreeningIssueReviewDate { get; set; }
    }
}

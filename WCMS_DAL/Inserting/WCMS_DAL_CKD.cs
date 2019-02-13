using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCMS_COMMON;
using WCMS_DAL.HelperClass;
using WCMS_DAL.Interfaces;
using WCMS_ENTITY;

namespace WCMS_DAL.Inserting
{
    public class WCMS_DAL_CKD : ICKD
    {
        private readonly WCMSEntities _entity = new WCMSEntities();

        
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]

        //For MMI
      

        public bool InsertCkdMmiComponentInfo(tblCkdMmiMaster mmItabltestComponent)
        {
            try
            {

                _entity.tblCkdMmiMaster.Add(mmItabltestComponent);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public  List<tblCkdMmiMaster> GetCkdMmiMasterInfo(tblCkdMmiMaster tblCkdMmiMaster)
        {
            List<tblCkdMmiMaster> mmiList;

            try
            {

                mmiList = _entity.tblCkdMmiMaster
                    .WhereIf(tblCkdMmiMaster.ProjectId != null, x => x.ProjectId == tblCkdMmiMaster.ProjectId)
                    .WhereIf(tblCkdMmiMaster.BarCode != null, x => x.BarCode == tblCkdMmiMaster.BarCode)
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mmiList;
        }

        public bool UpdateCkdMmiInfo(tblCkdMmiMaster mmItabltestComponent)
        {

            
                _entity.Configuration.LazyLoadingEnabled = false;
                var mmiMaster =
                    _entity.tblCkdMmiMaster.FirstOrDefault(x => x.BarCode == mmItabltestComponent.BarCode);


                if (mmiMaster != null)
                {
                    if (mmItabltestComponent.Passed != null)
                        mmiMaster.Passed = mmItabltestComponent.Passed;
                    if (mmItabltestComponent.UpdatedBy != null)
                        mmiMaster.UpdatedBy = mmItabltestComponent.UpdatedBy;
                    if (mmItabltestComponent.UpdatedDate!=null)
                        mmiMaster.UpdatedDate = mmItabltestComponent.UpdatedDate;




                    _entity.Entry(mmiMaster).State = EntityState.Modified;
                    _entity.SaveChanges();
                }
                else
                {
                    return false;
                }


          

            return true;
        }

        //For SMT

        public bool InsertCkdSmtComponentInfo(tblCkdSmtMaster smtTableTestComponent)
        {
            try
            {

                _entity.tblCkdSmtMaster.Add(smtTableTestComponent);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }


        public List<tblCkdSmtMaster> GetCkdSmtMasterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            List<tblCkdSmtMaster> smtList;

            try
            {

                smtList = _entity.tblCkdSmtMaster
                    .WhereIf(tblCkdSmtMaster.ProjectId != null, x => x.ProjectId == tblCkdSmtMaster.ProjectId)
                    .WhereIf(tblCkdSmtMaster.BarCode != null, x => x.BarCode == tblCkdSmtMaster.BarCode)
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return smtList;
        }

        public bool UpdateCkdSmtInfo(tblCkdSmtMaster smtTableTestComponent)
        {


            _entity.Configuration.LazyLoadingEnabled = false;
            var smtMaster =
                _entity.tblCkdSmtMaster.FirstOrDefault(x => x.BarCode == smtTableTestComponent.BarCode);


            if (smtMaster != null)
            {
                if (smtTableTestComponent.Passed != null)
                    smtMaster.Passed = smtTableTestComponent.Passed;
                if (smtTableTestComponent.UpdatedBy != null)
                    smtMaster.UpdatedBy = smtTableTestComponent.UpdatedBy;
                if (smtTableTestComponent.UpdatedDate != null)
                    smtMaster.UpdatedDate = smtTableTestComponent.UpdatedDate;




                _entity.Entry(smtMaster).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }




            return true;
        }

        //For RF
        public bool InsertRfStationInformation(tblCkdRfMaster rfTableTestComponent)
        {
            try
            {

                _entity.tblCkdRfMaster.Add(rfTableTestComponent);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblCkdRfMaster> GetCkdRfMasterInfo(tblCkdRfMaster tblCkdRfMaster)
        {
            List<tblCkdRfMaster> rfList;

            try
            {

                rfList = _entity.tblCkdRfMaster
                    .WhereIf(tblCkdRfMaster.ProjectId != null, x => x.ProjectId == tblCkdRfMaster.ProjectId)
                    .WhereIf(tblCkdRfMaster.BarCode != null, x => x.BarCode == tblCkdRfMaster.BarCode)
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rfList;
        }

      

        public bool UpdateCkdRfInfo(tblCkdRfMaster rfTableTestComponent)
        {


            _entity.Configuration.LazyLoadingEnabled = false;
            var rfMaster =
                _entity.tblCkdRfMaster.FirstOrDefault(x => x.BarCode == rfTableTestComponent.BarCode);


            if (rfMaster != null)
            {
                if (rfTableTestComponent.Passed != null)
                    rfMaster.Passed = rfTableTestComponent.Passed;
                if (rfTableTestComponent.UpdatedBy != null)
                    rfMaster.UpdatedBy = rfTableTestComponent.UpdatedBy;
                if (rfTableTestComponent.UpdatedDate != null)
                    rfMaster.UpdatedDate = rfTableTestComponent.UpdatedDate;




                _entity.Entry(rfMaster).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }




            return true;
        }

        //For Software Load

        public bool InsertSoftwareLoadStationInformation(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {
            try
            {

                _entity.tblCkdSoftwareLoadMaster.Add(softwareLoadTableTestComponent);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblCkdSoftwareLoadMaster> GetCkdSoftwareLoadMasterInfo(tblCkdSoftwareLoadMaster tblCkdSoftwareLoadMaster)
        {
            List<tblCkdSoftwareLoadMaster> softwareLoadList;

            try
            {

                softwareLoadList = _entity.tblCkdSoftwareLoadMaster
                    .WhereIf(tblCkdSoftwareLoadMaster.ProjectId != null, x => x.ProjectId == tblCkdSoftwareLoadMaster.ProjectId)
                    .WhereIf(tblCkdSoftwareLoadMaster.BarCode != null, x => x.BarCode == tblCkdSoftwareLoadMaster.BarCode)
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return softwareLoadList;
        }



        public bool UpdateCkdSoftwareLoadInfo(tblCkdSoftwareLoadMaster softwareLoadTableTestComponent)
        {


            _entity.Configuration.LazyLoadingEnabled = false;
            var softwareLoadMaster =
                _entity.tblCkdSoftwareLoadMaster.FirstOrDefault(x => x.BarCode == softwareLoadTableTestComponent.BarCode);


            if (softwareLoadMaster != null)
            {
                if (softwareLoadTableTestComponent.Passed != null)
                    softwareLoadMaster.Passed = softwareLoadTableTestComponent.Passed;
                if (softwareLoadTableTestComponent.UpdatedBy != null)
                    softwareLoadMaster.UpdatedBy = softwareLoadTableTestComponent.UpdatedBy;
                if (softwareLoadTableTestComponent.UpdatedDate != null)
                    softwareLoadMaster.UpdatedDate = softwareLoadTableTestComponent.UpdatedDate;




                _entity.Entry(softwareLoadMaster).State = EntityState.Modified;
                _entity.SaveChanges();
            }
            else
            {
                return false;
            }




            return true;
        }
        //count
        public List<tblCkdSoftwareLoadMaster> GetSoftwareLoadQrCount()
        {
            List<tblCkdSoftwareLoadMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _entity.tblCkdSoftwareLoadMaster.Where(a => a.AddedDate >= startDate && a.UpdatedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<tblCkdSmtMaster> GetSmtQrCount()
        {
            List<tblCkdSmtMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _entity.tblCkdSmtMaster.Where(a => a.AddedDate >= startDate && a.UpdatedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<tblCkdRfMaster> GetRfQrCount()
        {
            List<tblCkdRfMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _entity.tblCkdRfMaster.Where(a => a.AddedDate >= startDate && a.UpdatedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public List<tblCkdMmiMaster> GetMmiQrCount()
        {
            List<tblCkdMmiMaster> list;
            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                list = _entity.tblCkdMmiMaster.Where(a => a.AddedDate >= startDate && a.UpdatedDate <= endDate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }


        public bool InsertCkdRework(tblCkdRework rework)
        {
            try
            {

                _entity.tblCkdRework.Add(rework);
                _entity.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblCkdSmtMaster> GetAnyParaMeterInfo(tblCkdSmtMaster tblCkdSmtMaster)
        {
            List<tblCkdSmtMaster> smtList;

            try
            {

                smtList = _entity.tblCkdSmtMaster
                   
                    .WhereIf(tblCkdSmtMaster.BarCode != null, x => x.BarCode == tblCkdSmtMaster.BarCode)
                    .WhereIf(tblCkdSmtMaster.Code != null, x => x.Code == tblCkdSmtMaster.Code)
                .AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return smtList;
        }

        public List<tblCkdIssues> GetAllIssueList()
        {
            List<tblCkdIssues> list;
            try
            {
                list = _entity.tblCkdIssues.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
    }


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSDAL;
using PMSWCFService.ServiceContracts;
using AutoMapper;
using PMSWCFService.DataContracts;

namespace PMSWCFService
{
    public partial class PMSService : IMaintenanceService
    {
        public int AddMainitenancePlan(DcMaintenancePlan model)
        {
            try
            {
                XS.Run();
                using (var dc=new PMSDbContext())
                {
                    int result = 0;
                    Mapper.Initialize(cfg => cfg.CreateMap<DcMaintenancePlan, MaintenancePlan>());
                    var plan = Mapper.Map<MaintenancePlan>(model);

                    return result;
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public int AddMainitenanceRecord(DcMaintenanceRecord model)
        {
            try
            {
                XS.Run();
                using (var dc = new PMSDbContext())
                {
                    int result = 0;
                    Mapper.Initialize(cfg => cfg.CreateMap<DcMaintenanceRecord, MaintenanceRecord>());
                    var record = Mapper.Map<MaintenanceRecord>(model);

                    return result;
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public int DeleteMainitenancePlan(Guid id)
        {
            try
            {
                XS.Run();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public int DeleteMainitenanceRecord(Guid id)
        {
            try
            {
                XS.Run();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public int GetMaintenancePlanCount()
        {
            try
            {
                XS.Run();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public List<DcMaintenancePlan> GetMaintenancePlans(int skip, int take)
        {
            try
            {
                XS.Run();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public List<DcMaintenanceRecord> GetMaintenanceRecords(string device, string part, int s, int t)
        {
            try
            {
                XS.Run();
                using (var db=new PMSDbContext())
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<MaintenanceRecord, DcMaintenanceRecord>());
                    var query = from m in db.MaintenanceRecords
                                where m.State != PMSCommon.SimpleState.作废.ToString()
                                && m.Device.Contains(device)
                                && m.Part.Contains(part)
                                select m;
                    var result = query.ToList().Skip(s).Take(t);
                    return Mapper.Map<List<MaintenanceRecord>,List<DcMaintenanceRecord>>(result.ToList());
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }
        }

        public int GetMaintenanceRecordsCount(string device, string part)
        {
            try
            {
                XS.Run();
                using (var db = new PMSDbContext())
                {
                    var query = from m in db.MaintenanceRecords
                                where m.State != PMSCommon.SimpleState.作废.ToString()
                                && m.Device.Contains(device)
                                && m.Part.Contains(part)
                                select m;
                    return query.Count();
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }
        }

        public int UpdateMainitenancePlan(DcMaintenancePlan model)
        {
            try
            {
                XS.Run();
                using (var dc = new PMSDbContext())
                {
                    int result = 0;
                    Mapper.Initialize(cfg => cfg.CreateMap<DcMaintenancePlan, MaintenancePlan>());
                    var plan = Mapper.Map<MaintenancePlan>(model);

                    return result;
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }

        public int UpdateMainitenanceRecord(DcMaintenanceRecord model)
        {
            try
            {
                XS.Run();
                using (var dc = new PMSDbContext())
                {
                    int result = 0;
                    Mapper.Initialize(cfg => cfg.CreateMap<DcMaintenanceRecord, MaintenanceRecord>());
                    var record = Mapper.Map<MaintenanceRecord>(model);

                    return result;
                }
            }
            catch (Exception ex)
            {
                XS.Current.Error(ex);
                throw;
            }

        }
    }
}
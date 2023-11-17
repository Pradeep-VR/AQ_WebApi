// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.UnloadController
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    public class UnloadController : ApiController
    {
        Logger log = new Logger();
        UnloadManagement uMgt = new UnloadManagement();

        [Route("api/UnloadDataNew")]
        public async Task<UnloadMaster> GetUnloadDataNew()
        {
            return await uMgt.unloaddetailsNew();
        }

        [Route("api/InsertUnloadData")]
        [HttpPost]
        public async Task<string> Post([FromBody] Dictionary<string, List<Unloading>> UnloadDetails)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadDetails != null)
                {
                    foreach (KeyValuePair<string, List<Unloading>> UnloadDetail in UnloadDetails)
                    {
                        List<Unloading> u = UnloadDetail.Value;
                        b = await uMgt.InsertUnloadData(u);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Data is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Data is Failed.." + s;
                }
                log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Data.." + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/InsertUnloadBatchAllocation")]
        [HttpPost]
        public async Task<string> PostInsertBatchAllocation([FromBody] Dictionary<string, List<UnloadBatchAllocation>> UnloadBatchAllocation)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadBatchAllocation != null)
                {
                    foreach (KeyValuePair<string, List<UnloadBatchAllocation>> item in UnloadBatchAllocation)
                    {
                        List<UnloadBatchAllocation> u = item.Value;
                        b = await uMgt.InsertBatchAllocation(u);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Batch Allocation is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Batch Allocation is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Batch Allocation.." + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadWashingDrainTime")]
        [HttpPost]
        public async Task<string> PostUnloadDrainTime([FromBody] Dictionary<string, List<UnloadWashingDrainTime>> UnloadDrainTime)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadDrainTime != null)
                {
                    foreach (KeyValuePair<string, List<UnloadWashingDrainTime>> item in UnloadDrainTime)
                    {
                        List<UnloadWashingDrainTime> DTime = item.Value;
                        b = await uMgt.InsertUnloadWashingDrainTime(DTime);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Washing DrainTime is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Washing DrainTime is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Washing DrainTime .." + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadWashingWeightment")]
        [HttpPost]
        public async Task<string> PostUnloadWashingWeightment([FromBody] Dictionary<string, List<UnloadWashingWeightment>> UnloadWashWeightment)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {

                if (UnloadWashWeightment != null)
                {
                    foreach (KeyValuePair<string, List<UnloadWashingWeightment>> item in UnloadWashWeightment)
                    {
                        List<UnloadWashingWeightment> ww = item.Value;
                        b = uMgt.InsertUnloadWashingWeightment(ww);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload WashWeightment is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload WashWeightment is Failed.." + s;
                }
                log.writeLog(log_txt);

            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload WashWeightment .." + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadNetSample")]
        [HttpPost]
        public async Task<string> PostUnloadNetSample([FromBody] Dictionary<string, List<UnloadRMNetSample>> UnloadNetSample)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadNetSample != null)
                {
                    foreach (KeyValuePair<string, List<UnloadRMNetSample>> item in UnloadNetSample)
                    {
                        List<UnloadRMNetSample> Net = item.Value;
                        b = await uMgt.InsertUnloadNetSampling(Net);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Net Sampling is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Unload Net Sampling is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In Unload Net Sampling .." + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        [Route("api/UnloadRMQuality")]
        [HttpPost]
        public async Task<string> PostUnloadQuality([FromBody] Dictionary<string, List<UnloadRMQuality>> UnloadRMQuality)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                if (UnloadRMQuality != null)
                {
                    foreach (KeyValuePair<string, List<UnloadRMQuality>> item in UnloadRMQuality)
                    {
                        List<UnloadRMQuality> Qty = item.Value;
                        b = await uMgt.InsertUnloadRMQuality(Qty);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting UnloadRM Quality is Success..";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting UnloadRM Quality is Failed.." + s;
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + ":::" + "Exception Catched In UnloadRM Quality .." + s;
                log.writeLog(log_exc);
            }
            return s;
        }
    }
}
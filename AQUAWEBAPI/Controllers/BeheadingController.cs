// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.BeheadingController
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;
using AQUAWEBAPI.Models;
namespace AQUAWEBAPI
{
    public class BeheadingController : ApiController
    {
        Logger log = new Logger();
        
        [Route("api/GetBeheading")]
        public async Task<List<BeheadingGet>> GetBeHeading()
        {
            DataTable dt = new DataTable();
            dt = null;
            List<BeheadingGet> rtdata = new List<BeheadingGet>();
            var log_txt = "";
            List<BeheadingGet> lbhload = new List<BeheadingGet>();
            BeheadingManagement bhMgt = new BeheadingManagement();
            rtdata = await bhMgt.GetBeheadingDetails();
            if(rtdata.Count == 0)
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Get Beheadding Details Faild...";
            }
            else
            {
                log_txt = DateTime.Now.ToString() + ":::" + "Get Beheadding Details Success !!!";
            }
            log.writeLog(log_txt);
            return rtdata;
        }

        public IEnumerable<string> Get()
        {
            return new string[2] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody] string value)
        {
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }

        [Route("api/AquaBeheadingTableAllocation")]
        [HttpPost]
        public async Task<string> Postallocation([FromBody] Dictionary<string, List<BeHeadingTableAllocation>> BeheadingTableAllocation)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingTableAllocation != null)
                {
                    foreach (KeyValuePair<string, List<BeHeadingTableAllocation>> item in BeheadingTableAllocation)
                    {
                        List<BeHeadingTableAllocation> p = item.Value;
                        b = await APMgt.InsertBaheadingTableAllocation(p);
                        s = ((!(b == "Success")) ? ("Failure" + BeheadingTableAllocation.Count + b) : " successfully");
                    }
                   
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabel Allocation Details Success.!!!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabel Allocation Details Failed.!!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
            }
            
            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaBeheadingFinalData")]
        [HttpPost]
        public async Task<string> PostFinal([FromBody] Dictionary<string, List<Beheading>> BeheadingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<Beheading>> BeheadingFinalDatum in BeheadingFinalData)
                    {
                        List<Beheading> p = BeheadingFinalDatum.Value;
                        b = await APMgt.InsertBeheadingFinalData(p);
                        s = ((!(b == "Success")) ? b : " successfully");
                    }
                   
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Beheadding Final Data Success...";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Inserting Beheadding Final Data Failed !!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString() + b;
            }
            log.writeLog(log_txt);
            return s;
        }

        [Route("api/AquaBeheadingTablewise")]
        [HttpPost]
        public async Task<string> Posttable([FromBody] Dictionary<string, List<BeHeadingTableWise>> BeheadingTablewise)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                BeheadingManagement APMgt = new BeheadingManagement();
                if (BeheadingTablewise != null)
                {
                    foreach (KeyValuePair<string, List<BeHeadingTableWise>> item in BeheadingTablewise)
                    {
                        List<BeHeadingTableWise> p = item.Value;
                        b = await APMgt.InsertBeheadingTablewise(p);
                        s = ((!(b == "Success")) ? ("Failure" + BeheadingTablewise.Count + b) : " successfully");
                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s.ToUpper() == "SUCCESSFULLY")
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabelwise Details Success.!!!";
                }
                else
                {
                    log_txt = DateTime.Now.ToString() + ":::" + "Insert Beheadding Tabelwise Details Failed.!!!" + ":::" + s;
                }
            }
            catch (Exception ex)
            {
                s = ex.ToString();
            }
            log.writeLog(log_txt);
            return s;
        }
    }
}
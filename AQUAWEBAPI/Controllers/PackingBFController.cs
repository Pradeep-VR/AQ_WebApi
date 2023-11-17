// AQUAWEBAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// AQUAWEBAPI.Controllers.PackingBFController
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using AQUAWEBAPI.Models;

namespace AQUAWEBAPI
{
    
    public class PackingBFController : ApiController
    {
        Logger log = new Logger();

        [Route("api/PackingBF")]
        public List<PackingBF> GetPackingBF()
        {
            DataTable dt = new DataTable();
            dt = null;
            List<PackingBF> LPck = new List<PackingBF>();
            PackingBFManagement pckmgt = new PackingBFManagement();
            return pckmgt.GetPackingBFDetails();
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        [Route("api/AquaPackingData")]
        [HttpPost]
        public string PostPackingFinal([FromBody] Dictionary<string, List<PackingScanning>> PackingFinalData)
        {
            string s = "Not Loaded";
            string b = "Loaded";
            var log_txt = "";
            try
            {
                PackingBFManagement packMgt = new PackingBFManagement();
                if (PackingFinalData != null)
                {
                    foreach (KeyValuePair<string, List<PackingScanning>> PackingFinalDatum in PackingFinalData)
                    {
                        List<PackingScanning> p = PackingFinalDatum.Value;
                        b = packMgt.InsertPackingScanData(p);
                        s = ((!(b == "Success")) ? b : "successfully");

                    }
                }
                else
                {
                    s = "Error" + b;
                }
                if (s == "successfully")
                {
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Failed..." + ":::" + s;
                }
                else
                {                    
                    log_txt = DateTime.Now.ToString() + " ::: " + "Inserting Packing Scan Data Success !!";
                }
                log.writeLog(log_txt);
            }
            catch (Exception ex)
            {
                s = ex.ToString();
                var log_exc = DateTime.Now.ToString() + " ::: " + "Exception Catched in Packing Scan Data..." + ":::" + s;
                log.writeLog(log_exc);
            }
            return s;
        }

        //public void Post([FromBody] string value)
        //{
        //}

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}
    }
}
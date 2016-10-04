using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TuscData;

namespace TuscService.Controllers
{
    public class TransactionController : ApiController
    {
        // GET api/users
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetDateRange(DateTime startDateTime, DateTime endDateTime)
        {
            return DataManager.GetTransactions().Where(t => t.Date >= startDateTime && t.Date <= endDateTime);
        }

    }
}

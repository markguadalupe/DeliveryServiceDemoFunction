using Dapper;
using Model;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repo.Implementation
{
    public class DeliveryItemRepo : GenericRepo<long, DeliveryItem>, IDeliveryItemRepo
    {
    }
}

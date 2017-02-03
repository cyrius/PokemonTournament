using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubDataAccessLayer
{
    public interface IDal
    {
        DataTable SelectByDataAdapter(string request);
        void Delete(string request, int id);
    }
}

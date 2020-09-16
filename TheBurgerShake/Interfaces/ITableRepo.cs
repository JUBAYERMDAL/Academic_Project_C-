using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITableRepo
    {
        bool InsertTable(Table table);
        bool DeleteTable(Table table);
        bool UpdateTable(Table table);
        Table GetTable(int tableId);
        List<Table> GetAllTables();
    }
}

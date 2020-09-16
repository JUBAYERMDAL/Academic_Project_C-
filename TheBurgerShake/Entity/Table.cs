using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Table
    {
        int tableId;
        int numberOfSeats;
        int status;

        public int TableId
        {
            get { return tableId; }
            set { tableId = value; }
        }

        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}

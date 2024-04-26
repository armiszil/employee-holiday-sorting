using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProject_SzA_DE6ZVJ
{
    class Admin
    {
        int vacation;
        int start;
        int end;


        //properties

        public int Vacation
        {
            get { return vacation; }
            set { vacation = value; }
        }

        public int Start
        {
            get { return start; }
        }


        public int End
        {
            get { return end; }
        }


        //Constructor

        public Admin(int vacation, int start, int end)
        {
            this.vacation = vacation;
            this.start = start;
            this.end = end;
        }

        public Admin(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}

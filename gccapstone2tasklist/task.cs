using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gccapstone2tasklist
{
    class Task
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
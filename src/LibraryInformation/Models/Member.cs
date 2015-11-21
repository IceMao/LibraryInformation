using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInformation.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string bookName { get; set; }
        public string writer { get; set; }
        public string publishing { get; set; }
        public string callNumber { get; set; } //索书号
        public string barCode { get; set; } //条码号
        public string Note { get; set; }
    }
}

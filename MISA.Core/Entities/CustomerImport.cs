using MISA.Import.Core.Entities;
using System.Collections.Generic;

namespace MISA.Import.Core.Entites { 
    public class CustomerImport
    {
        public Customer Data { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}

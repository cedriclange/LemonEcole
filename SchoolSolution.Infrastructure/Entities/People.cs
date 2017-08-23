using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public abstract class People
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string FullName { get {
                return $"{Lastname}  {Firstname}"; } }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

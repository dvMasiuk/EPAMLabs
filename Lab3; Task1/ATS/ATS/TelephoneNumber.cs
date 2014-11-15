using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ATS
{
    public class TelephoneNumber : IEqualityComparer<TelephoneNumber>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Number { get; set; }

        public bool Equals(TelephoneNumber x, TelephoneNumber y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            return x != null && y != null && x.Id.Equals(y.Id) && x.Number.Equals(y.Number);
        }

        public int GetHashCode(TelephoneNumber obj)
        {
            int hashNumber = obj.Number == null ? 0 : obj.Number.GetHashCode();
            int hashId = obj.Id.GetHashCode();
            return hashNumber ^ hashId;
        }
    }
}

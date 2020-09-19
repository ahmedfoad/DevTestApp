namespace DevTest_Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Accounts1 = new HashSet<Account>();
        }

        [Key]
        [StringLength(10)]
        public string Acc_Number { get; set; }

        [StringLength(10)]
        public string ACC_Parent { get; set; }

        public decimal? Balance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts1 { get; set; }

        public virtual Account Account1 { get; set; }
    }
}

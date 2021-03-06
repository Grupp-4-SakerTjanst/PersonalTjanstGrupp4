namespace PersonalTjanstGrupp4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personal")]
    public partial class Personal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AnvandarNamn { get; set; }

        [Required]
        [StringLength(50)]
        public string Namn { get; set; }

        [Required]
        [StringLength(50)]
        public string Efternamn { get; set; }

        public int BehorighetsNiva { get; set; }

        [Required]
        [StringLength(50)]
        public string Roll { get; set; }

        public int RefID { get; set; }
    }
}

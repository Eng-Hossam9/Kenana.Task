using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXamination.Core
{
    public class BaseEntity<Tkey>
    {
        [Key]

        public Tkey Id { get; set; }
    }
}

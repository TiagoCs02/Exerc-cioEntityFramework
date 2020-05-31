using System;
using System.Collections.Generic;

namespace ExercícioEntityFramework.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int CodCid { get; set; }
        public int CodEst { get; set; }
        public string NomeCid { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}

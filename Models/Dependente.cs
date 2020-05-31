using System;
using System.Collections.Generic;

namespace ExercícioEntityFramework.Models
{
    public partial class Dependente
    {
        public int CodDep { get; set; }
        public int CodFunc { get; set; }
        public string NomeDep { get; set; }
        public DateTime DataNascDep { get; set; }
        public string SexoDep { get; set; }

        public virtual Funcionario CodFuncNavigation { get; set; }
    }
}

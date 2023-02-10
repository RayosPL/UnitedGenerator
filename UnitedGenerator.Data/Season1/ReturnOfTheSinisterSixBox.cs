using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class ReturnOfTheSinisterSixBox : BoxBase
    {
        public ReturnOfTheSinisterSixBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Return of the Sinister Six";

        public override IVillain[] Villains => new IVillain[]
        {
            DoctorOtctopus,
            Electro,
            Kraven,
            Vulture,
            Mysterio,
            Sandman,
            SinisterSix
        };

        public IVillain DoctorOtctopus => new Villain(this, "Doctor Otctopus");
        public IVillain Electro => new Villain(this, "Electro");
        public IVillain Kraven => new Villain(this, "Kraven");
        public IVillain Vulture => new Villain(this, "Vulture");
        public IVillain Mysterio => new Villain(this, "Mysterio");
        public IVillain Sandman => new Villain(this, "Sandman");
        public IVillain SinisterSix => new Villain(this, "Sinister Six");
    }
}

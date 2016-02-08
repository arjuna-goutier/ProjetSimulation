using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage
{
    public abstract class EtatFeuAbstrait
    {
        public abstract void ModifieEtat(FeuTricolor feuTricolor);
        public abstract bool peuPasser { get; }
    }

    public class EtatFeuRouge : EtatFeuAbstrait
    {
        public override bool peuPasser
        {
            get
            {
                return false;
            }
        }

        public override void ModifieEtat(FeuTricolor feuTricolor)
        {
            feuTricolor.etatCourant = new EtatFeuVert();
        }
    }

    public class EtatFeuVert : EtatFeuAbstrait
    {
        public override bool peuPasser
        {
            get
            {
                return true;
            }
        }

        public override void ModifieEtat(FeuTricolor feuTricolor)
        {
            feuTricolor.etatCourant = new EtatFeuOrange();
        }
    }

    public class EtatFeuOrange : EtatFeuAbstrait
    {
        public override bool peuPasser
        {
            get
            {
                return false;
            }
        }

        public override void ModifieEtat(FeuTricolor feuTricolor)
        {
            feuTricolor.etatCourant = new EtatFeuRouge();
        }
    }

    public class EtatFeuEnPanne : EtatFeuAbstrait
    {
        public override bool peuPasser
        {
            get
            {
                return true;
            }
        }

        public override void ModifieEtat(FeuTricolor feuTricolor)
        {
            feuTricolor.etatCourant = new EtatFeuRouge();
        }
    }

    public class FeuTricolor : Personnage
    {
         public EtatFeuAbstrait etatCourant = new EtatFeuRouge();
        public override void Tick(TickEvent e)
        {
            etatCourant.ModifieEtat(this);            
        }
        public FeuTricolor(ISimulation sumilation, string nom) : base(sumilation, nom)
        {


        }
        public bool peuPassé => etatCourant.peuPasser;

    }
}

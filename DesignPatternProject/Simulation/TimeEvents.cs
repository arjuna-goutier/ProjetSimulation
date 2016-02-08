using SimulationPersonnage;

namespace SimulationPersonnage
{
    public class TimeEvent : Event<SimulationDeJeux> { }
    //raised at the start of the simulation
    public class BeginEvent : TimeEvent { }
    public class BeginCourse : TimeEvent { }
    public class FinCourse : TimeEvent { }
    //raised at the end of the 
    public class EndEvent : TimeEvent { }

    //raised a each turn
    public class TickEvent : TimeEvent { }

    //a la fin du tour, notament pour l'interface graphique
    public class EndTurnEvent :TimeEvent { }
}
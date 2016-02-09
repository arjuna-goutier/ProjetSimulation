using SimulationPersonnage;

namespace SimulationPersonnage
{
    public class TimeEvent : Event<SimulationDeJeux> { }
    //raised at the start of the simulation
    class BeginEvent : TimeEvent { }
    class BeginCourse : TimeEvent { }
    class FinCourse : TimeEvent { }
    //raised at the end of the 
    class EndEvent : TimeEvent { }

    //raised a each turn
    class TickEvent : TimeEvent { }

    //a la fin du tour, notament pour l'interface graphique
    class EndTurnEvent :TimeEvent { }
}
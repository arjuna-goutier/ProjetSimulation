using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationPersonnage
{

    public  abstract class Event<TSource>
    {
        public TSource Source { get; set; }
    }

    public delegate void EventHandler<in T>(T t);

   public  interface IObservable<in TEvent>
    {
        void Attach<T>(EventHandler<T> observateur) where T : TEvent;
        void Detach<T>(IObservateur<T> observateur) where T : TEvent;
    }
    public abstract class Observable<TEvent>:IObservable<TEvent>
    {
        private readonly TypedDictionary observateurs = new TypedDictionary();

        public void Attach<T>(EventHandler<T> observateur) where T: TEvent
            => observateurs.AddValue(observateur);

        public void Detach<T>(IObservateur<T> observateur) where T : TEvent
            => observateurs.RemoveValue(observateur);

        protected void Raise<T>(T c) where T: TEvent
        {
            foreach (var observateur in observateurs.GetValues<EventHandler<T>>())
                observateur(c);
        }
    }


    public class TypedDictionary
    {
        private readonly Dictionary<Type, List<object>> values = new Dictionary<Type, List<object>>();

        public IEnumerable<TType> GetValues<TType>()
        {
            if (!values.ContainsKey(typeof(TType)))
                return new List<TType>();

            return values[typeof (TType)].Cast<TType>();
        }

        public void RemoveValue<TType>(TType value)
        {
            if (!values.ContainsKey(typeof (TType)))
                return;

            values[typeof (TType)].Remove(value);
        }

        public void AddValue<TType>(TType value)
        {
            if (!values.ContainsKey(typeof(TType)))
                values[typeof(TType)] = new List<object>();

            values[typeof(TType)].Add(value);
        }
    }
}
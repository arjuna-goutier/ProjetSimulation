using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace SimulationPersonnage
{
    public abstract class Observable
    {

        private readonly TypedDictionary observateurs = new TypedDictionary();
        public void Attach<TChanged>(IObservateur<TChanged> observateur)
            => observateurs.AddValue(observateur);

        
        public void Detach<TChanged>(IObservateur<TChanged> observateur)
            => observateurs.RemoveValue(observateur);

        protected void Update<TChanged>(TChanged c)
        {
            foreach (var observateur in observateurs.GetValues<TChanged>())
                ((IObservateur<TChanged>) observateur).Update(c);
        }
    }

    public class TypedDictionary
    {
        private readonly Dictionary<Type, List<object>> values = new Dictionary<Type, List<object>>();

        public IEnumerable<TType> GetValues<TType>()
        {
            if (!values.ContainsKey(typeof(TType)))
                return new List<TType>();

            return (IEnumerable<TType>) values[typeof (TType)];
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
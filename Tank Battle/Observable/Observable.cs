using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Observable
{
    public class Observable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private T subject;

        public T Subject
        {
            get => subject;
            set
            {
                subject = value;
                Notify();
            }
        }

        public void Register(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(subject);
            }
        }
    }
}

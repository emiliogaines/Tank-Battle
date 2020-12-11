using System;
using System.Collections.Generic;
using System.Text;

namespace Tank_Battle.Observable
{
    public interface IObserver<T>
    {
        void Update(T data);
    }
}

using System;

namespace MyValueViewPckage
{
    public interface IValueChanging
    {
        public event Action<float, float> ValueChanged;
    }
}

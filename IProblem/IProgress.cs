using System;

namespace ProjectEuler
{
    public class CProgress
    {
        public double MaxValue { private set; get; }
        public double MinValue { private set; get; }
        public double CurrentValue { private set; get; }
        public string Message { set; get; }
        public double Percentage
        {
            get
            {
                return (CurrentValue - MinValue) / (MaxValue - MinValue);
            }
        }

        public CProgress(double MinValue=0,double MaxValue=100)
        {
            SetRange(MinValue, MaxValue);
            Reset();
        }

        public void Reset()
        {
            CurrentValue = MinValue;
        }

        public void Finish()
        {
            CurrentValue = MaxValue;
        }

        public void SetRange(double MaxValue)
        {
            SetRange(0, MaxValue);
        }

        public void SetRange(double MinValue, double MaxValue)
        {
            if (MinValue >= MaxValue)
                throw new ArgumentOutOfRangeException("MinValue should be less than MaxValue");
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
        }

        public void Update(double value)
        {
            this.CurrentValue = value;
        }

    }

    public interface IProgress
    {
        CProgress Progress { get; }
    }
}

namespace ObserverPattern
{
    internal class Discount
    {
        public double Percent { get; set; }
        public double MinFinalValue { get; set; }
        public Discount(double percent, double minFinalValue)
        {
            Percent = percent;
            MinFinalValue = minFinalValue;
        }
    }
}
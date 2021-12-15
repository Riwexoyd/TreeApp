namespace TreeApp.ApplicationServices.Models
{
    public sealed class TreeHeight
    {
        public double Value { get; }

        public TreeHeight(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var meters = (int)Value / 100;

            return string.Format("{0}{1:0.##} см.", meters >=1 ? $"{meters} м. " : "", Value % 100);
        }
    }
}

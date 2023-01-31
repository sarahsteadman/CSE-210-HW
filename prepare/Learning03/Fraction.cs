public class Fraction
    {
        private int _top;
        private int _bottom;

        public  Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        public  Fraction(int wholenumber)
        {
            _top = wholenumber;
            _bottom = 1;
        }
        public  Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }

        private int GetTop()
        {
            return _top;
        }
        public void SetTop(int top)
        {
            _top = top;
        }
        private int Getbottom()
        {
            return _bottom;
        }        
        public void SetBottom(int bottom)
        {
            _bottom =bottom;
        }

        public string GetFractionString()
        {
            string text = $"{_top}/{_bottom}";
            return text;
        }
        public double GetDecimal()
        {
        return (double)_top / (double)_bottom;
        }
    }
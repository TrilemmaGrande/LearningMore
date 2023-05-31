using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.SimpleCalculator
{
    public enum CalcState
    {
        Active, Inactive
    }
    public class Calculator
    {
        public decimal Value { get; set; }
        private CalcState state = CalcState.Inactive;

        public decimal Add(decimal value)
        {
            Value = Value + value;
            state = CalcState.Active;
            return Value;
        }
        public decimal Sub(decimal value)
        {
            Value = Value - value;
            state = CalcState.Active;
            return Value;
        }
        public decimal Mult(decimal value)
        {
            if (state == CalcState.Inactive)
            {
                Value = value;
                state = CalcState.Active;
                return Value;
            }
            Value = Value * value;
            return Value;
        }
        public decimal Div(decimal value)
        {
            if (state == CalcState.Inactive)
            {
                Value = value;
                state = CalcState.Active;
                return Value;
            }
            Value = Value / value;
            return Value;
        }
        public void reset()
        {
            Value = 0;
            state = CalcState.Inactive;
        }
    }
}

using System;
using Xamarin.Forms;

namespace Calculadora.ViewModels
{
    public class CalculadoraViewModel : BaseViewModel
    {
        private string numero;
        private string operacion;
        private string resultado;
        private Double _numero;
        private Double _numeroTmp;
        public Command<object> OperationButtonCommand { get; set; }
        public Command<object> NumericButtonCommand { get; set; }
        public Command<object> ResultButtonCommand { get; set; }
        public string Numero
        {
            get
            {
                return this.numero;
            }

            set
            {
                if (this.numero == value)
                {
                    return;
                }

                this.numero = value;
                this.NotifyPropertyChanged();
            }
        }
        public string Resultado
        {
            get
            {
                return this.resultado;
            }

            set
            {
                if (this.resultado == value)
                {
                    return;
                }

                this.resultado = value;
                this.NotifyPropertyChanged();
            }
        }

        public CalculadoraViewModel()
        {
            this.NumericButtonCommand = new Command<object>(this.NumericButton);
            this.OperationButtonCommand = new Command<object>(this.OperationButton);
            this.ResultButtonCommand = new Command<object>(this.ResultButton);
            Numero = String.Empty;
            operacion = String.Empty;
        }

        private void NumericButton(object obj)
        {
            if (obj.ToString() == "+/-")
            {
                _numero *= -1;
                Numero = _numero.ToString();
            }
            else
            {
                Numero += obj.ToString();
                Double.TryParse(Numero, out _numero);
            }
        }
        private void OperationButton(object obj)
        {
            operacion = obj.ToString();
            _numeroTmp = _numero;
            Numero = String.Empty;
            switch (operacion)
            {
                case "CE":
                    _numeroTmp = 0;
                    _numero = 0;
                    Numero = String.Empty;
                    Resultado = String.Empty;
                    break;

            }
        }
        private void ResultButton(object obj)
        {
            Double r = 0;
            Double.TryParse(Numero, out _numero);
            switch (operacion)
            {
                case "%":
                    break;
                case "/":
                    r = _numeroTmp / _numero;
                    break;
                case "R":
                    r = Math.Sqrt(_numeroTmp);
                    break;
                case "X":
                    r = _numeroTmp * _numero;
                    break;
                case "-":
                    r = _numeroTmp - _numero;
                    break;
                case "+":
                    r = _numeroTmp + _numero;
                    break;
            }
            _numeroTmp = 0;
            _numero = 0;
            Numero = String.Empty;
            Resultado = r.ToString();
        }
    }
}

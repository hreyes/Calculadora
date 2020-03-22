using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Calculadora.ViewModels
{
    public class CalculadoraViewModel : BaseViewModel
    {
        private string numero;
        private string operacion;
        private string resultado;
        private Double _numeroUno;
        private Double _numeroDos;
        private Double _numeroTmp;
        public Command<object> OperationButtonCommand { get; set; }
        public Command<object> NumericButtonCommand { get; set; }
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
            Numero = String.Empty;
            operacion = String.Empty;
        }

        private void NumericButton(object obj)
        {
            Numero += obj.ToString();

            bool _isNumber = Double.TryParse(Numero, out _numeroUno);           

            switch (operacion)
            {
                case "%":
                    break;
                case "/":
                    var r = _numeroTmp / _numeroUno;
                    _numeroUno = r;
                    Resultado = r.ToString();
                    operacion = String.Empty;
                    break;
                case "R":
                    break;
                case "X":
                    break;
                case "CE":
                    break;
                case "-":
                    break;
                case "+/-":
                    break;
                case "+":
                    break;
                case "=":
                    break;
            }
        }
        private void OperationButton(object obj)
        {
            operacion = obj.ToString();            
            _numeroTmp = _numeroUno;
            Numero = String.Empty;
        }
    }
}

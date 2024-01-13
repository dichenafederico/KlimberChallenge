using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{   

    public abstract class FormaGeometrica
    {      
        protected FormaGeometrica() {}
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();            
       
    }

    public class Cuadrado : FormaGeometrica
    {
        public decimal lado { get; set; }
        public Cuadrado(decimal lado) 
        {
            this.lado = lado;
        }

        public override decimal CalcularArea()
        {
            return lado * lado;
        }

        public override decimal CalcularPerimetro()
        {
            return lado * 4;
        }
    }

    public class Circulo : FormaGeometrica
    {
        public decimal ancho { get; set; }
        public Circulo(decimal ancho)
        {
            this.ancho = ancho;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (ancho / 2) * (ancho / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * ancho;
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        public decimal lado { get; set; }
        public TrianguloEquilatero(decimal lado) 
        {
            this.lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * lado * lado;
        }

        public override decimal CalcularPerimetro()
        {
            return lado * 3;
        }
    }

    public class Rectangulo : FormaGeometrica
    {
        public decimal ladoMayor { get; set; }
        public decimal ladoMenor { get; set; }

        public Rectangulo(decimal lado1, decimal lado2)
        {
            this.ladoMayor = lado1 > lado2 ? lado1 : lado2;
            this.ladoMenor = lado1 < lado2 ? lado1 : lado2;
        }

        public override decimal CalcularArea()
        {
            return ladoMenor * ladoMayor;
        }

        public override decimal CalcularPerimetro()
        {
            return (ladoMenor * 2) + (ladoMayor * 2);
        }
    }
}
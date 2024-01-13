/******************************************************************************************************************/
/******* ENUNCUADO¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class Language
    {
        protected Dictionary<Type, (string singular, string plural)> tipoNombres = new Dictionary<Type, (string, string)>();

        public string ReporteSinFormas;
        public string TituloReporteConFormas;
        public string palabraTotal;
        public string palabraForma;
        public string palabraFormas;
        public string palabraPerimetro;
        public string palabraArea;

        public string TraducirForma(FormaGeometrica forma, int cantidad)
        {
            return tipoNombres.ContainsKey(forma.GetType()) ? (cantidad > 1 ? tipoNombres[forma.GetType()].plural : tipoNombres[forma.GetType()].singular) : string.Empty;
        }
        public string ObtenerLinea(int cantidad, decimal areaTotal, decimal perimetroTotal, FormaGeometrica formaGeometrica) {
            if (cantidad > 0)
                return $"{cantidad} {TraducirForma(formaGeometrica, cantidad)} | {palabraArea} {areaTotal:#.##} | {palabraPerimetro} {perimetroTotal:#.##} <br/>";
            else
                return string.Empty;
        }

        public string Imprimir(List<FormaGeometrica> formas) {

            var sb = new StringBuilder();

            if (!formas.Any())
            { 
                sb.Append("<h1>" + ReporteSinFormas + "</h1>");
                return sb.ToString();
            }

            sb.Append("<h1>" + TituloReporteConFormas + "</h1>");

            var formasAgrupadas = formas.GroupBy(f => f.GetType());

            foreach (var grupo in formasAgrupadas)
            {
                var cantidad = grupo.Count();
                var area = grupo.Sum(f => f.CalcularArea());
                var perimetro = grupo.Sum(f => f.CalcularPerimetro());
                sb.Append(ObtenerLinea(cantidad, area, perimetro, grupo.First()));
            }

            // FOOTER
            sb.Append(palabraTotal + ":<br/>");

            var cantidadFormas = formas.Count();

            sb.Append(cantidadFormas + " " + (cantidadFormas > 1 ? palabraFormas : palabraForma));            
            sb.Append($" {palabraPerimetro} {formas.Sum(f => f.CalcularPerimetro()):#.##} ");
            sb.Append($"{palabraArea} {formas.Sum(f => f.CalcularArea()):#.##}");

            return sb.ToString();
        }        
               
    }

    public class Español : Language
    {
        public Español()
        {
            ReporteSinFormas = "Lista vacía de formas!";
            TituloReporteConFormas = "Reporte de Formas";
            palabraArea = "Area";
            palabraPerimetro = "Perimetro";
            palabraForma = "forma";
            palabraFormas = "formas";
            palabraTotal = "TOTAL";
            tipoNombres[typeof(Cuadrado)] = ("Cuadrado", "Cuadrados");
            tipoNombres[typeof(Circulo)] = ("Círculo", "Círculos");
            tipoNombres[typeof(TrianguloEquilatero)] = ("Triángulo", "Triángulos");
            tipoNombres[typeof(Rectangulo)] = ("Rectángulo", "Rectángulos");
        }     
    }
    public class Ingles : Language
    {
        public Ingles()
        {
            ReporteSinFormas = "Empty list of shapes!";
            TituloReporteConFormas = "Shapes report";
            palabraArea = "Area";
            palabraPerimetro = "Perimeter";
            palabraForma = "shape";
            palabraFormas = "shapes";
            palabraTotal = "TOTAL";
            tipoNombres[typeof(Cuadrado)] = ("Square", "Squares");
            tipoNombres[typeof(Circulo)] = ("Circle", "Circles");
            tipoNombres[typeof(TrianguloEquilatero)] = ("Triangle", "Triangles");
            tipoNombres[typeof(Rectangulo)] = ("Rectangle", "Rectangles");
        }
    }

    public class Italiano : Language
    {
        public Italiano()
        {
            ReporteSinFormas = "Elenco vuoto di forme, mamma mia!";
            TituloReporteConFormas = "Rapporto sui moduli";
            palabraArea = "La zona";
            palabraPerimetro = "Perimetro";
            palabraForma = "forma";
            palabraFormas = "forme";
            palabraTotal = "TOTALE";
            tipoNombres[typeof(Cuadrado)] = ("Piazza", "Piazze");
            tipoNombres[typeof(Circulo)] = ("Cerchio", "Cerchi");
            tipoNombres[typeof(TrianguloEquilatero)] = ("Triangolo", "Triangoli");
            tipoNombres[typeof(Rectangulo)] = ("Rettangolo", "Rettangoli");
        }
    }


}

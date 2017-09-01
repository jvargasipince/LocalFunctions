using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LocalFunctions
{
    class LocalFunctions
    {
        static void Main(string[] args)
        {

            List<Factura> facturas = new List<Factura>();
            facturas.Add(new Factura() { IdFactura = 1, Cantidad = 5, ConDescuento = true, Precio = 20.50m });
            facturas.Add(new Factura() { IdFactura = 2, Cantidad = 10, ConDescuento = false, Precio = 10.25m });
            facturas.Add(new Factura() { IdFactura = 3, Cantidad = 2, ConDescuento = true, Precio = 35.80m });
            facturas.Add(new Factura() { IdFactura = 4, Cantidad = 4, ConDescuento = false, Precio = 15.00m });

            CalcularFactura facturador = new CalcularFactura();
            facturador.CalcularMontoNeto(facturas);
        }

        public class CalcularFactura
        {
            public void CalcularMontoNeto(List<Factura> facturas)
            {
                decimal dscto = 0.1m;
                decimal igv = 0.18m;

                foreach (Factura factura in facturas)
                {
                    decimal SubTotal = 0;
                    decimal Total = 0;
                    decimal Dscto = 0;
                    CalcularMontos();
                    imprimir();

                    void CalcularMontos()
                    {
                        SubTotal = factura.Cantidad * factura.Precio;
                        Total = SubTotal * (1 + igv);
                        Dscto = factura.ConDescuento ? Total * dscto : 0;
                    }

                    void imprimir()
                    {
                        WriteLine("La factura con id " + factura.IdFactura);
                        WriteLine("Tiene un importe de " + SubTotal + " sin IGV");
                        WriteLine("Tiene un importe de " + Total + " con IGV");
                        WriteLine((factura.ConDescuento ? "SI" : "NO") + " tiene descuento");
                        WriteLine("Siendo el monto a pagar de " + (Total - Dscto));
                        Write(Environment.NewLine);
                        ReadLine();
                    }


                }

            }

        }


        public class Factura
        {
            public int IdFactura;
            public int Cantidad;
            public bool ConDescuento;
            public decimal Precio;
        }


    }
    }

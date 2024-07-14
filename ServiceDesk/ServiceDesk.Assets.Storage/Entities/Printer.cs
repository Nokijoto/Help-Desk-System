using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Assets.Storage.Entities
{
    public class Printer : Asset
    {
        public bool IsColor { get; set; }                 // Czy drukuje w kolorze
        public int PrintSpeed { get; set; }               // Szybkość druku (stron na minutę)
        public string? PrinterType { get; set; }          // Typ drukarki (Laserowa, Atramentowa)
        public bool HasScanner { get; set; }              // Czy posiada skaner
        public int PaperCapacity { get; set; }            // Pojemność na papier
    }
}

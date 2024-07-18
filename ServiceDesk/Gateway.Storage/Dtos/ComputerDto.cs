using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Gateway.Storage.Dtos
{
    public class ComputerDto : AssetDto
    {
        [DisplayName("System operacyjny")]
    public string? OperatingSystem { get; set; }

    [DisplayName("Rozmiar RAM")]
    public int RAMSize { get; set; }

    [DisplayName("Pojemność")]
    public int StorageSize { get; set; }

    [DisplayName("Procesor")]
    public string? Processor { get; set; }

    [DisplayName("Karta graficzna")]
    public bool HasGraphicsCard { get; set; }

    [DisplayName("Model karty graficznej")]
    public string? GraphicsCardModel { get; set; }
    }
}

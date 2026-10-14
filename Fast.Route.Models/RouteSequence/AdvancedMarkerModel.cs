using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.RouteSequence
{
    public class AdvancedMarkerModel
    {
        public AdvancedMarkerModel(SequenceModel sequence)
        {
            Title = sequence.Client;
            Sequence = sequence.Sequence.ToString();
            PopupContent = GetPopup(sequence);

        }
        public string Title { get; set; }
        public string Sequence { get; set; }
        public string PopupContent { get; set; }

        string GetPopup(SequenceModel seq)
        {
            return $"<div> <div id='content'>Cliente: {seq.Client} <br>Vendedor: {seq.Vendor} <br>Día de Visita: {seq.Cluster} <br>Secuencia de Visita: {seq.Sequence} <br> </div>";
        }
    }
}

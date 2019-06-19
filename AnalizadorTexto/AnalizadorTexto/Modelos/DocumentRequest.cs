using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorTexto.Modelos
{
    public class DocumentRequest
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
    }
}

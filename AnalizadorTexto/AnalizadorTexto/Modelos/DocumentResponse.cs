using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizadorTexto.Modelos
{
    public class InnerError
    {
        public string RequestId { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public InnerError InnerError { get; set; }
        public string Message { get; set; }
    }

    public class Document
    {
        public string Id { get; set; }
        public float Score { get; set; }
    }

    public class DocumentResponse
    {
        public Document[] Documents { get; set; }
        public Error[] Errors { get; set; }
    }
}

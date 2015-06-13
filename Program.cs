using System;
using System.Xml;
using System.Xml.Schema;

namespace EventsSchemaGenerator {

    //--- Types ---
    class EventSchemaGenerator {

        //--- Methods ---
        public static void Main (string[] args) {
            var infer = new XmlSchemaInference();
            var schemaSet = new XmlSchemaSet();
            foreach(var filename in args) {
                using(var reader = XmlReader.Create(filename)) {
                    schemaSet = infer.InferSchema(reader, schemaSet);
                }
            }
            foreach(XmlSchema schema in schemaSet.Schemas()) {
                schema.Write(Console.Out);
            }
        }
    }
}

using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace SchemaValidatorExample;

internal static class XmlSchemaValidator
{
    internal static bool IsValidXml(string schemaXml, string xml)
    {
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        try
        {
            schemaSet.Add("", XmlReader.Create(new System.IO.StringReader(schemaXml)));
        }
        catch (Exception e)
        {
            Console.WriteLine("Schema file is invalid.");
            return false;
        }

        XDocument xDocument;
        try
        {
            xDocument = XDocument.Parse(xml);
        }
        catch (Exception e)
        {
            Console.WriteLine("XML is invalid.");
            return false;
        }

        bool isValid = true;
        List<string> errorMessages = new List<string>();

        xDocument.Validate(schemaSet, (sender, args) =>
        {
            isValid = false;
            errorMessages.Add(args.Message);
        });

        if (isValid)
        {
            return true;
        }

        Console.WriteLine("The XML is invalid. Errors:");

        foreach (string error in errorMessages)
        {
            Console.WriteLine(error);
        }
        return false;

    }
}


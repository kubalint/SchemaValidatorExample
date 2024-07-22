using System.Text;
using SchemaValidatorExample;
using SchemaValidatorExample.Properties;

byte[] jsonBytes = Resources.JsonExample;
byte[] invalidJsonBytes = Resources.InvalidJson;

byte[] jsonSchemaBytes = Resources.JsonSchemaExample;

string json = Encoding.UTF8.GetString(jsonBytes);
string invalidJson = Encoding.UTF8.GetString(invalidJsonBytes);
string jsonSchema = Encoding.UTF8.GetString(jsonSchemaBytes);

string xml = Resources.XmlExample;
string invalidXml = Resources.InvalidXmlExample;

string xmlSchema = Resources.XmlSchemaExample;


bool isJsonValid = JsonSchemeValidator.IsValidJson(jsonSchema, json);
Console.WriteLine("JSON Validation result: " + (isJsonValid ? "Valid" : "Invalid"));

bool isXmlValid = XmlSchemaValidator.IsValidXml(xmlSchema, xml);
Console.WriteLine("XML Validation result: " + (isXmlValid ? "Valid" : "Invalid"));

Console.WriteLine();
Console.WriteLine("Invalid files validation below: ");
Console.WriteLine();

bool isInvalidJsonValid = JsonSchemeValidator.IsValidJson(jsonSchema, invalidJson);
Console.WriteLine("Invalid JSON Validation result: " + (isInvalidJsonValid ? "Valid" : "Invalid"));

bool isInvalidXmlValid = XmlSchemaValidator.IsValidXml(xmlSchema, invalidXml);
Console.WriteLine("Invalid XML Validation result: " + (isInvalidXmlValid ? "Valid" : "Invalid"));


Console.WriteLine("Press any key to exit.");
Console.ReadKey();
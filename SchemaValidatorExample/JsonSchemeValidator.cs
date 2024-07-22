using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace SchemaValidatorExample
{
    internal static class JsonSchemeValidator
    {
        internal static bool IsValidJson(string schemaJson, string json)
        {

            JSchema schema;

            try
            {
                schema = JSchema.Parse(schemaJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Schema file is invalid.");
                return false;
            }


            JObject jsonObject;

            try
            {
                jsonObject = JObject.Parse(json);
            }
            catch (Exception e)
            {
                return false;
            }

            bool isValid = jsonObject.IsValid(schema, out IList<string> errorMessages);

            if (isValid)
            {
                return true;
            }

            Console.WriteLine("The json is invalid. Errors:");

            foreach (string error in errorMessages)
            {
                Console.WriteLine(error);
            }

            return false;
        }
    }
}

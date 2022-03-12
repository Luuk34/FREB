//
// 2022-03-12: Luuk
// Convert XML from Failed Reuqest logs (IIS) to html
//
// With some help from:
// https://docs.microsoft.com/en-us/dotnet/standard/linq/use-xslt-transform-xml-tree
//



using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;


if (args.Length == 1)
{
    FileInfo fi = new FileInfo(args[0]);

    string xsltFile = Path.Combine( fi.DirectoryName , "freb.xsl");
    string oldFile = args[0];
    string newFile = args[0].Replace(".xml", ".html");

    string xslt = File.ReadAllText(xsltFile);

    XDocument oldDocument = XDocument.Load(oldFile);

    var newDocument = new XDocument();

    using (var stringReader = new StringReader(xslt))
    {
        using (XmlReader xsltReader = XmlReader.Create(stringReader))
        {
            var transformer = new XslCompiledTransform();
            transformer.Load(xsltReader);
            using (XmlReader oldDocumentReader = oldDocument.CreateReader())
            {
                using (XmlWriter newDocumentWriter = newDocument.CreateWriter())
                {
                    transformer.Transform(oldDocumentReader, newDocumentWriter);
                }
            }
        }
    }

    string result = newDocument.ToString();
    File.WriteAllText(newFile, result);
}
else
{
    Console.WriteLine("One parameter expected, pick an XML from the Failed Request logs ");
}
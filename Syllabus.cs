using System;
using System.Xml;
using HtmlAgilityPack;

public class Syllabus
{
    HtmlNode node;

	//I find it easier to attach a String link to go and extract html file of a website
	public Syllabus(String link)
	{
		var html = @link;
		HtmlWeb web = new HtmlWeb();
        var doc = web.Load(html);
		node = doc.DocumentNode.SelectSingleNode("//body");
	}

	// This part is totally erasable becasue it is just for us to see that code is running properly
	public void writenode()
    {
		Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
	}

}

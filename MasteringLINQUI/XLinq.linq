<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Linq.dll</Reference>
  <Namespace>System.Xml.Linq</Namespace>
</Query>

int trackId = 1;

XDocument doc = new XDocument(
	new XElement("library",
		new XElement("track",
			new XAttribute("id", trackId++),
			new XAttribute("genre", "Rap"),
			new XAttribute("time", "3:24"),
			new XElement("name", "Who We Be RMX (feat. 2Pac)"),
			new XElement("artist", "DMX"),
			new XElement("album", "The Dogz Mixtape: Who's Next?!")),
		new XElement("track",
			new XAttribute("id", trackId++),
			new XAttribute("genre", "Rap"),
			new XAttribute("time", "5:06"),
			new XElement("name", "Angel (ft. Regina Bell)"),
			new XElement("artist", "DMX"),
			new XElement("album", "...And Then There Was X")),
		new XElement("track",
			new XAttribute("id", trackId++),
			new XAttribute("genre", "Break Beat"),
			new XAttribute("time", "6:16"),
			new XElement("name", "Dreaming Your Dreams"),
			new XElement("artist", "Hybrid"),
			new XElement("album", "Wide Angle")),
		new XElement("track",
			new XAttribute("id", trackId++),
			new XAttribute("genre", "Break Beat"),
			new XAttribute("time", "9:38"),
			new XElement("name", "Finished Symphony"),
			new XElement("artist", "Hybrid"),
			new XElement("album", "Wide Angle"))));
			
Console.WriteLine(doc.Root.Elements());

// get all the attributes from all data
Console.WriteLine(
	doc.Root.Elements().SelectMany(e => e.Attributes()));

Console.WriteLine(
	doc.Root.Elements().Where(e => e.Attribute("id").Value == "1"));
	
// xpath
Console.WriteLine(
	// all rap tracks
	doc.XPathSelectElements("//track[@genre='Rap']") // case-sensitive!
);
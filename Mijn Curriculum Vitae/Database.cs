using System.Xml.Linq;
using System.Text;

namespace Mijn_Curriculum_Vitae
{

    // De classes om de data te lezen en schrijven en in de html te gebruiken
    public class XMLData
    {
		static Random ranDom = new();
        static Random getRandom => ranDom;
        public XMLData(string path)
        {
            AllXMLContent = XElement.Load(path);
            var records = AllXMLContent.Elements().ToList();
			int aantalRecords = records.Count();
			int randIndex = getRandom.Next(0,aantalRecords); 
			Record = records[randIndex];

        }

        // XElement is object dat XML representeert.
		// AllXMLContent gebruiken we om de hele XML file in te lezen
		// Record gebruiken we voor de xml die op een persoon betrekking heeft 
		public XElement AllXMLContent { get; set; }
		public XElement Record { get; set; }
        // We initialiseren we het object van het type Curriculum        
        private Curriculum _curriculum;

        // Deze method zorgt ervoor dat het object curriculum wordt gevuld met data uit de xml als de method vanaf de indexpagina wordt aangeroepen
        public Curriculum GetCurriculum()
        {
            _curriculum = new Curriculum();

            _curriculum.Access = Record.Element("access").Value;
            _curriculum.Voornaam = Record.Element("voornaam").Value;
            _curriculum.Tussenvoegsel = Record.Element("tussenvoegsel").Value;
            _curriculum.Achternaam = Record.Element("achternaam").Value;
            _curriculum.Leeftijd = int.Parse(Record.Element("leeftijd").Value);
            _curriculum.Adres = Record.Element("adres").Value;
            _curriculum.Postcode = Record.Element("postcode").Value;
            _curriculum.Woonplaats = Record.Element("woonplaats").Value;
            _curriculum.Email = Record.Element("email").Value;
            _curriculum.Telefoon = Record.Element("telefoon").Value;
            _curriculum.Foto = Record.Element("foto").Value;

            _curriculum.Meta = Record.Element("meta").Value;

            foreach (var ite in Record.Element("container_werkervaring").Elements())
            {
                Werkervaring werkerv = new Werkervaring();
                werkerv.Werkgever = ite.Element("werkgever").Value;
                werkerv.Functie = ite.Element("functie").Value;
                werkerv.Periode = ite.Element("periode").Value;
                werkerv.Referenties = ite.Element("referenties").Value;
                _curriculum.LijstWerkervaring.Add(werkerv);
            }

            foreach (var ite in Record.Element("container_opleiding").Elements())
            {
                Opleiding opl = new Opleiding();
                opl.NaamOpleiding = ite.Element("naamopleiding").Value;
                opl.Niveau = ite.Element("niveau").Value;
                opl.Diploma = ite.Element("diploma").Value;
                opl.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstOpleiding.Add(opl);
            }

            foreach (var ite in Record.Element("container_vaardigheden").Elements())
            {
                Vaardigheden vaar = new Vaardigheden();
                vaar.Omschrijving = ite.Element("omschrijving").Value;
                vaar.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstVaardigheden.Add(vaar);
            }

            foreach (var ite in Record.Element("container_vrijetijdsbesteding").Elements())
            {
                Vrijetijdsbesteding vrijetijd = new Vrijetijdsbesteding();
                vrijetijd.Activiteit = ite.Element("activiteit").Value;
                _curriculum.LijstVrijetijdsbesteding.Add(vrijetijd);
            }

            foreach (var ite in Record.Element("container_referentie").Elements())
            {
                Referentie referentie = new Referentie();
                referentie.Naam = ite.Element("naam").Value;
				referentie.Functie = ite.Element("functie").Value;
                _curriculum.LijstReferentie.Add(referentie);
            }

            foreach (var ite in Record.Element("container_tool").Elements())
            {
                Tool tool = new Tool();
                tool.ExperienceLevel = ite.Element("experiencelevel").Value;
                _curriculum.LijstTool.Add(tool);
            }

            foreach (var ite in Record.Element("container_training").Elements())
            {
                Training training = new Training();
                training.Name = ite.Element("naam").Value;
                training.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstTraining.Add(training);
            }

            foreach (var ite in Record.Element("container_cursus").Elements())
            {
                Cursus cursus = new Cursus();
                cursus.Name = ite.Element("naam").Value;
                cursus.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstCursus.Add(cursus);
            }

            foreach (var ite in Record.Element("container_certificaat").Elements())
            {
                Certificaat certificaat = new Certificaat();
                certificaat.Name = ite.Element("naam").Value;
                certificaat.Toelichting = ite.Element("toelichting").Value;
                _curriculum.LijstCertificaat.Add(certificaat);
            }
            return _curriculum;
        }

        // hier bewandelen we de omgekeerde weg: we gebruiken het object curriculum om wijzigingen in de data die de user heeft aangebracht
        // weer in de xml file te krijgen zodat ze een volgende keer ook weer ingelezen kunnen worden.
        public void Save(Curriculum C)
        {
            //Curriculum C = ListOFCV.FirstOrDefault(c => c.Access == Accesscode);

            IEnumerable<XElement> LoopW()
            {
                foreach (var item in C.LijstWerkervaring)
                {
                    XElement LW = new XElement("werkervaring",
                        new XElement("id", item.Id),
                        new XElement("werkgever", item.Werkgever),
                        new XElement("functie", item.Functie),
                        new XElement("periode", item.Periode),
                        new XElement("referenties", item.Referenties));
                    yield return LW;
                }
            }

            IEnumerable<XElement> LoopO()
            {
                foreach (var item in C.LijstOpleiding)
                {
                    XElement LO = new XElement("opleiding",
                        new XElement("id", item.Id),
                        new XElement("naamopleiding", item.NaamOpleiding),
                        new XElement("niveau", item.Niveau),
                        new XElement("diploma", item.Diploma),
                        new XElement("toelichting", item.Toelichting));
                    yield return LO;
                }
            }

            IEnumerable<XElement> LoopV()
            {
                foreach (var item in C.LijstVaardigheden)
                {
                    XElement LV = new XElement("vaardigheden",
                        new XElement("id", item.Id),
                        new XElement("omschrijving", item.Omschrijving),
                        new XElement("toelichting", item.Toelichting));

                    yield return LV;
                }
            }

            IEnumerable<XElement> LoopVB()
            {
                foreach (var item in C.LijstVrijetijdsbesteding)
                {
                    XElement LVB = new XElement("vrijetijdsbesteding",
                        new XElement("id", item.Id),
                        new XElement("toelichting", item.Activiteit));
                    yield return LVB;
                }
            }

			IEnumerable<XElement> LoopR()
            {
                foreach (var item in C.LijstReferentie)
                {
                    XElement LR = new XElement("referentie",
                        new XElement("id", item.Id),
                        new XElement("naam", item.Naam),
						new XElement("toelichting", item.Functie));
                    yield return LR;
                }
            }

			IEnumerable<XElement> LoopT()
            {
                foreach (var item in C.LijstTool)
                {
                    XElement LT = new XElement("tool",
                        new XElement("id", item.Id),
						new XElement("experiencelevel", item.ExperienceLevel));
                    yield return LT;
                }
            }

			IEnumerable<XElement> LoopTraining()
            {
                foreach (var item in C.LijstTraining)
                {
                    XElement LTraining = new XElement("training",
                        new XElement("id", item.Id),
						new XElement("name", item.Name),
						new XElement("toelichting", item.Toelichting)
						);
                    yield return LTraining;
                }
            }

			IEnumerable<XElement> LoopCursus()
            {
                foreach (var item in C.LijstCursus)
                {
                    XElement LCursus = new XElement("cursus",
                        new XElement("id", item.Id),
						new XElement("name", item.Name),
						new XElement("toelichting", item.Toelichting)
						);
                    yield return LCursus;
                }
            }

			IEnumerable<XElement> LoopCertificaat()
            {
                foreach (var item in C.LijstCertificaat)
                {
                    XElement LCertificaat = new XElement("certificaat",
                        new XElement("id", item.Id),
						new XElement("name", item.Name),
						new XElement("toelichting", item.Toelichting)
						);
                    yield return LCertificaat;
                }
            }

            XElement Doc = new XElement("cv",
                new XElement("access", C.Access),
                new XElement("voornaam", C.Voornaam),
                new XElement("tussenvoegsel", C.Tussenvoegsel),
                new XElement("achternaam", C.Achternaam),
                new XElement("leeftijd", C.Leeftijd),
                new XElement("adres", C.Adres),
                new XElement("postcode", C.Postcode),
                new XElement("woonplaats", C.Woonplaats),
                new XElement("email", C.Email),
                new XElement("telefoon", C.Telefoon),
                new XElement("foto", C.Foto),
                new XElement("meta", C.Meta),
                new XElement("container_werkervaring",
                    LoopW()),
                new XElement("container_opleiding",
                    LoopO()),
                new XElement("container_vaardigheden",
                    LoopV()),
                new XElement("container_vrijetijdsbesteding",
                    LoopVB()),
				new XElement("container_referentie",
                    LoopR()),
				new XElement("container_tool",
                    LoopT()),
				new XElement("container_cursus",
                    LoopCursus()),
				new XElement("container_certificaat",
                    LoopCertificaat()),
				new XElement("container_training",
                    LoopTraining())
				);

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String path = Directory.GetCurrentDirectory();
            Doc.Save(path + "\\Xml" + "\\XMLFile.xml");
			Doc.Save(@"C:\Users\Admin\source\repos\Mijn Curriculum Vitae\Mijn Curriculum Vitae\Xml\XMLFile.xml");
        }
    }

    // Onze c# gegevensdrager voor de CV data
    public class Curriculum : Object
    {
        public Curriculum()
        {
            LijstWerkervaring = new List<Werkervaring>();
            LijstOpleiding = new List<Opleiding>();
            LijstVaardigheden = new List<Vaardigheden>();
            LijstVrijetijdsbesteding = new List<Vrijetijdsbesteding>();
			LijstReferentie = new List<Referentie>();
			LijstTool = new List<Tool>();
			LijstCertificaat = new List<Certificaat>();
			LijstCursus = new List<Cursus>();
			LijstTraining = new List<Training>();
        }

		public int Id { get; set; }
        public string Access { get; set; }

        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int Leeftijd { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Foto { get; set; }

        public string Meta { get; set; }

        public List<Werkervaring> LijstWerkervaring;
        public List<Opleiding> LijstOpleiding;
        public List<Vaardigheden> LijstVaardigheden;
        public List<Vrijetijdsbesteding> LijstVrijetijdsbesteding;       
		public List<Referentie> LijstReferentie;
		public List<Tool> LijstTool;
		public List<Certificaat> LijstCertificaat; 
		public List<Cursus> LijstCursus;
		public List<Training> LijstTraining;
    }

    // De classes die binnen Curriculum worden gebruikt 
    public class Werkervaring
    {
        public int Id { get; set; } = 0;
        public string Werkgever { get; set; }
        public string Functie { get; set; }
        public string Periode { get; set; }
        public string Referenties { get; set; }
    }

    public class Opleiding
    {
        public int Id { get; set; } = 0;
        public string NaamOpleiding { get; set; }
        public string Niveau { get; set; }
        public string Diploma { get; set; }
        public string Toelichting { get; set; }
    }

    public class Vaardigheden
    {
        public int Id { get; set; } = 0;
        public string Omschrijving { get; set; }
        public string Toelichting { get; set; }
    }

    public class Vrijetijdsbesteding
    {
        public int Id { get; set; } = 0;
        public string Activiteit { get; set; }
    }

    public class Referentie
    {
        public int Id { get; set; } = 0;
        public string Naam { get; set; }
        public string Functie { get; set; }
    }

	public class Tool
	{
        public int Id { get; set; } = 0;
		public string ExperienceLevel { get; set; }
    }

	public class Training
	{
        public int Id { get; set; } = 0;
		public string Name { get; set; }
		public string Toelichting { get; set; }
    }

	public class Cursus
	{
        public int Id { get; set; } = 0;
		public string Name { get; set; }
		public string Toelichting { get; set; }
    }

	public class Certificaat
	{
        public int Id { get; set; } = 0;
		public string Name { get; set; }
		public string Toelichting { get; set; }
    }
 



}







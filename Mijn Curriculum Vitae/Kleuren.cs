using System.Xml.Linq;
using System.Text;
using Mijn_Curriculum_Vitae.Pages.Index.IndexComponents;
using Mijn_Curriculum_Vitae;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Drawing;
using System;

namespace Mijn_Curriculum_Vitae
{
    public class Rand
    {
		static Random ranDom = new();
        public static Random getRandom => ranDom;
    }

    public class Colors 
    {
        public Colors()
        {
            KleurenBoek = new();
        }

        #region MyRegion
        private Dictionary<string, string> kleurenBoek;
        public Dictionary<string, string> KleurenBoek { get => kleurenBoek; set => kleurenBoek = value; }
        public static string button;
        //Dit zijn de kleuren die in de bovenstaande method worden geset en in de css van de indexpagina worden gebruikt.
        public int BaseColor;
        public int ContrastColor;
        public int MinusColor;
        public int PlusColor;
        // deze zorgen ervoor dat de kleurkeuze buttons op de indexpagina de juiste kleur krijgen
        public static string Rood { get => "hsl(0, 100%, 50%);"; } 
        public static string Geel { get => "hsl(60, 100%, 50%);"; }
        public static string Groen { get => "hsl(120, 100%, 50%);"; }
        public static string Cyaan { get => "hsl(180, 100%, 50%);"; }
        public static string Blauw { get => "hsl(240, 100%, 50%);"; }
        public static string Magenta { get => "hsl(300, 100%, 50%);"; } 
        #endregion

// /////////////////////////////////////////////////////////////////////////////////
// /////////////////////////////////////////////////////////////////////////////////

        #region Sleutels voor strings kleurwaarden CSS
        public string Bg_Grid_Container_Background { get; set; } = "Bg_Grid_Container_Background";
        public string Bg_Grid_Container_Div { get; set; } = "Bg_Grid_Container_Div";  //color: hsl(@Colours.basisKleur_Min,77%,65%); 

        public string Bg_Item1_Background { get; set; } = "Bg_Item1_Background"; // hsl(@Colours.basisKleur,50%,13%) !important;}
        public string Bg_Item2_Background { get; set; } = "Bg_Item2_Background";//  hsl(@Colours.basisKleur_Min,  50%,@Rand.getRandom.Next(80,90)%) !important;}
        public string Bg_Item3_Background { get; set; } = "Bg_Item3_Background"; // hsl(@Colours.basisKleur_Min+20,  50%,@Rand.getRandom.Next(48,95)%) !important;}
        public string Bg_Item4_Background { get; set; } = "Bg_Item4_Background"; // hsl(@Colours.basisKleur_Min+15,  40%,@Rand.getRandom.Next(40,95)%) !important;}
        public string Bg_Item5_Background { get; set; } = "Bg_Item5_Background"; // hsl(@Colours.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item6_Background { get; set; } = "Bg_Item6_Background"; // hsl(@Colours.basisKleurSL(50,53,18,28)) !important;}
        public string Bg_Item7_Background { get; set; } = "Bg_Item7_Background"; //  hsl(@Colours.basisKleur_Min,  40%,@Rand.getRandom.Next(80,90)%) !important;
        public string Bg_Item7_Border     { get; set; } = "Bg_Item7_Border"; // :dashed 15px hsl(@Colours.basisKleur,50%,12%);
        public string Bg_Item8_Background { get; set; } = "Bg_Item8_Background"; // hsl(@Colours.basisKleur_Min_20,  40%,@Rand.getRandom.Next(40,90)%) !important;}
        public string Bg_Item9_Background { get; set; } = "Bg_Item9_Background"; // hsl(@Colours.basisKleur_Min+10,  20%,@Rand.getRandom.Next(40,90)%) !important;}
        public string Bg_Item10_Background_Image { get; set; } = "Bg_Item10_Background_Image"; // :linear_gradient(hsl(@Colours.basisKleurSL(30, 80, 70,90)), hsl(@Colours.basisKleurSL(30, 80, 10, 20)));
        public string Bg_Item11_Background { get; set; } = "Bg_Item11_Background"; // hsl(@Colours.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item12_Background { get; set; } = "Bg_Item12_Background"; // hsl(@Colours.basisKleur_Plus, 60%,@Rand.getRandom.Next(50,65)%) !important;}
        public string Bg_Item12_Border     { get; set; } = "Bg_Item12_Border"; // :dashed 15px hsl(@Colours.basisKleur,50%,12%);
        public string Bg_Item13_Background { get; set; } = "Bg_Item13_Background"; // hsl(@Colours.basisKleur_Min,  70%,@Rand.getRandom.Next(80,95)%) !important;}
        public string Bg_Item14_Background { get; set; } = "Bg_Item14_Background"; // hsl(@Colours.basisKleur_Min,  60%,@Rand.getRandom.Next(20,30)%) !important;}
        public string Bg_Item15_Background { get; set; } = "Bg_Item15_Background"; // hsl(@Colours.basisKleur_Min, 60%,@Rand.getRandom.Next(40,90)%) !important;}

        public string Btn_Primary_Background { get; set; } = "Btn_Primary_Background";  // hsl(@Colours.basisKleurSL(98,101,48,52));} 
        public string Btn_Primary_Hover_Background { get; set; } = "Btn_Primary_Hover_Background"; //  hsl(@(Colours.basisKleur + 20), 100%, 50%);}

        public string DataDrager_Dating_Background { get; set; } = "DataDrager_Dating_Background"; //hsl(@Colours.basisKleurSL(20, 60, 20, 80));}
        public string DataDrager_B_Background      { get; set; } = "DataDrager_B_Background";  //hsl(@Colours.basisKleurSL(20, 60, 20, 80));}
        public string Divcolorbuttons_Background   { get; set; } = "Divcolorbuttons_Background"; //hsl(@Colours.basisKleurSL(20,70,20,80));} 

        public string Fieldset_Background { get; set; } = "Fieldset_Background";//hsl(@Colours.basisKleurSL(45, 60, 40, 42));
        public string Fieldset_Even_Background { get; set; } = "Fieldset_Even_Background";

        public string HouseofcolorsBEE_Background     { get; set; } = "HouseofcolorsBEE_Background"; //hsl(@Colours.basisKleur,100%,50%);}
        public string HouseofcolorsHoC_Background     { get; set; } = "HouseofcolorsHoC_Background"; //hsl(@Colours.basisKleurTegenover,100%,50%);}
        public string HouseofcolorsHusk_Background    { get; set; } = "HouseofcolorsHusk_Background"; //hsl(@Colours.basisKleur_Plus,100%,50%);}
        public string HouseofcolorsHeerlen_Background { get; set; } = "HouseofcolorsHeerlen_Background"; //hsl(@Colours.basisKleur_Min,100%,50%);}

        public string InputBackground { get; set; } = "InputBackground";
        public string Legend_Span_Background { get; set; } = "Legend_Span_Background"; //hsl(@Colours.basisKleurSL(50, 60, 20, 30));
        public string Nuance1_Background { get; set; } = "Nuance1_Background";//hsl(@Colours.basisKleurSL(49,80,15,25));

        public string Nuance2_Background { get; set; } = "Nuance2_Background";//hsl(@Colours.basisKleurSL(40,80,30,40));
        public string Nuance3_Background { get; set; } = "Nuance3_Background";  // hsl(@Colours.basisKleurSL(40,80,45,55));
        public string Nuance4_Background { get; set; } = "Nuance4_Background";//hsl(@Colours.basisKleurSL(40,80,60,70));
        public string Nuance5_Background { get; set; } = "Nuance5_Background";//hsl(@Colours.basisKleurSL(40,80,75,85));
        public string Nuance6_Background { get; set; } = "Nuance6_Background";//hsl(@Colours.basisKleurSL(40,80,88,95));
        public string Pictureframe_Background_Image { get; set; } = "Pictureframe_Background_Image"; // linear_gradient(to left top, hsl(@Colours.basisKleurSL(30, 80, 70, 90)), hsl(@Colours.basisKleurSL(60, 80, 35,60)));
		#endregion

        public void VulKleurenboek()
        {
            KleurenBoek.Add(Bg_Grid_Container_Background,   $"hsl({BaseColor},      50%, 12%) !important");
            KleurenBoek.Add(Bg_Grid_Container_Div,          $"hsl({MinusColor},        77%, 65%) !important");
            KleurenBoek.Add(Bg_Item1_Background,            $"hsl({BaseColor},      50%, 13%) !important");
            KleurenBoek.Add(Bg_Item2_Background,            $"hsl({MinusColor},        50%, {Rand.getRandom.Next(30, 90)}%) !important");
            KleurenBoek.Add(Bg_Item3_Background,            $"hsl({(MinusColor + 20)}, 50%, {Rand.getRandom.Next(38, 95)}%) !important");
            KleurenBoek.Add(Bg_Item4_Background,            $"hsl({(MinusColor + 15)}, 50%, {Rand.getRandom.Next(48, 95)}%) !important");
            KleurenBoek.Add(Bg_Item5_Background,            $"hsl({MinusColor},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item6_Background,            $"hsl({BaseColor},      50%, 22%) !important");
            KleurenBoek.Add(Bg_Item7_Background,            $"hsl({MinusColor},        40%, 85%) !important");
            KleurenBoek.Add(Bg_Item7_Border,                $"dashed 15px hsl({BaseColor},50%, 12%) !important");
            KleurenBoek.Add(Bg_Item8_Background,            $"hsl({(MinusColor - 20)}, 40%, {Rand.getRandom.Next(40, 90)}%) !important");
            KleurenBoek.Add(Bg_Item9_Background,            $"hsl({(MinusColor + 10)}, 20%, {Rand.getRandom.Next(40, 90)}%) !important");
            KleurenBoek.Add(Bg_Item10_Background_Image,     $"linear-gradient(hsl({BaseColor},48%, 80%), hsl({BaseColor},50%, 15%))");
            KleurenBoek.Add(Bg_Item11_Background,           $"hsl({MinusColor},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item12_Background,           $"hsl({PlusColor},       60%, {Rand.getRandom.Next(50, 65)}%) !important");
            KleurenBoek.Add(Bg_Item12_Border,               $"dashed 15px hsl({BaseColor},50%, 12%) !important");
            KleurenBoek.Add(Bg_Item13_Background,           $"hsl({MinusColor},        70%, {Rand.getRandom.Next(20, 95)}%) !important");
            KleurenBoek.Add(Bg_Item14_Background,           $"hsl({MinusColor},        60%, {Rand.getRandom.Next(20, 30)}%) !important");
            KleurenBoek.Add(Bg_Item15_Background,           $"hsl({MinusColor},        60%, {Rand.getRandom.Next(40, 90)}%) !important");

            KleurenBoek.Add(Btn_Primary_Background,         $"hsl({BaseColor},            98%, 48%)");
            KleurenBoek.Add(Btn_Primary_Hover_Background,   $"hsl({(BaseColor + 20)},     100%,50%)");

            KleurenBoek.Add(DataDrager_Dating_Background,   $"hsl({BaseColor},      40%, 60%) !important");
            KleurenBoek.Add(DataDrager_B_Background,        $"hsl({BaseColor},      35%, 55%) !important");
            KleurenBoek.Add(Divcolorbuttons_Background,     $"hsl({BaseColor},      40%, 70%) !important");

            KleurenBoek.Add(Fieldset_Background,            $"hsl({BaseColor},      {Rand.getRandom.Next(35, 50)}%, {Rand.getRandom.Next(15, 50)}%) !important");
            KleurenBoek.Add(Fieldset_Even_Background,       $"hsl({PlusColor},      50%, {Rand.getRandom.Next(40, 70)}%) !important");

            KleurenBoek.Add(HouseofcolorsBEE_Background,    $"hsl({BaseColor},      100%,50%)");
            KleurenBoek.Add(HouseofcolorsHoC_Background,    $"hsl({ContrastColor},   100%,50%)");
            KleurenBoek.Add(HouseofcolorsHusk_Background,   $"hsl({PlusColor},       100%,50%)");
            KleurenBoek.Add(HouseofcolorsHeerlen_Background,$"hsl({MinusColor},        100%,50%)"); 

            KleurenBoek.Add(InputBackground,                $"hsl({BaseColor},      90%,90%) !important");
            KleurenBoek.Add(Legend_Span_Background,         $"hsl({BaseColor},      55%, 45%) !important");

            KleurenBoek.Add(Nuance1_Background,             $"hsl({ContrastColor},      50%, 20%) !important");
            KleurenBoek.Add(Nuance2_Background,             $"hsl({ContrastColor},      50%, 35%) !important");
            KleurenBoek.Add(Nuance3_Background,             $"hsl({ContrastColor},      50%, 50%) !important");
            KleurenBoek.Add(Nuance4_Background,             $"hsl({ContrastColor},      50%, 65%) !important");
            KleurenBoek.Add(Nuance5_Background,             $"hsl({ContrastColor},      50%, 80%) !important");
            KleurenBoek.Add(Nuance6_Background,             $"hsl({ContrastColor},      50%, 95%) !important");

            KleurenBoek.Add(Pictureframe_Background_Image,  $"linear-gradient(to left top, hsl({BaseColor}, 50%, 80%), hsl({BaseColor}, {Rand.getRandom.Next(40, 90)}%, 45%))");  
        }




// /////////////////////////////////////////////////////////////////////////////////
// /////////////////////////////////////////////////////////////////////////////////
		// Eigenlijk zou dit een void moeten zijn maar die kan (voorzover onze kennis reikt) niet vanaf een andere component worden aangeroepen
		// de return value van deze method wordt niet gebruikt. De method zet de values van de vier kleuren die gebruikt worden 
		// voor de kleurcombinatie.
        public  int SetValues(string buttn, int minmax)
        {
            KleurenBoek.Clear();
            int RandomColor = 0;
            if (buttn == "Rood")
            { 
                int xx = Rand.getRandom.Next(330, 360);
                int xxx = Rand.getRandom.Next(0, 30);
                int xxxx = Rand.getRandom.Next(1, 3);

                if (xxxx % 2 == 0) // de operator % laat de (eventuele) rest zien van een deling. Ideaal icm een randwaarde.                                   
                    RandomColor = xx; // if en else kun je ook zonder {} schrijven als ze maar 1 statement bevatten
                else
                    RandomColor = xxx;
            }

            if (buttn == "Geel")
                { RandomColor = Rand.getRandom.Next(30, 90);} // 30 en 90 zijn de grenzen tussen rood/geel en geel/groen. dit is het gebied
                                                    // waaruit de random de basiskleur trekt

            if (buttn == "Groen")
                { RandomColor = Rand.getRandom.Next(90, 150);}

            if (buttn == "Cyaan")
                { RandomColor = Rand.getRandom.Next(150, 210 );}

            if (buttn == "Blauw")
                { RandomColor = Rand.getRandom.Next(210, 270);}

            if (buttn == "Magenta")
                { RandomColor = Rand.getRandom.Next(270, 330);}

            #region MyRegion
            BaseColor = RandomColor;

            if (RandomColor + 180 >= 360)
                { ContrastColor = RandomColor + 180 - 360; }
            else
                {ContrastColor = RandomColor + 180;}

            if (BaseColor % 2 == 0)
            {
                if (RandomColor + minmax >= 360)
                    { PlusColor = RandomColor + minmax - 360; }
                else
                    {PlusColor = RandomColor + minmax;}

                if (RandomColor - minmax < 0)
                    {MinusColor = RandomColor + 360 - minmax;}
                else
                    {MinusColor = RandomColor - minmax;}
            }
            else
            {
                if (RandomColor + minmax >= 360)
                    { MinusColor = RandomColor + minmax - 360; }
                else
                    {MinusColor = RandomColor + minmax;}

                if (RandomColor - minmax < 0)
                    {PlusColor = RandomColor + 360 - minmax;}
                else
                    {PlusColor = RandomColor - minmax;}
            }
            #endregion

            VulKleurenboek();
            return 0;   
        } 

		

        // Deze methods worden in de css gebruikt om de css string te creeren. Dit is een onderdeel dat niet af is en er
        // zouden er nog een paar bij moeten zodat we ook de andere kleuren uit het pakket kant en klaar in stringvorm op de 
        // indexagina kunnen gebruiken
        public string basisKleurSL(int smin, int smx, int lmin, int lmax)
        {
            string sat = Rand.getRandom.Next(smin, smx).ToString(); 

            int helderheid = Rand.getRandom.Next(lmin, lmax);
            string light = helderheid.ToString();

            string bk = BaseColor.ToString() + ", " + sat.ToString() + "%, " + light.ToString() + "%"; 

            return bk;
        }

        public string basisKleurTegenoverSL(int smin, int smx, int lmin, int lmax)
        {
            string bk = "";
            string sat = Rand.getRandom.Next(smin, smx).ToString(); 
            string light = Rand.getRandom.Next(lmin, lmax).ToString();

            bk = "hsl(" + BaseColor.ToString() + ", " + sat.ToString() + "%, " + light.ToString() + "%);"; 

            return bk;
        }


    }
    

 
    

// we wilden graag een keer met een interface werken maar het was weer eens helemaal niet nodig. Toch gaan we hem nodig maken zodat we 
// leren ermee te werken.



}







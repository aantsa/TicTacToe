using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text.RegularExpressions;


namespace Projekti_OH2
{
    public partial class frmTicTacToe : Form
    {

        public int turn = 0;     //Jokaisen painalluksen jälkeen vuorot lisääntyy, mikäli vuoroja 9 eikä voittaajaa, ohjelma ilmoittaa "Ei voittajaa".
        public int vuoro = 0;   //Vuoro pitää kirjaa onko 0 (Ensimmäisen pelaajan vuoro) vai 1 (toisen pelaajan/tietokoneen vuoro).

        /////////////////////////////////////////////////////////////////////////////////////
        ///Nämä panelNumeroClicked pitää kirjaa siitä mitä paneleja on clickattu.
        ///Esimerkiksi jos ensimmäinen pelaaja piirtää ensimmäiseen paneliin
        ///tulee arvoiksi panelOneClickedX = 2 && panelOneClickedO = 1.
        ///Jos paneelin arvo on 0, niin se on tyhjä, jos se on 1
        ///niin joku toinen on piirtänyt siihen ja jos se on 2 niin olet itse piirtänyt siihen.
        ////////////////////////////////////////////////////////////////////////////////////////
        public int panelOneClickedX = 0;
        public int panelOneClickedO = 0;
        public int panelTwoClickedX = 0;
        public int panelTwoClickedO = 0;
        public int panelThreeClickedX = 0;
        public int panelThreeClickedO = 0;
        public int panelFourClickedX = 0;
        public int panelFourClickedO = 0;
        public int panelFiveClickedO = 0;
        public int panelFiveClickedX = 0;
        public int panelSixClickedO = 0;
        public int panelSixClickedX = 0;
        public int panelSevenClickedO = 0;
        public int panelSevenClickedX = 0;
        public int panelEightClickedO = 0;
        public int panelEightClickedX = 0;
        public int panelNineClickedO = 0;
        public int panelNineClickedX = 0;

        //////////////////////////////////////////////////////////////////////////////
        /// Boolean operaatiot jotka pitävät textboxien oikeinkirjoituksesta kirjaa.
        /////////////////////////////////////////////////////////////////////////////
        public Boolean etunimiOK = false;
        public Boolean sukunimiOK = false;
        public Boolean syntymaVuosiOK = false;
        public Boolean etunimi2OK = false;
        public Boolean sukunimi2OK = false;
        public Boolean syntymaVuosi2OK = false;

        public int voitot = 0;
        public int tappiot = 0;
        public int tasapelit = 0;
        public int pelattujenPelienYhteiskesto = 0;

        public Boolean voittoX = false; //Tarkistaa voiton, mikäli true niin pelaaja 1 voitti.
        public Boolean voittoO = false; //Tarkistaa voiton, mikäli ture, niin pelaaja 2/tietokone voitti.

        public int ajastin = 0; // Tätä muuttujaa tarvitaan "Vastustaja miettii..." labeliin.


        public frmTicTacToe()
        {
            InitializeComponent();
            dgvHenkilot.DataSource = listaHenkiloTiedot;
        }
        public void NollaaPaneelit()
        {
            /////////////////////////////////////////////////////////
            ///Tämä funktio nollaa paneelit seuraavaa peliä varten
            ////////////////////////////////////////////////////////
            vuoro = 0;
            panelOneClickedX = 0;
            panelOneClickedO = 0;
            panelTwoClickedX = 0;
            panelTwoClickedO = 0;
            panelThreeClickedX = 0;
            panelThreeClickedO = 0;
            panelFourClickedX = 0;
            panelFourClickedO = 0;
            panelFiveClickedO = 0;
            panelFiveClickedX = 0;
            panelSixClickedO = 0;
            panelSixClickedX = 0;
            panelSevenClickedO = 0;
            panelSevenClickedX = 0;
            panelEightClickedO = 0;
            panelEightClickedX = 0;
            panelNineClickedO = 0;
            panelNineClickedX = 0;
            lblVuoro.Visible = false;
            panelOne.Enabled = true;
            panelTwo.Enabled = true;
            panelThree.Enabled = true;
            panelFouri.Enabled = true;
            panelFive.Enabled = true;
            panelSix.Enabled = true;
            panelSeven.Enabled = true;
            panelEight.Enabled = true;
            panelNine.Enabled = true;
        }

        public void SerializeJSON(List<HenkiloTiedot> input)
        {
            string Json = JsonConvert.SerializeObject(input);
            File.WriteAllText("c:/temp/filu.json", Json);
        }
       
        public List<HenkiloTiedot> DeserializeJSON()
        {

                 if (listaHenkiloTiedot == null)
                 {
                     listaHenkiloTiedot = new List<HenkiloTiedot>();
                 }
            if (File.Exists("c:/temp/filu.json"))
            {
                using (StreamReader sr = new StreamReader("c:/temp/filu.json"))
                {
                    string json = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<HenkiloTiedot>>(json);
                }
            }
            else
            {
                return null;
            }
        }
        public List<HenkiloTiedot> listaHenkiloTiedot = new List<HenkiloTiedot>();
        private void FrmTicTacToe_Load(object sender, EventArgs e)
        {
            panelCanvas.Visible = false;
            panelOne.Visible = false;
            panelTwo.Visible = false;
            panelThree.Visible = false;
            panelFour.Visible = false;
            panelFive.Visible = false;
            panelSix.Visible = false;
            panelSeven.Visible = false;
            panelEight.Visible = false;
            panelNine.Visible = false;

            ///////////////////////////////////////////////////
            ///Mikäli ohjelma käynnistetään ensimmäistä kertaa,
            ///luodaan tietokoneelle profiili.
            ///////////////////////////////////////////////////
            if (!File.Exists("c:/temp/filu.json"))
            {
                HenkiloTiedot h1 = new HenkiloTiedot();
                h1.etunimi = "Voittamaton";
                h1.sukunimi = "Tietokone";
                h1.syntymavuosi = "9999";
                h1.voitot = voitot;
                h1.tappiot = tappiot;
                h1.tasapelit = tasapelit;
                h1.pelattujenPelienYhteiskesto = pelattujenPelienYhteiskesto;

                listaHenkiloTiedot.Add(h1);
                SerializeJSON(listaHenkiloTiedot);
                listaHenkiloTiedot.Remove(h1);
            }
            listaHenkiloTiedot = DeserializeJSON();

            dgvHenkilot.DataSource = listaHenkiloTiedot;
            dgvHenkilot.Refresh();
        }
        public class HenkiloTiedot
        {
            public string etunimi;
            public string sukunimi;
            public string syntymavuosi;
            public int voitot;
            public int tappiot;
            public int tasapelit;
            public int pelattujenPelienYhteiskesto;

            public string Etunimi { get { return etunimi; } }
            public string Sukunimi { get { return sukunimi; } }
            public string Syntymavuosi { get { return syntymavuosi; } }
            public int Voitot { get { return voitot; } }
            public int Tappiot { get { return tappiot; } }
            public int Tasapelit { get { return tasapelit; } }
            public int YhteisKesto { get { return pelattujenPelienYhteiskesto; } }

        }

        ///////////////////////////
        /// Pelikentän piirtäminen
        //////////////////////////

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = panelCanvas.CreateGraphics();
            Pen pen = new Pen(Color.Black, 4);
            Point fromTop1 = new Point(panelCanvas.Width / 3, 0);
            Point toDown1 = new Point(panelCanvas.Width / 3, panelCanvas.Height);

            Point fromTop2 = new Point((panelCanvas.Width / 3) + (panelCanvas.Width / 3), 0);
            Point toDown2 = new Point((panelCanvas.Width / 3) + (panelCanvas.Width / 3), panelCanvas.Height);

            Point fromLeft1 = new Point(0, panelCanvas.Height / 3);
            Point toRight1 = new Point(panelCanvas.Width, panelCanvas.Height / 3);

            Point fromLeft2 = new Point(0, (panelCanvas.Height / 3) + (panelCanvas.Height / 3));
            Point toRight2 = new Point(panelCanvas.Width, (panelCanvas.Height / 3) + (panelCanvas.Height / 3));

            e.Graphics.DrawLine(pen, fromTop1, toDown1);
            e.Graphics.DrawLine(pen, fromTop2, toDown2);
            e.Graphics.DrawLine(pen, fromLeft1, toRight1);
            e.Graphics.DrawLine(pen, fromLeft2, toRight2);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chTietokone.Checked == true)
            {
                chKaksinTaistelu.Enabled = false;
                tbEtunimi2.Enabled = false;
                tbSukunimi2.Enabled = false;
                tbSyntymaVuosi2.Enabled = false;
                tbEtunimi2.Text = "Voittamaton";
                tbSukunimi2.Text = "Tietokone";
                tbSyntymaVuosi2.Text = "9999";
            }
            if (chTietokone.Checked == false)
            {
                chKaksinTaistelu.Enabled = true;
                tbEtunimi2.Enabled = true;
                tbSukunimi2.Enabled = true;
                tbSyntymaVuosi2.Enabled = true;
                tbEtunimi2.Text = "";
                tbSukunimi2.Text = "";
                tbSyntymaVuosi2.Text = "";
            }
        }

        private void TbEtunimi_Validated(object sender, EventArgs e)
        {
            epEtunimi.SetError(tbEtunimi, "");
            etunimiOK = true;
        }

        private void TbEtunimi_Validating(object sender, CancelEventArgs e)
        {
            if (tbEtunimi.Text == "")
            {
                e.Cancel = false;
            }
            else if (!Regex.IsMatch(tbEtunimi.Text, @"^[a-öA-Ö]+$"))
            {
                e.Cancel = true;
                tbEtunimi.Select(0, tbEtunimi.Text.Length);
                epEtunimi.SetError(tbEtunimi, "Virheellinen etunimi, käytä vain kirjaimia");
            }
        }

        private void TbSyntymaVuosi_Validated(object sender, EventArgs e)
        {
            epSyntymavuosi.SetError(tbSyntymaVuosi, "");
            syntymaVuosiOK = true;
        }

        private void TbSyntymaVuosi_Validating(object sender, CancelEventArgs e)
        {
            int parse;
            string errorMsg = "Virheellinen syntymävuosi";

            if (tbSyntymaVuosi.Text == "")
            {
                e.Cancel = false;
            }

            else if (!int.TryParse(tbSyntymaVuosi.Text, out parse))
            {
                e.Cancel = true;
                tbSyntymaVuosi.Select(0, tbSyntymaVuosi.Text.Length);
                this.epSyntymavuosi.SetError(tbSyntymaVuosi, errorMsg);
            }
            else if (tbSyntymaVuosi.Text.Length < 4 || tbSyntymaVuosi.Text.Length > 4)
            {
                e.Cancel = true;
                tbSyntymaVuosi.Select(0, tbSyntymaVuosi.Text.Length);
                this.epSyntymavuosi.SetError(tbSyntymaVuosi, errorMsg);
            }
        }

        private void TbSukunimi_Validated(object sender, EventArgs e)
        {
            epSukunimi.SetError(tbSukunimi, "");
            sukunimiOK = true;
        }

        private void TbSukunimi_Validating(object sender, CancelEventArgs e)
        {
            if (tbSukunimi.Text == "")
            {
                e.Cancel = false;
            }
            else if (!Regex.IsMatch(tbSukunimi.Text, @"^[a-öA-Ö]+$"))
            {
                e.Cancel = true;
                tbSukunimi.Select(0, tbSukunimi.Text.Length);
                epSukunimi.SetError(tbSukunimi, "Virheellinen sukunimi, käytä vain kirjaimia");
            }
        }

        private void ChKaksinTaistelu_CheckedChanged(object sender, EventArgs e)
        {
            if (chKaksinTaistelu.Checked == true)
            {
                chTietokone.Enabled = false;
            }
            if (chKaksinTaistelu.Checked == false)
            {
                chTietokone.Enabled = true;
            }
        }

        private void FrmTicTacToe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /////////////////////////////////////////////////////
        /// Funktio joka piirtää Pelaaja 1:selle X.
        ////////////////////////////////////////////////////
        public void drawX(Panel panelParametriX)
        {
            Graphics dc = panelParametriX.CreateGraphics();
            Point fromLeft = new Point(25, 20);
            Point toRight = new Point(122, 122);
            Point fromRight = new Point(122, 20);
            Point toLeft = new Point(25, 122);
            Pen myX = new Pen(Color.Blue, 3);
            dc.DrawLine(myX, fromLeft, toRight);
            dc.DrawLine(myX, fromRight, toLeft);
            lblVuoro.Location = new Point(406, 80);
            vuoro = 1;
        }

        /////////////////////////////////////////////////////
        /// Funktio joka piirtää Pelaaja 2/tietokoneelle O.
        ////////////////////////////////////////////////////

        public void drawO(Panel panelParemetriO)
        {
            if (chTietokone.Checked == true)
            {
                TimerTietokone.Stop();
            }
            Graphics dc = panelParemetriO.CreateGraphics();
            Pen myCircle = new Pen(Color.Red, 3);
            Rectangle rect = new Rectangle(25, 20, 100, 100);
            dc.DrawEllipse(myCircle, rect);
            lblVuoro.Location = new Point(97, 80);
            vuoro = 0;
        }

        public void TarkistaVoittaja()
        {
            //Tarkistaa voittiko pelaaja 1
            if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelThreeClickedX == 2 && panelSixClickedX == 2 && panelNineClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }
            if (panelThreeClickedX == 2 && panelFiveClickedX == 2 && panelSevenClickedX == 2 && voittoO == false)
            {
                OnnittelutPelaaja1();
                lopetaMiettiminen();
            }

            //Tarkistaa voittiko pelaaja 2
            if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2 && voittoX == false)
            {
                OnnittelutPelaaja2();
            }
            //Mikäli kumpikaan ei voita, kutsutaan "eiVoittajaa" funktiota.
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                eiVoittajaa();
                lopetaMiettiminen();
            }
        }

        ///////////////////////////////////////////////////////////
        /// Funktio, jota kutsutaan tilanteessa kun tulee tasapeli.
        ///////////////////////////////////////////////////////////
        public void eiVoittajaa()
        {
            lblEiVoittajaa.Visible = true;
            lblVuoro.Visible = false;

            HenkiloTiedot tasapeli = null;
            foreach (HenkiloTiedot hen in listaHenkiloTiedot)
            {

                if (hen.etunimi == tbEtunimi.Text && hen.sukunimi == tbSukunimi.Text)
                {
                    tasapeli = hen;
                }
            }
            tasapeli.tasapelit++;

            HenkiloTiedot tasa = null;

            foreach (HenkiloTiedot henk in listaHenkiloTiedot)
            {
                if (henk.etunimi == tbEtunimi2.Text && henk.sukunimi == tbSukunimi2.Text)
                {
                    tasa = henk;
                }
            }
            timerKesto.Stop();
            tasa.tasapelit++;
            tasapeli.pelattujenPelienYhteiskesto += timerTick;
            tasa.pelattujenPelienYhteiskesto += timerTick;
            SerializeJSON(listaHenkiloTiedot);
        }

        ////////////////////////////////////////////
        /// Funktio tietokoneen miettimistä varten.
        ////////////////////////////////////////////
        public void lopetaMiettiminen()
        {
            lblTietokoneMiettii.Visible = false;
            timerMiettii.Stop();
            ajastin = 0;
        }

        ///////////////////////////////////////////////////
        /// Funktio, jota kutsutaan kun pelaaja 1 voittaa.
        ///////////////////////////////////////////////////
        public void OnnittelutPelaaja1()
        {
            if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 2)
            {
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 2)
            {
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 2)
            {
                ;
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
            }
            else if (panelThreeClickedX == 2 && panelSixClickedX == 2 && panelNineClickedX == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
            }

            else if (panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 2)
            {
                panelOne.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelThreeClickedX == 2 && panelFiveClickedX == 2 && panelSevenClickedX == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;

            }
            timerKesto.Stop();
            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            lblOnneksiOlkoon.Visible = true;
            lblOnneksiOlkoon.Location = new Point(35, 122);
            lblVuoro.Visible = false;
            voittoX = true;

            HenkiloTiedot h1 = new HenkiloTiedot();
            h1.etunimi = tbEtunimi.Text;
            h1.sukunimi = tbSukunimi.Text;
            h1.syntymavuosi = tbSyntymaVuosi.Text;
            h1.voitot = voitot;
            h1.tappiot = tappiot;
            h1.tasapelit = tasapelit;
            h1.pelattujenPelienYhteiskesto = pelattujenPelienYhteiskesto;

            HenkiloTiedot h2 = new HenkiloTiedot();
            h2.etunimi = tbEtunimi.Text;
            h2.sukunimi = tbSukunimi.Text;
            h2.syntymavuosi = tbSyntymaVuosi.Text;
            h2.voitot = voitot;
            h2.tappiot = tappiot;
            h2.tasapelit = tasapelit;
            h2.pelattujenPelienYhteiskesto = pelattujenPelienYhteiskesto;

            HenkiloTiedot voittaja = null;
            foreach (HenkiloTiedot hen in listaHenkiloTiedot)
            {

                if (hen.etunimi == tbEtunimi.Text && hen.sukunimi == tbSukunimi.Text)
                {
                    voittaja = hen;
                }
            }
            voittaja.voitot++;

            HenkiloTiedot haviaja = null;

            foreach (HenkiloTiedot henk in listaHenkiloTiedot)
            {
                if (henk.etunimi == tbEtunimi2.Text && henk.sukunimi == tbSukunimi2.Text)
                {
                    haviaja = henk;
                }
            }
            haviaja.tappiot++;
            voittaja.pelattujenPelienYhteiskesto += timerTick;
            haviaja.pelattujenPelienYhteiskesto += timerTick;
            SerializeJSON(listaHenkiloTiedot);
        }
        ///////////////////////////////////////////////////
        /// Funktio, jota kutsutaan kun pelaaja 2 voittaa.
        ///////////////////////////////////////////////////
        public void OnnittelutPelaaja2()
        {
            if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
            {
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
            {
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
            }
            else if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
            {
                panelOne.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
            {
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
            }
            else if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
                panelNine.Enabled = false;
            }
            else if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
            {
                panelOne.Enabled = false;
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelFive.Enabled = false;
                panelSix.Enabled = false;
            }
            timerKesto.Stop();
            lblOnneksiOlkoon.Location = new Point(350, 122);
            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            lblOnneksiOlkoon.Visible = true;
            lblVuoro.Visible = false;
            voittoO = true;

            HenkiloTiedot voittaja = null;
            foreach (HenkiloTiedot hen in listaHenkiloTiedot)
            {

                if (hen.etunimi == tbEtunimi.Text && hen.sukunimi == tbSukunimi.Text)
                {
                    voittaja = hen;
                }
            }
            voittaja.voitot++;

            HenkiloTiedot haviaja = null;

            foreach (HenkiloTiedot henk in listaHenkiloTiedot)
            {
                if (henk.etunimi == tbEtunimi2.Text && henk.sukunimi == tbSukunimi2.Text)
                {
                    haviaja = henk;
                }
            }
            haviaja.tappiot++;
            voittaja.pelattujenPelienYhteiskesto += timerTick;
            haviaja.pelattujenPelienYhteiskesto += timerTick;
            SerializeJSON(listaHenkiloTiedot);

        }
        ///////////////////////////////////////////////////
        /// Funktio, jota kutsutaan kun tietokone voittaa.
        ///////////////////////////////////////////////////
        public void tietokoneVoitti()
        {
            {
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    panelFouri.Enabled = false;
                    panelFive.Enabled = false;
                    panelSix.Enabled = false;
                    panelSeven.Enabled = false;
                    panelEight.Enabled = false;
                    panelNine.Enabled = false;
                }
                else if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    panelTwo.Enabled = false;
                    panelThree.Enabled = false;
                    panelFouri.Enabled = false;
                    panelSix.Enabled = false;
                    panelSeven.Enabled = false;
                    panelEight.Enabled = false;
                }
                else if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    panelOne.Enabled = false;
                    panelThree.Enabled = false;
                    panelFouri.Enabled = false;
                    panelSix.Enabled = false;
                    panelSeven.Enabled = false;
                    panelNine.Enabled = false;
                }
                else if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    panelTwo.Enabled = false;
                    panelThree.Enabled = false;
                    panelFive.Enabled = false;
                    panelSix.Enabled = false;
                    panelEight.Enabled = false;
                    panelNine.Enabled = false;
                }
                else if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
                {
                    panelOne.Enabled = false;
                    panelTwo.Enabled = false;
                    panelFouri.Enabled = false;
                    panelFive.Enabled = false;
                    panelSeven.Enabled = false;
                    panelEight.Enabled = false;
                }
                else if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
                {
                    panelOne.Enabled = false;
                    panelTwo.Enabled = false;
                    panelFouri.Enabled = false;
                    panelSix.Enabled = false;
                    panelEight.Enabled = false;
                    panelNine.Enabled = false;
                }
                else if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    panelOne.Enabled = false;
                    panelTwo.Enabled = false;
                    panelThree.Enabled = false;
                    panelSeven.Enabled = false;
                    panelEight.Enabled = false;
                    panelNine.Enabled = false;
                }
                else if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    panelOne.Enabled = false;
                    panelTwo.Enabled = false;
                    panelThree.Enabled = false;
                    panelFouri.Enabled = false;
                    panelFive.Enabled = false;
                    panelSix.Enabled = false;
                }
                timerKesto.Stop();
                lblTietokoneVoitti.Visible = true;
                lblVuoro.Visible = false;
                vuoro = 1;
                voittoO = true;

                HenkiloTiedot voittaja = null;
                foreach (HenkiloTiedot hen in listaHenkiloTiedot)
                {

                    if (hen.etunimi == tbEtunimi2.Text && hen.sukunimi == tbSukunimi2.Text)
                    {
                        voittaja = hen;
                    }
                }
                voittaja.voitot++;

                HenkiloTiedot haviaja = null;

                foreach (HenkiloTiedot henk in listaHenkiloTiedot)
                {
                    if (henk.etunimi == tbEtunimi.Text && henk.sukunimi == tbSukunimi.Text)
                    {
                        haviaja = henk;
                    }
                }
                haviaja.tappiot++;
                voittaja.pelattujenPelienYhteiskesto += timerTick;
                haviaja.pelattujenPelienYhteiskesto += timerTick;
                SerializeJSON(listaHenkiloTiedot);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////// 
        /// Kun tätä panelia klikataan, niin tarkastetaan onko paneelia jo klikattu
        /// sekä myös tarkastetaan, että voittaako pelaaja, tuleeko tasapeli vai
        /// jatkuuko peli vielä. Mikäli Pelaaja 1 painaa paneelia niin panel(paneelinnumero)ClickedX
        /// arvoksi tulee 2 ja panel(paneelinnumero)ClickedO arvoksi 1. Ne ovat alussa molemmat 0.
        ////////////////////////////////////////////////////////////////////////////////////////////

        private void PanelOne_Click(object sender, EventArgs e)
        {
            // Kaksinpeli
            if (vuoro == 0 && panelOneClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelOne);
                panelOneClickedO = 1;
                panelOneClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelOneClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelOne);
                panelOneClickedO = 2;
                panelOneClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            //Pelaajan valinnan jälkeen timeri lähtee käyntiin ja tietokone alkaa miettiä.
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelOne);
                panelOneClickedO = 1;
                panelOneClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                } 
            }
        }
        private void PanelTwo_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelTwoClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelTwo);
                panelTwoClickedO = 1;
                panelTwoClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelTwoClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelTwo);
                panelTwoClickedO = 2;
                panelTwoClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelTwoClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelTwo);
                panelTwoClickedO = 1;
                panelTwoClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }
        private void PanelThree_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelThreeClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelThree);
                panelThreeClickedO = 1;
                panelThreeClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelThreeClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelThree);
                panelThreeClickedO = 2;
                panelThreeClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelThreeClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelThree);
                panelThreeClickedO = 1;
                panelThreeClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }
        
        private void PanelFivee_Click(object sender, EventArgs e) //Paneli oli alussa nimetty väärin, tämä on siis NELJÄS (4) paneli.
        {

            if (vuoro == 0 && panelFourClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelFouri);
                panelFourClickedO = 1;
                panelFourClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelFourClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelFouri);
                panelFourClickedO = 2;
                panelFourClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelFourClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelFouri);
                panelFourClickedO = 1;
                panelFourClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }

        private void PanelFive_Click(object sender, EventArgs e)
        {

            if (vuoro == 0 && panelFiveClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelFive);
                panelFiveClickedO = 1;
                panelFiveClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelFiveClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelFive);
                panelFiveClickedO = 2;
                panelFiveClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelFiveClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelFive);
                panelFiveClickedO = 1;
                panelFiveClickedX = 2;
                turn++;
                TarkistaVoittaja();

            if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
            {
                lblTietokoneMiettii.Visible = true;
                timerMiettii.Start();
                TimerTietokone.Start();
            }
        }
    }

        private void PanelSix_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelSixClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelSix);
                panelSixClickedO = 1;
                panelSixClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelSixClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelSix);
                panelSixClickedO = 2;
                panelSixClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelSixClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelSix);
                panelSixClickedO = 1;
                panelSixClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }
        private void PanelSeven_Click(object sender, EventArgs e)
        {

            if (vuoro == 0 && panelSevenClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelSeven);
                panelSevenClickedO = 1;
                panelSevenClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelSevenClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelSeven);
                panelSevenClickedO = 2;
                panelSevenClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelSevenClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelSeven);
                panelSevenClickedO = 1;
                panelSevenClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }
        private void PanelEight_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelEightClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelEight);
                panelEightClickedO = 1;
                panelEightClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelEightClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelEight);
                panelEightClickedO = 2;
                panelEightClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelEightClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelEight);
                panelEightClickedO = 1;
                panelEightClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }
        private void PanelNine_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelNineClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelNine);
                panelNineClickedO = 1;
                panelNineClickedX = 2;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 1 && panelNineClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelNine);
                panelNineClickedO = 2;
                panelNineClickedX = 1;
                turn++;
                TarkistaVoittaja();
            }
            else if (vuoro == 0 && panelNineClickedX == 0 && chTietokone.Checked == true)
            {

                drawX(panelNine);
                panelNineClickedO = 1;
                panelNineClickedX = 2;
                turn++;
                TarkistaVoittaja();

                if (voittoX == false && turn != 9 && chTietokone.Checked == true && voittoO == false)
                {
                    lblTietokoneMiettii.Visible = true;
                    timerMiettii.Start();
                    TimerTietokone.Start();
                }
            }
        }

        //////////////////////////////////////////////////////////
        /// Nappia painamalla formin elementit häviävät näkyvistä
        /// ja pelinäkymä tulee esille.
        //////////////////////////////////////////////////////////

        private void BtnAloita_Click(object sender, EventArgs e)
        {
            if (tbEtunimi.Text == "" || tbEtunimi2.Text == "" || tbSukunimi.Text == "" || tbSukunimi2.Text == "" || tbSyntymaVuosi.Text == "" || tbSyntymaVuosi2.Text == "")
            {
                MessageBox.Show("Syötä pelaajien tiedot", "Virhe");
            }
            else if (chTietokone.Checked == true || chKaksinTaistelu.Checked == true)
            {
                dgvHenkilot.Visible = false;
                panelCanvas.Visible = true;
                panelOne.Visible = true;
                panelTwo.Visible = true;
                panelThree.Visible = true;
                panelFouri.Visible = true;
                panelFive.Visible = true;
                panelSix.Visible = true;
                panelSeven.Visible = true;
                panelEight.Visible = true;
                panelNine.Visible = true;

                lblAloita.Visible = false;
                lblEtunimi.Visible = false;
                lblSukunimi.Visible = false;
                lblSyntymaVuosi.Visible = false;
                lblValitse.Visible = false;
                lblPelaaja1.Visible = false;
                lblPelaaja2.Visible = false;
                lblPelaaja1Vuoro.Visible = true;
                lblPelaaja2Vuoro.Visible = true;
                lblVuoro.Visible = true;
                chTietokone.Visible = false;
                chKaksinTaistelu.Visible = false;
                btnAloita.Visible = false;
                tbEtunimi.Visible = false;
                tbEtunimi2.Visible = false;
                tbSukunimi.Visible = false;
                tbSukunimi2.Visible = false;
                tbSyntymaVuosi.Visible = false;
                tbSyntymaVuosi2.Visible = false;
                btnSyotaTiedot.Visible = false;
                timerKesto.Start();
            }
            else
            {
                MessageBox.Show("Valitse pelimuoto", "Virhe");
            }
        } 

        /////////////////////////////////////////////////////////////////////////////
        /// Painamalla Tiedosto > Uusi peli, formi latautuu uudestaan ja mahdollistaa
        /// pelaajan pelaamaan uudestaan sulkematta formia.
        /////////////////////////////////////////////////////////////////////////////

        private void StripUusiPeli_Click(object sender, EventArgs e)
        {
            this.Refresh();
            tbSyntymaVuosi.Text = "";
            tbSyntymaVuosi2.Text = "";
            tbEtunimi.Text = "";
            tbEtunimi2.Text = "";
            tbSukunimi.Text = "";
            tbSukunimi2.Text = "";
            panelCanvas.Visible = false;
            lblAloita.Visible = true;
            lblEtunimi.Visible = true;
            lblSukunimi.Visible = true;
            lblSyntymaVuosi.Visible = true;
            lblValitse.Visible = true;
            lblPelaaja1.Visible = true;
            lblPelaaja2.Visible = true;
            lblPelaaja1Vuoro.Visible = false;
            lblPelaaja2Vuoro.Visible = false;
            lblVuoro.Visible = false;
            vuoro = 0;
            lblEiVoittajaa.Visible = false;
            chTietokone.Visible = true;
            chKaksinTaistelu.Visible = true;
            chTietokone.Checked = false;
            chKaksinTaistelu.Checked = false;
            btnAloita.Visible = true;
            tbEtunimi.Visible = true;
            tbEtunimi2.Visible = true;
            tbSukunimi.Visible = true;
            tbSukunimi2.Visible = true;
            tbSyntymaVuosi.Visible = true;
            tbSyntymaVuosi2.Visible = true;
            lblOnneksiOlkoon.Visible = false;
            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            dgvHenkilot.Visible = true;
            btnSyotaTiedot.Visible = true;
            turn = 0;
            lblVuoro.Location = new Point(97, 80);
            voittoO = false;
            voittoX = false;
            lblTietokoneVoitti.Visible = false;
            etunimiOK = false;
            sukunimiOK = false;
            syntymaVuosiOK = false;
            timerTick = 0;

            etunimi2OK = false;
            sukunimi2OK = false;
            syntymaVuosi2OK = false;

        NollaaPaneelit();
        }

        private void StripSulje_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StripTietoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tämän ristinollan on luonut Anton Fagerholm Kuopiossa.\n" +
                "Peli on tehty ohjelmointi 2 kurssin lopputyönä. Peliä saa jakaa ja sen koodia saa käyttää vapaasti.\n" +
                "Mikäli piditte pelistä, niin peli löytyy myös GitHubistani https://github.com/aantsa", "Tietoa");
        }

        private void OhjeetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tervetuloa pelaamaan ristinollaa! Alhaalla ohjeet pelin pelaamiseen: \n\n" +
                "1: Syötä pelaajan/pelaajien tiedot tai valitse alhaalta olemassa oleva profiili ja valitse pelimuoto (kaksinpeli/tietokone).\n" +
                "2: Paina aloita (mikäli olet jo aikaisemmin pelannut peliä niin uudet tuloksesi tallennetaan olemassa olevien sekaan.\n" +
                "3: Pelaaja kumpi saa 3 pystyyn, vaakaan tai kulmasta kulmaan voittaa.\n" +
                "4: Uuden pelin saa painamalla Tiedosto > Uusi peli", "Ohje");
        }

        private void TbEtunimi2_Validated(object sender, EventArgs e)
        {
            epEtunimi2.SetError(tbEtunimi2, "");
            etunimi2OK = true;
        }

        private void TbEtunimi2_Validating(object sender, CancelEventArgs e)
        {
            if (tbEtunimi2.Text == "")
            {
                e.Cancel = false;
            }
            else if (!Regex.IsMatch(tbEtunimi2.Text, @"^[a-öA-Ö]+$"))
            {
                e.Cancel = true;
                tbEtunimi2.Select(0, tbEtunimi2.Text.Length);
                epEtunimi2.SetError(tbEtunimi2, "Virheellinen etunimi, käytä vain kirjaimia.");
            }
        }

        private void TbSukunimi2_Validated(object sender, EventArgs e)
        {
            epSukunimi2.SetError(tbSukunimi2, "");
            sukunimi2OK = true;
        }

        private void TbSukunimi2_Validating(object sender, CancelEventArgs e)
        {
            if (tbSukunimi2.Text == "")
            {
                e.Cancel = false;
            }
            else if (!Regex.IsMatch(tbSukunimi2.Text, @"^[a-öA-Ö]+$"))
            {
                e.Cancel = true;
                tbSukunimi2.Select(0, tbSukunimi2.Text.Length);
                epSukunimi2.SetError(tbSukunimi2, "Virheellinen sukunimi, käytä vain kirjaimia.");
            }
        }

        private void TbSyntymaVuosi2_Validated(object sender, EventArgs e)
        {
            epSyntymaVuosi2.SetError(tbSyntymaVuosi2, "");
            syntymaVuosi2OK = true;
        }

        private void TbSyntymaVuosi2_Validating(object sender, CancelEventArgs e)
        {
            int parse;
            string errorMsg = "Virheellinen syntymävuosi, käytä vain numeroita.";

            if (tbSyntymaVuosi2.Text == "")
            {
                e.Cancel = false;
            }
            else if (!int.TryParse(tbSyntymaVuosi2.Text, out parse) && tbSyntymaVuosi2.Text.Length != 4)
            {
                e.Cancel = true;
                tbSyntymaVuosi2.Select(0, tbSyntymaVuosi2.Text.Length);
                this.epSyntymaVuosi2.SetError(tbSyntymaVuosi2, errorMsg);
            }
            else if (tbSyntymaVuosi2.Text.Length < 4 || tbSyntymaVuosi2.Text.Length > 4)
            {
                e.Cancel = true;
                tbSyntymaVuosi2.Select(0, tbSyntymaVuosi2.Text.Length);
                this.epSyntymaVuosi2.SetError(tbSyntymaVuosi2, errorMsg);
            }
        }

        private void TimerTietokone_Tick(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////
            /// Ensiksi tietokone käy ne vaihtoehdot läpi,
            /// että voiko se seuraavalla siirrolla itse voittaa.
            //////////////////////////////////////////////////////

            if (panelTwoClickedO == 2 && panelThreeClickedO == 2 && panelOneClickedO == 0 || panelFourClickedO == 2 && panelSevenClickedO == 2 && panelOneClickedO == 0 || panelFiveClickedO == 2 && panelNineClickedO == 2 && panelOneClickedO == 0)
            {
                drawO(panelOne);
                panelOneClickedX = 1;
                panelOneClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if(panelOneClickedO == 2 && panelThreeClickedO == 2 && panelTwoClickedO == 0 || panelFiveClickedO == 2 && panelEightClickedO == 2 && panelTwoClickedO == 0)
            {
                drawO(panelTwo);
                panelTwoClickedX = 1;
                panelTwoClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if(panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 0 || panelSixClickedO == 2 && panelNineClickedO == 2 && panelThreeClickedO == 0 || panelFiveClickedO == 2 && panelSevenClickedO == 2 && panelThreeClickedO == 0)
            {
                drawO(panelThree);
                panelThreeClickedX = 1;
                panelThreeClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelFiveClickedO == 2 && panelThreeClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelNineClickedO == 2 && panelSixClickedO == 2 && panelThreeClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFiveClickedO == 2 && panelSixClickedO == 2 && panelFourClickedO == 0 || panelOneClickedO == 2 && panelSevenClickedO == 2 && panelFourClickedO == 0)
            {
                drawO(panelFouri);
                panelFourClickedX = 1;
                panelFourClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            } else if (panelFourClickedO == 2 && panelSixClickedO == 2 && panelFiveClickedO == 0 || panelTwoClickedO == 2 && panelEightClickedO == 2 && panelFiveClickedO == 0 || panelOneClickedO == 2 && panelNineClickedO == 2 && panelFiveClickedO == 0 || panelThreeClickedO == 2 && panelSevenClickedO == 2 && panelFiveClickedO == 0)
            {
                drawO(panelFive);
                panelFiveClickedX = 1;
                panelFiveClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 0 || panelThreeClickedO == 2 && panelNineClickedO == 2 && panelSixClickedO == 0)
            {
                drawO(panelSix);
                panelSixClickedX = 1;
                panelSixClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelEightClickedO == 2 && panelNineClickedO == 2 && panelSevenClickedO == 0 || panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 0 || panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 0)
            {
                drawO(panelSeven);
                panelSevenClickedX = 1;
                panelSevenClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelSevenClickedO == 2 && panelNineClickedO == 2 && panelEightClickedO == 0 || panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 0)
            {
                drawO(panelEight);
                panelEightClickedX = 1;
                panelEightClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 0 || panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 0 || panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 0)
            {
                drawO(panelNine);
                panelNineClickedX = 1;
                panelNineClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    tietokoneVoitti();
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            ///////////////////////////////////////////////////////////////
            ///Seuraavaksi tietokone tarkistaa,
            ///että voiko vastustaja voittaa ja sijoittaa sen perusteella.
            ///////////////////////////////////////////////////////////////

            else if (panelTwoClickedX == 2 && panelThreeClickedX == 2 && panelOneClickedX == 0 || panelFourClickedX == 2 && panelSevenClickedX == 2 && panelOneClickedX == 2 || panelFiveClickedX == 2 && panelNineClickedX == 2 && panelOneClickedX == 2)
            {
                drawO(panelOne);
                panelOneClickedX = 1;
                panelOneClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelOneClickedX == 2 && panelThreeClickedX == 2 && panelTwoClickedX == 0 || panelFiveClickedX == 2 && panelEightClickedX == 2 && panelTwoClickedX == 0)
            {
                drawO(panelTwo);
                panelTwoClickedX = 1;
                panelTwoClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 0 || panelSixClickedX == 2 && panelNineClickedX == 2 && panelThreeClickedX == 0 || panelFiveClickedX == 2 && panelSevenClickedX == 2 && panelThreeClickedX == 0)
            {
                drawO(panelThree);
                panelThreeClickedX = 1;
                panelThreeClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelFiveClickedO == 2 && panelThreeClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelNineClickedO == 2 && panelSixClickedO == 2 && panelThreeClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFiveClickedX == 2 && panelSixClickedX == 2 && panelFourClickedX == 0 || panelOneClickedX == 2 && panelSevenClickedX == 2 && panelFourClickedX == 0)
            {
                drawO(panelFouri);
                panelFourClickedX = 1;
                panelFourClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFourClickedX == 2 && panelSixClickedX == 2 && panelFiveClickedX == 0 || panelTwoClickedX == 2 && panelEightClickedX == 2 && panelFiveClickedX == 0 || panelOneClickedX == 2 && panelNineClickedX == 2 && panelFiveClickedX == 0 || panelThreeClickedX == 2 && panelSevenClickedX == 2 && panelFiveClickedX == 0)
            {
                drawO(panelFive);
                panelFiveClickedX = 1;
                panelFiveClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 0 || panelThreeClickedX == 2 && panelNineClickedX == 2 && panelSixClickedX == 0)
            {
                drawO(panelSix);
                panelSixClickedX = 1;
                panelSixClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
                {
                   lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelEightClickedX == 2 && panelNineClickedX == 2 && panelSevenClickedX == 0 || panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 0 || panelThreeClickedX == 2 && panelFiveClickedX == 2 && panelSevenClickedX == 0)
            {
                drawO(panelSeven);
                panelSevenClickedX = 1;
                panelSevenClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelSevenClickedX == 2 && panelNineClickedX == 2 && panelEightClickedX == 0 || panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 0)
            {
                drawO(panelEight);
                panelEightClickedX = 1;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
                panelEightClickedO = 2;
            }
            else if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 0 || panelThreeClickedX == 2 && panelSixClickedX == 2 && panelNineClickedX == 0 || panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 0)
            {
                drawO(panelNine);
                panelNineClickedX = 1;
                panelNineClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
                {
                    lopetaMiettiminen();
                }
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            ///////////////////////////////////////////////////
            ///Mikäli kummallakaan ei ole yhden päässä voittoa,
            ///tietokone sijoittaa sattuman varaisesti O:n.
            //////////////////////////////////////////////////
            else if(panelOneClickedO == 0 && voittoX == false)
            {
                drawO(panelOne);
                panelOneClickedX = 1;
                panelOneClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelTwoClickedO == 0 && voittoX == false)
            {
                drawO(panelTwo);
                panelTwoClickedX = 1;
                panelTwoClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelThreeClickedO == 0 && voittoX == false)
            {
                drawO(panelThree);
                panelThreeClickedX = 1;
                panelThreeClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFourClickedO == 0 && voittoX == false)
            {
                drawO(panelFouri);
                panelFourClickedX = 1;
                panelFourClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelFiveClickedO == 0 && voittoX == false)
            {
                drawO(panelFive);
                panelFiveClickedX = 1;
                panelFiveClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelSixClickedO == 0 && voittoX == false)
            {
                drawO(panelSix);
                panelSixClickedX = 1;
                panelSixClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelSevenClickedO == 0 && voittoX == false)
            {
                drawO(panelSeven);
                panelSevenClickedX = 1;
                panelSevenClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelEightClickedO == 0 && voittoX == false)
            {
                drawO(panelEight);
                panelEightClickedX = 1;
                panelEightClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            }
            else if (panelNineClickedO == 0 && voittoX == false)
            {
                drawO(panelNine);
                panelNineClickedX = 1;
                panelNineClickedO = 2;
                lblTietokoneMiettii.Visible = false;
                timerMiettii.Stop();
                ajastin = 0;
                turn++;
                if (turn == 9 && lblOnneksiOlkoon.Visible == false)
                {
                    eiVoittajaa();
                    lopetaMiettiminen();
                }
            } 
        }

        private void BtnSyotaTiedot_Click(object sender, EventArgs e)
        {
            Boolean ekaNimiLoytyi = false;
            Boolean tokaNimiLoytyi = false;
            HenkiloTiedot h1 = new HenkiloTiedot();
            h1.etunimi = tbEtunimi.Text;
            h1.sukunimi = tbSukunimi.Text;
            h1.syntymavuosi = tbSyntymaVuosi.Text;
            h1.voitot = voitot;
            h1.tappiot = tappiot;
            h1.tasapelit = tasapelit;
            h1.pelattujenPelienYhteiskesto = pelattujenPelienYhteiskesto;

            HenkiloTiedot h2 = new HenkiloTiedot();
            h2.etunimi = tbEtunimi2.Text;
            h2.sukunimi = tbSukunimi2.Text;
            h2.syntymavuosi = tbSyntymaVuosi2.Text;
            h2.voitot = voitot;
            h2.tappiot = tappiot;
            h2.tasapelit = tasapelit;
            h2.pelattujenPelienYhteiskesto = pelattujenPelienYhteiskesto;

            foreach (HenkiloTiedot hen in listaHenkiloTiedot)
            {
                if (hen.etunimi == tbEtunimi.Text && hen.sukunimi == tbSukunimi.Text)
                {
                    MessageBox.Show("Pelaaja 1 löytyy jo tiedoista.");
                    ekaNimiLoytyi = true;
                    break;
                }
            }
            foreach (HenkiloTiedot hen in listaHenkiloTiedot)
            {
                if (hen.etunimi == tbEtunimi2.Text && hen.sukunimi == tbSukunimi2.Text)
                {
                    MessageBox.Show("Pelaaja 2 löytyy jo tiedoista.");
                    tokaNimiLoytyi = true;
                    break;
                }
            }

            if (chKaksinTaistelu.Checked == true && tokaNimiLoytyi == false && ekaNimiLoytyi == false && etunimiOK == true && sukunimiOK == true && syntymaVuosiOK == true && etunimi2OK == true && sukunimi2OK == true && syntymaVuosi2OK == true)
            {
                listaHenkiloTiedot.Add(h1);
                listaHenkiloTiedot.Add(h2);

                dgvHenkilot.DataSource = null;
                dgvHenkilot.DataSource = listaHenkiloTiedot;

                SerializeJSON(listaHenkiloTiedot);

            }
            else if (chTietokone.Checked == true && ekaNimiLoytyi == false && etunimiOK == true && sukunimiOK == true && syntymaVuosiOK == true)
            {
                listaHenkiloTiedot.Add(h1);

                dgvHenkilot.DataSource = null;
                dgvHenkilot.DataSource = listaHenkiloTiedot;

                SerializeJSON(listaHenkiloTiedot);

            }
            else if (chKaksinTaistelu.Checked == true && tokaNimiLoytyi == false && etunimi2OK == true && sukunimi2OK == true && syntymaVuosi2OK == true)
            {
                listaHenkiloTiedot.Add(h2);

                dgvHenkilot.DataSource = null;
                dgvHenkilot.DataSource = listaHenkiloTiedot;

                SerializeJSON(listaHenkiloTiedot);
            }

            else if (chKaksinTaistelu.Checked == false && chTietokone.Checked == false)
            {
                MessageBox.Show("Valitse vastustaja", "Virhe");
            }
        }
        private void TimerMiettii_Tick(object sender, EventArgs e)
        {
            switch (ajastin % 4)
            {
                case 0:
                    lblTietokoneMiettii.Text = "Vastustaja miettii";
                    break;
                case 1:
                    lblTietokoneMiettii.Text = "Vastustaja miettii.";
                    break;
                case 2:
                    lblTietokoneMiettii.Text = "Vastustaja miettii..";
                    break;
                case 3:
                    lblTietokoneMiettii.Text = "Vastustaja miettii...";
                    break;
            }
            ajastin++;
        }

        public int valittuRivi;
        public int riviaJoKlikattu = 0;

        private void DgvHenkilot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            valittuRivi = e.RowIndex;
            dgvHenkilot.Rows[1].Frozen = true;
            if (valittuRivi >= 0)
            {
                DataGridViewRow rivi = dgvHenkilot.Rows[valittuRivi];

                if (riviaJoKlikattu == 0 && chTietokone.Checked == false)
                {
                    tbEtunimi.Text = rivi.Cells[0].Value.ToString();
                    tbSukunimi.Text = rivi.Cells[1].Value.ToString();
                    tbSyntymaVuosi.Text = rivi.Cells[2].Value.ToString();
                    riviaJoKlikattu = 1;
                    lblPelaaja2.Font = new Font("Candara", 10.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    lblPelaaja1.Font = new Font("Candara", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }

                else if (riviaJoKlikattu == 1 && chTietokone.Checked == false)
                {
                    tbEtunimi2.Text = rivi.Cells[0].Value.ToString();
                    tbSukunimi2.Text = rivi.Cells[1].Value.ToString();
                    tbSyntymaVuosi2.Text = rivi.Cells[2].Value.ToString();
                    riviaJoKlikattu = 0;
                    lblPelaaja1.Font = new Font("Candara", 10.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    lblPelaaja2.Font = new Font("Candara", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
                else if (chTietokone.Checked == true)
                {
                    tbEtunimi.Text = rivi.Cells[0].Value.ToString();
                    tbSukunimi.Text = rivi.Cells[1].Value.ToString();
                    tbSyntymaVuosi.Text = rivi.Cells[2].Value.ToString();
                    riviaJoKlikattu = 1;
                }
            }
        }
        public int timerTick = 0;
        private void TimerKesto_Tick(object sender, EventArgs e)
        {
            timerTick += 1;
        }
    }
}
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
        private Graphics g;
        public int turn = 0;
        public int vuoro = 0;
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
        public int piste = 0;


        public frmTicTacToe()
        {
            InitializeComponent();
            dgvHenkilot.DataSource = listaHenkiloTiedot;


        }
        public void nollaaPaneelit()
        {
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

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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

        }

        private void DrawEllipse(object sender, PaintEventArgs e)
        {
        }
        public List<HenkiloTiedot> listaHenkiloTiedot = new List<HenkiloTiedot>();
        public struct HenkiloTiedot
        {
            public string etunimi;
            public string sukunimi;
            public string syntymavuosi;
            public int pisteet;
            public string Etunimi { get { return etunimi; } }
            public string Sukunimi { get { return sukunimi; } }
            public string Syntymavuosi { get { return syntymavuosi; } }
            public int Pisteet { get { return pisteet; } }
        }
        
        public string Tiedot = "c:\\temp\\kysymykset.txt";

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
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

        private void Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblAloita_Click(object sender, EventArgs e)
        {
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chTietokone.Checked == true)
            {
                chKaksinTaistelu.Enabled = false;
                tbEtunimi2.Enabled = false;
                tbSukunimi2.Enabled = false;
                tbSyntymaVuosi2.Enabled = false;

            }
            if (chTietokone.Checked == false)
            {
                chKaksinTaistelu.Enabled = true;
                tbEtunimi2.Enabled = true;
                tbSukunimi2.Enabled = true;
                tbSyntymaVuosi2.Enabled = true;
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbEtunimi_Validated(object sender, EventArgs e)
        {
            epEtunimi.SetError(tbEtunimi, "");
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
            
        }

        private void Error(object sender, EventArgs e)
        {

        }

        private void TbSukunimi_Validated(object sender, EventArgs e)
        {
            epSukunimi.SetError(tbSukunimi, "");
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
        private void PanelOne_Click(object sender, EventArgs e)
        {

            // Kaksinpeli
            if (vuoro == 0 && panelOneClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelOne);
                panelOneClickedO = 1;
                panelOneClickedX = 2;
            }
            else if (vuoro == 1 && panelOneClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelOne);
                panelOneClickedO = 2;
                panelOneClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                TimerTietokone.Start();
                drawX(panelOne);
            } 


            if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelTwo_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelTwoClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelTwo);
                panelTwoClickedO = 1;
                panelTwoClickedX = 2;
            }
            else if (vuoro == 1 && panelTwoClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelTwo);
                panelTwoClickedO = 2;
                panelTwoClickedX = 1;
            }
               else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
               {
                   drawX(panelTwo);
                   TimerTietokone.Start();

               }


            if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 2)
            {
                OnnittelutPelaaja1();
            }          
            if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelThree_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelThreeClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelThree);
                panelThreeClickedO = 1;
                panelThreeClickedX = 2;
            }
            else if (vuoro == 1 && panelThreeClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelThree);
                panelThreeClickedO = 2;
                panelThreeClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelThree);
                TimerTietokone.Start();

            }

            if (panelOneClickedX == 2 && panelTwoClickedX == 2 && panelThreeClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelSevenClickedX == 2 && panelFiveClickedX == 2 && panelThreeClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelNineClickedX == 2 && panelSixClickedX == 2 && panelThreeClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedO == 2 && panelTwoClickedO == 2 && panelThreeClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelSevenClickedO == 2 && panelFiveClickedO == 2 && panelThreeClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelNineClickedO == 2 && panelSixClickedO == 2 && panelThreeClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }
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
                panelTwo.Enabled = false;
                panelThree.Enabled = false;
                panelFouri.Enabled = false;
                panelSix.Enabled = false;
                panelSeven.Enabled = false;
                panelEight.Enabled = false;
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

            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            lblOnneksiOlkoon.Visible = true;
            lblOnneksiOlkoon.Location = new Point(35, 122);
            lblVuoro.Visible = false;
            piste++;

        }
        public void OnnittelutPelaaja2()
        {
            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            lblOnneksiOlkoon.Visible = true;
            lblOnneksiOlkoon.Location = new Point(350, 122);
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
            lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            lblOnneksiOlkoon.Visible = true;
            lblOnneksiOlkoon.Location = new Point(35, 122);
            lblVuoro.Visible = false;
            piste++;


        }
        private void PanelFivee_Click(object sender, EventArgs e)
        {

            if (vuoro == 0 && panelFourClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelFouri);
                panelFourClickedO = 1;
                panelFourClickedX = 2;
            }
            else if (vuoro == 1 && panelFourClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelFouri);
                panelFourClickedO = 2;
                panelFourClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelFouri);
                TimerTietokone.Start();
            }


            if (panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelFive_Click(object sender, EventArgs e)
        {

            if (vuoro == 0 && panelFiveClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelFive);
                panelFiveClickedO = 1;
                panelFiveClickedX = 2;
            }
            else if (vuoro == 1 && panelFiveClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelFive);
                panelFiveClickedO = 2;
                panelFiveClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelFive);
                TimerTietokone.Start();

            }


            if (panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelThreeClickedX == 2 && panelFiveClickedX == 2 && panelSevenClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelSix_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelSixClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelSix);
                panelSixClickedO = 1;
                panelSixClickedX = 2;
            }
            else if (vuoro == 1 && panelSixClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelSix);
                panelSixClickedO = 2;
                panelSixClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelSix);
                TimerTietokone.Start();
            }


            if (panelThreeClickedX == 2 && panelSixClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelFourClickedX == 2 && panelFiveClickedX == 2 && panelSixClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelFourClickedO == 2 && panelFiveClickedO == 2 && panelSixClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelSeven_Click(object sender, EventArgs e)
        {

            if (vuoro == 0 && panelSevenClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelSeven);
                panelSevenClickedO = 1;
                panelSevenClickedX = 2;
            }
            else if (vuoro == 1 && panelSevenClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelSeven);
                panelSevenClickedO = 2;
                panelSevenClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelSeven);
                TimerTietokone.Start();
            }

            if (panelThreeClickedX == 2 && panelFiveClickedX == 2 && panelSevenClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedX == 2 && panelFourClickedX == 2 && panelSevenClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelThreeClickedO == 2 && panelFiveClickedO == 2 && panelSevenClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFourClickedO == 2 && panelSevenClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelEight_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelEightClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelEight);
                panelEightClickedO = 1;
                panelEightClickedX = 2;
            }
            else if (vuoro == 1 && panelEightClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelEight);
                panelEightClickedO = 2;
                panelEightClickedX = 1;
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelEight);
                TimerTietokone.Start();
            }

            if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelTwoClickedX == 2 && panelFiveClickedX == 2 && panelEightClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelTwoClickedO == 2 && panelFiveClickedO == 2 && panelEightClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void PanelNine_Click(object sender, EventArgs e)
        {
            if (vuoro == 0 && panelNineClickedX == 0 && chKaksinTaistelu.Checked == true)
            {
                drawX(panelNine);
                panelNineClickedO = 1;
                panelNineClickedX = 2;
            }
            else if (vuoro == 1 && panelNineClickedO == 0 && chKaksinTaistelu.Checked == true)
            {
                drawO(panelNine);
                panelNineClickedO = 2;
                panelNineClickedX = 1; 
            }
            else if (vuoro == 0 && panelOneClickedX == 0 && chTietokone.Checked == true)
            {
                drawX(panelNine);
                TimerTietokone.Start();

            }

            if (panelThreeClickedX == 2 && panelSixClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelOneClickedX == 2 && panelFiveClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelSevenClickedX == 2 && panelEightClickedX == 2 && panelNineClickedX == 2)
            {
                OnnittelutPelaaja1();
            }
            if (panelThreeClickedO == 2 && panelSixClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelOneClickedO == 2 && panelFiveClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            if (panelSevenClickedO == 2 && panelEightClickedO == 2 && panelNineClickedO == 2)
            {
                OnnittelutPelaaja2();
            }
            turn++;
            if (turn == 9 && lblOnneksiOlkoon.Visible == false)
            {
                lblEiVoittajaa.Visible = true;
                lblVuoro.Visible = false;
            }
        }

        private void BtnAloita_Click(object sender, EventArgs e)
        {
            dgvHenkilot.Visible = false;
            panelCanvas.Visible = true;
            panelOne.Visible = true;
            panelTwo.Visible = true;
            panelThree.Visible = true;
            panelFour.Visible = true;
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

        }
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
            lblEiVoittajaa.Visible =  false;
            chTietokone.Visible = true;
            chKaksinTaistelu.Visible = true;
            btnAloita.Visible = true;
            tbEtunimi.Visible = true;
            tbEtunimi2.Visible = true;
            tbSukunimi.Visible = true;
            tbSukunimi2.Visible = true;
            tbSyntymaVuosi.Visible = true;
            tbSyntymaVuosi2.Visible = true;
            lblOnneksiOlkoon.Visible = false;
            dgvHenkilot.Visible = true;
            btnSyotaTiedot.Visible = true;
            turn = 0;
            lblVuoro.Location = new Point(97, 80);

            nollaaPaneelit();
        }

        private void StripSulje_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StripTietoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tämän ristinollan on luonut Anton Fagerholm Kuopiossa." +
                " Peli on tehty ohjelmointi 2 kurssin lopputyöksi. Peliä saa jakaa ja sen koodia saa kopioida vapaasti omiin projekteihin.", "Tietoa");
        }

        private void OhjeetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tervetuloa pelaamaan ristinollaa! Alhaalla ohjeet pelin pelaamisesta: \n\n" +
                "1: Syötä pelaajan/pelaajien tiedot ja valitse pelimuoto (kaksinpeli/tietokone).\n" +
                "2: Paina aloita (mikäli olet aikaisemmin pelannut peliä niin uudet tuloksesi tallennetaan olemassa olevien sekaan).", "Ohje");
        }

        private void TbEtunimi2_Validated(object sender, EventArgs e)
        {
            epEtunimi2.SetError(tbEtunimi2, "");
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
        }

        private void TbSyntymaVuosi2_Validating(object sender, CancelEventArgs e)
        {
            int parse;
            string errorMsg = "Virheellinen syntymävuosi, käytä vain numeroita.";
            if (tbSyntymaVuosi2.Text == "")
            {
                e.Cancel = false;
            }
            else if (!int.TryParse(tbSyntymaVuosi2.Text, out parse))
            {
                e.Cancel = true;
                tbSyntymaVuosi2.Select(0, tbSyntymaVuosi2.Text.Length);
                this.epSyntymaVuosi2.SetError(tbSyntymaVuosi2, errorMsg);
            }
        }

        private void TimerTietokone_Tick(object sender, EventArgs e)
        {

        /*    if (panelOneClickedX == 2 && panelTwoClickedX == 0 && panelThreeClickedX == 0 && panelFourClickedX == 0 && panelFiveClickedX == 0 && panelSixClickedX == 0 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelFive);
            }
            else if (panelOneClickedX == 0 && panelTwoClickedX == 2 && panelThreeClickedX == 0 && panelFourClickedX == 0 && panelFiveClickedX == 0 && panelSixClickedX == 0 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelFive);
            }
            else if (panelOneClickedX == 0 && panelTwoClickedX == 0 && panelThreeClickedX == 2 && panelFourClickedX == 0 && panelFiveClickedX == 0 && panelSixClickedX == 0 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelFive);
            }
            else if (panelOneClickedX == 0 && panelTwoClickedX == 0 && panelThreeClickedX == 0 && panelFourClickedX == 2 && panelFiveClickedX == 0 && panelSixClickedX == 0 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelFive);
            }
            else if (panelOneClickedX == 0 && panelTwoClickedX == 0 && panelThreeClickedX == 0 && panelFourClickedX == 0 && panelFiveClickedX == 2 && panelSixClickedX == 0 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelOne);

            }
            else if (panelOneClickedX == 0 && panelTwoClickedX == 0 && panelThreeClickedX == 0 && panelFourClickedX == 0 && panelFiveClickedX == 0 && panelSixClickedX == 2 && panelSevenClickedX == 0 && panelEightClickedX == 0 && panelNineClickedX == 0)
            {
                drawO(panelFive);
            }*/
            
            Random satun = new Random();
            int luku;

            while (true) {
                Boolean löytyi = false;
                luku = satun.Next(0, 10);
                switch (luku)
                {
                    case 1:
                        if (panelOneClickedX == 2)
                        {
                            löytyi = true;
                        }
                        else
                        {
                            drawO(panelOne);
                        }
                
                break;
                case 2:
                    drawO(panelTwo);
                break;
                case 3:
                    drawO(panelThree);
                break;
                case 4:
                    drawO(panelFouri);
                break;
                case 5:
                    drawO(panelFive);
                break;
                case 6:
                    drawO(panelSix);
                break;
                case 7:
                    drawO(panelSeven);
                break;
                case 8:
                    drawO(panelEight);
                break;
                case 9:
                    drawO(panelNine);
                break;
            }if (!löytyi)
                {
                    break;
                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSyotaTiedot_Click(object sender, EventArgs e)
        {
            HenkiloTiedot h1;
            h1.etunimi = tbEtunimi.Text;
            h1.sukunimi = tbSukunimi.Text;
            h1.syntymavuosi = tbSyntymaVuosi.Text;
            h1.pisteet = piste;

            HenkiloTiedot h2;
            h2.etunimi = tbEtunimi2.Text;
            h2.sukunimi = tbSukunimi2.Text;
            h2.syntymavuosi = tbSukunimi2.Text;
            h2.pisteet = piste;

            listaHenkiloTiedot.Add(h1);
            listaHenkiloTiedot.Add(h2);

            dgvHenkilot.DataSource = null;
            dgvHenkilot.DataSource = listaHenkiloTiedot;

            SerializeJSON(listaHenkiloTiedot);
        }

        private void LblVuoro_Click(object sender, EventArgs e)
        {

        }
    }
}

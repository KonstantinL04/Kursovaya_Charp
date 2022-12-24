using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kursovaya.Particle;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                Speed = 25,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем систему

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // рендерим систему
            }

            picDisplay.Invalidate();
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.Speed= tbSpeed.Value;
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading= tbSpreading.Value;
        }

        private void tbParticlesCount_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbParticlesCount.Value;
        }

        private void tbParticleLife_Scroll(object sender, EventArgs e)
        {
            emitter.Life = tbParticleLife.Value;
        }
    }
}

﻿using System.Drawing;
namespace Kursovaya
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public abstract void ImpactParticle(Particle particle);
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
}

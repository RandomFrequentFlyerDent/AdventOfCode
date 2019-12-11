using SantaShip;
using System;

namespace AnswerApp
{
    public class SantaShip
    {
        public GravityAssistProgram GravityAssist { get; private set; }

        public SantaShip()
        {
            GravityAssist = new GravityAssistProgram();
        }
    }
}

using System;
namespace wizard
{
    public class Spider : Enemy
    {
        public Spider (string n) : base(n)
        {
            dexterity = 15;
            intelligence = 7;
        }
    }
}
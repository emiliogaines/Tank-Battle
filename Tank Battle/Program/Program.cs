using System;
using Tank_Battle.UI;
using Tank_Battle.Object;

namespace Tank_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver AllyDriver = new Driver("Mio");
            Driver EnemyDriver = new Driver("Klaus");

            Tank AllyTank = new Tank();
            Tank EnemyTank = new Tank();

            AllyTank.EnterTank(AllyDriver);
            EnemyTank.EnterTank(EnemyDriver);

            Render.Initialize();
            Render.DrawBorder("TANK BATTLE", AllyTank.driver.name + " VS " + EnemyTank.driver.name);

            Render.DrawTank(TankFacingDirection.EAST, AllyTank);
            Render.DrawTank(TankFacingDirection.WEST, EnemyTank);
            Option[] Options = new Option[]
            {
                new Option("Attack"),
                new Option("Save checkpoint"),
                new Option("Restore checkpoint")
            };
            Render.DrawOptions(Options, TankChoice);
            Console.ReadKey();
        }

        static void TankChoice(int choice)
        {

        }

    }
}

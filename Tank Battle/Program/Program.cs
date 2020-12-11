using System;
using Tank_Battle.UI;
using Tank_Battle.Object;
using System.Collections.Generic;
using System.Linq;

namespace Tank_Battle
{
    class Program
    {
        static Checkpoint Checkpoint;
        static Tank AllyTank, EnemyTank;
        static void Main(string[] args)
        {
            //Init checkpoint
            Checkpoint = new Checkpoint();
            //Init drivers
            Driver AllyDriver = new Driver("Mio");
            Driver EnemyDriver = new Driver("Klaus");

            //Init tanks
            AllyTank = new Tank();
            EnemyTank = new Tank();
            EnemyTank.BaseFirepower = 3;

            //Enter tanks
            AllyTank.EnterTank(AllyDriver);
            EnemyTank.EnterTank(EnemyDriver);

            //Init our renderer
            Render.Initialize();

            //Draw our border and title
            Render.DrawBorder("TANK BATTLE");

            //Draw our tanks
            Render.RenderTanks(AllyTank, EnemyTank);

            //Create and display options that the user can click on
            Option[] Options = new Option[]
            {
                new Option("Attack"),
                new Option("Save Checkpoint"),
                new Option("Restore Checkpoint")
            };

            Render.DisplayMessage(AllyTank.Driver.Name + " VS " + EnemyTank.Driver.Name);

            while (EnemyTank.Health > 0 && AllyTank.Health > 0)
            {
                //Draw our tanks
                Render.RenderTanks(AllyTank, EnemyTank);

                //Wait for user to select an option
                Render.DrawOptions(Options, TankChoice);

            }

            Render.Reset();
            Render.DrawBorder("GAME OVER");
            Render.RenderTanks(AllyTank, EnemyTank);

            if (AllyTank.Health > 0)
            {
                Render.DisplayMessage("YOU WON!", true);
            }
            else
            {
                Render.DisplayMessage(EnemyTank.Driver.Name + " WON!", true);
            }

            while (true) { Console.ReadKey(); }
        }

        static void TankChoice(int choice)
        {
            Render.Reset();
            Render.DrawBorder("TANK BATTLE");
            switch (choice)
            {
                case 0: // Attack
                    //Ally fire at enemy
                    int DamageDone = AllyTank.ShootAt(EnemyTank);
                    Render.RenderTanks(AllyTank, EnemyTank);
                    Render.DisplayMessage("You dealt " + DamageDone + " damage!");

                    if(EnemyTank.Health == 0) break;

                    //Enemy fires back
                    int DamageTaken = EnemyTank.ShootAt(AllyTank);
                    Render.RenderTanks(AllyTank, EnemyTank);
                    Render.DisplayMessage("You took " + DamageTaken + " damage!");
                    break;
                case 1: // Save checkpoint
                    Checkpoint.SaveCheckpoint(AllyTank);
                    Render.RenderTanks(AllyTank, EnemyTank);
                    Render.DisplayMessage("Saving ...");
                    break;
                case 2: // Restore checkpoint
                    var ResultBoolean = Checkpoint.RestoreCheckpoint(AllyTank);
                    Render.RenderTanks(AllyTank, EnemyTank);
                    if (ResultBoolean)
                    {
                        Render.DisplayMessage("Restoring ...");
                    }
                    else
                    {
                        Render.DisplayMessage("NO CHECKPOINT FOUND!");
                    }
                    break;
            }
        }
    }
}

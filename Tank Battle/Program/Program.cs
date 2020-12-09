using System;
using Tank_Battle.UI;
using Tank_Battle.Object;
using System.Collections.Generic;
using System.Linq;

namespace Tank_Battle
{
    class Program
    {
        static TankMemory TankMemory;
        static Tank AllyTank, EnemyTank;
        static void Main(string[] args)
        {
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
            Render.DrawTank(TankFacingDirection.EAST, AllyTank);
            Render.DrawTank(TankFacingDirection.WEST, EnemyTank);

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
                Render.DrawTank(TankFacingDirection.EAST, AllyTank);
                Render.DrawTank(TankFacingDirection.WEST, EnemyTank);

                //Wait for user to select an option
                Render.DrawOptions(Options, TankChoice);

            }

            Render.Reset();
            Render.DrawBorder("GAME OVER");
            Render.DrawTank(TankFacingDirection.EAST, AllyTank);
            Render.DrawTank(TankFacingDirection.WEST, EnemyTank);

            if (AllyTank.Health > 0)
            {
                Render.DisplayMessage("YOU WON!", true);
            }
            else
            {
                Render.DisplayMessage(EnemyTank.Driver.Name + " WON!");
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
                    RenderTanks();
                    Render.DisplayMessage("You dealt " + DamageDone + " damage!");

                    if(EnemyTank.Health == 0) break;

                    //Enemy fires back
                    int DamageTaken = EnemyTank.ShootAt(AllyTank);
                    RenderTanks();
                    Render.DisplayMessage("You took " + DamageTaken + " damage!");
                    break;
                case 1: // Save checkpoint
                    SaveCheckpoint(AllyTank);
                    break;
                case 2: // Restore checkpoint
                    RestoreCheckpoint(AllyTank);
                    break;
            }
        }

        static void RenderTanks()
        {
            Render.DrawTank(TankFacingDirection.EAST, AllyTank);
            Render.DrawTank(TankFacingDirection.WEST, EnemyTank);
        }

        static void SaveCheckpoint(Tank tank)
        {
            if(TankMemory == null)
            {
                TankMemory = new TankMemory();
            }

            TankMemory.Memento = tank.CaptureMemento();
            RenderTanks();
            Render.DisplayMessage("Saving ...");
        }

        static void RestoreCheckpoint(Tank Tank)
        {
            if(TankMemory != null)
            {
                Tank.RestoreMemento(TankMemory.Memento);
                RenderTanks();
                Render.DisplayMessage("Restoring ...");
            }
            else
            {
                RenderTanks();
                Render.DisplayMessage("NO CHECKPOINT FOUND!");
            }
            
        }

    }
}

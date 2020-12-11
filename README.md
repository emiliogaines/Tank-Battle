# Tank-Battle
Du kontrollerar en pansarvagn som har möjligheten att spara checkpoints och återställa de med hjälp utav **Memento Pattern**.
Det är din fördel när du möter din motståndare, var smart!

## Memento Pattern
Koden nyttjar Memento Pattern likt följande utdrag ur *Checkpoint.cs* för att spara:
```
public void SaveCheckpoint(Tank tank)
{
  if (TankMemory == null)
  {
    TankMemory = new TankMemory();
  }

  TankMemory.Memento = tank.CaptureMemento();
}
```
och återställa:
```
public bool RestoreCheckpoint(Tank Tank)
{
  if (TankMemory != null)
  {
    Tank.RestoreMemento(TankMemory.Memento);
  }
  return (TankMemory != null);
}
```

## Observable Pattern
Koden nyttjar även **Observable Pattern** som används för att rendera ut pansarvagnarna på skärmen när de tar skada eller dylikt.
Exempel på detta är följande utdrag ur *Program.cs*, kika på klasserna under mappen *Observable* för att få full kontext.
```
//Creates main observable
var TankObservable = new Observable<Tank>();

//Creates observer for each tank
var AllyTankObserver = new TankObserver();
var EnemyTankObserver = new TankObserver();

//Register Tanks to re-draw themselves when they are updated, eg. taking damage
TankObservable.Register(AllyTankObserver);
TankObservable.Register(EnemyTankObserver);
```

public delegate void Action<in T>(T obj);
public delegate void ActionBulletsTypeChanged<in T>(T obj, int currentCount, int clipSize, int countInInventory);
public delegate void Action();
public delegate void ActionWeapon<in T>(T obj, int damage);
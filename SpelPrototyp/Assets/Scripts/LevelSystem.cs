public class LevelSystem
{
    private int level;
    private int currExp;
    private int reqExp;

    public LevelSystem()
    {
        level = 0;
        currExp = 0;
        reqExp = 100;
    }

    public void GainExp(int amount)
    {
        currExp += amount;
        if(currExp >= reqExp)
        {
            level++;
            currExp -= reqExp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SkillData
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int MpCost { get; private set; }

    public SkillData(int id, string name, int damage, int mpCost)
    {
        Id = id;
        Name = name;
        Damage = damage;
        MpCost = mpCost;
    }
}

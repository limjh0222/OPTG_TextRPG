using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

public class SkillManager
{
    private static SkillManager instance = null;
    public static SkillManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkillManager();
            }
            return instance;
        }
    }

    private Dictionary<int, Dictionary<int, Skill>> jobSkills;

    private SkillManager()
    {
        jobSkills = new Dictionary<int, Dictionary<int, Skill>>();

        // 전사 스킬
        Dictionary<int, Skill> warriorSkills = new Dictionary<int, Skill>
        {
            { 1, new Skill(1, "강력한 일격", 40, 30) },
            { 2, new Skill(2, "방패 강타", 30, 20) }
        };
        jobSkills.Add(1, warriorSkills);

        // 마법사 스킬
        Dictionary<int, Skill> mageSkills = new Dictionary<int, Skill>
        {
            { 2, new Skill(2, "화염 폭발", 40, 30) },
            { 3, new Skill(3, "얼음 창", 30, 25) }
        };
        jobSkills.Add(2, mageSkills);

        // 도적 스킬
        Dictionary<int, Skill> rogueSkills = new Dictionary<int, Skill>
        {
            { 3, new Skill(3, "연속 베기", 20, 20) },
            { 4, new Skill(4, "기습 공격", 40, 30) }
        };
        jobSkills.Add(3, rogueSkills);

        // 궁수 스킬
        Dictionary<int, Skill> archerSkills = new Dictionary<int, Skill>
        {
            { 4, new Skill(4, "정확한 사격", 30, 20) },
            { 1, new Skill(1, "강력한 일격", 15, 10) }
        };
        jobSkills.Add(4, archerSkills);
    }

    public Dictionary<int, Skill> GetSkillsForJob(int jobId)
    {
        if (jobSkills.ContainsKey(jobId))
        {
            return jobSkills[jobId];
        }
        else
        {
            return new Dictionary<int, Skill>();
        }
    }
}


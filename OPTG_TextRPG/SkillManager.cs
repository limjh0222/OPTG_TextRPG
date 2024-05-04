using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using OPTG_TextRPG;
using System.Xml.Linq;

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

    private Dictionary<int, Dictionary<int, SkillData>> jobSkills;

    private SkillManager()
    {
        jobSkills = new Dictionary<int, Dictionary<int, SkillData>>();

        // 전사 스킬
        Dictionary<int, SkillData> warriorSkills = new Dictionary<int, SkillData>
        {
            { 1, new SkillData(1, "강력한 일격", 40, 30) },
            { 2, new SkillData(2, "방패 강타", 30, 20) }
        };
        jobSkills.Add(1, warriorSkills);

        // 마법사 스킬
        Dictionary<int, SkillData> mageSkills = new Dictionary<int, SkillData>
        {
            { 2, new SkillData(2, "화염 폭발", 40, 30) },
            { 3, new SkillData(3, "얼음 창", 30, 25) }
        };
        jobSkills.Add(2, mageSkills);

        // 도적 스킬
        Dictionary<int, SkillData> rogueSkills = new Dictionary<int, SkillData>
        {
            { 3, new SkillData(3, "연속 베기", 20, 20) },
            { 4, new SkillData(4, "기습 공격", 40, 30) }
        };
        jobSkills.Add(3, rogueSkills);

        // 궁수 스킬
        Dictionary<int, SkillData> archerSkills = new Dictionary<int, SkillData>
        {
            { 4, new SkillData(4, "정확한 사격", 30, 20) },
            { 1, new SkillData(1, "강력한 일격", 15, 10) }
        };
        jobSkills.Add(4, archerSkills);

        Dictionary<int, SkillData> GMSkills = new Dictionary<int, SkillData>
        {
            { 1, new SkillData(1, "유니티망겜", 999, 1) },
            { 2, new SkillData(2, "망할 C#", 999, 1) }
        };
        jobSkills.Add(5, GMSkills);
    }

    public Dictionary<int, SkillData> GetSkillsForJob(int jobId)
    {
        if (jobSkills.ContainsKey(jobId))
        {
            return jobSkills[jobId];
        }
        else
        {
            return new Dictionary<int, SkillData>();
        }
    }

    public void SkillAttack(PlayerData player, MonsterData monster, int skillId)
    {
        if (int.TryParse(player.Job, out int jobId))
        {
            if (jobSkills.ContainsKey(jobId))
            {
                var skills = jobSkills[jobId];
                if (skills.ContainsKey(skillId))
                {
                    SkillData skill = skills[skillId];
                    if (player.Mp >= skill.MpCost)
                    {
                        Console.WriteLine($"{player.Name}이(가) {monster.Name}을(를) {skill.Name}으로 공격합니다!");
                        //BattleManager(skill.Damage);
                        player.Mp -= skill.MpCost;
                    }
                    else
                    {
                        Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다!");
                    }
                }
                else
                {
                    Console.WriteLine("해당 스킬이 존재하지 않습니다!");
                }
            }
            else
            {
                Console.WriteLine("해당 직업의 스킬이 존재하지 않습니다!");
            }
        }
        else
        {
            Console.WriteLine("직업을 숫자로 변환할 수 없습니다!");
        }
    }
}



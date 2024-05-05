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
            { 1, new SkillData(1, "파이어 볼트   ", 25, 5) },
            { 2, new SkillData(2, "아이스 애로우 ", 27, 10) },
            { 3, new SkillData(2, "윈드커터      ", 30, 13) },
            { 4, new SkillData(2, "스톤엣지      ", 34, 16) },
            { 5, new SkillData(2, "그래비티      ", 36, 24) },
            { 6, new SkillData(2, "인페르노      ", 42, 26) },
            { 7, new SkillData(2, "프로즌 오브   ", 45, 31) },
            { 8, new SkillData(2, "블리자드      ", 52, 35) },
            { 9, new SkillData(2, "익스플로전    ", 80, 50) }
        };
        jobSkills.Add(2, mageSkills);

        // 도적 스킬
        Dictionary<int, SkillData> rogueSkills = new Dictionary<int, SkillData>
        {
            { 1, new SkillData(1, "연속 베기", 35, 20) },
            { 2, new SkillData(2, "기습 공격", 55, 27) },
            { 3, new SkillData(2, "그림자 베기", 62, 36) },
            { 4, new SkillData(2, "급소 찌르기", 74, 55) }
        };
        jobSkills.Add(3, rogueSkills);

        // 궁수 스킬
        Dictionary<int, SkillData> archerSkills = new Dictionary<int, SkillData>
        {
            { 1, new SkillData(1, "재빠른 사격", 40, 25) },
            { 2, new SkillData(2, "강력한 일격", 50, 28) },
            { 3, new SkillData(2, "연속 사격", 60, 31) },
            { 4, new SkillData(2, "화살비", 70, 42) },
            { 5, new SkillData(2, "혼신의 일격", 80, 65) }
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
}


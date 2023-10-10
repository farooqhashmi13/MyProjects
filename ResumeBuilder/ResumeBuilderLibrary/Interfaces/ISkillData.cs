using ResumeBuilderLibrary.Models;

namespace ResumeBuilderLibrary.Interfaces
{
    public interface ISkillData
    {
        Task<int> Create(Skill skill);
        Task<int> CreateAll(List<Skill> skills);
        int Delete(Skill skill);
        Task<Skill> GetSkillId(int id);
        Task<List<Skill>> GetSkills();
        int Update(Skill skill);
    }
}
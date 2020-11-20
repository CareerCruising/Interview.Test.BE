using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;
using GraduationTracker.Infra.Data.Context;
using System;

namespace GraduationTracker.Infra.Data.Repository
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly StaticDataContext _ctx;

        public RequirementRepository(StaticDataContext ctx)
        {
            _ctx = ctx;
        }

        public Requirement[] GetRequirements()
        {
            return _ctx.Requirements;
        }

        public Requirement GetRequirement(int id)
        {
            return Array.Find(_ctx.Requirements, element => element.Id == id);
        }
    }
}

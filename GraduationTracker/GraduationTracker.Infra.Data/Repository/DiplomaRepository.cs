using GraduationTracker.Domain.Interfaces;
using GraduationTracker.Domain.Models;
using GraduationTracker.Infra.Data.Context;
using System;

namespace GraduationTracker.Infra.Data.Repository
{
    public class DiplomaRepository : IDiplomaRepository
    {
        private readonly StaticDataContext _ctx;

        public DiplomaRepository(StaticDataContext ctx)
        {
            _ctx = ctx;
        }

        public Diploma[] GetDiplomas()
        {
            return _ctx.Diplomas;
        }

        public Diploma GetDiploma(int id)
        {
            return Array.Find(_ctx.Diplomas, element => element.Id == id);
        }
    }
}
